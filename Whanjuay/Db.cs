using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic; // <--- เพิ่ม
using System.Text; // <--- เพิ่ม

namespace Whanjuay
{
    internal static class Db
    {
        private static string ConnStr =>
            ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

        private static MySqlConnection CreateConn() => new MySqlConnection(ConnStr);

        // --- [เพิ่มใหม่] ---
        // เมธอดสำหรับบันทึก Order ทั้งหมดลง Database
        public static string CreateOrder(string username, decimal totalAmount, List<CartItem> items)
        {
            using (var conn = CreateConn())
            {
                conn.Open();
                // ใช้ Transaction เพื่อความปลอดภัย (ถ้าล้มเหลวจะ Rollback ทั้งหมด)
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. สร้าง Order หลักก่อน (ยังไม่มี Order Code)
                        var cmdOrder = new MySqlCommand(
                            "INSERT INTO orders (username, total_amount, order_date, order_code) VALUES (@user, @total, NOW(), @code); SELECT LAST_INSERT_ID();",
                            conn, trans);
                        cmdOrder.Parameters.AddWithValue("@user", username);
                        cmdOrder.Parameters.AddWithValue("@total", totalAmount);
                        cmdOrder.Parameters.AddWithValue("@code", ""); // ใส่ค่าว่างไปก่อน

                        // ดึง ID ที่เพิ่งสร้าง (เช่น 123)
                        long newOrderId = Convert.ToInt64(cmdOrder.ExecuteScalar());

                        // 2. สร้าง Order Code (เช่น WJ000123)
                        string orderCode = "WJ" + newOrderId.ToString("D6"); // D6 = เติม 0 ให้ครบ 6 หลัก

                        // 3. อัปเดต Order Code กลับเข้าไป
                        var cmdUpdateCode = new MySqlCommand(
                            "UPDATE orders SET order_code = @code WHERE order_id = @id", conn, trans);
                        cmdUpdateCode.Parameters.AddWithValue("@code", orderCode);
                        cmdUpdateCode.Parameters.AddWithValue("@id", newOrderId);
                        cmdUpdateCode.ExecuteNonQuery();

                        // 4. วนลูปบันทึกรายการสินค้า (Order Items)
                        foreach (var item in items)
                        {
                            var cmdItem = new MySqlCommand(
                                "INSERT INTO order_items (order_id, display_name, quantity, price_per_item, sub_total, details) VALUES (@order_id, @name, @qty, @price, @subtotal, @details)",
                                conn, trans);

                            cmdItem.Parameters.AddWithValue("@order_id", newOrderId);
                            cmdItem.Parameters.AddWithValue("@name", item.DisplayName);
                            cmdItem.Parameters.AddWithValue("@qty", item.Quantity);
                            cmdItem.Parameters.AddWithValue("@price", item.TotalPrice); // ราคาต่อชิ้น (ที่รวม option แล้ว)
                            cmdItem.Parameters.AddWithValue("@subtotal", item.TotalPrice * item.Quantity);
                            cmdItem.Parameters.AddWithValue("@details", FormatItemDetails(item)); // <--- เมธอดช่วยจัดรูปแบบ

                            cmdItem.ExecuteNonQuery();
                        }

                        // 5. ถ้าทุกอย่างสำเร็จ
                        trans.Commit();
                        return orderCode; // คืนค่า WJ000123 กลับไป
                    }
                    catch (Exception)
                    {
                        trans.Rollback(); // ถ้ามีอะไรพลาด ให้ยกเลิกทั้งหมด
                        throw; // โยน Error กลับไปให้ PaymentForm
                    }
                }
            }
        }

        // --- [เพิ่มใหม่] ---
        // เมธอดช่วยจัดรูปแบบรายละเอียดสินค้า (เช่น ไส้เครป, ตัวเลือกเครื่องดื่ม)
        private static string FormatItemDetails(CartItem item)
        {
            var details = new StringBuilder();
            if (item.IsCustomCrepe && item.Ingredients != null)
            {
                foreach (var ing in item.Ingredients)
                {
                    details.Append($"• {ing.Name}");
                    if (ing.IsExtra)
                        details.Append($" (เพิ่มพิเศษ +{ing.ExtraPrice:N2})");
                    details.AppendLine();
                }
            }
            else if (item.Options != null)
            {
                foreach (var opt in item.Options)
                {
                    details.AppendLine($"• {opt}");
                }
            }
            return details.Length > 0 ? details.ToString() : null;
        }

        // --- [เพิ่มใหม่] ---
        // เมธอดสำหรับอัปเดต Path ของสลิป
        public static void UpdateOrderSlipPath(string orderCode, string slipPath)
        {
            using (var conn = CreateConn())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(
                    "UPDATE orders SET slip_path = @path WHERE order_code = @code", conn))
                {
                    cmd.Parameters.AddWithValue("@path", slipPath);
                    cmd.Parameters.AddWithValue("@code", orderCode);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // --- [เพิ่มใหม่] ---
        // ดึงข้อมูล Order หลัก (สำหรับใบเสร็จ)
        public static DataTable GetOrderDetails(string orderCode)
        {
            using (var conn = CreateConn())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(
                    "SELECT * FROM orders WHERE order_code = @code", conn))
                {
                    cmd.Parameters.AddWithValue("@code", orderCode);
                    using (var da = new MySqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // --- [เพิ่มใหม่] ---
        // ดึงข้อมูลรายการสินค้าใน Order (สำหรับใบเสร็จ)
        public static DataTable GetOrderItemsDetails(int orderId)
        {
            using (var conn = CreateConn())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(
                    "SELECT * FROM order_items WHERE order_id = @id ORDER BY order_item_id ASC", conn))
                {
                    cmd.Parameters.AddWithValue("@id", orderId);
                    using (var da = new MySqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // (GetCategories - โค้ดเดิม)
        public static DataTable GetCategories()
        {
            using (var conn = CreateConn())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(
                    "SELECT category_id, name FROM categories WHERE is_active = 1 ORDER BY name;", conn))
                using (var da = new MySqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // (GetCategoryIconPath - โค้ดเดิม)
        public static string GetCategoryIconPath(int categoryId)
        {
            using (var conn = CreateConn())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(
                    "SELECT cart_icon_path FROM categories WHERE category_id = @id;", conn))
                {
                    cmd.Parameters.AddWithValue("@id", categoryId);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return result.ToString();
                    }
                    return null;
                }
            }
        }


        // (GetIngredientCategories - โค้ดเดิม)
        public static DataTable GetIngredientCategories(int mainCategoryId)
        {
            using (var conn = CreateConn())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(
                    "SELECT ing_category_id, name FROM ingredient_categories WHERE category_id = @MainCatID ORDER BY sort_order, name;", conn))
                {
                    cmd.Parameters.AddWithValue("@MainCatID", mainCategoryId);
                    using (var da = new MySqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // (GetProductsForListWithStock - โค้ดเดิม)
        public static DataTable GetProductsForListWithStock()
        {
            using (var conn = CreateConn())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(@"
SELECT p.product_id, p.name, p.price, p.status, p.image_path, p.is_hot_sale, p.stock_quantity,
       ic.name AS category_name
FROM products p
LEFT JOIN ingredient_categories ic ON p.ing_category_id = ic.ing_category_id
ORDER BY p.is_hot_sale DESC, p.created_at DESC, p.product_id DESC;", conn))
                using (var da = new MySqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // (GetProductById - โค้ดเดิม)
        public static DataTable GetProductById(int productId)
        {
            using (var conn = CreateConn())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(@"
SELECT p.product_id, p.name, p.price, p.status, p.image_path, p.stock_quantity, p.is_hot_sale,
       ic.ing_category_id,
       ic.category_id
FROM products p
LEFT JOIN ingredient_categories ic ON p.ing_category_id = ic.ing_category_id
WHERE p.product_id = @id;", conn))
                {
                    cmd.Parameters.AddWithValue("@id", productId);
                    using (var da = new MySqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // (InsertProduct - โค้ดเดิม)
        public static int InsertProduct(string name, int ingCategoryId, decimal price,
                                        string status, string imagePath,
                                        int stockQuantity)
        {
            using (var conn = CreateConn())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(@"
INSERT INTO products (name, ing_category_id, price, status, image_path, stock_quantity, is_hot_sale, created_at)
VALUES (@n, @c, @p, @s, @img, @stock, 0, NOW());
SELECT LAST_INSERT_ID();", conn))
                {
                    cmd.Parameters.AddWithValue("@n", name);
                    cmd.Parameters.AddWithValue("@c", ingCategoryId);
                    cmd.Parameters.AddWithValue("@p", price);
                    cmd.Parameters.AddWithValue("@s", status);
                    cmd.Parameters.AddWithValue("@img", (object)imagePath ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@stock", stockQuantity);

                    object scalar = cmd.ExecuteScalar();
                    return Convert.ToInt32(scalar);
                }
            }
        }

        // (UpdateProduct - โค้ดเดิม)
        public static void UpdateProduct(int productId, string name, int ingCategoryId, decimal price,
                                         string status, string imagePath,
                                         int stockQuantity)
        {
            using (var conn = CreateConn())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(@"
UPDATE products SET 
    name = @n, 
    ing_category_id = @c,
    price = @p, 
    status = @s, 
    image_path = @img, 
    stock_quantity = @stock
WHERE product_id = @id;", conn))
                {
                    cmd.Parameters.AddWithValue("@id", productId);
                    cmd.Parameters.AddWithValue("@n", name);
                    cmd.Parameters.AddWithValue("@c", ingCategoryId);
                    cmd.Parameters.AddWithValue("@p", price);
                    cmd.Parameters.AddWithValue("@s", status);
                    cmd.Parameters.AddWithValue("@img", (object)imagePath ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@stock", stockQuantity);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // (GetProductsByIngredientCategory - โค้ดเดิม)
        public static DataTable GetProductsByIngredientCategory(int ingCategoryId)
        {
            using (var conn = CreateConn())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(@"
SELECT product_id, name, price, image_path, stock_quantity 
FROM products 
WHERE ing_category_id = @IngCatID 
  AND stock_quantity > 0 
ORDER BY name;", conn))
                {
                    cmd.Parameters.AddWithValue("@IngCatID", ingCategoryId);
                    using (var da = new MySqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // (DeleteProduct - โค้ดเดิม)
        public static void DeleteProduct(int productId)
        {
            using (var conn = CreateConn())
            {
                conn.Open();
                using (var cmd = new MySqlCommand("DELETE FROM products WHERE product_id = @id;", conn))
                {
                    cmd.Parameters.AddWithValue("@id", productId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // (UpdateHotSaleStatus - โค้ดเดิม)
        public static void UpdateHotSaleStatus(int productId, bool isHotSale)
        {
            using (var conn = CreateConn())
            {
                conn.Open();
                using (var cmd = new MySqlCommand("UPDATE products SET is_hot_sale = @status WHERE product_id = @id;", conn))
                {
                    cmd.Parameters.AddWithValue("@status", isHotSale);
                    cmd.Parameters.AddWithValue("@id", productId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
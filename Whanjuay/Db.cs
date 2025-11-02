using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Whanjuay
{
    internal static class Db
    {
        private static string ConnStr =>
            ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

        private static MySqlConnection CreateConn() => new MySqlConnection(ConnStr);

        // =================================================================
        // [ปรับปรุงใหม่] เมธอดสำหรับหน้า Product (Pagination + Filter)
        // =================================================================

        public static int GetProductCount(int mainCategoryId, int subCategoryId, string searchQuery)
        {
            int count = 0;
            var whereClauses = new List<string>();

            string sqlQuery = @"
                SELECT COUNT(p.product_id) 
                FROM products p
                LEFT JOIN ingredient_categories ic ON p.ing_category_id = ic.ing_category_id
                LEFT JOIN categories c ON ic.category_id = c.category_id";

            using (var conn = CreateConn())
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    if (mainCategoryId > 0)
                    {
                        whereClauses.Add("c.category_id = @MainCategoryId");
                        cmd.Parameters.AddWithValue("@MainCategoryId", mainCategoryId);
                    }
                    if (subCategoryId > 0)
                    {
                        whereClauses.Add("p.ing_category_id = @SubCategoryId");
                        cmd.Parameters.AddWithValue("@SubCategoryId", subCategoryId);
                    }
                    if (!string.IsNullOrEmpty(searchQuery))
                    {
                        whereClauses.Add("p.name LIKE @SearchQuery");
                        cmd.Parameters.AddWithValue("@SearchQuery", $"%{searchQuery}%");
                    }

                    if (whereClauses.Count > 0)
                    {
                        sqlQuery += " WHERE " + string.Join(" AND ", whereClauses);
                    }

                    cmd.Connection = conn;
                    cmd.CommandText = sqlQuery;

                    try
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            count = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error GetProductCount: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return count;
        }

        // =================================================================
        // [แก้ไข] เอาระบบคำนวณ/เรียงลำดับ Hot Sale ออก
        // =================================================================
        public static DataTable GetProductsPaginated(int pageNumber, int pageSize, int mainCategoryId, int subCategoryId, string searchQuery)
        {
            var dt = new DataTable();
            var whereClauses = new List<string>();

            // [แก้ไข] กลับไปใช้ SQL แบบง่าย ไม่ต้อง Join หายอดขาย
            string sqlQuery = @"
                SELECT p.product_id, p.name, p.price, p.status, p.image_path, p.stock_quantity,
                       ic.name AS category_name
                FROM products p
                LEFT JOIN ingredient_categories ic ON p.ing_category_id = ic.ing_category_id
                LEFT JOIN categories c ON ic.category_id = c.category_id
            ";

            // [แก้ไข] เรียงตาม ID (ใหม่สุดไปเก่าสุด)
            string paginationSql = " ORDER BY p.product_id DESC LIMIT @PageSize OFFSET @Offset";

            using (var conn = CreateConn())
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    if (mainCategoryId > 0)
                    {
                        whereClauses.Add("c.category_id = @MainCategoryId");
                        cmd.Parameters.AddWithValue("@MainCategoryId", mainCategoryId);
                    }
                    if (subCategoryId > 0)
                    {
                        whereClauses.Add("p.ing_category_id = @SubCategoryId");
                        cmd.Parameters.AddWithValue("@SubCategoryId", subCategoryId);
                    }
                    if (!string.IsNullOrEmpty(searchQuery))
                    {
                        whereClauses.Add("p.name LIKE @SearchQuery");
                        cmd.Parameters.AddWithValue("@SearchQuery", $"%{searchQuery}%");
                    }

                    if (whereClauses.Count > 0)
                    {
                        sqlQuery += " WHERE " + string.Join(" AND ", whereClauses);
                    }

                    int offset = (pageNumber - 1) * pageSize;
                    cmd.Parameters.AddWithValue("@PageSize", pageSize);
                    cmd.Parameters.AddWithValue("@Offset", offset);

                    cmd.Connection = conn;
                    cmd.CommandText = sqlQuery + paginationSql;

                    try
                    {
                        using (var da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error GetProductsPaginated: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return dt;
        }

        public static DataTable GetMainCategoriesForFilter()
        {
            DataTable dt = null;
            try
            {
                using (var conn = CreateConn())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(
                        "SELECT category_id, name FROM categories WHERE is_active = 1 ORDER BY name;", conn))
                    using (var da = new MySqlDataAdapter(cmd))
                    {
                        dt = new DataTable();
                        da.Fill(dt);

                        DataRow dr = dt.NewRow();
                        dr["category_id"] = 0; // 0 = All
                        dr["name"] = "--- ทุกเมนูหลัก ---";
                        dt.Rows.InsertAt(dr, 0);

                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetMainCategoriesForFilter: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;
            }
        }

        public static DataTable GetSubCategoriesForFilter(int mainCategoryId)
        {
            DataTable dt = null;
            string sqlQuery = "SELECT ing_category_id, name FROM ingredient_categories";

            try
            {
                using (var conn = CreateConn())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand())
                    {
                        if (mainCategoryId > 0)
                        {
                            sqlQuery += " WHERE category_id = @MainCategoryId";
                            cmd.Parameters.AddWithValue("@MainCategoryId", mainCategoryId);
                        }
                        sqlQuery += " ORDER BY name;";
                        cmd.CommandText = sqlQuery;
                        cmd.Connection = conn;

                        using (var da = new MySqlDataAdapter(cmd))
                        {
                            dt = new DataTable();
                            da.Fill(dt);

                            DataRow dr = dt.NewRow();
                            dr["ing_category_id"] = 0; // 0 = All
                            dr["name"] = "--- ทุกหมวดหมู่ย่อย ---";
                            dt.Rows.InsertAt(dr, 0);

                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetSubCategoriesForFilter: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;
            }
        }


        // =================================================================
        // [โค้ดเดิมทั้งหมดของคุณ] (เมธอดสำหรับ Dashboard, Orders, Products ฯลฯ)
        // =================================================================

        public static DataTable GetDashboardData(string startDate, string endDate)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT 
                    SUM(total_amount) AS TotalSales, 
                    COUNT(order_id) AS TotalOrders 
                FROM orders 
                WHERE order_date >= @start_date AND order_date < @end_date_plus_one";
            try
            {
                using (var conn = CreateConn())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@start_date", DateTime.Parse(startDate).Date);
                        cmd.Parameters.AddWithValue("@end_date_plus_one", DateTime.Parse(endDate).Date.AddDays(1));
                        using (var da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard data: " + ex.Message);
            }
            return dt;
        }
        public static int GetLowStockCount(int lowStockThreshold = 5)
        {
            int count = 0;
            string query = "SELECT COUNT(product_id) FROM products WHERE stock_quantity <= @threshold";
            try
            {
                using (var conn = CreateConn())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@threshold", lowStockThreshold);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            count = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking low stock: " + ex.Message);
            }
            return count;
        }
        public static DataTable GetRecentOrders(int limit = 10)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT 
                    order_code AS 'รหัสออเดอร์', 
                    total_amount AS 'ยอดรวม', 
                    order_date AS 'วันที่สั่งซื้อ', 
                    slip_path AS 'สลิป' 
                FROM orders 
                ORDER BY order_date DESC 
                LIMIT @limit";
            try
            {
                using (var conn = CreateConn())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@limit", limit);
                        using (var da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading recent orders: " + ex.Message);
            }
            return dt;
        }
        public static DataTable GetTopSellingProducts(string startDate, string endDate, int limit = 5)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT 
                    oi.display_name AS 'ชื่อสินค้า',
                    SUM(oi.quantity) AS 'จำนวนที่ขายได้',
                    SUM(oi.sub_total) AS 'ยอดขายรวม'
                FROM order_items oi
                JOIN orders o ON oi.order_id = o.order_id
                WHERE o.order_date >= @start_date AND o.order_date < @end_date_plus_one
                GROUP BY oi.display_name
                ORDER BY SUM(oi.quantity) DESC
                LIMIT @limit";
            try
            {
                using (var conn = CreateConn())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@start_date", DateTime.Parse(startDate).Date);
                        cmd.Parameters.AddWithValue("@end_date_plus_one", DateTime.Parse(endDate).Date.AddDays(1));
                        cmd.Parameters.AddWithValue("@limit", limit);
                        using (var da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading top selling products: " + ex.Message);
            }
            return dt;
        }
        public static string CreateOrder(string username, decimal totalAmount, List<CartItem> items)
        {
            using (var conn = CreateConn())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        var cmdOrder = new MySqlCommand(
                            "INSERT INTO orders (username, total_amount, order_date, order_code) VALUES (@user, @total, NOW(), @code); SELECT LAST_INSERT_ID();",
                            conn, trans);
                        cmdOrder.Parameters.AddWithValue("@user", username);
                        cmdOrder.Parameters.AddWithValue("@total", totalAmount);
                        cmdOrder.Parameters.AddWithValue("@code", "");
                        long newOrderId = Convert.ToInt64(cmdOrder.ExecuteScalar());
                        string orderCode = "WJ" + newOrderId.ToString("D6");
                        var cmdUpdateCode = new MySqlCommand(
                            "UPDATE orders SET order_code = @code WHERE order_id = @id", conn, trans);
                        cmdUpdateCode.Parameters.AddWithValue("@code", orderCode);
                        cmdUpdateCode.Parameters.AddWithValue("@id", newOrderId);
                        cmdUpdateCode.ExecuteNonQuery();
                        foreach (var item in items)
                        {
                            var cmdItem = new MySqlCommand(
                                "INSERT INTO order_items (order_id, display_name, quantity, price_per_item, sub_total, details) VALUES (@order_id, @name, @qty, @price, @subtotal, @details)",
                                conn, trans);
                            cmdItem.Parameters.AddWithValue("@order_id", newOrderId);
                            cmdItem.Parameters.AddWithValue("@name", item.DisplayName);
                            cmdItem.Parameters.AddWithValue("@qty", item.Quantity);
                            cmdItem.Parameters.AddWithValue("@price", item.TotalPrice);
                            cmdItem.Parameters.AddWithValue("@subtotal", item.TotalPrice * item.Quantity);
                            cmdItem.Parameters.AddWithValue("@details", FormatItemDetails(item));
                            cmdItem.ExecuteNonQuery();
                        }
                        trans.Commit();
                        return orderCode;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("เกิดข้อผิดพลาดในการสร้าง Order: " + ex.Message);
                        throw;
                    }
                }
            }
        }
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
        public static void UpdateOrderSlipPath(string orderCode, string slipPath)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error updating slip path: " + ex.Message);
            }
        }
        public static void UpdateOrderReceiptPath(string orderCode, string receiptPath)
        {
            try
            {
                using (var conn = CreateConn())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(
                        "UPDATE orders SET receipt_pdf_path = @path WHERE order_code = @code", conn))
                    {
                        cmd.Parameters.AddWithValue("@path", receiptPath);
                        cmd.Parameters.AddWithValue("@code", orderCode);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating receipt path: " + ex.Message);
            }
        }
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
                    return (result != null && result != DBNull.Value) ? result.ToString() : null;
                }
            }
        }
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
        public static DataTable GetProductById(int productId)
        {
            using (var conn = CreateConn())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(@"
                    SELECT p.product_id, p.name, p.price, p.status, p.image_path, p.stock_quantity,
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
        public static int InsertProduct(string name, int ingCategoryId, decimal price,
                                        string status, string imagePath,
                                        int stockQuantity)
        {
            using (var conn = CreateConn())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(@"
                    INSERT INTO products (name, ing_category_id, price, status, image_path, stock_quantity, created_at)
                    VALUES (@n, @c, @p, @s, @img, @stock, NOW());
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

        // [ลบออก] เมธอด UpdateHotSaleStatus ถูกลบออก
    }
}
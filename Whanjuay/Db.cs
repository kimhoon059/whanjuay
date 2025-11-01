using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace Whanjuay
{
    internal static class Db
    {
        private static string ConnStr =>
            ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

        private static MySqlConnection CreateConn() => new MySqlConnection(ConnStr);

        // (GetCategories - โค้ดเดิมถูกต้อง)
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

        // [แก้] ดึงประเภทวัตถุดิบย่อย (เรียงตาม sort_order)
        public static DataTable GetIngredientCategories(int mainCategoryId)
        {
            using (var conn = CreateConn())
            {
                conn.Open();
                // [แก้] เพิ่ม ORDER BY sort_order
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

        // (GetProductsForListWithStock - โค้ดเดิมถูกต้อง)
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

        // (GetProductById - โค้ดเดิมถูกต้อง)
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

        // (InsertProduct - โค้ดเดิมถูกต้อง)
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

        // (UpdateProduct - โค้ดเดิมถูกต้อง)
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

        // (GetProductsByIngredientCategory - โค้ดเดิมถูกต้อง)
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
ORDER BY name;", conn)) // (เรียงตามชื่อวัตถุดิบในกลุ่ม)
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

        // (DeleteProduct - โค้ดเดิมถูกต้อง)
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

        // (UpdateHotSaleStatus - โค้ดเดิมถูกต้อง)
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
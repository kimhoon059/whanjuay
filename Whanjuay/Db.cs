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

        // ---------- Categories ----------
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

        // ---------- Products: list for grid ----------
        public static DataTable GetProductsForList()
        {
            using (var conn = CreateConn())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(@"
SELECT p.product_id,
       p.name,
       p.price,
       p.status,
       p.image_path,
       p.is_hot_sale,  
       c.name AS category_name
FROM products p
LEFT JOIN categories c ON c.category_id = p.category_id
ORDER BY p.is_hot_sale DESC, p.created_at DESC, p.product_id DESC;", conn))
                using (var da = new MySqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // ---------- Insert product -> return new ID ----------
        // FIX: เพิ่มพารามิเตอร์ stockQuantity เพื่อรับค่าจาก ProductAddView.cs
        public static int InsertProduct(string name, int categoryId, decimal price,
                                        string status, string description, string imagePath,
                                        int stockQuantity)
        {
            using (var conn = CreateConn())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(@"
INSERT INTO products (name, category_id, price, status, description, image_path, stock_quantity, is_hot_sale, created_at)
VALUES (@n, @c, @p, @s, @d, @img, @stock, 0, NOW());
SELECT LAST_INSERT_ID();", conn))
                {
                    cmd.Parameters.AddWithValue("@n", name);
                    cmd.Parameters.AddWithValue("@c", categoryId);
                    cmd.Parameters.AddWithValue("@p", price);
                    cmd.Parameters.AddWithValue("@s", status);
                    cmd.Parameters.AddWithValue("@d", (object)description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@img", (object)imagePath ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@stock", stockQuantity); // บันทึก Stock

                    object scalar = cmd.ExecuteScalar();
                    return Convert.ToInt32(scalar);
                }
            }
        }

        // ---------- (ทางเลือก) ลบสินค้า ----------
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

        // ---------- Update Hot Sale Status (จำเป็นสำหรับ ProductListView) ----------
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
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
        // คืน: product_id, name, price, status, image_path, category_name
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
       c.name AS category_name
FROM products p
LEFT JOIN categories c ON c.category_id = p.category_id
ORDER BY p.created_at DESC, p.product_id DESC;", conn))
                using (var da = new MySqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // ---------- Insert product -> return new ID ----------
        public static int InsertProduct(string name, int categoryId, decimal price,
                                        string status, string description, string imagePath)
        {
            using (var conn = CreateConn())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(@"
INSERT INTO products (name, category_id, price, status, description, image_path, created_at)
VALUES (@n, @c, @p, @s, @d, @img, NOW());
SELECT LAST_INSERT_ID();", conn))
                {
                    cmd.Parameters.AddWithValue("@n", name);
                    cmd.Parameters.AddWithValue("@c", categoryId);
                    cmd.Parameters.AddWithValue("@p", price);
                    cmd.Parameters.AddWithValue("@s", status);
                    cmd.Parameters.AddWithValue("@d", (object)description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@img", (object)imagePath ?? DBNull.Value);

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
    }
}
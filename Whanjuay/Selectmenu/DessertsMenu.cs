using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms; // <--- เพิ่ม Guna

namespace Whanjuay
{
    public partial class DessertsMenu : Form
    {
        // [อัปเดต] ID 1 คือ "ของหวาน" (จาก DB)
        private const int DESSERTS_CATEGORY_ID = 1;

        // [อัปเดต] เพิ่มตัวแปรเก็บ Icon Path
        private string _categoryIconPath;

        public DessertsMenu()
        {
            InitializeComponent();

            // [อัปเดต] ผูก Event กับปุ่ม
            this.Load += DessertsMenu_Load;
            this.btnBack.Click += btnBack_Click;
            this.btnCart.Click += btnCart_Click;
        }

        private void DessertsMenu_Load(object sender, EventArgs e)
        {
            // [อัปเดต] โหลด Icon Path ก่อน
            try
            {
                _categoryIconPath = Db.GetCategoryIconPath(DESSERTS_CATEGORY_ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถโหลด Icon Path: " + ex.Message);
                _categoryIconPath = null;
            }

            LoadDessertItems(); // [อัปเดต] เปลี่ยนชื่อเมธอด
        }

        // [อัปเดต] นี่คือ Logic ใหม่ทั้งหมดสำหรับหน้านี้
        private void LoadDessertItems()
        {
            try
            {
                // 1. ดึง "กลุ่มย่อย" ของของหวาน (เช่น เค้ก, ไอศกรีม)
                DataTable dtGroups = Db.GetIngredientCategories(DESSERTS_CATEGORY_ID);

                if (dtGroups == null || dtGroups.Rows.Count == 0)
                {
                    MessageBox.Show("ไม่พบกลุ่มของหวาน (กรุณาตั้งค่า 'ingredient_categories' สำหรับ 'ของหวาน')", "ข้อมูลไม่พร้อมใช้งาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 2. วน Loop แต่ละกลุ่ม
                foreach (DataRow groupRow in dtGroups.Rows)
                {
                    int ingCategoryId = Convert.ToInt32(groupRow["ing_category_id"]);
                    string groupName = groupRow["NAME"].ToString();

                    // (แสดงชื่อกลุ่ม เช่น "เค้ก")
                    Label lblGroup = new Label();
                    lblGroup.Text = groupName;
                    lblGroup.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
                    lblGroup.ForeColor = Color.SaddleBrown;
                    lblGroup.AutoSize = false;
                    lblGroup.Width = flowMainPanel.Width - 40;
                    lblGroup.Height = 40;
                    lblGroup.Margin = new Padding(10, 20, 10, 10);
                    flowMainPanel.Controls.Add(lblGroup);

                    // สร้าง Panel ย่อย
                    FlowLayoutPanel flowItems = new FlowLayoutPanel();
                    flowItems.Dock = DockStyle.None;
                    flowItems.AutoSize = true;
                    flowItems.MaximumSize = new Size(flowMainPanel.Width - 40, 0);
                    flowItems.FlowDirection = FlowDirection.LeftToRight;
                    flowItems.BackColor = Color.Transparent;
                    flowMainPanel.Controls.Add(flowItems);

                    // 3. ดึง "สินค้า" (Products) ที่อยู่ในกลุ่มย่อยนี้
                    DataTable dtProducts = Db.GetProductsByIngredientCategory(ingCategoryId);

                    if (dtProducts == null || dtProducts.Rows.Count == 0)
                    {
                        Label lblNoItems = new Label();
                        lblNoItems.Text = "(ยังไม่มีสินค้าในกลุ่มนี้)";
                        lblNoItems.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
                        lblNoItems.ForeColor = Color.Gray;
                        lblNoItems.AutoSize = true;
                        lblNoItems.Margin = new Padding(10, 0, 0, 10);
                        flowItems.Controls.Add(lblNoItems);
                        continue;
                    }

                    // 4. วน Loop สร้าง DessertItemControl (ตัวใหม่)
                    foreach (DataRow productRow in dtProducts.Rows)
                    {
                        DessertItemControl item = new DessertItemControl();
                        item.SetData(
                            Convert.ToInt32(productRow["product_id"]),
                            productRow["NAME"].ToString(),
                            Convert.ToDecimal(productRow["price"]),
                            productRow["image_path"].ToString(),
                            "ของหวาน" // CategoryName หลัก
                        );

                        // [สำคัญ] ส่ง Icon Path ของหมวดใหญ่ (ของหวาน) ไปให้ Control ลูก
                        item.CategoryIconPath = _categoryIconPath;

                        flowItems.Controls.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการโหลดเมนูของหวาน: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // (เราไม่จำเป็นต้อง Reset ค่าอะไร เพราะ Control ของหวานไม่มีตัวเลือก)
            mainpagewj mainForm = Application.OpenForms.OfType<mainpagewj>().FirstOrDefault();
            if (mainForm != null)
            {
                mainForm.Show();
            }
            this.Hide();
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            // (เราไม่จำเป็นต้อง Reset ค่าอะไร)
            mainpagewj mainForm = Application.OpenForms.OfType<mainpagewj>().FirstOrDefault();
            mainForm?.btnCart_Click(sender, e);
            this.Hide();
        }
    }
}
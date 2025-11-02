using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Whanjuay
{
    public partial class DrinksMenu : Form
    {
        private const int DRINKS_CATEGORY_ID = 4;
        private string _categoryIconPath;

        public DrinksMenu()
        {
            InitializeComponent();
            this.Load += DrinksMenu_Load;
            this.btnBack.Click += btnBack_Click;
            this.btnCart.Click += btnCart_Click;
        }

        private void DrinksMenu_Load(object sender, EventArgs e)
        {
            // โหลด Icon Path ก่อน
            try
            {
                _categoryIconPath = Db.GetCategoryIconPath(DRINKS_CATEGORY_ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถโหลด Icon Path: " + ex.Message);
                _categoryIconPath = null;
            }

            LoadDrinkItems();
        }

        private void LoadDrinkItems()
        {
            try
            {
                DataTable dtGroups = Db.GetIngredientCategories(DRINKS_CATEGORY_ID);

                if (dtGroups == null || dtGroups.Rows.Count == 0)
                {
                    MessageBox.Show("ไม่พบกลุ่มเครื่องดื่ม (กรุณาตั้งค่า 'ingredient_categories' สำหรับ 'เครื่องดื่ม')", "ข้อมูลไม่พร้อมใช้งาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (DataRow groupRow in dtGroups.Rows)
                {
                    int ingCategoryId = Convert.ToInt32(groupRow["ing_category_id"]);
                    string groupName = groupRow["NAME"].ToString();

                    Label lblGroup = new Label();
                    lblGroup.Text = groupName;
                    lblGroup.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
                    lblGroup.ForeColor = Color.SaddleBrown;
                    lblGroup.AutoSize = false;
                    lblGroup.Width = flowMainPanel.Width - 40;
                    lblGroup.Height = 40;
                    lblGroup.Margin = new Padding(10, 20, 10, 10);
                    flowMainPanel.Controls.Add(lblGroup);

                    FlowLayoutPanel flowItems = new FlowLayoutPanel();
                    flowItems.Dock = DockStyle.None;
                    flowItems.AutoSize = true;
                    flowItems.MaximumSize = new Size(flowMainPanel.Width - 40, 0);
                    flowItems.FlowDirection = FlowDirection.LeftToRight;
                    flowItems.BackColor = Color.Transparent;
                    flowMainPanel.Controls.Add(flowItems);

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

                    foreach (DataRow productRow in dtProducts.Rows)
                    {
                        DrinkItemControl item = new DrinkItemControl();
                        item.SetData(
                            Convert.ToInt32(productRow["product_id"]),
                            productRow["NAME"].ToString(),
                            Convert.ToDecimal(productRow["price"]),
                            productRow["image_path"].ToString(),
                            "เครื่องดื่ม"
                        );

                        item.CategoryIconPath = _categoryIconPath;
                        flowItems.Controls.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการโหลดเมนูเครื่องดื่ม: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // [อัปเดต] สั่ง Reset ค่า Control ลูกทั้งหมดก่อนซ่อน
            ResetAllDrinkSelections();

            mainpagewj mainForm = Application.OpenForms.OfType<mainpagewj>().FirstOrDefault();
            if (mainForm != null)
            {
                mainForm.Show();
            }
            this.Hide();
        }

        // [เพิ่มใหม่] เมธอดสำหรับวน Loop สั่ง Reset Control ลูก
        private void ResetAllDrinkSelections()
        {
            // วน Loop ใน Panel หลัก
            foreach (Control control in flowMainPanel.Controls)
            {
                // หาทุก Panel ย่อย (ที่เก็บรายการเครื่องดื่ม)
                if (control is FlowLayoutPanel itemPanel)
                {
                    // วนหา Control เครื่องดื่มทั้งหมดใน Panel ย่อย
                    foreach (DrinkItemControl drinkControl in itemPanel.Controls.OfType<DrinkItemControl>())
                    {
                        // สั่ง Reset!
                        drinkControl.ResetSelections();
                    }
                }
            }
        }


        private void btnCart_Click(object sender, EventArgs e)
        {
            // [อัปเดต] สั่ง Reset ค่าก่อนไปหน้าตะกร้าด้วย
            ResetAllDrinkSelections();

            mainpagewj mainForm = Application.OpenForms.OfType<mainpagewj>().FirstOrDefault();
            mainForm?.btnCart_Click(sender, e);
            this.Hide();
        }
    }
}
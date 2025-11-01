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
    public partial class HotCrepeMenu : Form
    {
        private const int HOT_CREPE_CATEGORY_ID = 2;

        public HotCrepeMenu()
        {
            InitializeComponent();
        }

        private void HotCrepeMenu_Load(object sender, EventArgs e)
        {
            LoadIngredientGroups();
        }

        private void LoadIngredientGroups()
        {
            try
            {
                DataTable dtGroups = Db.GetIngredientCategories(HOT_CREPE_CATEGORY_ID);

                if (dtGroups == null || dtGroups.Rows.Count == 0)
                {
                    MessageBox.Show("ไม่พบกลุ่มวัตถุดิบสำหรับเครปร้อน (กรุณาตรวจสอบฐานข้อมูล ตาราง 'ingredient_categories')", "ข้อมูลไม่พร้อมใช้งาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        IngredientControl item = new IngredientControl();
                        item.SetData(
                            Convert.ToInt32(productRow["product_id"]),
                            productRow["NAME"].ToString(),
                            Convert.ToDecimal(productRow["price"]),
                            productRow["image_path"].ToString(),
                            groupName
                        );

                        flowItems.Controls.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการโหลดเมนู: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            mainpagewj mainForm = Application.OpenForms.OfType<mainpagewj>().FirstOrDefault();
            if (mainForm != null)
            {
                mainForm.Show();
            }
            this.Close();
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            CartPage cartForm = new CartPage();
            cartForm.Show();
            this.Hide();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            List<CartIngredient> selectedIngredients = new List<CartIngredient>();
            decimal totalPrice = 0;

            foreach (Control groupControl in flowMainPanel.Controls)
            {
                if (groupControl is FlowLayoutPanel itemPanel)
                {
                    foreach (IngredientControl ingredient in itemPanel.Controls.OfType<IngredientControl>())
                    {
                        if (ingredient.IsSelected)
                        {
                            CartIngredient ingredientItem = new CartIngredient
                            {
                                ProductId = ingredient.ProductId,
                                Name = ingredient.ItemName,
                                BasePrice = ingredient.BasePrice,
                                IsExtra = ingredient.IsExtra,
                                ExtraPrice = ingredient.IsExtra ? ingredient.ExtraPrice : 0
                            };

                            selectedIngredients.Add(ingredientItem);

                            totalPrice += ingredient.BasePrice;
                            if (ingredient.IsExtra)
                            {
                                totalPrice += ingredient.ExtraPrice;
                            }
                        }
                    }
                }
            }

            if (selectedIngredients.Count == 0)
            {
                MessageBox.Show("กรุณาเลือกวัตถุดิบอย่างน้อย 1 รายการ", "ยังไม่ได้เลือกสินค้า", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CartItem customCrepe = new CartItem
            {
                DisplayName = "เครปร้อน (สั่งทำ)",
                TotalPrice = totalPrice,
                Quantity = 1,
                IsCustomCrepe = true,
                CategoryName = "เครปร้อน",
                Ingredients = selectedIngredients
            };

            CartService.AddItem(customCrepe);

            MessageBox.Show($"เพิ่ม 'เครปร้อน (สั่งทำ)' ราคา {totalPrice:N2} บาท ลงในตะกร้าแล้ว!", "เพิ่มสินค้าสำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnBack_Click(sender, e);
        }
    }
}
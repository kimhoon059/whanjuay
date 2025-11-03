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
    public partial class ColdCrepeMenu : Form
    {
        // [แก้ไข] เปลี่ยน ID
        private const int COLD_CREPE_CATEGORY_ID = 3;
        // [เพิ่มใหม่] กำหนดราคาฐาน
        private const decimal BASE_CREPE_PRICE = 45m;
        private string _categoryIconPath;

        public ColdCrepeMenu()
        {
            InitializeComponent();
            this.Load += ColdCrepeMenu_Load;
            // Event อื่นๆ ผูกใน Designer แล้ว
        }

        private void ColdCrepeMenu_Load(object sender, EventArgs e)
        {
            // [เพิ่มใหม่] ตั้งค่าปุ่มยืนยัน
            chkConfirmCrepe.Text = $"ยืนยันเครปเย็น (ฐานราคา {BASE_CREPE_PRICE:N2} บาท)";
            chkConfirmCrepe.CheckedChanged += chkConfirmCrepe_CheckedChanged;

            // [เพิ่มใหม่] ตั้งค่าสถานะเริ่มต้น
            UpdateControlsState();

            // [แก้ไข] กลับไปใช้ Logic การโหลดแบบเดิม
            LoadIngredientGroups();

            try
            {
                // [แก้ไข] ID
                _categoryIconPath = Db.GetCategoryIconPath(COLD_CREPE_CATEGORY_ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถโหลด Icon Path: " + ex.Message);
                _categoryIconPath = null;
            }
        }

        // [เพิ่มใหม่] Event เมื่อติ๊กปุ่มยืนยัน
        private void chkConfirmCrepe_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControlsState();
        }

        // [เพิ่มใหม่] เมธอดควบคุมสถานะ
        private void UpdateControlsState()
        {
            bool isCrepeSelected = chkConfirmCrepe.Checked;
            flowMainPanel.Enabled = isCrepeSelected;
            if (!isCrepeSelected)
            {
                ResetAllSelections(false);
            }
        }

        // [แก้ไข] กลับมาใช้ LoadIngredientGroups (เหมือน DrinksMenu.cs)
        private void LoadIngredientGroups()
        {
            if (flowMainPanel == null) return;

            try
            {
                // [แก้ไข] ID
                DataTable dtGroups = Db.GetIngredientCategories(COLD_CREPE_CATEGORY_ID);

                if (dtGroups == null || dtGroups.Rows.Count == 0)
                {
                    MessageBox.Show("ไม่พบกลุ่มวัตถุดิบสำหรับเครปเย็น", "ข้อมูลไม่พร้อมใช้งาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        // [แก้ไข] ปรับปรุงการ Reset
        private void ResetAllSelections(bool resetBaseCrepe = true)
        {
            if (flowMainPanel == null) return;

            foreach (Control control in flowMainPanel.Controls)
            {
                if (control is FlowLayoutPanel itemPanel)
                {
                    foreach (IngredientControl ingredientControl in itemPanel.Controls.OfType<IngredientControl>())
                    {
                        ingredientControl.Reset();
                    }
                }
            }

            if (resetBaseCrepe)
            {
                chkConfirmCrepe.Checked = false;
            }

            if (resetBaseCrepe)
            {
                UpdateControlsState();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ResetAllSelections();
            mainpagewj mainForm = Application.OpenForms.OfType<mainpagewj>().FirstOrDefault();
            if (mainForm != null)
            {
                mainForm.Show();
            }
            this.Hide();
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            ResetAllSelections();
            mainpagewj mainForm = Application.OpenForms.OfType<mainpagewj>().FirstOrDefault();
            mainForm?.btnCart_Click(sender, e);
            this.Hide();
        }

        // [แก้ไข] Logic การเพิ่มลงตะกร้า (กลับไปใช้แบบ Scan ทั้งหมด + เพิ่มราคาฐาน)
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (flowMainPanel == null) return;

            // 1. ตรวจสอบ
            if (!chkConfirmCrepe.Checked)
            {
                MessageBox.Show("กรุณาติ๊ก \"ยืนยันเครปเย็น\" ก่อนครับ", "ยังไม่ได้เลือกเครป", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. [แก้ไข] เริ่มต้นราคาที่ 45 บาท
            List<CartIngredient> selectedIngredients = new List<CartIngredient>();
            decimal totalPrice = BASE_CREPE_PRICE;

            // 3. [เพิ่มใหม่] เพิ่ม "เครปฐาน"
            selectedIngredients.Add(new CartIngredient
            {
                ProductId = -2, // ID พิเศษสำหรับเครปฐานเย็น
                Name = $"เครปเย็น (ฐาน)",
                BasePrice = BASE_CREPE_PRICE,
                IsExtra = false,
                ExtraPrice = 0
            });

            // 4. [แก้ไข] กลับไปใช้ Loop แบบเดิม
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

                            // 5. [แก้ไข] คำนวณราคา
                            totalPrice += ingredient.BasePrice;
                            if (ingredient.IsExtra)
                            {
                                totalPrice += ingredient.ExtraPrice;
                            }
                        }
                    }
                }
            }

            // 6. [แก้ไข] ตรวจสอบ
            if (selectedIngredients.Count <= 1)
            {
                MessageBox.Show("กรุณาเลือกวัตถุดิบอย่างน้อย 1 รายการ", "ยังไม่ได้เลือกสินค้า", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 7. สร้าง CartItem [แก้ไข] CategoryName, DisplayName
            CartItem customCrepe = new CartItem
            {
                DisplayName = "เครปเย็น (สั่งทำ)",
                TotalPrice = totalPrice,
                Quantity = 1,
                IsCustomCrepe = true,
                CategoryName = "เครปเย็น",
                Ingredients = selectedIngredients,
                IconPath = _categoryIconPath,
                ProductImagePath = null
            };

            CartService.AddItem(customCrepe);

            // 8. (เหมือนเดิม) แจ้งเตือน, Reset, เปิดปุ่ม
            btnAddToCart.Enabled = false;
            MessageBox.Show($"เพิ่ม 'เครปเย็น (สั่งทำ)' ราคา {totalPrice:N2} บาท ลงในตะกร้าแล้ว!", "เพิ่มสินค้าสำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ResetAllSelections();

            btnAddToCart.Enabled = true;
        }
    }
}
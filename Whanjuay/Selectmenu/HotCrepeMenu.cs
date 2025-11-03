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
        // [เพิ่มใหม่] กำหนดราคาฐาน
        private const decimal BASE_CREPE_PRICE = 45m;
        private string _categoryIconPath;

        public HotCrepeMenu()
        {
            InitializeComponent();
            // [แก้ไข] ย้ายการผูก Event มาที่นี่
            this.Load += HotCrepeMenu_Load;
            // Event ของปุ่ม Back, Cart, AddToCart ถูกผูกใน Designer แล้ว
        }

        private void HotCrepeMenu_Load(object sender, EventArgs e)
        {
            // [เพิ่มใหม่] ตั้งค่าปุ่มยืนยัน
            chkConfirmCrepe.Text = $"ยืนยันเครปร้อน (ราคา {BASE_CREPE_PRICE:N2} บาท)";
            chkConfirmCrepe.CheckedChanged += chkConfirmCrepe_CheckedChanged;

            // [เพิ่มใหม่] ตั้งค่าสถานะเริ่มต้น (ปิดการใช้งานวัตถุดิบ)
            UpdateControlsState();

            // [แก้ไข] กลับไปใช้ Logic การโหลดแบบเดิม
            LoadIngredientGroups();

            try
            {
                _categoryIconPath = Db.GetCategoryIconPath(HOT_CREPE_CATEGORY_ID);
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
            flowMainPanel.Enabled = isCrepeSelected; // นี่คือ Logic หลัก

            if (!isCrepeSelected)
            {
                // ถ้าผู้ใช้ยกเลิกการเลือกเครป ให้ล้างวัตถุดิบที่เลือกไว้ทั้งหมด
                ResetAllSelections(false); // ส่ง false คือ ไม่ต้องติ๊ก chkConfirmCrepe ออก (เพราะมันเป็นตัวต้นเหตุ)
            }
        }

        // [แก้ไข] กลับมาใช้ LoadIngredientGroups (เหมือน DrinksMenu.cs)
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

        // [แก้ไข] ปรับปรุงการ Reset
        private void ResetAllSelections(bool resetBaseCrepe = true)
        {
            foreach (Control control in flowMainPanel.Controls)
            {
                if (control is FlowLayoutPanel itemPanel)
                {
                    foreach (IngredientControl ingredientControl in itemPanel.Controls.OfType<IngredientControl>())
                    {
                        ingredientControl.Reset(); // สั่งให้ Control ลูก ล้างค่าตัวเอง
                    }
                }
            }

            if (resetBaseCrepe)
            {
                chkConfirmCrepe.Checked = false;
            }

            // [แก้ไข] ไม่ต้องเลื่อน Scroll กลับ เพราะเราไม่ได้เปลี่ยนหน้า
            // flowMainPanel.AutoScrollPosition = new Point(0, 0);

            // [เพิ่มใหม่] อัปเดตสถานะ (ถ้า chkConfirmCrepe ถูกสั่งให้ติ๊กออก)
            if (resetBaseCrepe)
            {
                UpdateControlsState();
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            ResetAllSelections(); // ล้างค่าทั้งหมด
            mainpagewj mainForm = Application.OpenForms.OfType<mainpagewj>().FirstOrDefault();
            if (mainForm != null)
            {
                mainForm.Show();
            }
            this.Hide();
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            ResetAllSelections(); // ล้างค่าทั้งหมด
            mainpagewj mainForm = Application.OpenForms.OfType<mainpagewj>().FirstOrDefault();
            mainForm?.btnCart_Click(sender, e);
            this.Hide();
        }

        // [แก้ไข] Logic การเพิ่มลงตะกร้า (กลับไปใช้แบบ Scan ทั้งหมด + เพิ่มราคาฐาน)
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            // 1. ตรวจสอบว่าเลือกเครปฐานหรือยัง
            if (!chkConfirmCrepe.Checked)
            {
                MessageBox.Show("กรุณาติ๊ก \"ยืนยันเครปร้อน\" ก่อนครับ", "ยังไม่ได้เลือกเครป", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. [แก้ไข] เริ่มต้นราคาที่ 45 บาท
            List<CartIngredient> selectedIngredients = new List<CartIngredient>();
            decimal totalPrice = BASE_CREPE_PRICE;

            // 3. [เพิ่มใหม่] เพิ่ม "เครปฐาน" เป็นรายการแรก
            selectedIngredients.Add(new CartIngredient
            {
                ProductId = -1, // ID พิเศษสำหรับเครปฐาน
                Name = $"เครปร้อน (ฐาน)",
                BasePrice = BASE_CREPE_PRICE,
                IsExtra = false,
                ExtraPrice = 0
            });

            // 4. [แก้ไข] กลับไปใช้ Loop แบบเดิมเพื่อ Scan หาวัตถุดิบ
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

                            // 5. [แก้ไข] คำนวณราคา (บวกเพิ่มจากราคาฐาน)
                            totalPrice += ingredient.BasePrice;
                            if (ingredient.IsExtra)
                            {
                                totalPrice += ingredient.ExtraPrice;
                            }
                        }
                    }
                }
            }

            // 6. [แก้ไข] ตรวจสอบว่าเลือกอย่างน้อย 1 อย่าง (นอกจากเครปฐาน)
            if (selectedIngredients.Count <= 1)
            {
                MessageBox.Show("กรุณาเลือกวัตถุดิบอย่างน้อย 1 รายการ", "ยังไม่ได้เลือกสินค้า", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 7. สร้าง CartItem
            CartItem customCrepe = new CartItem
            {
                DisplayName = "เครปร้อน (สั่งทำ)", // CartService จะเติม #1, #2... ให้เอง
                TotalPrice = totalPrice,
                Quantity = 1,
                IsCustomCrepe = true,
                CategoryName = "เครปร้อน",
                Ingredients = selectedIngredients,
                IconPath = _categoryIconPath,
                ProductImagePath = null
            };

            CartService.AddItem(customCrepe);

            // 8. (เหมือนเดิม) แจ้งเตือน, Reset, เปิดปุ่ม
            btnAddToCart.Enabled = false;
            MessageBox.Show($"เพิ่ม 'เครปร้อน (สั่งทำ)' ราคา {totalPrice:N2} บาท ลงในตะกร้าแล้ว!", "เพิ่มสินค้าสำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ResetAllSelections(); // ล้างค่า

            btnAddToCart.Enabled = true;
        }

        private void chkConfirmCrepe_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}
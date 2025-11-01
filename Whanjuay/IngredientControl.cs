using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Whanjuay
{
    public partial class IngredientControl : UserControl
    {
        public int ProductId { get; private set; }
        public string ItemName { get; private set; }
        public decimal BasePrice { get; private set; }
        public decimal ExtraPrice { get; private set; }
        public string GroupName { get; private set; }

        public bool IsSelected => chkSelect.Checked;
        public bool IsExtra => chkExtra.Checked;

        public IngredientControl()
        {
            InitializeComponent();
        }

        public void SetData(int productId, string name, decimal price, string imagePath, string groupName)
        {
            this.ProductId = productId;
            this.ItemName = name;
            this.BasePrice = price;
            this.GroupName = groupName;

            chkSelect.Text = name;
            lblPrice.Text = $"(+{price:N2} บาท)"; // [แก้]

            if (groupName.Contains("แป้ง"))
            {
                this.ExtraPrice = 10;
            }
            else if (groupName.Contains("ไส้") || groupName.Contains("ซอส") || groupName.Contains("ไอศกรีม"))
            {
                this.ExtraPrice = 5;
            }
            else
            {
                this.ExtraPrice = 0;
            }
            chkExtra.Text = $"เพิ่มพิเศษ (+{this.ExtraPrice:N2} บาท)"; // [แก้]

            LoadImage(imagePath);
        }

        private void LoadImage(string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePath.Replace('/', Path.DirectorySeparatorChar));
                if (File.Exists(fullPath))
                {
                    try
                    {
                        using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                        {
                            pbImage.Image = Image.FromStream(stream);
                        }
                    }
                    catch { pbImage.Image = null; }
                }
            }
        }

        private void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelect.Checked)
            {
                if (this.ExtraPrice > 0)
                {
                    chkExtra.Visible = true;
                }
            }
            else
            {
                chkExtra.Visible = false;
                chkExtra.Checked = false;
            }
        }
    }
}
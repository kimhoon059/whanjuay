using System.Collections.Generic;
using System.Linq;

namespace Whanjuay
{
    public class CartIngredient
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public decimal ExtraPrice { get; set; }
        public bool IsExtra { get; set; }
    }

    public class CartItem
    {
        public int ItemId { get; set; }
        public string DisplayName { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public bool IsCustomCrepe { get; set; }
        public string CategoryName { get; set; }
        public string IconPath { get; set; }
        public string ProductImagePath { get; set; }
        public List<string> Options { get; set; }
        public List<CartIngredient> Ingredients { get; set; }
    }

    public static class CartService
    {
        private static List<CartItem> _items = new List<CartItem>();
        private static int _nextItemId = 1;

        // [เพิ่มใหม่] เพิ่มตัวนับสำหรับเครปแต่ละชนิด
        private static int _hotCrepeCounter = 1;
        private static int _coldCrepeCounter = 1;


        // [อัปเดต] แก้ไขเมธอดนี้
        public static void AddItem(CartItem item)
        {
            item.ItemId = _nextItemId++;

            // [อัปเดต] Logic การเพิ่มหมายเลขต่อท้าย
            // เราจะเช็ค 'IsCustomCrepe' เพราะทั้งเครปร้อนและเย็นจะตั้งค่านี้เป็น true
            if (item.IsCustomCrepe)
            {
                if (item.CategoryName == "เครปร้อน")
                {
                    item.DisplayName += $" #{_hotCrepeCounter}"; // เช่น เครปร้อน (สั่งทำ) #1
                    _hotCrepeCounter++; // เพิ่มค่านับสำหรับชิ้นต่อไป
                }
                else if (item.CategoryName == "เครปเย็น")
                {
                    item.DisplayName += $" #{_coldCrepeCounter}"; // เช่น เครปเย็น (สั่งทำ) #1
                    _coldCrepeCounter++; // เพิ่มค่านับสำหรับชิ้นต่อไป
                }
            }

            _items.Add(item);
        }

        public static List<CartItem> GetItems()
        {
            return _items;
        }

        public static void RemoveItem(int itemId)
        {
            var item = _items.FirstOrDefault(i => i.ItemId == itemId);
            if (item != null)
            {
                _items.Remove(item);
            }

            // หมายเหตุ: การลบของออกอาจทำให้เลขไม่เรียงกัน (เช่น มี #1, #3)
            // แต่นี่คือวิธีที่ตรงตามคำสั่ง "นับตามลำดับที่กด" ที่สุดครับ
            // หากต้องการให้เลขเรียงใหม่ทุกครั้งที่ลบ (Re-index) จะต้องแก้ไข Logic ซับซ้อนกว่านี้
        }

        public static void UpdateQuantity(int itemId, int newQuantity)
        {
            var item = _items.FirstOrDefault(i => i.ItemId == itemId);
            if (item != null && newQuantity > 0)
            {
                item.Quantity = newQuantity;
            }
        }

        // [อัปเดต] แก้ไขเมธอดนี้
        public static void ClearCart()
        {
            _items.Clear();
            _nextItemId = 1;

            // [อัปเดต] รีเซ็ตตัวนับกลับไปเป็น 1
            _hotCrepeCounter = 1;
            _coldCrepeCounter = 1;
        }

        public static decimal GetTotalPrice()
        {
            return _items.Sum(item => item.TotalPrice * item.Quantity);
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace Whanjuay
{
    // [แก้] คลาสสำหรับเก็บรายการวัตถุดิบ (มีสถานะ "เพิ่มพิเศษ")
    public class CartIngredient
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; } // ราคาปกติ
        public decimal ExtraPrice { get; set; } // ราคาที่บวกเพิ่ม (ถ้ามี)
        public bool IsExtra { get; set; } // ติ๊ก "เพิ่มพิเศษ" หรือไม่
    }

    // คลาสสำหรับเก็บรายการสินค้าในตะกร้า
    public class CartItem
    {
        public int ItemId { get; set; } // ID ของตะกร้า (ไม่ซ้ำกัน)
        public string DisplayName { get; set; } // "เครปร้อน (สั่งทำ)" หรือ "โกโก้"
        public decimal TotalPrice { get; set; } // ราคารวมของรายการนี้
        public int Quantity { get; set; }
        public bool IsCustomCrepe { get; set; }
        public string CategoryName { get; set; } // "เครปร้อน", "เครื่องดื่ม"
        public List<CartIngredient> Ingredients { get; set; } // รายการวัตถุดิบที่เลือก
    }

    // คลาส static สำหรับจัดการตะกร้าสินค้า (ส่วนกลาง)
    public static class CartService
    {
        private static List<CartItem> _items = new List<CartItem>();
        private static int _nextItemId = 1; // ใช้นับ ID ตะกร้า

        public static void AddItem(CartItem item)
        {
            item.ItemId = _nextItemId++; // กำหนด ID ที่ไม่ซ้ำกัน
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
        }

        public static void UpdateQuantity(int itemId, int newQuantity)
        {
            var item = _items.FirstOrDefault(i => i.ItemId == itemId);
            if (item != null && newQuantity > 0)
            {
                item.Quantity = newQuantity;
            }
        }

        public static void ClearCart()
        {
            _items.Clear();
            _nextItemId = 1;
        }

        public static decimal GetTotalPrice()
        {
            // คำนวณราคารวมทั้งหมด
            return _items.Sum(item => item.TotalPrice * item.Quantity);
        }
    }
}
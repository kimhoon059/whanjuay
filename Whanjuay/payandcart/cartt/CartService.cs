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
        private static int _hotCrepeCounter = 1;
        private static int _coldCrepeCounter = 1;

        // [เพิ่มใหม่] กำหนดอัตรา VAT
        private const decimal VAT_RATE = 0.07m;


        public static void AddItem(CartItem item)
        {
            item.ItemId = _nextItemId++;

            if (item.IsCustomCrepe)
            {
                if (item.CategoryName == "เครปร้อน")
                {
                    item.DisplayName += $" #{_hotCrepeCounter}";
                    _hotCrepeCounter++;
                }
                else if (item.CategoryName == "เครปเย็น")
                {
                    item.DisplayName += $" #{_coldCrepeCounter}";
                    _coldCrepeCounter++;
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
            _hotCrepeCounter = 1;
            _coldCrepeCounter = 1;
        }

        /// <summary>
        /// [แก้ไข] เมธอดนี้คือยอดรวมสินค้า (Subtotal)
        /// </summary>
        public static decimal GetTotalPrice()
        {
            return _items.Sum(item => item.TotalPrice * item.Quantity);
        }

        /// <summary>
        /// [เพิ่มใหม่] คำนวณ VAT 7% จาก Subtotal
        /// </summary>
        public static decimal GetVatAmount()
        {
            return GetTotalPrice() * VAT_RATE;
        }

        /// <summary>
        /// [เพิ่มใหม่] คำนวณยอดสุทธิ (Subtotal + VAT)
        /// </summary>
        public static decimal GetGrandTotal()
        {
            return GetTotalPrice() + GetVatAmount();
        }
    }
}
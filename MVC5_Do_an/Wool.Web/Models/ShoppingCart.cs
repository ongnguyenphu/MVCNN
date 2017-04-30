using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wool.Model;
using Wool.Service;

namespace Wool.Web.Models
{
    public class ShoppingCart
    {
        public List<Product> Items = new List<Product>();
        private readonly IProductService productService;

        public ShoppingCart(IProductService productService)
        {
            this.productService = productService;
        }

        public ShoppingCart()
        {
            
        }

        public void Add(long Id)
        {
            try
            {
                var Item = Items.Single(p => p.ID == Id);
                Item.Quantity++;
            }
            catch
            {
                var item = productService.GetProductByID(Id);
                item.Quantity = 1;
                Items.Add(item);
            }
        }

        public void Remove(long Id)
        {
            var Item = Items.Single(p => p.ID == Id);
            Items.Remove(Item);
        }

        public void Update(long Id, int newQuantity)
        {
            var Item = Items.Single(p => p.ID == Id);
            Item.Quantity = newQuantity;
        }

        public void Clear()
        {
            Items.Clear();
        }

        public double Amount
        {
            get
            {
                var amount = Items.Sum(p => p.UnitPrice * p.Quantity * (1 - p.Discount));
                return amount;
            }
        }

        public int Count
        {
            get
            {
                var count = Items.Sum(p => p.Quantity);
                return count;
            }
        }

        public double getItemAmount(int Id)
        {
            var Item = Items.Single(p => p.ID == Id);
            return Item.UnitPrice * Item.Quantity * (1 - Item.Discount);
        }

        //--TRUY XUẤT GIỎ HÀNG TRONG SESSION--//
        public static ShoppingCart Cart
        {
            get
            {
                var cart = HttpContext.Current.Session["ShoppingCart"] as ShoppingCart;
                if (cart == null)
                {
                    cart = new ShoppingCart();
                    HttpContext.Current.Session["ShoppingCart"] = cart;
                }
                return cart;
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wool.Web.Models;

namespace Wool.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Add(int Id)
        {
            ShoppingCart.Cart.Add(Id);
            var response = new
            {
                Count = ShoppingCart.Cart.Count,
                Amount = ShoppingCart.Cart.Amount.ToString("#,###.#0")
            };
            return Json(response);
        }

        public ActionResult Remove(int Id)
        {
            ShoppingCart.Cart.Remove(Id);
            var response = new
            {
                Count = ShoppingCart.Cart.Count,
                Amount = ShoppingCart.Cart.Amount.ToString("#,###.#0")
            };
            return Json(response);
        }

        public ActionResult Update(int Id, int newQty)
        {
            ShoppingCart.Cart.Update(Id, newQty);
            var response = new
            {
                Count = ShoppingCart.Cart.Count,
                Amount = ShoppingCart.Cart.Amount.ToString("#,###.#0"),
                ItemAmount = ShoppingCart.Cart.getItemAmount(Id).ToString("c")
            };
            return Json(response);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Clear()
        {
            ShoppingCart.Cart.Clear();
            return RedirectToAction("Index");
        }
    }
}
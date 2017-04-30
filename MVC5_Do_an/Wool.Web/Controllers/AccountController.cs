using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wool.Model;
using Wool.Service;
using Wool.Web.ViewModels;

namespace Wool.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly ICustomerService customerService;

        public AccountController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public ActionResult Login()
        {
            var cookie = Request.Cookies["user"];
            if (cookie != null)
            {
                ViewBag.username = cookie.Values["username"];
                ViewBag.Password = cookie.Values["Pw"];
                ViewBag.Remember = true;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password, bool remember)
        {
            var user = customerService.GetCustomerByName(username);

            if (user == null)
            {
                ModelState.AddModelError("", "Sai tên đang nhập");
            }
            else if (user.Password != password)
            {
                ModelState.AddModelError("", "Sai mật khẩu");
            }
            else if (!user.Activated)
            {
                ModelState.AddModelError("", "Tài khoản của bạn chưa được kích hoạt");
            }
            else
            {
                ModelState.AddModelError("", "Đăng nhập thành công");
                Session["user"] = user;
                var cookie = new HttpCookie("user");

                if (remember)
                {
                    cookie.Values["username"] = username;
                    cookie.Values["Pw"] = password;
                    cookie.Expires = DateTime.Now.AddMonths(1);
                }
                else
                {
                    cookie.Expires = DateTime.Now;
                }
                Response.Cookies.Add(cookie);

                var requestURI = Session["RequestUri"] as string;
                if (requestURI != null)
                {
                    return Redirect(requestURI);
                }
            }
            return View();
        }

        public ActionResult Logoff()
        {
            Session.Remove("user");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Forgot()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Forgot(long Id, string Email)
        {
            var user = customerService.GetCustomerByID(Id);
            if (user == null)
            {
                ModelState.AddModelError("", "Sai tên đang nhập");
            }
            else if (user.Email != Email)
            {
                ModelState.AddModelError("", "Sai dia chi email");
            }
            else
            {
                ModelState.AddModelError("", "Mat khau da duoc gui qua email");
                //Mailer.Send(Email,
                //    "Forgot password",
                //    "Your password is " + user.Password);

            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer model)
        {
            try
            {
                var file = Request.Files["upPhoto"];
                model.Photo = Guid.NewGuid() + file.FileName.Substring(file.FileName.LastIndexOf("."));
                var path = "~/images/customers/" + model.Photo;
                file.SaveAs(Server.MapPath(path));

                customerService.CreateCustomer(model);
                customerService.SaveCustomer();

                ModelState.AddModelError("", "Dang ky thanh cong");
                //var uri = Request.Url.AbsoluteUri.Replace("Register", "Activate/" + model.Username.Encode());
                //var link = "<a href='" + uri + "'>Activate</a>";
                //Mailer.Send(model.Email,
                //            "Welcome Mail",
                //            "Click vao lien ket sau de kich hoat tai khoan: " + link);
            }
            catch
            {
                ModelState.AddModelError("", "Dang ky that bai");
            }
            return View("Login");
        }

        public ActionResult Activate(long id)
        {
            var user = customerService.GetCustomerByID(id);
            user.Activated = true;
            customerService.SaveCustomer();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Edit()
        {
            var model = Session["user"] as CustomerViewModel;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CustomerViewModel customerViewModel)
        {
            try
            {
                var file = Request.Files["upPhoto"];
                if (file.ContentLength > 0)
                {
                    var path = "~/images/customers/" + customerViewModel.Photo;
                    System.IO.File.Delete(Server.MapPath(path));

                    customerViewModel.Photo = Guid.NewGuid() + file.FileName.Substring(file.FileName.LastIndexOf("."));
                    path = "~/images/customers/" + customerViewModel.Photo;
                    file.SaveAs(Server.MapPath(path));
                }

                var customer = Mapper.Map<CustomerViewModel, Customer>(customerViewModel);

                customerService.UpdateCustomer(customer);
                customerService.SaveCustomer();
                Session["user"] = customerViewModel;
                ModelState.AddModelError("", "Cap nhat thanh cong");
            }
            catch
            {
                ModelState.AddModelError("", "Cap nhat that bai");
            }
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ChangePassword(long id, string Password, string newPassword, string confirmPassword)
        {
            var user = customerService.GetCustomerByID(id);
            if (user == null)
            {
                ModelState.AddModelError("", "Sai ten dang nhap");
            }
            else if (user.Password != Password)
            {
                ModelState.AddModelError("", "Sai mat khau");
            }
            else if (newPassword != confirmPassword)
            {
                ModelState.AddModelError("", "Xac nhan mat khau khong chinh xac");
            }
            else
            {
                user.Password = newPassword;
                customerService.SaveCustomer();
                ModelState.AddModelError("", "Doi mat khau thanh cong");

                var customerViewModel = Mapper.Map<Customer, CustomerViewModel>(user);

                Session["user"] = customerViewModel;
            }
            return View();
        }
    }
}
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wool.Model;
using Wool.Service;
using Wool.Web.ViewModels;

namespace Wool.Web.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }


        // GET: Admin/Category
        public ActionResult Index()
        {
            var vmCategory = new CategoryViewModel();

            IEnumerable<CategoryViewModel> viewModelCategories;
            IEnumerable<Category> categories;

            categories = categoryService.GetCategories().ToList();

            ViewBag.Items = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);

            return View(vmCategory);
        }

        public ActionResult Insert(CategoryViewModel newCategory)
        {
            if (newCategory != null)
            {
                var category = Mapper.Map<CategoryViewModel, Category>(newCategory);
                categoryService.CreateCategory(category);
                categoryService.SaveCategory();
                ModelState.Clear();
            }
            var categories = categoryService.GetCategories().ToList();
            ViewBag.Items = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);

            return View("Index");
        }

        public ActionResult Edit(long id)
        {
            var category = categoryService.GetCategoryByID(id);
            var categories = categoryService.GetCategories().ToList();
            ViewBag.Items = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
            var categoryViewModel = Mapper.Map<Category, CategoryViewModel>(category);
            return View("Index", categoryViewModel);
        }

        public ActionResult Delete(long id)
        {
            var category = categoryService.GetCategoryByID(id);
            var categoryViewModel = Mapper.Map<Category, CategoryViewModel>(category);
            try
            {
                categoryService.DeleteCategory(category);
                categoryService.SaveCategory();
                ModelState.Clear();
                ModelState.AddModelError("", "Xóa thành công !");
                var categories = categoryService.GetCategories().ToList();
                ViewBag.Items = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
                return View("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Xóa thất bại !");
                return View("Index", categoryViewModel);
            }
        }

        public ActionResult Update(CategoryViewModel updatedCategory)
        {
            try
            {
                var category = Mapper.Map<CategoryViewModel, Category>(updatedCategory);
                categoryService.UpdateCategory(category);
                categoryService.SaveCategory();
                ModelState.AddModelError("", "Cap nhat thành công !");
            }
            catch
            {
                ModelState.AddModelError("", "Cap nhat thất bại !");
            }
            var categories = categoryService.GetCategories().ToList();
            ViewBag.Items = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
            return View("Index");
        }
    }
}
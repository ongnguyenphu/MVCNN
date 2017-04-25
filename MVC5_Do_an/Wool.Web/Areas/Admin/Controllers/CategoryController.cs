using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Wool.Model;
using Wool.Service;
using Wool.Web.ViewModels.Admin;

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
            var vmCategory = new AdminCategoryViewModel();

            IEnumerable<AdminCategoryViewModel> viewModelCategories;
            IEnumerable<Category> categories;

            categories = categoryService.GetCategories().ToList();

            ViewBag.Items = Mapper.Map<IEnumerable<Category>, IEnumerable<AdminCategoryViewModel>>(categories);

            return View(vmCategory);
        }

        public ActionResult Insert(AdminCategoryViewModel newCategory)
        {
            if (newCategory != null)
            {
                var category = Mapper.Map<AdminCategoryViewModel, Category>(newCategory);
                categoryService.CreateCategory(category);
                categoryService.SaveCategory();
                ModelState.Clear();
            }
            var categories = categoryService.GetCategories().ToList();
            ViewBag.Items = Mapper.Map<IEnumerable<Category>, IEnumerable<AdminCategoryViewModel>>(categories);

            return View("Index");
        }

        public ActionResult Edit(long id)
        {
            var category = categoryService.GetCategoryByID(id);
            var categories = categoryService.GetCategories().ToList();
            ViewBag.Items = Mapper.Map<IEnumerable<Category>, IEnumerable<AdminCategoryViewModel>>(categories);
            var categoryViewModel = Mapper.Map<Category, AdminCategoryViewModel>(category);
            return View("Index", categoryViewModel);
        }

        public ActionResult Delete(long id)
        {
            var category = categoryService.GetCategoryByID(id);
            var categoryViewModel = Mapper.Map<Category, AdminCategoryViewModel>(category);
            try
            {
                categoryService.DeleteCategory(category);
                categoryService.SaveCategory();
                ModelState.Clear();
                ModelState.AddModelError("", "Xóa thành công !");
                var categories = categoryService.GetCategories().ToList();
                ViewBag.Items = Mapper.Map<IEnumerable<Category>, IEnumerable<AdminCategoryViewModel>>(categories);
                return View("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Xóa thất bại !");
                return View("Index", categoryViewModel);
            }
        }

        public ActionResult Update(AdminCategoryViewModel updatedCategory)
        {
            try
            {
                var category = Mapper.Map<AdminCategoryViewModel, Category>(updatedCategory);
                categoryService.UpdateCategory(category);
                categoryService.SaveCategory();
                ModelState.AddModelError("", "Cap nhat thành công !");
            }
            catch
            {
                ModelState.AddModelError("", "Cap nhat thất bại !");
            }
            var categories = categoryService.GetCategories().ToList();
            ViewBag.Items = Mapper.Map<IEnumerable<Category>, IEnumerable<AdminCategoryViewModel>>(categories);
            return View("Index");
        }
    }
}
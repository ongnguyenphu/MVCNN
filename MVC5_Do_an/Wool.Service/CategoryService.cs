using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Data.Infrastructure;
using Wool.Data.Repositories;
using Wool.Model;

namespace Wool.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public IEnumerable<Category> GetCategories(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return categoryRepository.GetAll();
            else
                return categoryRepository.GetAll().Where(c => c.Name == name);
        }

        public Category GetCategoryByID(long id)
        {
            Category category = categoryRepository.GetById(id);
            return category;
        }

        public Category GetCategoryByName(string name)
        {
            Category category = categoryRepository.GetCategoryByName(name);
            return category;
        }

        public void CreateCategory(Category category)
        {
            categoryRepository.Add(category);
        }

        public void SaveCategory()
        {
            unitOfWork.Commit();
        }



        #endregion

    }
}

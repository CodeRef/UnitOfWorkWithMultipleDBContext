using System.Collections.Generic;
using System.Linq;
using UoW_MultipleDBContext.Data.UnitOfWork;
using UoW_MultipleDBContext.Entity;
using UoW_MultipleDBContext.Service.IService;

namespace UoW_MultipleDBContext.Service
{
    public class CategoryService : ICategoryService
    {
        private IDBOneRepositories categoryRepositories;
        public CategoryService(IDBOneRepositories categoryRepositories)
        {
            this.categoryRepositories = categoryRepositories;
        }
        public List<Category> CallRightOne()
        {
            var xx = this.categoryRepositories.CategoryRepository.GetAll();
            return xx.ToList();
        }
    }
}

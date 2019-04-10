using Lesson11.My3tierApplication.Core.Entities;
using Lesson11.My3tierApplication.Core.Managers;
using Lesson11.My3tierApplication.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11.My3tierApplication.BLL
{
    public class CategoryManager : IManager
    {
        private IRepository<Category, int> _categoryRepo;
        private IValidator _categoryValidator;

        public CategoryManager(IRepository<Category, int> categoryReposotory,
            IValidator categoryValidator)
        {
            _categoryRepo = categoryReposotory;
            _categoryValidator = categoryValidator;
        }

        public ICollection<Category> GetCategories()
        {
            var result = new List<Category>();

            try
            {
                result = _categoryRepo.GetCollection().ToList();
            }
            catch (Exception ex)
            {
                // some logger call
            }

            return result;
        }

        public bool TryCreate(Category category)
        {
            var result = true;

            try
            {
                if (!Validate(category))
                    throw new Exception();

                _categoryRepo.Create(category);

            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public bool TryDelete(int id)
        {
            var result = true;

            try
            {
                _categoryRepo.Delete(id);
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public bool TryUpdate(int id, Category category)
        {
            var result = true;

            try
            {
                if (!Validate(category))
                    throw new Exception();

                _categoryRepo.Update(id, category);
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public bool Validate(Category category)
        {
            return _categoryValidator.Validate(category);
        }
    }
}

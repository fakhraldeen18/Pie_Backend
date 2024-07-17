using BackendPieProject.DBContext;
using BackendPieProject.Models;

namespace BackendPieProject.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BethanysPieShopDbContext _dbContext;

        public CategoryRepository (BethanysPieShopDbContext dbContext)
        {
               _dbContext = dbContext;
        }

        public Category CreateOne(Category newcategory)
        {
            var createCategory = _dbContext.Categories.Add(newcategory);
            _dbContext.SaveChanges();
            return newcategory;
        }

        public bool DeleteOne(int id)
        {
            var findCategory = FindOne(id);
            if(findCategory == null) return false;
            _dbContext.Categories.Remove(findCategory);
            _dbContext.SaveChanges();
            return true;
        }

        public Category FindOne(int id)
        {
            var categories = GetAll();
            var findCategory= categories.Where(c=>c.CategoryId == id).FirstOrDefault();
            return findCategory;
        }

        public IEnumerable<Category> GetAll()
        {
            var categories = _dbContext.Categories;
            return categories;
        }

        public Category UpdateOne(Category updatedcategory)
        {
            var updateCate =_dbContext.Categories.Update(updatedcategory);
            _dbContext.SaveChanges();
            return updatedcategory;

        }
    }
}

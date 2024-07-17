using BackendPieProject.Models;

namespace BackendPieProject.Repositories
{
    public interface ICategoryRepository
    {

        public IEnumerable<Category> GetAll();
        public Category FindOne(int id);
        public Category CreateOne(Category newcategory);
        public Category UpdateOne(Category updatedcategory);
        public bool DeleteOne(int id);  
    }
}

using BackendPieProject.DBContext;
using BackendPieProject.Dtos;
using BackendPieProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendPieProject.Repositories
{
    public class PieRepository : IPieReopsitory
    {
        private readonly BethanysPieShopDbContext _dbContext;
        private readonly ICategoryRepository _categoryRepository;
        public PieRepository(BethanysPieShopDbContext dbContext , ICategoryRepository categoryRepository)
        {
            _dbContext = dbContext;
            _categoryRepository = categoryRepository;
        }

        public Pie CreateOne(Pie newPie)
        {
            var pies = _dbContext.Pies;
            pies.Add(newPie);
            _dbContext.SaveChanges();
            return newPie;
        }

		public bool DeleteOne(int Id)
		{
			var findPie = FindOne(Id);
            if(findPie == null) return false;
            _dbContext.Pies.Remove(findPie);
            _dbContext.SaveChanges();
            return true;
		}

		public Pie FindOne(int Id)
        {
            var pies = GetAll();
            var findOne = pies.Where(p=>p.PieId == Id).FirstOrDefault();
            return findOne;
        }

        public IEnumerable<Pie> GetAll()
        {
            var pies = _dbContext.Pies;
            return pies;
        }

		public IEnumerable<Pie> PiesOfTheWeek()
		{
            var ofTheWeek = _dbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            return ofTheWeek;
		}

		public IEnumerable<Pie> PieWithCategory(string? currentCategory)
		{
            IEnumerable<Pie> pies;

			if (string.IsNullOrEmpty(currentCategory))
			{
				pies = GetAll().OrderBy(p => p.PieId);
			}
			else
			{
				pies = _dbContext.Pies.Where(p => p.Category.CategoryName == currentCategory).OrderBy(p => p.PieId);
			}
            return pies;
		}

		public Pie UpdateOne(Pie updatedPie)
		{
            var updatePie= _dbContext.Pies.Update(updatedPie);
            _dbContext.SaveChanges();
            return updatedPie;
		}
	}
}

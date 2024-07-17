using BackendPieProject.Dtos;
using BackendPieProject.Models;

namespace BackendPieProject.Repositories
{
    public interface IPieReopsitory
    {
        public IEnumerable<Pie> GetAll();
        public Pie FindOne(int Id);

        public Pie CreateOne(Pie newPie);

        public IEnumerable<Pie> PiesOfTheWeek();

        public IEnumerable<Pie> PieWithCategory(string currentCategory);
        public Pie UpdateOne(Pie updatedPie);
        public bool DeleteOne (int Id);
	}
}

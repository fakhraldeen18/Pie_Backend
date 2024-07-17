using BackendPieProject.Models;

namespace BackendPieProject.Repositories
{
	public interface IOrderRepository
	{

		public IEnumerable<Order> GetAll();
		public Order FindOne(int id);
	}
}

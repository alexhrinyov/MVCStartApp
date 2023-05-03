using MVCStartApp.Models.Db;
using System.Threading.Tasks;

namespace MVCStartApp.Models.Repositories
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
    }
}

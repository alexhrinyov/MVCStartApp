using Microsoft.AspNetCore.Mvc;
using MVCStartApp.Models.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStartApp.Controllers
{
    public class RequestsController : Controller
    {
        // ссылка на репозиторий
        private readonly IRequestRepository _repo;

        public RequestsController(IRequestRepository repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Index()
        {
           var requests = await _repo.GetRequests();
            requests = requests.OrderBy(r => r.Date).ToArray();
            return View(requests);
        }
    }
}

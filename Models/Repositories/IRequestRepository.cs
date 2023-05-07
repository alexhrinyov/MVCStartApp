using Microsoft.EntityFrameworkCore;
using MVCStartApp.Models.Db;
using System.Threading.Tasks;
using System;

namespace MVCStartApp.Models.Repositories
{
    public interface IRequestRepository
    {
        public Task AddRequest(Request request);
        public Task<Request[]> GetRequests();
    }
}

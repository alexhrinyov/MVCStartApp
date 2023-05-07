using Microsoft.EntityFrameworkCore;
using MVCStartApp.Models.Db;
using System.Threading.Tasks;
using System;

namespace MVCStartApp.Models.Repositories
{
    public class RequestRepository:IRequestRepository
    {
        // ссылка на контекст
        private readonly BlogContext _context;

        // Метод-конструктор для инициализации
        public RequestRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task AddRequest(Request request)
        {
            // Генерация даты и айди
            request.Date = DateTime.Now;
            request.Id = Guid.NewGuid();
            // Добавление request
            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetRequests()
        {
            // Получим все requests
            return await _context.Requests.ToArrayAsync();
        }
    }
}

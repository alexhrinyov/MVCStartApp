﻿using Microsoft.EntityFrameworkCore;
using MVCStartApp.Models.Db;
using System;
using System.Threading.Tasks;

namespace MVCStartApp.Models.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        // ссылка на контекст
        private readonly BlogContext _context;

        // Метод-конструктор для инициализации
        public BlogRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            // Генерация даты и айди
            user.JoinDate = DateTime.Now;
            user.Id = Guid.NewGuid();
            // Добавление пользователя
            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
                await _context.Users.AddAsync(user);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }

        public async Task<User[]> GetUsers()
        {
            // Получим всех активных пользователей
            return await _context.Users.ToArrayAsync();
        }
    }
}

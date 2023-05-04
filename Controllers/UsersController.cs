﻿using Microsoft.AspNetCore.Mvc;
using MVCStartApp.Models.Db;
using System.Threading.Tasks;
using System;
using MVCStartApp.Models.Repositories;

namespace MVCStartApp.Controllers
{
    public class UsersController:Controller
    {
        // ссылка на репозиторий
        private readonly IBlogRepository _repo;

        public UsersController(IBlogRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _repo.GetUsers();
            return View(authors);
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }
    }
}

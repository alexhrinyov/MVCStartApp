using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using MVCStartApp.Models.Repositories;
using MVCStartApp.Models.Db;

namespace MVCStartApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private IRequestRepository _requestRepository;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
            
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context, IRequestRepository requestRepository)
        {
            // Для логирования данных о запросе используем свойста объекта HttpContext
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");

            //string filePath = Path.Combine(Directory.GetCurrentDirectory(), "RequestLog.txt");

            //using (StreamWriter sw = new StreamWriter(filePath, true))
            //{
            //    await sw.WriteLineAsync($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
            //}

            //Логирование запросов к серверу в базу данных 
            _requestRepository = requestRepository;
            var request = new Request();
            request.Url = context.Request.Host.Value + context.Request.Path;
            await _requestRepository.AddRequest(request);


            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}

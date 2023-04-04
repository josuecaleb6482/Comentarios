using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Data.Common;
using System.IO;

namespace ApiComentarios.WebApi.Filters
{
    public class MyExceptionHandler : IExceptionFilter
    {
        private readonly ILogger<MyExceptionHandler> _logger;

        public MyExceptionHandler(ILogger<MyExceptionHandler> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            int statusCode;
            string errorMessage;

            if (context.Exception is DivideByZeroException)
            {
                statusCode = 400;
                errorMessage = "Error: División por cero.";
            }
            else if (context.Exception is ArgumentException)
            {
                statusCode = 400;
                errorMessage = "Error: Argumento no válido.";
            }
            else if (context.Exception is NullReferenceException)
            {
                statusCode = 400;
                errorMessage = "Error: Referencia nula.";
            }
            else if (context.Exception is InvalidOperationException)
            {
                statusCode = 400;
                errorMessage = "Error: Operación no válida.";
            }
            else if (context.Exception is TimeoutException)
            {
                statusCode = 408;
                errorMessage = "Error: Tiempo de espera agotado.";
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                statusCode = 401;
                errorMessage = "Error: Acceso no autorizado.";
            }
            else if (context.Exception is FileNotFoundException)
            {
                statusCode = 404;
                errorMessage = "Error: Archivo no encontrado.";
            }
            else if (context.Exception is NotSupportedException)
            {
                statusCode = 405;
                errorMessage = "Error: Operación no soportada.";
            }
            else if (context.Exception is DBConcurrencyException dbConEx)
            {
                statusCode = 409;
                errorMessage = $"Error de concurrencia en la base de datos: {dbConEx.Message}";
            }
            else if (context.Exception is DataException dataEx)
            {
                statusCode = 500;
                errorMessage = $"Error de manipulación de datos: {dataEx.Message}";
            }
            else if (context.Exception is DbUpdateException dbUpdateEx)
            {
                statusCode = 500;
                errorMessage = $"Error al actualizar datos en la base de datos: {dbUpdateEx.Message}";
            }
            else if (context.Exception is DbUpdateConcurrencyException dbUpdateConEx)
            {
                statusCode = 409;
                errorMessage = $"Error de concurrencia en la base de datos: {dbUpdateConEx.Message}";
            }
            else if (context.Exception is DbException dbEx)
            {
                statusCode = 500;
                errorMessage = $"Error al conectarse a la base de datos: {dbEx.Message}";
            }
            else
            {
                statusCode = 500;
                errorMessage = "Error interno del servidor.";
            }

            context.Result = new JsonResult(new { error = errorMessage });
            context.HttpContext.Response.StatusCode = statusCode;
            context.ExceptionHandled = true;

            _logger.LogError($"Error: {context.HttpContext.Response.StatusCode}");
            
        }
    }

}

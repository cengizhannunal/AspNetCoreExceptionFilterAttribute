using AspNetCoreExceptionFilterAttribute.Attribute;
using AspNetCoreExceptionFilterAttribute.Enums;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AspNetCoreExceptionFilterAttribute.Controllers
{
    public class DefaultController : Controller
    {
        [ExceptionLog(logTypes: new[] { (short)LoggerType.DatabaseLogger, (short)LoggerType.EmailLogger, (short)LoggerType.FileLogger })]
        public IActionResult Index()
        {
            return View();
        }
    }
}
using AspNetCoreExceptionFilterAttribute.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace AspNetCoreExceptionFilterAttribute.Attribute
{
    public class ExceptionLog : TypeFilterAttribute
    {
        public ExceptionLog(short[] logTypes) : base(typeof(ExceptionHandling))
        {
            Arguments = new object[] { logTypes };
        }

        private class ExceptionHandling : ExceptionFilterAttribute
        {
            private readonly short[] _logTypes;
            public ExceptionHandling(short[] logTypes)
            {
                _logTypes = logTypes;
            }

            public override void OnException(ExceptionContext context)
            {
                var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;

                var methodDescriptor = string.Format("{0}.{1}.{2}", controllerActionDescriptor.MethodInfo.ReflectedType.Namespace,
                    controllerActionDescriptor.MethodInfo.ReflectedType.Name,
                    controllerActionDescriptor.MethodInfo.Name);


                //Exception Type Code =  context.Exception.GetType(); 
                //Exception code  =  context.Exception.ToString(); 

                if (_logTypes.Contains((short)LoggerType.DatabaseLogger))
                {
                    //Database Logger Code
                }

                if (_logTypes.Contains((short)LoggerType.FileLogger))
                {
                    //File Logger Code
                }

                if (_logTypes.Contains((short)LoggerType.EmailLogger))
                {
                    //Email Logger Code
                }

            }

        }
    }
}

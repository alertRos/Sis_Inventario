using InventorySystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InventorySystem.Middlewares
{
    public class ValidarNegocioCreateFilterAttribute:ActionFilterAttribute
    {
        private readonly IOperationStatusService _operationStatusService;

        public ValidarNegocioCreateFilterAttribute(IOperationStatusService operationStatusService)
        {
            _operationStatusService = operationStatusService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!_operationStatusService.OperationSuccess)
            {
                // Redirige a una página de error o realiza otras acciones según tus necesidades
                context.Result = new RedirectToActionResult("Error", "Home", null);
            }
            _operationStatusService.OperationSuccess = false;
        }
    }
}

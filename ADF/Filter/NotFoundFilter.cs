using ADF.Core.Services.Interface;
using ADF.CoreApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace ADF.CoreApi.Filter
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly IProductService _Productservice;
        public NotFoundFilter(IProductService productService)
        {
            _Productservice = productService;
        }


        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var product = await _Productservice.GetByIdAsync(id);

            if (product != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 404;

                errorDto.Errors.Add($"Not found {id}.");

                context.Result = new NotFoundObjectResult(errorDto);
            }

        }
    }
}

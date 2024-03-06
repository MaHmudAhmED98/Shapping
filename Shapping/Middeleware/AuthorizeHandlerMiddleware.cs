using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shapping.Model;
using System.Security.Claims;

namespace Shapping.Middeleware
{
    public class AuthorizeHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private ShapingContext _context;
        private UserManager<AppUser> userManager;        

        public AuthorizeHandlerMiddleware(RequestDelegate next/*, ShippingContext context, UserManager<AppUser> userManager*/)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            _context = context.RequestServices.GetRequiredService<ShapingContext>();
            // userManager = context.RequestServices.GetRequiredService<UserManager<AppUser>>();
            var controller = context.Request.HttpContext.GetRouteValue("controller");
            var action = context.Request.HttpContext.GetRouteValue("action").ToString();
            var methType = context.Request.Method.ToString();
            var userId = context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? null;

            if (!context.User?.Identity?.IsAuthenticated ?? false && action != "Login")
                throw new ExceptionLogic("un authorize");
            else if (!context.User?.Identity?.IsAuthenticated ?? false && action == "Login")
            {
                await _next(context);
                return;
            }



            var user = await userManager.FindByIdAsync(userId);
            if(await userManager.IsInRoleAsync(user!, "admin"))
            {
                await _next(context);
                return;
            }

            //check user and permission
            var userRoles = await userManager.GetRolesAsync(user!);
            var screen = 
                await _context.Screens.Include(x => x.ScreenPermission).ThenInclude(x => x.Role)
                .Where(x => x.ControllerName.ToLower().Trim() == controller.ToString().ToLower().Trim() && 
                 x.ScreenPermission.Any(y => userRoles.Contains(y.Role.Name) ))
                .FirstOrDefaultAsync();

            if (
                (methType.ToLower() == "get" && screen.ScreenPermission.Any(x => x.Get)) ||
                (methType.ToLower() == "post" && screen.ScreenPermission.Any(x => x.Add)) ||
                (methType.ToLower() == "put" && screen.ScreenPermission.Any(x => x.Update)) ||
                (methType.ToLower() == "delete" && screen.ScreenPermission.Any(x => x.Delete))
                    ) await _next(context);
            else throw new ExceptionLogic("Not Allowed!");

        }
    }
}

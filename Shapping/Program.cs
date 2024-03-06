using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shapping.Handler;
using Shapping.Handler.BranchesHandler;
using Shapping.Handler.City;
using Shapping.Handler.GovernorateHandler;
using Shapping.Handler.Marchant;
using Shapping.Handler.Weight;
using Shapping.Middeleware;
using Shapping.Model;
using Shapping.Reprostary;
using Shapping.Reprostary.Governorate;
using Shapping.Reprostary.Merchant;
using Shapping.Reprostary.Product;
using Shapping.Reprostary.SpecialPrice;
using Shapping.Reprostary.Weight;
using System;
using System.Text;

namespace Shapping
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<ShapingContext>().AddDefaultTokenProviders();
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
                };


            });

            builder.Services.AddDbContext<ShapingContext>(op => 
                op.UseSqlServer(builder.Configuration.GetConnectionString("cs")));
            builder.Services.AddScoped<IOrderHandler,OrderHandler>();
            builder.Services.AddScoped<IOrderReposiatry, OrderReposiatry>();
            builder.Services.AddScoped<IBranchesRepository, BranchesRepository>();
            builder.Services.AddScoped<IBranchesHandler, BranchesHandler>();
            builder.Services.AddScoped<ICityReprosatriy, CityReprosatriy>();
            builder.Services.AddScoped<ICityHandler, CityHandler>();
            builder.Services.AddScoped<IGovernorateHandler, GovernorateHandler>();
            builder.Services.AddScoped<IGovernorateRepository, GovernorateRepository>();
            builder.Services.AddScoped<ISpecialPriceRopresatry,SpecialPriceRoprisatry>();
            builder.Services.AddScoped<IProductRepeosatry,ProductReprosatry>();
            builder.Services.AddScoped<IWeightHandler, WeightHandler>();
            builder.Services.AddScoped<IWeightReperosatry,WeightReprosatry>();
            builder.Services.AddScoped<IAccountUser, AccountUser>();
            builder.Services.AddScoped<IRoleRopersiatry, RoleRopersatriy>();
            builder.Services.AddScoped<IRoleHandler, RoleHandler>();
            builder.Services.AddScoped<IUserIdentifierProvider, UserIdentifierProvider>();
            builder.Services.AddScoped<IMerchantHandler, MerchantHandler>();
            builder.Services.AddScoped<IMerchantReprosatry, MerchantReprosatry>();
            
            //builder.Services.AddScoped<UserManager<Marchant>>();
            //builder.Services.AddScoped<UserManager<AppUser>>();

            var app = builder.Build();
            
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<AuthorizeHandlerMiddleware>();
            app.MapControllers();

            app.Run();
        }
    }
}

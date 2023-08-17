using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectUpdateApp.Data;
using ProjectUpdateApp.IRepository;
using ProjectUpdateApp.IService;
using ProjectUpdateApp.Repository;
using ProjectUpdateApp.Service;
using System.Text;

namespace ProjectUpdateApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
          
            builder.Services.AddScoped<ILoginService, LoginService>();
            builder.Services.AddScoped<ILoginRepository, LoginRepository>();
            builder.Services.AddScoped<IUserService,UserService>();
            builder.Services.AddScoped<IUserRepository,UserRepository>();
         
            builder.Services.AddScoped<IProjectUpdateService,ProjectUpdateService>();
            builder.Services.AddScoped<IProjectUpdateRepository,ProjectUpdateRepository>();
            builder.Services.AddScoped<IUserProjectUpdateService,UserProjectUpdateService>();
            builder.Services.AddScoped<IUserProjectUpdateRepository,UserProjectUpdateRepository>();
            builder.Services.AddScoped<IRoleRepository,RoleRepository>();
            builder.Services.AddScoped<IRoleService,RoleService>();
            builder.Services.AddScoped<IUserRoleService,UserRoleService>();
            builder.Services.AddScoped<IUserRoleRepository,UserRoleRepository>();

           
           

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
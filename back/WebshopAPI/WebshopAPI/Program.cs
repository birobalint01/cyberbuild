using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;

namespace WebshopAPI
{
    public class Program
    {
        public static string ConnectionString { get; private set; }
        public static byte[] JWTKey { get; private set; }
        public static string Audience { get; private set; }
        public static string Issuer { get; private set; }
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Program.ConnectionString = builder.Configuration.GetConnectionString("SQL");
            Program.JWTKey = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
            Program.Audience = builder.Configuration["JWT:Audience"];
            Program.Issuer = builder.Configuration["JWT:Issuer"];

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Webshop API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(a =>
            {
                a.RequireHttpsMetadata = false;
                a.SaveToken = true;
                a.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    IssuerSigningKey = new SymmetricSecurityKey(JWTKey),
                    ValidAudience = Audience,
                    ValidIssuer = Issuer
                };
            });

            builder.Services.AddScoped<UserManagerService>();
            builder.Services.AddScoped<ProductManagerService>();
            builder.Services.AddScoped<OrderManagerService>();

            builder.Services.AddAuthorization(a =>
            {
                a.AddPolicy("Admin", b =>
                {
                    b.RequireClaim(ClaimTypes.Role, "1");
                });
                a.AddPolicy("Operator", b =>
                {
                    b.RequireClaim(ClaimTypes.Role, "2", "1");
                });
                a.AddPolicy("User", b =>
                {
                    b.RequireClaim(ClaimTypes.Role, "3", "2", "1");
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
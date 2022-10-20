using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Approval_Api.DataModel_.entities;
using Approval_Api.Services;



using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using Approval_Api.DataModel.Repository;
using Approval_Api.DataModel.Repository.Interface;
using Approval_Api.Services.Interface;
using Approval_Api.Mapper;
using Approval_Api.DataModel_.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Approval_Api.ServiceModel.DTO.Request;

namespace Approval_Api.Extensions
{
    public static class DependencyInjections
    {
        public static void ConfigureDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<IRequestServices, RequestServices>();
            services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IFileUploadRepository, FileUploadRepository>();
            services.AddScoped<IFileUploadServices, FileUploadServices>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<IAuthenticationServices, AuthenticationServices>();
            services.AddScoped<ITokenServices, TokenServices>();
            services.AddScoped<MailService>();
            services.AddAutoMapper(typeof(ProfileMapper));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options => options.TokenValidationParameters =
               new TokenValidationParameters
               {

                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"])),
                   ValidateIssuer = false,
                   ValidateAudience = false

               });
            services.AddAuthorization(config =>
            {
                config.AddPolicy("2", Policies.AdminPolicy());
                
            });
        }
    }
}

using Ecraft.Api.Data;
using Ecraft.Api.Data.Repositories.Cryptography;
using Ecraft.Api.Data.Repositories.UnitsOfWork;
using Ecraft.Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Ecraft.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddControllers();

            services.AddDbContext<ECraftContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("ECraftContext")));

            var cryptoSection = Configuration.GetSection("CryptoKey");
            services.Configure<CryptographySettings>(cryptoSection);
            var crypto = cryptoSection.Get<CryptographySettings>();

            var jwtSection = Configuration.GetSection("JWTSettings");
            services.Configure<JWTSettings>(jwtSection);
            var appSettings = jwtSection.Get<JWTSettings>();

            var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            services.AddTransient<ECraftContext>();
            services.AddTransient<UnitOfWorkPerguntas>();
            services.AddTransient<UnitOfWorkProjetos>();
            services.AddTransient<UnitOfWorkReceitas>();
            services.AddTransient<UnitOfWorkTags>();
            services.AddTransient<UnitOfWorkUser>();
            services.AddTransient<AesCryptographyService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //var ptBr = new CultureInfo("pt-BR");
            //var localizationOptions = new RequestLocalizationOptions
            //{
            //    DefaultRequestCulture = new RequestCulture(ptBr),
            //    SupportedCultures = new List<CultureInfo> { ptBr },
            //    SupportedUICultures = new List<CultureInfo> { ptBr }
            //};

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(opt => opt.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

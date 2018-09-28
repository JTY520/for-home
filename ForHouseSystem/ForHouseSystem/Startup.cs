using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForHouseApplication.Comment;
using ForHouseApplication.House;
using ForHouseApplication.User;
using ForHouseEntity.Models;
using ForHouseSystem.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace ForHouseSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
		//public void ConfigureJwtAuthService(IServiceCollection services)
		//{
		//	var audienceConfig = Configuration.GetSection("TokenAuthentication:Audience").Value;
		//	var symmetricKeyAsBase64 = Configuration.GetSection("TokenAuthentication:SecretKey").Value;
		//	var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
		//	var signingKey = new SymmetricSecurityKey(keyByteArray);

		//	var tokenValidationParameters = new TokenValidationParameters
		//	{
		//		// The signing key must match!  
		//		ValidateIssuerSigningKey = true,
		//		IssuerSigningKey = signingKey,

		//		// Validate the JWT Issuer (iss) claim  
		//		ValidateIssuer = true,
		//		ValidIssuer = audienceConfig,

		//		// Validate the JWT Audience (aud) claim  
		//		ValidateAudience = true,
		//		ValidAudience = audienceConfig,

		//		// Validate the token expiry  
		//		ValidateLifetime = true,

		//		ClockSkew = TimeSpan.Zero
		//	};

		//	services.AddAuthentication(options =>
		//	{
		//		options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
		//		options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		//	})
		//	.AddJwtBearer(o =>
		//	{
		//		o.TokenValidationParameters = tokenValidationParameters;
		//	});
		//}
		public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			//ConfigureJwtAuthService(services);
			//register the Swagger generator

			services.AddCors(options =>
			{
				options.AddPolicy("any", builder =>
				{
					builder.AllowAnyOrigin() //允许任何来源的主机访问
					.AllowAnyMethod()
					.AllowAnyHeader()
					.AllowCredentials();//指定处理cookie
				});
			});
			services.AddMvc();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info
				{
					Title = "For Home API",
					Version = "v1",

				});
				var basePath = PlatformServices.Default.Application.ApplicationBasePath;
				var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "ForHouseSystem.xml");
				c.IncludeXmlComments(filePath);
				c.OperationFilter<HttpHeaderOperation>(); // 添加httpHeader参数
			});
			services.AddTransient<IUserApplication, UserApplication>();
			services.AddTransient<IHouseApplication, HouseApplication>();
			services.AddTransient<ICommentApplication, CommentApplication>();
			services.AddScoped<ForHouseContext>();
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "For Home API V1");
			});

			//session
			//app.UseSession();

			//用户身份认证
			app.UseAuthentication();
			app.UseStaticFiles();

			//全局调用
			app.UseCors("any");

			app.UseMvc();
		}
    }
}

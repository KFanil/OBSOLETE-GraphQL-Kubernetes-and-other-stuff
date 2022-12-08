using Blog.Data;
using Blog.Data.Abstract;
using Blog.Data.Repositories;
using IdentityService.Services;
using IdentityService.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Newtonsoft.Json.Converters;
using IdentityService;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
// services.AddCors();

builder.Services.AddDbContextFactory<BlogContext>(opt =>
                    opt.UseSqlServer(builder.Configuration.GetConnectionString("CommandConStr"), 
                    b => b.MigrationsAssembly("IdentityService"))
                );

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JWTSecretKey"))
            )
        };
    });


services.AddScoped<IUserRepository, UserRepository>();

services.AddSingleton<IAuthService>(
    new AuthService(
        builder.Configuration.GetValue<string>("JWTSecretKey"),
        builder.Configuration.GetValue<int>("JWTLifespan")
    )
);

services
    .AddMvc()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        options.SerializerSettings.Converters.Add(new StringEnumConverter());
    });

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseCors(builder =>
    builder
      .WithOrigins("http://localhost:3000")
      .AllowAnyHeader()
      .AllowAnyMethod()
      .AllowCredentials()
  );
// app.UseHttpsRedirection();

app.UseAuthentication();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapGet("/", () => "Hello World!");

var t = app.Services.GetService<IDbContextFactory<BlogContext>>();
PrepDb.PrepPopulation(app, builder.Environment.IsProduction());

app.Run();

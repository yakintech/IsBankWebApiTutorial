using FluentValidation;
using FluentValidation.AspNetCore;
using IsBankWebApiTutorial.Models;
using IsBankWebApiTutorial.Models.DTO;
using IsBankWebApiTutorial.Models.ORM;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(
    options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true)
    .AddFluentValidation();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//add identity basic configuration

builder.Services.AddDbContext<IsBankDbContext>();

//change password validation
builder.Services.Configure<IdentityOptions>(options =>
{
    //basic password settings
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;

});

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<IsBankDbContext>()
     .AddDefaultTokenProviders(); ;


builder.Services.AddScoped<IValidator<CreateProductRequestDto>, CreateProductRequestDtoValidator>();

//add jwt  bearer authentication

builder.Services.AddAuthentication
    (options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "mail@isbank.com",
            ValidAudience = "mail@isbank.com",
            //ValidIssuer = builder.Configuration["Jwt:Issuer"],
            //ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("loremipsumloremipsumloremipsumloremipsumloremipsumloremipsum")),
            ClockSkew = TimeSpan.Zero // remove delay of token when expire
        };
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

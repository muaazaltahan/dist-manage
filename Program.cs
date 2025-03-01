using dist_manage.DB;
using dist_manage.Models;
using dist_manage.Models.SqlServerEF;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews().AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
   {
     new OpenApiSecurityScheme
     {
       Reference = new OpenApiReference
       {
         Type = ReferenceType.SecurityScheme,
         Id = "Bearer"
       }
      },
      new string[] { }
    }
  });
});
builder.Services.AddCors(o =>
{
    o.AddDefaultPolicy(b =>
    {
        b.AllowAnyHeader();
        b.AllowAnyMethod();
        b.WithOrigins("http://localhost:4200");
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("vas23doif54iw35aeoptghysdavas23doif54iw35aeoptghysda"))
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
    {
        policy.RequireClaim(ClaimTypes.Role, UserRole.Admin.ToString());
    });
    options.AddPolicy("Moderator", policy =>
    {
        policy.RequireClaim(ClaimTypes.Role, new[] { UserRole.Admin.ToString(), UserRole.Moderator.ToString() });
    });
    options.AddPolicy("User", policy =>
    {
        policy.RequireClaim(ClaimTypes.Role, new[] { UserRole.Admin.ToString(), UserRole.Moderator.ToString(), UserRole.User.ToString() });
    });
});
builder.Services.AddDbContext<DBContext>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<CardsEntity>();
builder.Services.AddScoped<IDataHelper<ProgramsDB>, ProgramsEntity>();
builder.Services.AddScoped<IDataHelper<UsersDB>, UsersEntity>();
builder.Services.AddScoped<IDataHelper<LogsDB>, LogsEntity>();
builder.Services.AddScoped<IDataHelper<Link_Prog_CardDB>, Link_Prog_CardEntity>();
builder.Services.AddScoped<IDataHelper<Link_Prog_UserDB>, Link_Prog_UserEntity>();
builder.Services.AddScoped<IDataHelper<RequestDB>, RequestEntity>();
builder.Services.AddScoped<IDataHelper<SectionsDB>, SectionsEntity>();
builder.Services.AddScoped<IDataHelper<SectionUsersDB>, SectionUsersEntity>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors();
}

app.UseDefaultFiles();
app.UseStaticFiles();
//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();

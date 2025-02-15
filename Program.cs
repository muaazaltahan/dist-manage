using dist_manage.DB;
using dist_manage.Models;
using dist_manage.Models.SqlServerEF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(o =>
{
    o.AddDefaultPolicy(b =>
    {
        b.AllowAnyHeader();
        b.AllowAnyMethod();
        b.WithOrigins("http://localhost:4200");
    });
});
builder.Services.AddDbContext<DBContext>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<IDataHelper<CardsDB>, CardsEntity>();
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
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();

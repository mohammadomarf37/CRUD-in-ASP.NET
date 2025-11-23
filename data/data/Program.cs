using Microsoft.EntityFrameworkCore;
using data.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddDbContext<MyContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("mycon"))
);
var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}"
);

app.UseStaticFiles();

app.Run();

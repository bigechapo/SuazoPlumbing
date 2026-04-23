var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles(); // THIS enables HTML files

app.Run();

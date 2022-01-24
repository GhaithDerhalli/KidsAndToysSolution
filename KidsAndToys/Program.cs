
var builder = WebApplication.CreateBuilder(args);

// Stöd för controllers och views
builder.Services.AddControllersWithViews();

//builder.Services.AddTransient<AcmeService>(); // DI: Ny instans varje gång
//builder.Services.AddSingleton<ProductService>(); // DI: Samma instans varje gång

//var connString = builder.Configuration.GetConnectionString("AcmeConnection");


var app = builder.Build();

// Stöd för att mappa HTTP-anrop till våra controllers
app.UseRouting();

// Stöd för Route-attribut på våra Action-metoder
app.UseEndpoints(o => o.MapControllers());

app.Run();
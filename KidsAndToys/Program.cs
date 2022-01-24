
var builder = WebApplication.CreateBuilder(args);

// St�d f�r controllers och views
builder.Services.AddControllersWithViews();

//builder.Services.AddTransient<AcmeService>(); // DI: Ny instans varje g�ng
//builder.Services.AddSingleton<ProductService>(); // DI: Samma instans varje g�ng

//var connString = builder.Configuration.GetConnectionString("AcmeConnection");


var app = builder.Build();

// St�d f�r att mappa HTTP-anrop till v�ra controllers
app.UseRouting();

// St�d f�r Route-attribut p� v�ra Action-metoder
app.UseEndpoints(o => o.MapControllers());

app.Run();
using TextEncryption.Interfaces;
using TextEncryption.Services;
using TextEncryption.Services.CaesarCipher;
using TextEncryption.Services.MorseCode;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IMorseCodeService, MorseCodeService>();
builder.Services.AddScoped<ICaesarCipherService, CaesarCipherService>();
builder.Services.AddTransient<IEncryptionAlgorithm, EncryptionAlgorithm>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");	
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=MorseCode}/{action=Index}/{id?}");

app.Run();

using Asp.Net_HW_Module_02_÷1.Models.Animals;
using Asp.Net_HW_Module_02_÷1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IOutputService, ConsoleOutputService>();

builder.Services.AddSingleton<IAnimalSerializer, JsonAnimalSerializer>();
builder.Services.AddSingleton<IAnimalSerializer, XmlAnimalSerializer>();

// Add services to the container.
builder.Services.AddRazorPages();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SchedualMe.Services; 
using SchedualMe.Models;

var builder = WebApplication.CreateBuilder(args);

// --- 1. CONFIGURING SERVICES (builder.Services) ---

// 1. Get Connection String (Clean and efficient)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// 2. Configure EF Core Services
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

// 3. Add Identity services (The main goal)
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// 4. Add Task Service (Only registered once)
builder.Services.AddScoped<ITaskService, TaskService>();

// 5. Add Razor Pages support (Only registered once)
builder.Services.AddRazorPages();

builder.Services.AddSignalR();

builder.Services.AddServerSideBlazor();

// --- 2. APPLICATION PIPELINE (app.Use...) ---

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// UseStaticFiles must be called before UseRouting/UseAuthentication
app.UseStaticFiles(); 

app.UseRouting();

// **CRITICAL: You must include UseAuthentication() BEFORE UseAuthorization()**
app.UseAuthentication(); 
app.UseAuthorization();

// --- 3. ENDPOINT MAPPING (app.Map...) ---

// Map the Identity UI pages and other Razor Pages
app.MapRazorPages(); 

// Note: MapStaticAssets and MapBlazorHub are often needed if this is a Blazor app
app.MapBlazorHub(); // If using Blazor Server/WebAssembly

app.Run();

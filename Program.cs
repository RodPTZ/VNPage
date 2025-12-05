using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VNpage.Data;
using VNpage.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                      ?? "Data Source=VNpage.db";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

// Identity con Roles y EF stores
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    // Opciones de contraseña (ajustá si querés mayor seguridad)
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddRazorPages();

var app = builder.Build();

// Seed inicial: rol Admin + usuario admin
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    // Crear rol Admin si no existe
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    // Buscar por USERNAME
    var adminUser = await userManager.FindByNameAsync("admin");

    if (adminUser == null)
    {
        var user = new ApplicationUser
        {
            UserName = "admin",
            Email = "admin@vnpage.local",
            EmailConfirmed = true
        };

        // Obligamos una política simple
        var result = await userManager.CreateAsync(user, "Admin123!");

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "Admin");
            Console.WriteLine(">> ADMIN CREADO: usuario: admin / clave: Admin123!");
        }
        else
        {
            Console.WriteLine("ERROR AL CREAR ADMIN:");
            foreach (var e in result.Errors)
                Console.WriteLine(" - " + e.Description);
        }
    }
}


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.Run();

﻿using System.Runtime.InteropServices;
using LS.Store.Domain.Constants;
using LS.Store.Domain.Entities;
using LS.Store.Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LS.Store.Infrastructure.Data;
public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole(Roles.Administrator);

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }
        }

        // Default data
        if (!_context.TodoLists.Any())
        {
            _context.TodoLists.Add(new TodoList
            {
                Title = "Todo List",
                Items =
                {
                    new TodoItem { Title = "Make a todo list 📃" },
                    new TodoItem { Title = "Check off the first item ✅" },
                    new TodoItem { Title = "Realise you've already done two things on the list! 🤯"},
                    new TodoItem { Title = "Reward yourself with a nice, long nap 🏆" },
                }
            });

            await _context.SaveChangesAsync();
        }

        if (!_context.Categories.Any())
        {

            _context.Categories.AddRange(new List<Category>
            {
               new() { Name = "Body" },
               new() { Name = "Lenses" },
               new() { Name = "Lights" },
               new() { Name = "Stabilizers" },

            });

            await _context.SaveChangesAsync();
        }

        if (!_context.Products.Any())
        {
            //initialise products
            _context.Products.AddRange(new List<Product>
            {
                Product.ProductBuilder("B001", "Body 1", "Body 1", 1000, 1, 10),
                Product.ProductBuilder("B002", "Body 2", "Body 2", 2000, 1, 10),
                Product.ProductBuilder("B003", "Body 3", "Body 3", 3000, 1, 10),
                Product.ProductBuilder("B004", "Body 4", "Body 4", 4000, 1, 10),
                Product.ProductBuilder("B005", "Body 5", "Body 5", 5000, 1, 10),
                Product.ProductBuilder("B006", "Body 6", "Body 6", 6000, 1, 10),
                Product.ProductBuilder("B007", "Body 7", "Body 7", 7000, 1, 10),
                Product.ProductBuilder("B008", "Body 8", "Body 8", 8000, 1, 10),
                Product.ProductBuilder("B009", "Body 9", "Body 9", 9000, 1, 10),
                Product.ProductBuilder("B010", "Body 10", "Body 10", 10000, 1, 10),
                Product.ProductBuilder("B011", "Body 11", "Body 11", 11000, 1, 10),
                Product.ProductBuilder("B012", "Body 12", "Body 12", 12000, 1, 10),
                Product.ProductBuilder("B013", "Body 13", "Body 13", 13000, 1, 10),
                Product.ProductBuilder("B014", "Body 14", "Body 14", 14000, 1, 10),
                Product.ProductBuilder("B015", "Body 15", "Body 15", 15000, 1, 10),
                Product.ProductBuilder("B016", "Body 16", "Body 16", 16000, 1, 10),
                Product.ProductBuilder("B017", "Body 17", "Body 17", 17000, 1, 10)
            });
        }
    }
}

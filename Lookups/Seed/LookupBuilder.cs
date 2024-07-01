using FinancialRevenues.DbContexts;
using Microsoft.EntityFrameworkCore;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Identity;

namespace FinancialRevenues.Lookups.Seed;

public class LookupBuilder
{
    private const string BaseResourcePath = "FinancialRevenues.Lookups.CSVs.";

    public static async Task InitializeAsync(FinancialRevenuesDbContext context)
    {
        await context.Database.MigrateAsync();
        await SeedGovernorateAsync(context);
        await SeedRolesAsync(context);
    }

    private static async Task SeedGovernorateAsync(FinancialRevenuesDbContext context)
    {

        if (!context.Governorates.Any())
        {
            var governorates = ReadGovernoratesFromCsv();
            await context.Governorates.AddRangeAsync(governorates);
            await context.SaveChangesAsync();
        }
    }

    private static List<Governorate> ReadGovernoratesFromCsv()
    {
        List<Governorate> governorates;
        string resourceName = BaseResourcePath + "Governorates.csv";
        Assembly assembly = Assembly.GetExecutingAssembly();
        using (Stream stream = assembly.GetManifestResourceStream(resourceName)!)
        using (StreamReader reader = new StreamReader(stream))
        using (CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csvReader.GetRecords<Governorate>().ToList();
            governorates = records.Select(e => new Governorate
            {
                Id = e.Id,
                NameEn = e.NameEn,
                NameAr = e.NameAr,
                IsDeleted = e.IsDeleted
            }).ToList();
        }

        return governorates;
    }
    private static async Task SeedRolesAsync(FinancialRevenuesDbContext context)
    {
        if (!context.Roles.Any())
        {
            string[] roleNames = { "Admin", "Manager", "Member" };
            foreach (var roleName in roleNames)
            {
                await context.Roles.AddAsync(new IdentityRole<int>(roleName));
            }

            await context.SaveChangesAsync();
        }
    }
}
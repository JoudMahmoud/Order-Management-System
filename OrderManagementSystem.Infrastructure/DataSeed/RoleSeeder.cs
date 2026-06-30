using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderManagementSystem.Infrastructure.DataSeed
{
    public class RoleSeeder
    {
        #region Fields 
        private readonly RoleManager<IdentityRole> _roleManager;
        #endregion

        #region Constructor
        public RoleSeeder(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        #endregion

        #region CRUD Operation
        public async Task seedRolesAsync()
        {
            var path = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot", "DataSeed", "Role.json");
            if (!File.Exists(path))
                return;

            var json = await File.ReadAllTextAsync(path);
            var roles =
                JsonSerializer.Deserialize<List<string>>(json);

            if (roles is null)
                return;

            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(
                        new IdentityRole(role));
                }
            }
        }
        #endregion

    }
}

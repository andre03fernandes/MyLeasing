using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MyLeasing.Web.Data.Entities;
using MyLeasing.Web.Helpers;

namespace MyLeasing.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private Random _random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Owner");
            await _userHelper.CheckRoleAsync("Lessee");

            int index = 0;
            var user = await _userHelper.GetUserByEmailAsync("andre2411fernandes@gmail.com");
            if (user == null && !_context.Owners.Any() || !_context.Lessees.Any())
            {
                for(int i= 0; i < 1; i++)
                {
                    user = new User
                    {
                        UserName = "admin@myleasing.pt",
                        Document = _random.Next(10000, 99999),
                        FirstName = "Admin",
                        LastName = "SuperUser",
                        Email = "admin@myleasing.pt",
                        Address = "Rua Admin"
                    };

                    var result = await _userHelper.AddUserAsync(user, "123456");
                    if (result != IdentityResult.Success)
                    {
                        throw new InvalidOperationException("Could not create the user in seeder");
                    }

                    await _userHelper.AddUserToRoleAsync(user, "Admin");

                    var isInRole = await _userHelper.IsUserInRoleAsync(user, "Admin");
                    if (!isInRole)
                    {
                        await _userHelper.AddUserToRoleAsync(user, "Admin");
                    }

                    AddAdmin(user);
                    await _context.SaveChangesAsync();
                }

                for (int i = 0; i < 10; i++)
                {
                    user = new User
                    {
                        UserName = "a" + index + "@gmail.com",
                        Document = _random.Next(10000, 99999),
                        FirstName = "A" + index,
                        LastName = "F" + index,
                        Email = "a" + index + "@gmail.com",
                        Address = "Rua " + index
                    };

                    var result = await _userHelper.AddUserAsync(user, "123456");
                    if (result != IdentityResult.Success)
                    {
                        throw new InvalidOperationException("Could not create the user in seeder");
                    }

                    await _userHelper.AddUserToRoleAsync(user, "Owner");

                    var isInRole = await _userHelper.IsUserInRoleAsync(user, "Owner");
                    if (!isInRole)
                    {
                        await _userHelper.AddUserToRoleAsync(user, "Owner");
                    }

                    AddOwner(user);
                    index++;
                    await _context.SaveChangesAsync();
                }
                for (int i = 0; i < 5; i++)
                {
                    user = new User
                    {
                        UserName = "a" + index + "@gmail.com",
                        Document = _random.Next(10000, 99999),
                        FirstName = "A" + index,
                        LastName = "F" + index,
                        Email = "a" + index + "@gmail.com",
                        Address = "Rua " + index
                    };

                    var result = await _userHelper.AddUserAsync(user, "123456");
                    if (result != IdentityResult.Success)
                    {
                        throw new InvalidOperationException("Could not create the user in seeder");
                    }

                    await _userHelper.AddUserToRoleAsync(user, "Lessee");

                    var isInRole = await _userHelper.IsUserInRoleAsync(user, "Lessee");
                    if (!isInRole)
                    {
                        await _userHelper.AddUserToRoleAsync(user, "Lessee");
                    }

                    AddLessee(user);
                    index++;
                    await _context.SaveChangesAsync();
                }
            }
        }

        private void AddAdmin(User user)
        {
            _context.Admins.Add(new Admin
            {
                Document = Convert.ToInt32(user.Document),
                FirstName = user.FirstName,
                LastName = user.LastName,
                FixedPhone = Convert.ToString(_random.Next(210000000, 219999999)),
                CellPhone = Convert.ToString(_random.Next(930000000, 939999999)),
                Address = user.Address,
                User = user
            });
        }

        private void AddOwner(User user)
        {
            _context.Owners.Add(new Owner
            {
                Document = Convert.ToInt32(user.Document),
                FirstName = user.FirstName,
                LastName = user.LastName,
                FixedPhone = Convert.ToString(_random.Next(210000000, 219999999)),
                CellPhone = Convert.ToString(_random.Next(930000000, 939999999)),
                Address = user.Address,
                User = user
            });
        }

        private void AddLessee(User user)
        {
            _context.Lessees.Add(new Lessee
            {
                Document = Convert.ToInt32(user.Document),
                FirstName = user.FirstName,
                LastName = user.LastName,
                FixedPhone = Convert.ToString(_random.Next(210000000, 219999999)),
                CellPhone = Convert.ToString(_random.Next(930000000, 939999999)),
                Address = user.Address,
                User = user
            });
        }
    }
}
using System;
using System.Linq;
using System.Threading.Tasks;
using MyLeasing.Web.Data.Entities;

namespace MyLeasing.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private Random _random;

        public SeedDb(DataContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.Owners.Any())
            {
                AddOwner("André", "Fernandes", "Rua do Vale Formoso de Cima");
                AddOwner("José", "Carlos", "Rua do Alecrim");
                AddOwner("Diogo", "Monteiro", "Rua da liberdade");
                AddOwner("Ricardo", "Lopes", "Rua de vila de baixo 112");
                AddOwner("Pedro", "Guerreiro", "Avenidade 25 de Abril");
                AddOwner("Hugo", "Reis", "Rua de Angola");
                AddOwner("Fernando", "Pessoa", "Estrada do Azeite 12");
                AddOwner("Cristina", "Mendes", "Avenidade de Coimbra");
                AddOwner("Filipe", "Ferreira", "Rua do montijo 13");
                AddOwner("Fernanda", "Correia", "Rua de cima 34");
                await _context.SaveChangesAsync();
            }
        }

        private void AddOwner(string firstName, string lastName, string address)
        {
            _context.Owners.Add(new Owner
            {
                Document = _random.Next(10000, 99999),
                FirstName = firstName,
                LastName = lastName,
                FixedPhone = Convert.ToString(_random.Next(210000000, 219999999)),
                CellPhone = Convert.ToString(_random.Next(930000000, 939999999)),
                Address = address
            });
        }
    }
}
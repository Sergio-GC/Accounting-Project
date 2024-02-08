using EF_DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Accounting_EF_Base
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Load configuration from appsettings file
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            // Dependency injection
            var serviceProvider = new ServiceCollection()
                .AddSingleton(config)
                .AddScoped<AccountingContext>()
                .AddDbContext<AccountingContext>(options => options.UseMySQL(config.GetConnectionString("DefaultConnection")))
                .BuildServiceProvider();

            // Launch app
            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                // Get the accounting context using dependency injection
                AccountingContext accountingContext = scope.ServiceProvider.GetRequiredService<AccountingContext>();

                if (accountingContext.Database.EnsureCreated())
                {
                    Console.WriteLine("Database has been crated");
                    _InitDB(accountingContext);
                }
                else
                {
                    Console.WriteLine("Database exists already");
                }
            }
        }

        /// <summary>
        /// Demo method to write test data to database in order to have something to work with during development
        /// </summary>
        /// <param name="ctx">Accounting context to manage databse using entity framework</param>
        private static void _InitDB(AccountingContext ctx)
        {
            Console.WriteLine("Creating demo data...");

            #region Create Kids
            Kid Leticia = new Kid()
            {
                Name = "Leticia",
                Lastname = "Magallaes",
                Birthdate = new DateTime(2013, 3, 14),
                StartDate = new DateTime(2015, 11, 1)
            };

            Kid Eva = new Kid()
            {
                Name = "Eva",
                Lastname = "Dos Santos",
                Birthdate = new DateTime(2014, 2, 18),
                StartDate = new DateTime(2014, 5, 1)
            };

            Kid Carolina = new Kid()
            {
                Name = "Carolina",
                Lastname = "Magallaes",
                Birthdate = new DateTime(2018, 12, 5),
                StartDate = new DateTime(2019, 3, 15)
            };

            SiblingRelationship sr1 = new SiblingRelationship()
            {
                KidId1 = Carolina.Id,
                Kid1 = Carolina,
                KidId2 = Leticia.Id,
                Kid2 = Leticia
            };

            Carolina.Siblings = new List<SiblingRelationship>() { sr1 };

            SiblingRelationship sr2 = new SiblingRelationship()
            {
                KidId1 = Leticia.Id,
                Kid1 = Leticia,
                KidId2 = Carolina.Id,
                Kid2 = Carolina
            };

            Leticia.Siblings = new List<SiblingRelationship>() { sr2 };

            // Add the kids
            ctx.Kids.Add(Leticia);
            ctx.Kids.Add(Eva);
            ctx.Kids.Add(Carolina);

            ctx.Siblings.Add(sr1);
            ctx.Siblings.Add(sr2);
            #endregion

            #region Create Prices
            Price normalPrice = new Price()
            {
                Amount = 5.0,
                Label = "Normal price",
                StartDate = new DateTime(2014, 1, 1)
            };

            Price lowPrice = new Price()
            {
                Amount = 4.5,
                Label = "Family reducted",
                StartDate = new DateTime(2015, 11, 1),
                EndDate = new DateTime(2018, 12, 31)
            };

            // Add the prices
            ctx.Prices.Add(normalPrice);
            ctx.Prices.Add(lowPrice);
            #endregion

            #region Create Entries
            ctx.CalendarEntries.Add(new CalendarEntry()
            {
                Kid = Eva,
                Price = normalPrice,
                Date = new DateTime(2016, 3, 1),
                Data = "jsonData demo"
            });

            ctx.CalendarEntries.Add(new CalendarEntry()
            {
                Kid = Leticia,
                Price = lowPrice,
                Date = new DateTime(2020, 5, 10),
                Data = "jsonData demo"
            });
            #endregion

            ctx.SaveChanges();
            Console.WriteLine("Demo data created.");
        }
    }
}
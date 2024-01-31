using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rowery.Data;
using System;
using System.Linq;

namespace Rowery.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RoweryContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RoweryContext>>()))
            {
                // Look for any movies.
                if (context.Rower.Any())
                {
                    return;   // DB has been seeded
                }
                context.Rower.AddRange(
                    new Rower
                    {
                        Name = "Skladak",
                        Price= 20,
                        url_img= "https://lh6.googleusercontent.com/proxy/NW4GNQfGz5Is1BRqojG-EN6HgegHnpzNaxxxiW-jDZlaHtYjfuF289Bksp0IzzQVPRJyT3SnW-pCXzfEEDbDU2TXSK7-S5dSuf3Gmxy5OOiyNMglbw6Y",
                        brand="Uniwersal",
                        IsAvailable=true,
                        Weight=7,
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        RentDate= DateTime.Parse("1999-12-30"),
                        ReturnDate= DateTime.Parse("1999-12-30")
                    },
                    new Rower
                    {
                        Name = "BMX",
                        Price = 100,
                        url_img = "https://www.greenbike.pl/images/mini/500px_Mongoose-Legion-L40-purpurowy-Rower-mlodziezowy-BMX-000.jpg",
                        brand = "Legion",
                        Weight = 5,
                        ReleaseDate = DateTime.Parse("2012-4-12"),
                        IsAvailable = true,
                        RentDate = DateTime.Parse("1999-12-30"),
                        ReturnDate = DateTime.Parse("1999-12-30")
                    },
                    new Rower
                    {
                        Name = "Romet 3000",
                        Price = 200,
                        url_img = "https://erharowery.pl/wp-content/uploads/2022/05/Rower-gorski-MTB-Romet-Rambler-R9.2-29-bialo-grafitowo-turkusowy.jpg",
                        brand = "Romet",
                        Weight = 7,
                        IsAvailable = true,
                        ReleaseDate = DateTime.Parse("2006-7-12"),
                        RentDate = DateTime.Parse("1999-12-30"),
                        ReturnDate = DateTime.Parse("1999-12-30")
                    },
                    new Rower
                    {
                        Name = "Capriolo kids",
                        Price = 200,
                        url_img = "https://a.allegroimg.com/original/1132bf/49040fe64883979bea1387390577/ROWER-DZIECIECY-MUSTANG-16-CAPRIOLO",
                        brand = "Capriolo",
                        Weight = 2,
                        IsAvailable = true,
                        ReleaseDate = DateTime.Parse("2012-10-6"),
                        RentDate = DateTime.Parse("1999-12-30"),
                        ReturnDate = DateTime.Parse("1999-12-30")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using De_Kast.Models;

namespace De_Kast.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Cursussen.Any())
            {
                return;
            }

            if (context.Personeel.Any())
            {
                return;
            }

            if (context.Abonnementen.Any())
            {
                return;
            }

            var cursussen = new Cursus[]
            {
                new Cursus{Naam="Yoga",Dag="Maandag",BeginTijd=new TimeSpan(13,30,0),EindTijd=new TimeSpan(14,30,0)},
                new Cursus{Naam="Pilates",Dag="Woensdag",BeginTijd=new TimeSpan(14,00,0),EindTijd=new TimeSpan(15,00,0)},
                new Cursus{Naam="Paaldansen",Dag="Vrijdag",BeginTijd=new TimeSpan(13,00,0),EindTijd=new TimeSpan(14,30,0)}
            };

            var personeel = new Personeelslid[]
            {
                new Personeelslid{Voornaam="Johan",Achternaam="Van Der Wal",Functie="Personnal Coach",Telefoonnummer=8943501}
            };

            var abonnementen = new Abonnement[]
            {
                new Abonnement{Type="1x per week",Prijs=5.99,Aangeschaft=false},
                new Abonnement{Type="2x per week",Prijs=9.99,Aangeschaft=false},
                new Abonnement{Type="Onbeperkt",Prijs=14.99,Aangeschaft=false},
                new Abonnement{Type="Addendum",Prijs=17.99,Aangeschaft=false}
            };

            context.Cursussen.AddRange(cursussen);
            context.Personeel.AddRange(personeel);
            context.Abonnementen.AddRange(abonnementen);
            context.SaveChanges();
        }
    }
}

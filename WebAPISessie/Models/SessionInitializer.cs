using System.Data.Entity;

namespace WebAPISessie.Models
{
    internal class SessionInitializer : DropCreateDatabaseAlways<SessionDataAcces>
    {
        protected override void Seed(SessionDataAcces context)
        {
            base.Seed(context);
            Sessie s1 = new Sessie("Ungular");
            context.Sessies.Add(s1);
            Sessie s2 = new Sessie("Phonegap");
            context.Sessies.Add(s2);
            Sessie s3 = new Sessie("Ionic");
            context.Sessies.Add(s3);
            Sessie s4 = new Sessie("JQuery Mobile");
            context.Sessies.Add(s4);
            Sessie s5 = new Sessie("Materialize");
            context.Sessies.Add(s5);

            context.SaveChanges();

        }
    }
}
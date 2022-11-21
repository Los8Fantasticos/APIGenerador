using APIGenerador.Clases;

using Bogus;

using Dapper;

using System.Data;
using System.Data.SqlClient;

namespace APIGenerador.Business
{
    public class BusinessLogic
    {

        public void Logic()
        {
            var lista = new List<string>();
            lista = GetPatentes();

            var telepeaje1 = new TelePeaje1();
            var telepeaje2 = new TelePeaje2();
            var telepeaje3 = new TelePeaje3();
            var telepeaje4 = new TelePeaje4();

            var vehiculo = new Vehiculo();

            vehiculo.Attach(telepeaje1);
            vehiculo.Attach(telepeaje2);
            vehiculo.Attach(telepeaje3);
            vehiculo.Attach(telepeaje4);

            foreach (var patente in lista)
            {
                vehiculo.Cliente = new Random().Next(1, 5);
                Console.WriteLine($"Vehiculo detectado en telepeaje: {vehiculo.Cliente}");

                //get random Patente from database
                vehiculo.Patente = patente;
                Console.WriteLine($"Patente detectada: {vehiculo.Patente}");

                vehiculo.Notify();
                //sleep for 1 second
                Thread.Sleep(2000);
            }

            vehiculo.Dispose();


        }
        
        private List<string> GeneratePatentesRandom()
        {
            var patenteNoReconocida = new Faker<PatenteModel>()
                       .RuleFor(a => a.Patente, new Func<Faker, PatenteModel, string>((f, a) =>
                       {
                           int tipoPatente = new Random().Next(1, 5);
                           if (tipoPatente == 1)
                               return (f.Random.String2(3, 3, "ABCDEFGHIJKLMNOPQRSTUVWXYZ") + " " + f.Random.String2(3, 3, "0123456789")).Trim();
                           else if (tipoPatente == 3)
                               return (f.Random.String2(3, 3, "ABCDEFGHIJKLMNOPQRSTUVWXYZ") + f.Random.String2(3, 3, "0123456789")).Trim();
                           else
                               return (f.Random.String2(2, 2, "ABCDEFGHIJKLMNOPQRSTUVWXYZ") + " " + f.Random.String2(3, 3, "0123456789") + " " + f.Random.String2(2, 2, "ABCDEFGHIJKLMNOPQRSTUVWXYZ")).Trim();
                       }))
                       .Generate(25);
            return patenteNoReconocida.Select(x => x.Patente).ToList();
        }
        
        private List<string> GetPatentesReconocidas()
        {
            var patenteReconocida = new List<string>();
            using (IDbConnection db = new SqlConnection("Data Source=localhost;Initial Catalog=Sistema_Peaje_Reconocimiento;User ID=testUser2;Password=1234;Current Language=Spanish;MultipleActiveResultSets=True;"))
            {
                patenteReconocida = db.Query<string>("SELECT Patente FROM Patente").ToList();
            }
            
            return patenteReconocida;
        }
        
        private List<string> GetPatentes()
        {
            var patente = new List<string>();
            var listaPatentesNoReconocida = GeneratePatentesRandom();
            var listaReconocida = GetPatentesReconocidas();
            
            //merge listaPatentesNoReconocida with listaReconocida
            patente.AddRange(listaPatentesNoReconocida);
            patente.AddRange(listaReconocida);

            //randomize patente list
            var random = new Random();
            var randomizedPatente = patente.OrderBy(x => random.Next()).ToList();           
            
            return randomizedPatente;
        }
    }
}

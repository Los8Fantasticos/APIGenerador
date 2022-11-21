using APIGenerador.Interfaces;

using Common.Messages.Client;

namespace APIGenerador.Clases
{
    public class TelePeaje2 : IObserver
    {
        Client telePeaje2 = new Client("127.0.0.1", 5000);
        ClientRequestNumMessage requestMessage = new ClientRequestNumMessage();

        public void Dispose()
        {
            telePeaje2.Dispose();
        }

        public void Update(Vehiculo vehiculo)
        {
            if (vehiculo == null)
                return;
            if (vehiculo.Cliente == 2)
            {
                requestMessage.Message = vehiculo.Patente;
                telePeaje2.Send(requestMessage);
            }

        }
    }
}

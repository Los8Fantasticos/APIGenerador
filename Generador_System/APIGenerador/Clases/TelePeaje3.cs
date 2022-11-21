using APIGenerador.Interfaces;

using Common.Messages.Client;

namespace APIGenerador.Clases
{
    public class TelePeaje3 : IObserver
    {
        Client telePeaje3 = new Client("127.0.0.1", 5000);
        ClientRequestNumMessage requestMessage = new ClientRequestNumMessage();

        public void Dispose()
        {
            telePeaje3.Dispose();
        }

        public void Update(Vehiculo vehiculo)
        {
            if (vehiculo == null)
                return;
            if (vehiculo.Cliente == 3)
            {
                requestMessage.Message = vehiculo.Patente;
                telePeaje3.Send(requestMessage);
            }

        }
    }
}

using APIGenerador.Interfaces;

using Common.Messages.Client;

namespace APIGenerador.Clases
{
    public class TelePeaje4 : IObserver
    {
        Client telePeaje4 = new Client("127.0.0.1", 5000);
        ClientRequestNumMessage requestMessage = new ClientRequestNumMessage();

        public void Dispose()
        {
            telePeaje4.Dispose();
        }

        public void Update(Vehiculo vehiculo)
        {
            if (vehiculo == null)
                return;
            if (vehiculo.Cliente == 4)
            {
                requestMessage.Message = vehiculo.Patente;
                telePeaje4.Send(requestMessage);
            }

        }
    }
}

using APIGenerador.Interfaces;

using Common.Messages.Client;

namespace APIGenerador.Clases
{
    public class TelePeaje1 : IObserver
    {
        Client telePeaje1 = new Client("localhost", 5000);
        ClientRequestNumMessage requestMessage = new ClientRequestNumMessage();

        public void Dispose()
        {
            telePeaje1.Dispose();
        }

        public void Update(Vehiculo vehiculo)
        {
            if (vehiculo == null)
                return;
            if (vehiculo.Cliente == 1)
            {
                requestMessage.Message = vehiculo.Patente;
                telePeaje1.Send(requestMessage);
            }
                
        }
    }
}

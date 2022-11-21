using APIGenerador.Interfaces;

namespace APIGenerador.Clases
{
    public class Vehiculo : ISubject
    {
        public int Cliente { get; set; }
        public string Patente { get; set; }

        private List<IObserver> _observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            Console.WriteLine($"Subject: Cliente {observer} ha sido añadido.");
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
            Console.WriteLine($"Subject: Cliente {observer} ha sido removido.");
        }

        public void Notify()
        {
            Console.WriteLine("Subject: Notificando a los observadores...");

            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public void Dispose()
        {
            Console.WriteLine("Cerrando conexiones...");
            foreach (var observer in _observers)
            {
                Console.WriteLine($"Disconnecting {observer}...");
                observer.Dispose();
            }
        }
    }
}

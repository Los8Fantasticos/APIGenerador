using APIGenerador.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIGenerador.Interfaces
{
    public interface IObserver
    {
        void Update(Vehiculo vehiculo);
        void Dispose();
    }
}

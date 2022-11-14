using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public interface IServicioE<Tipo>
    {
        List<Tipo> Mostrar();
    }
}

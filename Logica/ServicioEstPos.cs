using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
namespace Logica
{
    public class ServicioEstPos : IServicioE<EstudiantePos>
    {
        readonly List<EstudiantePos> ListaPos;
        readonly List<double> listaProm;
        readonly Datos.Postgrado miruta1 = new Datos.Postgrado();
        public ServicioEstPos()
        {
            ListaPos = new List<EstudiantePos>();
            listaProm = new List<double>();
        }
        public List<EstudiantePos> Mostrar()
        {
            foreach (var item in miruta1.Leer())
            {
                if (item.TipoEstudiante == "POST")
                {
                    ListaPos.Add(item);
                }
            }
            return ListaPos;
        }
        public bool Seguir(char continuar)
        {
            if (continuar == 's' || continuar == 'S')
            {
                foreach (var item in miruta1.Leer())
                {
                    ListaPos.RemoveAll(x => item.TipoEstudiante == "POST");
                }
                return true;
            }
            else
            {
                return false;
            }

        }
        public double promedioPosGrado(string name)
        {
            double suma = 0;
            double promedio = 0;
            int contador = 0;
            foreach (var item in miruta1.Leer())
            {
                if (item.ProgramaPosgrado == name)
                {
                    suma += item.PromedioSemestre;
                    contador++;
                    promedio = suma / contador;
                }
            }
            return promedio;
        }
        double mayorProm;
        EstudiantePos estudiantePos = new EstudiantePos();
        public EstudiantePos MayorPromedio(string name)
        {
            foreach (var item in miruta1.Leer())
            {
                if (item.ProgramaPosgrado == name)
                {
                    listaProm.Add(item.PromedioSemestre);
                    mayorProm = listaProm.Max();
                    if (item.PromedioSemestre == mayorProm)
                    {
                        estudiantePos = item;
                        return estudiantePos;
                    }
                }
            }
            return null;
        }
    }
}

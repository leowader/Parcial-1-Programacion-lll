using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
namespace Logica
{
    public class ServicioEstPre : IServicioE<EstudiantePre>
    {
        readonly List<EstudiantePre> ListaPre;//lista pregrados
        readonly List<double> listaProm;
        readonly List<double> listasuma;//lista que guarda la suma del primer corte,2do y tercero
        double suma = 0;
        double sumaTotal = 0;
        double promedioGeneral = 0;
        readonly Datos.Pregrado miruta = new Datos.Pregrado();
        public ServicioEstPre()
        {
            ListaPre = new List<EstudiantePre>();
            listasuma = new List<double>();
            listaProm = new List<double>();
        }
        public List<EstudiantePre> Mostrar()
        {
            foreach (var item in miruta.Leer())
            {
                if (item.TipoEstudiante == "PRE")
                {
                    ListaPre.Add(item);
                }
            }
            return ListaPre;
        }
        public bool Seguir(char continuar)
        {
            if (continuar == 's' || continuar == 'S')
            {
                foreach (var item in miruta.Leer())
                {
                    ListaPre.RemoveAll(x => item.TipoEstudiante == "PRE");
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public double PromedioPre(string name)
        {
            double suma1 = 0;
            double suma2 = 0;
            foreach (var item in miruta.Leer())
            {
                if (item.ProgramaPregrado == name)
                {
                    suma += item.PromedioCorte1;
                    listasuma.Add(suma);
                    suma1 += item.PromedioCorte2;
                    listasuma.Add(suma1);
                    suma2 += item.PromedioCorte3;
                    listasuma.Add(suma2);
                    sumaTotal = suma + suma1 + suma2;
                    promedioGeneral = sumaTotal / listasuma.Count();
                }
            }
            return promedioGeneral;
        }
        //bool confirmar;
        //public bool ConfirmarPrograma(string nombre)
        //{
        //    try
        //    {
        //        foreach (var item in miruta.Leer())
        //        {

        //            if (item.ProgramaPregrado.Equals(nombre))
        //            {
        //                confirmar = true;
        //                return confirmar;
        //            }
        //            else
        //            {
        //                confirmar = false;
        //            }
        //        }

        //    }
        //    catch (NullReferenceException Ne)
        //    {

        //        Console.WriteLine(Ne.Message);
        //    }
        //    return confirmar ;
        //}
        Entidad.EstudiantePre estudiantePre = new EstudiantePre();
        public EstudiantePre MayorPromedio(string name)
        {
            double promedio;
            double mayorProm;
            foreach (var item in miruta.Leer())
            {
                if (item.ProgramaPregrado == name)
                {
                    double suma = item.PromedioCorte1 + item.PromedioCorte2 + item.PromedioCorte3;
                    promedio = suma / 3;
                    listaProm.Add(promedio);
                    mayorProm = listaProm.Max();
                    if (promedio == mayorProm)
                    {
                        estudiantePre = item;
                    }
                }
            }
            return estudiantePre;
        }
        public double PromDestacado(EstudiantePre estudiantePre)
        {
            double suma = estudiantePre.PromedioCorte1 + estudiantePre.PromedioCorte2 + estudiantePre.PromedioCorte3;
            double promedio = suma / 3;
            return promedio;
        }
    }
}

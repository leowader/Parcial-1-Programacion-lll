using Entidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Datos
{
    public class Postgrado : Archivos
    {
        public List<EstudiantePos> Leer()
        {
            StreamReader srPos = new StreamReader(ruta);
            List<Entidad.EstudiantePos> listaEstudiantesPos = new List<EstudiantePos>();
            try
            {
                while (!srPos.EndOfStream)
                {
                    listaEstudiantesPos.Add(Mappear(srPos.ReadLine()));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            srPos.Close();
            return listaEstudiantesPos;
        }
        public Entidad.EstudiantePos Mappear(string linea)
        {
            var estudiantePos = new Entidad.EstudiantePos();
            estudiantePos.TipoEstudiante = linea.Split(';')[0];
            estudiantePos.NoDocumento = int.Parse(linea.Split(';')[1]);
            estudiantePos.Nombre = (linea.Split(';')[2]);
            estudiantePos.Apellido = (linea.Split(';')[3]);
            estudiantePos.ProgramaPosgrado = (linea.Split(';')[4]);
            estudiantePos.Semestre = (int.Parse(linea.Split(';')[5]));
            estudiantePos.PromedioSemestre = (double.Parse(linea.Split(';')[6]));
            return estudiantePos;
        }
    }
}

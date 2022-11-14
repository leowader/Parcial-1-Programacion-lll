using Entidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Pregrado : Archivos
    {
        public List<EstudiantePre> Leer()
        {
            StreamReader srPre = new StreamReader(ruta);
            List<EstudiantePre> listaEstudiantesPre = new List<EstudiantePre>();
            try
            {
                while (!srPre.EndOfStream)
                {
                    listaEstudiantesPre.Add(Mappear(srPre.ReadLine()));
                }
            }
            catch (System.NullReferenceException Nul)
            {
                Console.WriteLine(Nul);
            }
            catch (System.IO.FileNotFoundException Fe)
            {
                Console.WriteLine(Fe.Message);
            }
            srPre.Close();
            return listaEstudiantesPre;
        }
        public EstudiantePre Mappear(string linea)
        {
            var estudiantePre = new EstudiantePre();
            estudiantePre.TipoEstudiante = linea.Split(';')[0];
            if (estudiantePre.TipoEstudiante == "PRE")
            {
                estudiantePre.NoDocumento = int.Parse(linea.Split(';')[1]);
                estudiantePre.Nombre = linea.Split(';')[2];
                estudiantePre.Apellido = linea.Split(';')[3];
                estudiantePre.ProgramaPregrado = linea.Split(';')[4];
                estudiantePre.Semestre = int.Parse(linea.Split(';')[5]);
                estudiantePre.PromedioCorte1 = double.Parse(linea.Split(';')[6]);
                estudiantePre.PromedioCorte2 = double.Parse(linea.Split(';')[7]);
                estudiantePre.PromedioCorte3 = double.Parse(linea.Split(';')[8]);
            }
            return estudiantePre;
        }
    }
}

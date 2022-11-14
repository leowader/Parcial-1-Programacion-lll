using Entidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Presentacion
{
    public class VistaPos
    {
        readonly Logica.ServicioEstPos milogica = new Logica.ServicioEstPos();
        public void MostrarPos(int a, int lado)
        {
            Console.Clear();
            Console.WriteLine(" --------------------------------------ESTUDIANTES DE POSGRADOS----------------------------------");
            Console.WriteLine("DOCUMENTO               NOMBRES        APELLIDOS                 PROGRAMA                 SEMESTRE        PROMEDIO");
            foreach (var item in milogica.Mostrar())
            {
                Console.SetCursorPosition(lado, a++); Console.Write(item.NoDocumento);
                Console.SetCursorPosition(lado + 20, a - 1); Console.Write(item.Nombre);
                Console.SetCursorPosition(lado + 39, a - 1); Console.Write(item.Apellido);
                Console.SetCursorPosition(lado + 65, a - 1); Console.Write(item.ProgramaPosgrado);
                Console.SetCursorPosition(lado + 93, a - 1); Console.Write(item.Semestre);
                Console.SetCursorPosition(lado + 110, a - 1); Console.WriteLine(item.PromedioSemestre);
            }
            bool est = false;
            while (est == false)
            {
                try
                {
                    Console.WriteLine("PRESIONE LA TECLA (S) PARA SEGUIR");
                    char continuar = char.Parse(Console.ReadLine());
                    bool estado = milogica.Seguir(continuar);
                    if (estado == true)
                    {
                        est = true;
                    }
                }
                catch (System.FormatException Fe)
                {
                    Console.WriteLine(Fe.Message);
                }
            }
        }
        void VerProgramas()
        {
            Console.WriteLine("-------PROGRAMAS REGISTRADOS POSGRADO-------");
            Console.WriteLine("DESARROLLO SOFTWARE,DERECHO ADMINISTRATIVO,AUDITORIA EN SALUD");
        }
        public void DestacadoPos()
        {
            Console.Clear();
            VerProgramas();
            Console.WriteLine("---------------DESTACADOS POSGRADO----------------");
            Console.WriteLine("ESCRIBA EL NOMBRE DEL PROGRAMA: ");
            string name = Console.ReadLine();
            Entidad.EstudiantePos promMayor = milogica.MayorPromedio(name.ToUpper());
            VerDestacado(2, 0, promMayor);
        }
        public void VerDestacado(int a, int lado, EstudiantePos promMayor)
        {
            Console.Clear();
            Console.WriteLine($"-------------INFORMACION DEL ESTUDIAMTE CON MAYOR PROMDEIO {promMayor.ProgramaPosgrado}-------------");
            Console.Write("DOCUMENTO               NOMBRES        APELLIDOS                 PROGRAMA                 SEMESTRE        PROMEDIO");
            Console.SetCursorPosition(lado, a++); Console.Write(promMayor.NoDocumento);
            Console.SetCursorPosition(lado + 20, a - 1); Console.Write(promMayor.Nombre);
            Console.SetCursorPosition(lado + 39, a - 1); Console.Write(promMayor.Apellido);
            Console.SetCursorPosition(lado + 65, a - 1); Console.Write(promMayor.ProgramaPosgrado);
            Console.SetCursorPosition(lado + 93, a - 1); Console.Write(promMayor.Semestre);
            Console.SetCursorPosition(lado + 108, a - 1); Console.WriteLine(promMayor.PromedioSemestre.ToString("N1"));
            Console.Write("\n");
        }
        public void PromedioPos()
        {
            Console.Clear();
            VerProgramas();
            Console.WriteLine("---------------PROMEDIO POR PROGRAMA POSGRADO----------------");
            Console.WriteLine("ESCRIBA EL NOMBRE DEL PROGRAMA ACADEMICO: ");
            string name = Console.ReadLine();
            double prom = milogica.promedioPosGrado(name.ToUpper());
            Console.WriteLine("PROMEDIO " + name.ToUpper() + ": " + prom.ToString("N1"));
        }
    
    }
}

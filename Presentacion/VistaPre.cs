using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
namespace Presentacion
{
    public class VistaPre
    {
        Logica.ServicioEstPre milogica2 = new Logica.ServicioEstPre();
        public void MostrarPre(int a, int lado)
        {
            Console.Clear();
            Console.WriteLine(" -----------------------------------ESTUDIANTES DE PREGRADOS-------------------------------");
            Console.WriteLine("DOCUMENTO               NOMBRES        APELLIDOS                 PROGRAMA      SEMESTRE    NOTA 1   NOTA 2  NOTA 3");
            foreach (var item in milogica2.Mostrar())
            {
                Console.SetCursorPosition(lado, a++); Console.Write(item.NoDocumento);
                Console.SetCursorPosition(lado + 20, a - 1); Console.Write(item.Nombre);
                Console.SetCursorPosition(lado + 39, a - 1); Console.Write(item.Apellido);
                Console.SetCursorPosition(lado + 65, a - 1); Console.Write(item.ProgramaPregrado);
                Console.SetCursorPosition(lado + 82, a - 1); Console.Write(item.Semestre);
                Console.SetCursorPosition(lado + 94, a - 1); Console.Write(item.PromedioCorte1);
                Console.SetCursorPosition(lado + 102, a - 1); Console.Write(item.PromedioCorte2);
                Console.SetCursorPosition(lado + 109, a - 1); Console.WriteLine(item.PromedioCorte3);
            }
            bool est = false;
            while (est == false)
            {
                try
                {
                    Console.WriteLine("PRESIONE LA TECLA (S) PARA SEGUIR");
                    char continuar = char.Parse(Console.ReadLine());
                    bool estado = milogica2.Seguir(continuar);
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
            Console.WriteLine("-------PROGRAMAS REGISTRADOS PREGRADO------");
            Console.WriteLine("SISTEMAS,DERECHO,ENFERMERIA,LICENCIATURA,MUSICA");
        }
        public void promedioPre()
        {
            Console.Clear();
            VerProgramas();
            Console.WriteLine("---------------PROMEDIO POR PROGRAMA PREGRADO----------------");
            Console.WriteLine("ESCRIBA EL NOMBRE DEL PROGRAMA: ");
            string name = Console.ReadLine();
            double prom = milogica2.PromedioPre(name.ToUpper());
            //bool estado = milogica2.ConfirmarPrograma(name.ToUpper());
            //if (estado == false)
            //{
            //    Console.WriteLine("EL PROOGRAMA NO ESTA REGISTRADO");
            //}
            //else
            //{
            //    Console.WriteLine("PROMEDIO " + name.ToUpper() + ": " + prom);
            //}
            Console.WriteLine("PROMEDIO " + name.ToUpper() + ": " + prom.ToString("N2"));
        }
        public void VerDestacado(int a, int lado, EstudiantePre promMayor)
        {
            Console.Clear();
            Console.WriteLine($"-------------INFORMACION DEL ESTUDIAMTE CON MAYOR PROMDEIO {promMayor.ProgramaPregrado}-------------");
            Console.Write("DOCUMENTO               NOMBRES        APELLIDOS             PROGRAMA      SEMESTRE    NOTA 1   NOTA 2  NOTA 3  PROMEDIO");
            Console.SetCursorPosition(lado, a++); Console.Write(promMayor.NoDocumento);
            Console.SetCursorPosition(lado + 20, a - 1); Console.Write(promMayor.Nombre);
            Console.SetCursorPosition(lado + 39, a - 1); Console.Write(promMayor.Apellido);
            Console.SetCursorPosition(lado + 61, a - 1); Console.Write(promMayor.ProgramaPregrado);
            Console.SetCursorPosition(lado + 78, a - 1); Console.Write(promMayor.Semestre);
            Console.SetCursorPosition(lado + 90, a - 1); Console.Write(promMayor.PromedioCorte1);
            Console.SetCursorPosition(lado + 98, a - 1); Console.Write(promMayor.PromedioCorte2);
            Console.SetCursorPosition(lado + 105, a - 1); Console.WriteLine(promMayor.PromedioCorte3);
        }
        public void DestacadoPre()
        {
            Console.Clear();
            VerProgramas();
            Console.WriteLine("---------------DESTACADOS PREGRADO----------------");
            Console.WriteLine("ESCRIBA EL NOMBRE DEL PROGRAMA: ");
            string name = Console.ReadLine();
            Entidad.EstudiantePre promMayor = milogica2.MayorPromedio(name.ToUpper());
            VerDestacado(2, 0, promMayor);
            double PromDestacado = milogica2.PromDestacado(promMayor);
            Console.SetCursorPosition(114, 2); Console.WriteLine(PromDestacado.ToString("N1"));
            Console.Write("\n");
        }
    }
}

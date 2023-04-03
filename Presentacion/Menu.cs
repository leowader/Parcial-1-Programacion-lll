using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    public class Menu
    {
        readonly VistaPos vistaPos = new VistaPos();
        readonly VistaPre vistaPre = new VistaPre();
        public void MenuPrincipal()
        {
            int op;
            do
            {
                Console.Clear();
                Console.WriteLine("---------MENU PRINCIPAL---------");
                Console.WriteLine("1. ESTUDIANTES DE PREGRADO");
                Console.WriteLine("2. ESTUDIANTES DE POSTGRADO");
                Console.WriteLine("3. PROMEDIO POR PROGRAMA");
                Console.WriteLine("4. ESTUDIANTES DESTACADOS");
                Console.WriteLine("5. SALIR");
                Console.WriteLine("ESCOJA UNA OPCION DEL MENU: ");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        vistaPre.MostrarPre(3, 0);
                        break;
                    case 2:
                        vistaPos.MostrarPos(3, 0);
                        break;
                    case 3:
                        MenuProm();
                        break;
                    case 4:
                        MenuDestacados();
                        break;
                    case 5:
                        Environment.Exit(op = 6);
                        break;
                }

            } while (op != 5);
        }
        public void MenuDestacados()
        {
            int op;
            do
            {
                Console.WriteLine("---------MENU DESTACADOS---------");
                Console.WriteLine("1. DESTACADOS POSGRADOS");
                Console.WriteLine("2. DESTACADOS PREGRADOS");
                Console.WriteLine("3. VOLVER");
                Console.WriteLine("ESCOJA UNA OPCION DEL MENU: ");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        vistaPos.DestacadoPos();
                        break;
                    case 2:
                        vistaPre.DestacadoPre();
                        break;
                    case 3:
                        MenuPrincipal();
                        break;
                }
            } while (op != 3);
        }
        public void MenuProm()
        {
            int op;
            do
            {
                Console.WriteLine("---------MENU PROMEDIO---------");
                Console.WriteLine("1. PROMEDIO POSGRADOS");
                Console.WriteLine("2. PROMEDIO PREGRADOS");
                Console.WriteLine("3. VOLVER");
                Console.WriteLine("ESCOJA UNA OPCION DEL MENU: ");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        vistaPos.PromedioPos();
                        break;
                    case 2:
                        vistaPre.promedioPre();
                        break;
                    case 3:
                        MenuPrincipal();
                        break;
                }
            } while (op != 3);
        }
    }
}

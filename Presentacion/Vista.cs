using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    public class Vista
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(125, 30);
            Menu menu = new Menu();
            menu.MenuPrincipal();
        }
    }
}

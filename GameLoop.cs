using Souls.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souls
{
    internal class GameLoop
    {

        public void Run()
        {
            PseudoRenderer render = new PseudoRenderer();
           
            while (true)
            {
                render.UpdateConsoleBuffer();
               // Console.Clear();
            }
        }


    }
}

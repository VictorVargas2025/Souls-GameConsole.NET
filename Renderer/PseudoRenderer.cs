using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souls.Renderer
{
    internal class PseudoRenderer
    {
        private int _bHeight = 30;
        private int _bWidth = 120;
        public void UpdateConsoleBuffer()
        {
            Console.WindowHeight = _bHeight;
            Console.WindowWidth = _bWidth;
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;

      
            int area = Console.BufferWidth * Console.BufferHeight; 
           
            WorldDefinitions.Instance.ConstructorWorld();
            Thread.Sleep(100000);
        }

        int GetAreaCam()
        {
            return _bHeight * _bWidth;
        }




    }
}

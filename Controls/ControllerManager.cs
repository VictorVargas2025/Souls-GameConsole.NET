using System.Numerics;

namespace Souls.Controls
{
    internal class ControllerManager
    {
        private static ControllerManager _instance;
        public static ControllerManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ControllerManager();
                }
                return _instance;
            }
        }



        ConsoleKey up = ConsoleKey.W;
        ConsoleKey down = ConsoleKey.S;
        ConsoleKey right = ConsoleKey.D;
        ConsoleKey left = ConsoleKey.A;

        ConsoleKey interact = ConsoleKey.E;
        ConsoleKey attack = ConsoleKey.N;


        public Vector2 MoveInput { get; private set; }
        public bool Interact { get; private set; }
        public bool Attack { get; private set; }

        
        public void UpdateControls()
        {
            bool CheckKey(ConsoleKey input)
            {
                if (Console.ReadKey().Key == input)
                {
                    return true;
                }
                return false;
            }
            int CheckKeyInt(ConsoleKey input)
            {
                if (Console.ReadKey().Key == input)
                {
                    return 1;
                }
                return 0;
            }


            int x = CheckKeyInt(right) - CheckKeyInt(left);
            int y = CheckKeyInt(up) - CheckKeyInt(down);

            MoveInput = new Vector2(x, y);
            Interact = CheckKey(interact);
            Attack = CheckKey(attack);

        }





    }
}

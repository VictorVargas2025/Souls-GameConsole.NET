using Souls.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souls
{
    internal class WorldDefinitions
    {
        private static WorldDefinitions _instance;
        public static WorldDefinitions Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new WorldDefinitions();
                }
                return _instance;
            }
        }


        string collX = "=";
        string collY = "|";

        public string ground = ".";
        public string grass = "M";
        public string door = "A";

        int _maxWidth = 15;
        int _maxHeight = 10;

        int _minWidth;
        int _minHeight;

        string Map;

        int idHomeX;
        int idHomeY;

        int idFinalX;
        int idFinalY;

        List<int> idMap = new List<int>();

        bool get = false;
        public void ConstructorWorld()
        {
            void ConstructLimits()
            {
                string line = string.Empty;
                for (int b = 0; b < _maxWidth; b++)
                {
                    line = line + collX;

                }


                string lineHeight = string.Empty;
                for (int i = 0; i < _maxHeight - 2; i++)
                {

                    lineHeight = string.Empty;
                    lineHeight = collY + lineHeight.PadRight(_maxWidth - 2) + collY;
                    line += Environment.NewLine + lineHeight;

                }
                line += Environment.NewLine;
                for (int c = 0; c < _maxWidth; c++)
                {
                    line += collX;
                }
                Console.WriteLine(line);
                Map = line;

            }

            void CounterDebug()
            {

            }
            void GetAreaUtil()
            {
                if (get) return;
                int count = 0;

                for (int i = 0; i < Map.Length; i++)
                {
                    if (Map[i] == ' ')
                    {
                        count++;
                        idMap.Add(i);
                    }

                }
                int cellPerLineUtil = _maxWidth - 2;
                int elimineCellW = 4;
                int padAreaUtilW = _maxWidth - 2 - elimineCellW * 2; // define um padding da borda

                //Count DEBUG

                int countW = 0;
                int countLine = 0;
                for (int b = 0; b < idMap.Count; b++)
                {

                    countW++;
                    if (countW == cellPerLineUtil)
                    {
                        countLine++;
                        Console.WriteLine(idMap[b] + ", ");
                        countW = 0;
                    }
                    else
                        Console.Write(idMap[b] + ", ");

                }
                Console.WriteLine();
                Console.WriteLine("Count: " + count);
                Console.WriteLine("Count Line: " + countLine);





                //Solve cell utils

                int countLineC = 0;
                int countColumnValide = 0;
                int countElimineId = 0;

                bool valideIdCountage = false;


                List<int> outputIds = new List<int>(); //reserva uma nova lista pra area util de celulas
                //uma matriz pra salvar os ids util de uma linha, com tamanho exato do padAreaUtilW OK
                // ^| Da pra usar um valor não fixo porque toda vez que ele da um new ele tá recriando a matriz nesse exato momento

                for (int c = 0; c < idMap.Count; c++)
                {
                    //Se não for contagem valida, suba a contagem dos eliminados
                    if (!valideIdCountage)
                    {
                        countElimineId++;
                    }
                    else
                    {
                        countColumnValide++; //soma a contagem dos validos
                        outputIds.Add(idMap[c]); //adiciona na lista de saida
                    }

                    //Verifica se a contagem dos id elimanados é igual o valor desejado ex: 4
                    if (countElimineId == elimineCellW && !valideIdCountage)
                    {
                        valideIdCountage = true; //assim que alcançou para
                        countElimineId = 0;
                    }
                    else if (countColumnValide == padAreaUtilW && valideIdCountage)
                    {
                        valideIdCountage = false;
                        countColumnValide = 0;
                    }

                    if ((c + 1) % cellPerLineUtil == 0)
                    {
                        countElimineId = 0;
                        valideIdCountage = false;
                       
                    }






                }
                Console.WriteLine("Pad: " + padAreaUtilW);
                Console.WriteLine("VALIDOS: ");
                Console.WriteLine();
                foreach (int bb in outputIds)
                {

                    // Console.Write(bb + ", ");
                }

                int countW2 = 0;
                int countLine2 = 0;
                for (int b = 0; b < outputIds.Count; b++)
                {

                    countW2++;
                    if (countW2 == padAreaUtilW)
                    {
                        countLine2++;
                        Console.WriteLine(outputIds[b] + ", ");
                        countW2 = 0;
                    }
                    else
                        Console.Write(outputIds[b] + ", ");

                }
                Console.WriteLine();
                Console.WriteLine("Count Out: " + outputIds.Count);
                Console.WriteLine("Count Line Out: " + countLine2);

                get = true;
            }

            void GenerateAreaUtil()
            {




            }


            ConstructLimits();
            GetAreaUtil();
        }







    }
}

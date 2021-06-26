using ConsolePong.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePong.Core.Views
{
    class ScoreView : View
    {
        private static int[,,] numbers = new int[10, 5, 4] {
            { 
                { 1, 1, 1, 1 }, 
                { 1, 0, 0, 1 }, 
                { 1, 0, 0, 1 }, 
                { 1, 0, 0, 1 }, 
                { 1, 1, 1, 1 } 
            },
            { 
                { 0 ,0 ,0, 1 }, 
                { 0 ,0 ,0, 1 }, 
                { 0 ,0 ,0, 1 }, 
                { 0 ,0 ,0, 1 }, 
                { 0 ,0 ,0, 1 } 
            },
            { 
                { 1, 1, 1, 1 }, 
                { 0, 0, 0, 1 }, 
                { 1, 1, 1, 1 }, 
                { 1, 0, 0, 0 }, 
                { 1, 1, 1, 1 } 
            },
            { 
                { 1, 1, 1, 1 }, 
                { 0, 0, 0, 1 }, 
                { 1, 1, 1, 1 }, 
                { 0, 0, 0, 1 }, 
                { 1 ,1, 1, 1 } 
            },
            { 
                { 1, 0, 0, 1 }, 
                { 1, 0, 0, 1 }, 
                { 1, 1, 1, 1 }, 
                { 0, 0, 0, 1 }, 
                { 0, 0, 0, 1 } 
            },
            { 
                { 1, 1, 1, 1 }, 
                { 1, 0, 0, 0 }, 
                { 1, 1, 1, 1 }, 
                { 0, 0, 0, 1 }, 
                { 1, 1, 1, 1 } 
            },
            { 
                { 1, 1, 1, 1 }, 
                { 1, 0, 0, 0 }, 
                { 1, 1, 1, 1 }, 
                { 1, 0, 0, 1 }, 
                { 1, 1, 1, 1 } 
            },
            { 
                { 1, 1, 1, 1 }, 
                { 0, 0, 0, 1 }, 
                { 0, 0, 0, 1 },
                { 0, 0, 0, 1 },
                { 0, 0, 0, 1 }
            },
            { 
                { 1, 1, 1, 1 }, 
                { 1, 0, 0, 1 }, 
                { 1, 1, 1, 1 }, 
                { 1, 0, 0, 1 }, 
                { 1, 1, 1, 1 } 
            },
            { 
                { 1, 1, 1, 1 }, 
                { 1, 0, 0, 1 }, 
                { 1, 1, 1, 1 }, 
                { 0, 0, 0, 1 }, 
                { 1, 1, 1, 1 } 
            },
        };

        public static void Display(int x, int score, char scoreChar)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(xOffset + x, i + 1);
                for (int j = 0; j < 4; j++)
                {
                    if (numbers[score, i, j] == 1)
                        Console.Write(scoreChar);
                    else
                        Console.Write(' ');
                }
            }

        }


    }
}

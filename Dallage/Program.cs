using System;
using System.Text;

namespace Dallage
{
    class Program
    {
        const int width = 80;
        static int squareSize = 2;
        //const int height = 24;

        static char[] MakeLine(params object[] args)
        {
            string chaine = String.Concat(args);
            StringBuilder strBuilder = new StringBuilder(width + chaine.Length, width + chaine.Length);
            for (int i = 0; i < width / chaine.Length; i++)
            {
                strBuilder.Append(chaine);
            }
            strBuilder.Append(chaine).Append(chaine, 0, width % chaine.Length);
            return strBuilder.ToString().ToCharArray();
        }

        static void Main(string[] args)
        {
            char leftUpward = '/';
            char leftDownward = '\\';
            char leftAngle = '<';
            char rightAngle = '>';
            char empty = ' ';
            char[] ligne;
            int l = 0;
            bool aPresse = false;

            //while (l < squareSize / 2)
            //{
            //    lignes[l] = MakeLine(
            //        //new string(empty, ((squareSize - 1 - l) * 2 - squareSize)),
            //        new string(empty, squareSize - 2 * (l + 1)),
            //        leftUpward,
            //        new string(empty, l * 4),
            //        leftDownward,
            //        //new string(empty, ((squareSize - 1 - l) * 2 - squareSize))
            //        new string(empty, squareSize - 2 * (l + 1))
            //    );
            //    l++;
            //}

            //if (squareSize % 2 == 1)
            //{
            //    lignes[l] = MakeLine(
            //        leftAngle,
            //        new string(empty, l * 4 - 2),
            //        rightAngle
            //    );
            //    l++;
            //}

            //while (l < squareSize)
            //{
            //    lignes[l] = MakeLine(
            //        new string(empty, (l * 2 - squareSize)),
            //        leftDownward,
            //        new string(empty, (squareSize - l - 1) * 4),
            //        leftUpward,
            //        new string(empty, (l * 2 - squareSize))
            //    );
            //    l++;
            //}

            while (!Console.KeyAvailable || Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Console.Clear();

                for (int j = 0; j < Console.WindowHeight - 1; j++)
                {
                    if (j % squareSize < squareSize / 2)
                    {
                        ligne = MakeLine(
                            //new string(empty, ((squareSize - 1 - l) * 2 - squareSize)),
                            new string(empty, squareSize - 2 * ((j % squareSize) + 1)),
                            leftUpward,
                            new string(empty, (j % squareSize) * 4),
                            leftDownward,
                            //new string(empty, ((squareSize - 1 - l) * 2 - squareSize))
                            new string(empty, squareSize - 2 * ((j % squareSize) + 1))
                        );
                    }
                    else if (squareSize % 2 == 1 && (j % squareSize) == squareSize / 2)
                    {
                        ligne = MakeLine(
                            leftAngle,
                            new string(empty, (j % squareSize) * 4 - 2),
                            rightAngle
                        );
                    }
                    else
                    {
                        ligne = MakeLine(
                            new string(empty, ((j % squareSize) * 2 - squareSize)),
                            leftDownward,
                            new string(empty, (squareSize - (j % squareSize) - 1) * 4),
                            leftUpward,
                            new string(empty, ((j % squareSize) * 2 - squareSize))
                        );
                    }

                    if (width == 80)
                    {
                        Console.Write(ligne, l % ((squareSize - 1) * 2), width);
                    }
                    else
                    {
                        Console.WriteLine(ligne, l % ((squareSize - 1) * 2), width);
                    }
                }

                l++;
                System.Threading.Thread.Sleep(50);
                if (Console.KeyAvailable)
                {
                    if (!aPresse)
                    {
                        switch (Console.ReadKey(true).KeyChar)
                        {
                            case '+':
                                squareSize++;
                                aPresse = true;
                                break;
                            case '-':
                                if (squareSize > 2)
                                {
                                    squareSize--;
                                }
                                aPresse = true;
                                break;
                        }
                    }
                }
                else
                {
                    aPresse = false;
                }
            }
        }
    }
}

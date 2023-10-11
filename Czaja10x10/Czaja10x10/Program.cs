namespace CzajaAlgorytm
{
    internal class Program
    {
        static void WriteOut(char[,] Plansza)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(Plansza[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void GraczRuch(ref char[,] Plansza, ref int GraczX, ref int GraczY, ref int BotX, ref int BotY, int BotStart)
        {
            Console.WriteLine("Gdzie  się poruszyć ? (opcje: lewodół, lewo, lewogóra, góra, prawogóra, prawo, prawodół, dół):");
            string input = Console.ReadLine();

            try
            {
                switch (input)
                {
                    case "lewodół":
                        if (Plansza[GraczX + 1, GraczY - 1] == 'O')
                            BotRuch(ref Plansza, ref BotX, ref BotY, BotStart);

                        if (Plansza[GraczX + 1, GraczY - 1] != 'X')
                        {
                            GraczX += 1;
                            GraczY -= 1;
                            Plansza[GraczX, GraczY] = 'X';
                        }
                        else
                            throw new Exception();
                        break;

                    case "lewo":
                        if (Plansza[GraczX, GraczY - 1] == 'O')
                            BotRuch(ref Plansza, ref BotX, ref BotY, BotStart);

                        if (Plansza[GraczX, GraczY - 1] != 'X')
                        {
                            GraczY -= 1;
                            Plansza[GraczX, GraczY] = 'X';
                        }
                        else
                            throw new Exception();
                        break;

                    case "lewogóra":
                        if (Plansza[GraczX - 1, GraczY - 1] == 'O')
                            BotRuch(ref Plansza, ref BotX, ref BotY, BotStart);

                        if (Plansza[GraczX - 1, GraczY - 1] != 'X')
                        {
                            GraczX -= 1;
                            GraczY -= 1;
                            Plansza[GraczX, GraczY] = 'X';
                        }
                        else
                            throw new Exception();
                        break;

                    case "góra":
                        if (Plansza[GraczX - 1, GraczY] == 'O')
                            BotRuch(ref Plansza, ref BotX, ref BotY, BotStart);

                        if (Plansza[GraczX - 1, GraczY] != 'X')
                        {
                            GraczX -= 1;
                            Plansza[GraczX, GraczY] = 'X';
                        }
                        else
                            throw new Exception();
                        break;
                    case "prawogóra":
                        if (Plansza[GraczX - 1, GraczY + 1] == 'O')
                            BotRuch(ref Plansza, ref BotX, ref BotY, BotStart);

                        if (Plansza[GraczX - 1, GraczY + 1] != 'X')
                        {
                            GraczX -= 1;
                            GraczY += 1;
                            Plansza[GraczX, GraczY] = 'X';
                        }
                        else
                            throw new Exception();
                        break;

                    case "prawo":
                        if (Plansza[GraczX, GraczY + 1] == 'O')
                            BotRuch(ref Plansza, ref BotX, ref BotY, BotStart);

                        if (Plansza[GraczX, GraczY + 1] != 'X')
                        {
                            GraczY += 1;
                            Plansza[GraczX, GraczY] = 'X';
                        }
                        else
                            throw new Exception();
                        break;

                    case "prawodół":
                        if (Plansza[GraczX + 1, GraczY + 1] == 'O')
                            BotRuch(ref Plansza, ref BotX, ref BotY, BotStart);

                        if (Plansza[GraczX + 1, GraczY + 1] != 'X')
                        {
                            GraczX += 1;
                            GraczY += 1;
                            Plansza[GraczX, GraczY] = 'X';
                        }
                        else
                            throw new Exception();
                        break;

                    case "dół":
                        if (Plansza[GraczX + 1, GraczY] == 'O')
                            BotRuch(ref Plansza, ref BotX, ref BotY, BotStart);

                        if (Plansza[GraczX + 1, GraczY] != 'X')
                        {
                            GraczX += 1;
                            Plansza[GraczX, GraczY] = 'X';
                        }
                        else
                            throw new Exception();
                        break;

                    default:
                        throw new Exception();
                }
            }
            catch
            {
                Console.WriteLine("Zła pozycja");
                GraczRuch(ref Plansza, ref GraczX, ref GraczY, ref BotX, ref BotY, BotStart);
            }
        }

        static bool GraczWin(char[,] Plansza)
        {
            for (int i = 0; i < 10; i++)
            {
                if (Plansza[i, 9] == 'X')
                {
                    return true;
                }
            }
            return false;
        }

        static bool BotWin(char[,] Plansza)
        {
            for (int i = 0; i < 10; i++)
            {
                if (Plansza[i, 0] == 'O')
                {
                    return true;
                }
            }
            return false;
        }

        private static void BotRuch(ref char[,] Plansza, ref int BotX, ref int BotY, int BotStart)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (Plansza[i, j] == 'O')
                    {
                        Plansza[i, j] = '#';
                    }
                }
            }
            BotX = BotStart;
            BotY = 9;
            Plansza[BotX, BotY] = 'O';
        }

        static void Main(string[] args)
        {
            char[,] Plansza = new char[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Plansza[i, j] = '#';
                }
            }

            Random random = new Random();
            int GraczStart = random.Next(0, 10);
            int BotX = GraczStart;
            int BotY = 0;
            Plansza[BotX, BotY] = 'X';

            int BotStart = random.Next(0, 10);
            int GraczX = BotStart;
            int GraczY = 9;
            Plansza[GraczX, GraczY] = 'O';

            WriteOut(Plansza);
            while (true)
            {
                GraczRuch(ref Plansza, ref BotX, ref BotY, ref GraczX, ref GraczY, BotStart);
                WriteOut(Plansza);

                if (GraczWin(Plansza))
                {
                    Console.WriteLine("Wygrałeś!");
                    break;
                }
                if (BotWin(Plansza))
                {
                    Console.WriteLine("Przegrałeś");
                    break;
                }
                BotRuch(ref Plansza, ref GraczX, ref GraczY, ref BotX, ref BotY, GraczStart);
            }
        }

        private static void BotRuch(ref char[,] Plansza, ref int BotX, ref int BotY, ref int GraczX, ref int GraczY, int GraczStart)
        {
            if (Plansza[BotX, BotY - 1] == 'X')
                GraczRuch(ref Plansza, ref GraczX, ref GraczY, GraczStart);
            BotY -= 1;
            Plansza[BotX, BotY] = 'O';
        }

        private static void GraczRuch(ref char[,] Plansza, ref int GraczX, ref int GraczY, int GraczStart)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (Plansza[i, j] == 'X')
                    {
                        Plansza[i, j] = '#';
                    }
                }
            }
            GraczX = GraczStart;
            GraczY = 9;
            Plansza[GraczX, GraczY] = 'X';
        }
    }
}
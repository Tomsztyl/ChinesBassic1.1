using System;

namespace ChinesBassic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! Welcome to the Chinese game made by Tomasz Jelito. Have fun!");
            Console.WriteLine();
            CheckMaps checkMaps = new CheckMaps();
            checkMaps.ManageMaps();
        }
    }
    class CheckMaps
    {
        static string[] players =new string[] {"Player Green","Player Red","Player Yellow","Player Blue"};
        static int[] area = new int[4];
        static int quantityPlayer=2;
        static int roleNumberCube;
        static int[] pawnEnd = new int[4];
        public void ManageMaps()
        {
            SelectHowManyPlayerIs();
            ReductConsole();
            CheckPointsPlayer();
            CheckAreaMap();
        }
        public void ShowPlayers()
        {
            Console.WriteLine(players[0] + " is located: " + area[0] + " area " + "and Pawn: " + pawnEnd[0]);
            Console.WriteLine(players[1] + " is located: " + area[1] + " area " + "and Pawn: " + pawnEnd[1]);
            Console.WriteLine(players[2] + " is located: " + area[2] + " area " + "and Pawn: " + pawnEnd[2]);
            Console.WriteLine(players[3] + " is located: " + area[3] + " area " + "and Pawn: " + pawnEnd[3]);
            Console.WriteLine();
        }
        public void SelectHowManyPlayerIs()
        {
            string playersInGame;
            Console.WriteLine("Write how many people play 2 or 4?");
            Console.WriteLine("If you enter incorrectly or do not choose anything, the program will default to 2 players");
            playersInGame=Console.ReadLine();
            if (playersInGame == "2")
            {
                Console.WriteLine("Now play: " + playersInGame+" players");
                quantityPlayer = Int32.Parse(playersInGame);
            }
            else if (playersInGame == "4")
            {
                Console.WriteLine("Now play: " + playersInGame + " players");
                quantityPlayer = Int32.Parse(playersInGame);
            }
            else
            {
                Console.WriteLine("Something is wrong try again");
            }
        }
        public void CubeControl()
        {
            Console.WriteLine();
            Console.WriteLine("If you want RoleCube press Enter");
            ConsoleKeyInfo inputCheck = Console.ReadKey();
            if (inputCheck.Key==ConsoleKey.Enter)    
            {
                roleNumberCube = CubeRole();
                Console.WriteLine();
                Console.WriteLine("Random Point is "+roleNumberCube);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Please press Enter if you want RoleCube");
            }
            
        }
        public int CubeRole()
        {
            Random random = new Random();
            return random.Next(1, 6);
        }
        public void ReductConsole()
        {
            Console.Clear();
            ShowPlayers();
        }
        public void MovePlayer()
        {
            if (quantityPlayer==2)
            {
                
                for(int l=0;l<quantityPlayer;l++)
                {
                    Console.WriteLine("Now started the: " + players[l]);
                    CubeControl();
                    area[l] += roleNumberCube;
                    Console.WriteLine("Hello There is a MenagerChines i add your points: " +area[l]+" press any key");
                    Console.ReadLine();
                    ReductConsole();
                }
            }
            else if (quantityPlayer == 4)
            {
                for (int s = 0; s < quantityPlayer; s++)
                {
                    Console.WriteLine("Now started the: " + players[s]);
                    CubeControl();
                    area[s] += roleNumberCube;
                    Console.WriteLine("Hello There is a MenagerChines i add your points: " + area[s] + " press any key");
                    Console.ReadLine();
                    ReductConsole();
                }
            }
            else
            {
                Console.WriteLine("Something is wrong");
            }
        }
        public void CheckAreaMap()
        {
            if (quantityPlayer==2)
            {
                for(int la =0;la<quantityPlayer; la++)
                {
                    if (area[la]>=40)
                    {
                        area[la] = 0;
                        pawnEnd[la]++;
                        if (pawnEnd[la]==4)
                        {
                            ReductConsole();
                            Console.WriteLine();
                            Console.WriteLine("Winner is : " +players[la] +" because have: " + pawnEnd[la]+" pawn");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                    }
                }
            }
            else if (quantityPlayer==4)
            {
                for (int sa = 0; sa < quantityPlayer; sa++)
                {
                    if (area[sa] >= 40)
                    {
                        area[sa] = 0;
                        pawnEnd[sa]++;
                        if (pawnEnd[sa] == 4)
                        {
                            ReductConsole();
                            Console.WriteLine();
                            Console.WriteLine("Winner is : " + players[sa] + " because have: " + pawnEnd[sa] + " pawn");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Something is wrong");
            }
        }
        public void CheckPointsPlayer()
        {
            for(int lasa=0;lasa<4;lasa++)
            {
                while(area[lasa]<=40&&pawnEnd[lasa]<=3)
                {
                    CheckAreaMap();
                    MovePlayer();
                    CheckAreaIsTheSamePleace();
                }
            }
        }
        public void CheckAreaIsTheSamePleace()
        {
            if (quantityPlayer == 2)
            {
                if (area[0] == area[1])
                {
                    area[0] = 0;
                    Console.WriteLine();
                    Console.WriteLine("You have the same area back to the start");
                }
            } 
            else if (quantityPlayer == 4)
            {
                if (area[0] == area[1] || area[0] == area[2] || area[0] == area[3])
                {
                    area[0] = 0;
                    Console.WriteLine();
                    Console.WriteLine("You have the same area back to the start");
                }
                else if (area[1] == area[2] || area[1] == area[3] || area[1] == area[0])
                {
                    area[1] = 0;
                    Console.WriteLine();
                    Console.WriteLine("You have the same area back to the start");
                }
                else if (area[2] == area[1] || area[2] == area[3]||area[2]==area[0])
                {
                    area[2] = 0;
                    Console.WriteLine();
                    Console.WriteLine("You have the same area back to the start");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Nothing area it is the same pleace");
            }
        }
    }
}

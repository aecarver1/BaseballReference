using System;
using System.IO;
using System.Collections.Generic;
namespace BaseballReference
{
    class Program
    {
static void Main(string[] args)
        {
            
            List<Player> players = new List<Player>();
            LoadPlayers(ref players);

            string choice = GetMenuChoice();
            while(choice != "5")
            {
                Exec(choice,ref players);
                Console.WriteLine("Press Any Key to Continue...");
                Console.ReadKey();
                choice = GetMenuChoice();
            }
            
            
            
        }
        public static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Main Menu:");
            Console.WriteLine("===============================");
            Console.WriteLine("1.   Add a Player");
            Console.WriteLine("2.   List Players");
            Console.WriteLine("3.   Save Players");
            Console.WriteLine("4.   Get Player Stats");
            Console.WriteLine("5.   Quit");
        }
        public static string GetMenuChoice()
        {
            DisplayMenu();
            string choice = Console.ReadLine();
            while(choice != "1" && choice !="2" && choice != "3" && choice != "4" && choice != "5")
            {
                Console.WriteLine("Invalid Selection. Please select 1-3\nPress Any Key to Continue...");
                Console.ReadKey();
                DisplayMenu();
                choice = Console.ReadLine();
            }
            
            return choice;
        }
        public static void Exec(string choice, ref List<Player> list)
        {
            if(choice == "1")
            {
                Add(ref list);
            }
            if(choice == "2")
            {
                ListPlayers(list);
            }
            if(choice == "3")
            {
                Save(list);
            } 
            if(choice == "4")
            {
                Stats(list);
            }
        }
        public static void AddPlayer(ref List<Player> list)
        {
            Console.WriteLine("Name?");
            string n = Console.ReadLine();
            Console.WriteLine("Year?");
            int y = int.Parse(Console.ReadLine());
            Console.WriteLine("Hits?");
            int h = int.Parse(Console.ReadLine());
            list.Add(NewPlayer(n,y,h));
                
        }
        public static Player NewPlayer(string name, int year,int hits)
        {
            Player temp = new Player(name, year,hits);
            return temp;
        }
        public static void LoadPlayers(ref List<Player> list)
        {
            //open
            StreamReader inFile = new StreamReader("players.txt");
            //process
            string dataRow = inFile.ReadLine();
            while(dataRow != null)
            {
                string[] temp = dataRow.Split('#');
                list.Add(NewPlayer(temp[0],int.Parse(temp[1]),int.Parse(temp[2])));  
                dataRow = inFile.ReadLine();
            }
            //close
            inFile.Close();
        }
        public static void SavePlayers(List<Player> list)
        {
            //open
            StreamWriter outFile = new StreamWriter("players.txt");
            //process
            for(int i = 0; i < list.Count;i++)
            {
                outFile.WriteLine(list[i].GetName() + "#" + list[i].GetYear() + "#" + list[i].GetHits());
            }
            //close
            outFile.Close();
        }
        public static void ListPlayers(List<Player> list)
        {
            Console.WriteLine("\nPlayers:");
            Console.WriteLine("===================");
            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine((i+1) + ".\t" + list[i]);
            }
            
        }
        public static void Save(List<Player> list)
        {
            Console.WriteLine("save changes? y/n");
            string saveYesOrNo = Console.ReadLine();
            if(saveYesOrNo == "y")
            {
                SavePlayers(list);
            }
        }
        public static void Add(ref List<Player> list)
        {
            Console.WriteLine("Add a Player? y/n");
            string ans = Console.ReadLine();
            while(ans != "n")
            {
                if(ans == "y")
                {
                    AddPlayer(ref list);
                }
                Console.WriteLine("add a Player? y/n");
                ans = Console.ReadLine();
            }
        }
        public static void Stats(List<Player> list)
        {
            Console.Clear();
            Console.WriteLine("Which Player would you like to reference?");
            ListPlayers(list);
            string who = Console.ReadLine();
            Console.WriteLine("Which Stat would you like to refernce for " + list[int.Parse(who)-1].GetName() + "?");
            ListStats();
            string what = Console.ReadLine();
            GetStats(who,what,list);
            Console.WriteLine("Get Another Stat? y/n");
            string choice = Console.ReadLine();
            if(choice == "y")
            {
                Stats(list);
            }
        }
        public static void ListStats()
        {
            Console.WriteLine("Stats:");
            Console.WriteLine("================");
            Console.WriteLine("1.   Year");
            Console.WriteLine("2.   Hits");
        }
        public static void GetStats(string who, string what, List<Player> list)
        {
            if(what == "1")
            {
                Console.WriteLine(list[int.Parse(who)-1] + "'s Year: " + list[int.Parse(who)-1].GetYear());
            }
            if(what == "2")
            {
                Console.WriteLine(list[int.Parse(who)-1] + "'s Hit Total: " + list[int.Parse(who)-1].GetHits());
            }
        }
    }
}

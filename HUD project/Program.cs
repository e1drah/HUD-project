using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUD_project
{
    internal class Program
    {
        //player stats
        static string playerName;
        static int health;
        static int maxHealth;
        static int sheild;
        static int maxSheild;
        static int lives;
        static int damage;
        static int xp;
        static int xpToNextLevel;
        //monster stats
        static int MonsterHealth;
        static int MonsterDamage;
        static int MonsterSheild;
        static void Main(string[] args)
        {
            //Player starting stats
            health = 100;
            maxHealth = 100;
            sheild = 100;
            maxSheild = 100;
            xpToNextLevel = 1000;
            lives = 3;
            playerName = "AAAAA";

            DebugMenu();
        }
        //Debug menu to test methods
        static void DebugMenu()
        {
            if (playerName == "AAAAA")
            {
                DeterminPlayerName();
            }
            else
            {
                ShowHUD();
                Console.WriteLine("Debug Commands");
                Console.WriteLine("'Take damage'");
                Console.WriteLine("'Heal self'");
                Console.WriteLine("'Restore sheilds'");
                Console.WriteLine("'Gain Experiance'");
                Console.ReadKey();
            }
        }
        //Sets player name
        static void DeterminPlayerName()
        {
            Console.WriteLine("What is your name");
            Console.WriteLine();
            playerName = Console.ReadLine();
            Console.Clear();
            DebugMenu();

        }
        static void Heal(int healAmount)
        {
            health += healAmount;
            if (health > 100)
            {
                health = 100;
            }
        }

        //Shows HUD
        static void ShowHUD()
        {
            Console.WriteLine(playerName + " Health: " + health + @"/" + maxHealth + " Sheild: " + sheild + @"/" + maxSheild + " XP: "+ xp + @"/" + xpToNextLevel);
            Console.WriteLine();
        }
    }
}

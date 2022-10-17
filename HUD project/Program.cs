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
        static string playerName = "PlayerName";
        static int health;
        static int maxHealth;
        static int shield;
        static int maxShield;
        static int lives;
        static int maxLives;
        static int playerDamage;
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
            shield = 100;
            maxShield = 100;
            xpToNextLevel = 1000;
            lives = 3;
            maxLives = 99;
            playerDamage = 10;

            Showcase();
            
        }
        //Debug menu to test methods
        static void DebugMenu()
        {
            Console.Clear();
            if (playerName == "")
            {
                DeterminPlayerName();
            }
            else
            {
                ShowHUD();
                Console.WriteLine("Debug Commands");
                Console.WriteLine("'Take playerDamage' - 1");
                Console.WriteLine("'Heal self' - 2");
                Console.WriteLine("'Restore sheilds' - 3");
                Console.WriteLine("'Gain Experiance' - 4");
                Console.ReadKey();
            }

        }
        static void Showcase()
        {
            //Showcases shield taking Damage
            Console.WriteLine("Showcasing shield taking damage");
            Console.WriteLine();
            Reset();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            ShowHUD();
            TakeDamage(50);
            ShowHUD();
            Console.WriteLine("------------------------------------------------------------------------------------------");

            //Showcases Sheild damage over flowing into health
            Console.WriteLine("Showcasing sheild damage over flowing into health");
            Console.WriteLine();
            Reset();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            ShowHUD();
            TakeDamage(150);
            ShowHUD();
            Console.WriteLine("------------------------------------------------------------------------------------------");

            //Showcases losing a life
            Console.WriteLine("Showcasing losing a life");
            Console.WriteLine();
            Reset();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            ShowHUD();
            TakeDamage(200);
            ShowHUD();
            Console.WriteLine("------------------------------------------------------------------------------------------");

            // Showcasing Player losing all lives
            Console.WriteLine("Showcasing getting a game over");
            Console.WriteLine();
            Reset();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            ShowHUD();
            TakeDamage(200);
            ShowHUD();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            ShowHUD();
            TakeDamage(200);
            ShowHUD();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            ShowHUD();
            TakeDamage(200);
            ShowHUD();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            ShowHUD();
            TakeDamage(200);
            ShowHUD();
            Console.WriteLine("------------------------------------------------------------------------------------------");

            //show caseing shield regeneration
            Console.WriteLine("Showcasing shield regeneration");
            Console.WriteLine();
            Reset();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            ShowHUD();
            TakeDamage(50);
            ShowHUD();
            RegenerateShield(25);
            ShowHUD();
            Console.WriteLine("------------------------------------------------------------------------------------------");

            //Showcase's shield regeneration seperate from health regeneration
            Console.WriteLine("Showcasing shield regenerating seperate from health");
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            ShowHUD();
            TakeDamage(150);
            ShowHUD();
            RegenerateShield(75);
            ShowHUD();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.ReadKey();
        }
        //Sets player name
        static void DeterminPlayerName()
        {
            Console.WriteLine("What is your name");
            Console.WriteLine();
            playerName = Console.ReadLine();
            DebugMenu();

        }
        //heals player
        static void Heal(int healAmount)
        {
            health += healAmount;
            if (health > 100)
            {
                health = 100;
            }
            DebugMenu();
        }
        static void RegenerateShield(int regenerateAmount)
        {
            Console.WriteLine("shield will be regenarated by " + regenerateAmount + " points!");
            if (regenerateAmount > 0)
            {
                shield += regenerateAmount;
                if (shield > maxShield)
                {
                    shield = maxShield;
                }
            }
            else
            {
                Console.WriteLine("Error! " + regenerateAmount + " is not a valid regenaration value! Player can not regenarate negative sheild");
            }
            Console.WriteLine("Player regenarates " + regenerateAmount + " points of shield");
            Console.WriteLine("");
        }
        //damages player
        static void TakeDamage(int damage)
        {
            Console.WriteLine("Player is about to take " + damage + " points of damage!");
            if (damage < 0)
            {
                Console.WriteLine("Error: " + damage + " is not a valid damage value! Player cannot take negative damage!");
            }
            else
            {
                if (shield >= 0)
                {
                    shield -= damage;
                    if (shield < 0)
                    {
                        health -= (shield * -1);
                        shield = 0;
                        if (health <= 0)
                        {
                            health = 0;
                            LoseALife();
                        }
                    }
                }
                Console.WriteLine(playerName + " takes " + damage + " damages");
            }
            Console.WriteLine();
        }
        //Takes away a life if player still has lives
        static void LoseALife()
        {
            if (lives <= 0)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                health = maxHealth;
                shield = maxShield;
                lives -= 1;
            }
        }
        static void Reset()
        {
            Console.WriteLine("Reseting varibles");
            Console.WriteLine();
            health = 100;
            maxHealth = 100;
            shield = 100;
            maxShield = 100;
            xpToNextLevel = 1000;
            lives = 3;
            maxLives = 99;
            playerDamage = 10;
        }
        //Shows HUD
        static void ShowHUD()
        {
            Console.WriteLine(playerName + " Health: " + health + @"/" + maxHealth + " Shield: " + shield + @"/" + maxShield + " Lives: " + lives + " XP: "+ xp + @"/" + xpToNextLevel +" " + playerName + "'s Attack: " + playerDamage);
            Console.WriteLine();
        }

    }
}

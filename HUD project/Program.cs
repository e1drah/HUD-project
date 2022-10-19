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
        static string playerName = "PlayerNameDefault";
        static int health;
        static int maxHealth;
        static int shield;
        static int maxShield;
        static int lives;
        static int maxLives;
        static int playerDamage;
        static int xp;
        static int xpToNextLevel;
        static int lvl;

        static float lvlUpModifier;

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
            xp = 0;
            lvl = 1;
            lvlUpModifier = 1.5f;
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
            Reset();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            ShowHUD();
            TakeDamage(150);
            ShowHUD();
            RegenerateShield(75);
            ShowHUD();
            Console.WriteLine("------------------------------------------------------------------------------------------");

            //Showcase's shield regeneration beyond the max amount
            Console.WriteLine("Showcasing an attempt to regenerate shield beyond the max amount");
            Console.WriteLine();
            Reset();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            ShowHUD();
            TakeDamage(75);
            ShowHUD();
            RegenerateShield(125);
            ShowHUD();
            Console.WriteLine("------------------------------------------------------------------------------------------");

            //Showcase's error when an attempt to regenerate a negitive value
            Console.WriteLine("Showcasing an attempt to regenerate shield by a negitive value");
            Console.WriteLine();
            Reset();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            ShowHUD();
            TakeDamage(75);
            ShowHUD();
            RegenerateShield(-75);
            ShowHUD();
            Console.WriteLine("------------------------------------------------------------------------------------------");

            //showcase's heal method
            Console.WriteLine("Showcasing Heal method");
            Console.WriteLine();
            Reset();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            ShowHUD();
            TakeDamage(175);
            ShowHUD();
            Heal(75);
            ShowHUD();
            Console.WriteLine("------------------------------------------------------------------------------------------");

            //showcase's an attempt to heal over the max amount
            Console.WriteLine("Showcasing 'over heal'");
            Console.WriteLine();
            Reset();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            ShowHUD();
            TakeDamage(175);
            ShowHUD();
            Heal(100);
            ShowHUD();
            Console.WriteLine("------------------------------------------------------------------------------------------");

            //showcase's error message when trying to heal by a negitive value
            Console.WriteLine("Showcasing error message when trying to heal by a negitive value'");
            Console.WriteLine();
            Reset();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            ShowHUD();
            TakeDamage(175);
            ShowHUD();
            Heal(-75);
            ShowHUD();
            Console.WriteLine("------------------------------------------------------------------------------------------");

            //showing XpGain method 
            Console.WriteLine("Showcasing xp gain");
            Console.WriteLine();
            Reset();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            ShowHUD();
            XpGain(500);
            ShowHUD();
            Console.WriteLine("------------------------------------------------------------------------------------------");

            //showcase's error message when trying to gain negitive Xp
            Console.WriteLine("Showcasing error message when trying to gain negitive Xp");
            Console.WriteLine();
            Reset();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            ShowHUD();
            XpGain(-500);
            ShowHUD();
            Console.WriteLine("------------------------------------------------------------------------------------------");

            //showcase's leveling up
            Console.WriteLine("Showcasing leveling up");
            Console.WriteLine();
            Reset();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            ShowHUD();
            XpGain(1000);
            ShowHUD();
            Console.WriteLine("------------------------------------------------------------------------------------------");

            //showcase's 'XP overflow' when leveling up
            Console.WriteLine("Showcasing 'XP overflow' when leveling up");
            Console.WriteLine();
            Reset();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            ShowHUD();
            XpGain(1500);
            ShowHUD();
            Console.WriteLine("------------------------------------------------------------------------------------------");

            //showcase's 'XP overflow' into next Lvl when leveling up
            Console.WriteLine("Showcasing 'XP overflow' into next Lvl when leveling up");
            Console.WriteLine();
            Reset();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            ShowHUD();
            XpGain(2500);
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
            Console.WriteLine("Player is about to be healed by " + healAmount+"!");
            if (healAmount >= 0)
            {
                health += healAmount;

                if (health > 100)
                {
                    health = maxHealth;
                    Console.WriteLine("Player at max health!");
                }
                Console.WriteLine("Player is healed by " + healAmount+"!");
            }
            else
            {
                Console.WriteLine("Error! " + healAmount + " is not a valid heal value! Player cannot be healed by a negitive value!");
            }
            Console.WriteLine();
        }
        //regenerates Shield
        static void RegenerateShield(int regenerateAmount)
        {
            Console.WriteLine("shield will be regenarated by " + regenerateAmount + " points!");
            if (regenerateAmount > 0)
            {
                shield += regenerateAmount;
                if (shield > maxShield)
                {
                    shield = maxShield;
                    Console.WriteLine("Player at max shield");
                }
                Console.WriteLine("Player regenarates " + regenerateAmount + " points of shield");
            }
            else
            {
                Console.WriteLine("Error! " + regenerateAmount + " is not a valid regenaration value! Player can not regenarate negative value");
            }
            Console.WriteLine();
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
        static void XpGain(int xpValue)
        {
            Console.WriteLine("player will reecive " + xpValue + " expariance!");
            if (xpValue > 0)
            {
                Console.WriteLine("Player gains " + xpValue + " expariance");
                xp += xpValue;
                if (xp >= xpToNextLevel)
                {
                    LevelUp(xp);
                }
            }
            else
            {
                Console.WriteLine("Error! " + xpValue + " is not a valid value! Player cannot gain negitive experiance");
            }
            Console.WriteLine();
        }
        static void LevelUp(int xpOverflow)
        {
            int xpToNextLvlOld = xpToNextLevel;
            Console.WriteLine("Player levels up!");

            //

            xpOverflow -= xpToNextLevel;

            maxHealth = (int)Math.Round(maxHealth * lvlUpModifier);
            health = maxHealth;
            maxShield = (int)Math.Round(maxShield * lvlUpModifier);
            shield = maxShield;
            xpToNextLevel = (int)Math.Round(xpToNextLevel * lvlUpModifier);
            playerDamage = (int)Math.Round(playerDamage * lvlUpModifier);
            xp = xpOverflow;
            lvl += 1;

            if (xp >= xpToNextLevel)
            {
                LevelUp(xp);
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
            xp = 0;
            lvl = 1;
        }
        //Shows HUD
        static void ShowHUD()
        {
            Console.WriteLine(playerName +" lvl: " + lvl + " Health: " + health + @"/" + maxHealth + " Shield: " + shield + @"/" + maxShield + " Lives: " + lives + " XP: "+ xp + @"/" + xpToNextLevel + " Attack: " + playerDamage);
            Console.WriteLine();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonCombatSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            DragonCombatSimulator();
            Console.ReadKey();
        }

        static void DragonCombatSimulator()
        {
            //Keep track of HP values and attack count
            int playerHP = 100;
            int dragonHP = 200;
            int attacks = 0;

            //Rng numbers for everything
            Random rng = new Random();
            Console.WriteLine(@"______                             _____                 _           _   
|  _  \                           /  __ \               | |         | |  
| | | |_ __ __ _  __ _  ___  _ __ | /  \/ ___  _ __ ___ | |__   __ _| |_ 
| | | | '__/ _` |/ _` |/ _ \| '_ \| |    / _ \| '_ ` _ \| '_ \ / _` | __|
| |/ /| | | (_| | (_| | (_) | | | | \__/\ (_) | | | | | | |_) | (_| | |_ 
|___/ |_|  \__,_|\__, |\___/|_| |_|\____/\___/|_| |_| |_|_.__/ \__,_|\__|
                  __/ |                                                  
                 |___/                                                   ");
            //Explain the game
            Console.WriteLine("You are here to slay a dragon. You have 3 choices for options.\n 1. Sword (70% hit, 20-35 damage)\n 2. Magic (100% hit, 10-15 damage)\n 3.Heal (Increases hp 10-20)\nPlease enter the action of your choice.\n");

            //Bool for exiting while loop
            bool playing = true;
            while(playing)
            {
                //Get user input each time
                string choiceString = Console.ReadLine();
                int choice = Convert.ToInt32(choiceString);

                //Stop condition for game
                if (playerHP <= 0 || dragonHP <= 0)
                    {
                        if (playerHP <= 0)
                        {
                            Console.WriteLine("You dead, son");
                            playing = false;
                        }
                        else if (dragonHP <= 0)
                        {
                            Console.WriteLine("You have slain the dragon");
                            playing = false;
                        }
                    }
                    else
                    {
                    //If user selects attack 1
                        if (choice == 1)
                        {
                            attacks++;
                            //No global RNG values here, broseph
                            int swordHitChance = rng.Next(1, 101);
                            int swordDmg = rng.Next(20, 36);

                            //30% chance to miss
                            if (swordHitChance < 30)
                            {
                                Console.WriteLine("You missed");
                            }
                            else
                            {
                                //70% of the time, you hit
                                dragonHP = dragonHP - swordDmg;
                                Console.WriteLine("You did " + swordDmg + " damage to the dragon!");
                            }
                        }
                        //Magic attack, 100% hit
                        else if (choice == 2)
                        {
                            attacks++;
                            int hitChance = rng.Next(1, 101);
                            int magicDmg = rng.Next(10, 16);

                            //You hit the dragon for between 10-15 damage
                            dragonHP -= magicDmg;
                            Console.WriteLine("You did " + magicDmg + " damage to the dragon!");
                        }
                        //Heal yourself for 10-20 HP
                        else if (choice == 3)
                        {
                            int healAmt = rng.Next(10, 21);
                            playerHP += healAmt;
                            Console.WriteLine("You healed for " + healAmt + " HP!");
                        }
                        //Incorrect input
                        else
                        {
                            Console.WriteLine("Please enter either 1, 2 or 3");
                        }
                        //Dragon misses 20% of the time
                        int dragDmg = rng.Next(5, 16);
                        int dragHitChance = rng.Next(1, 101);
                        if (dragHitChance < 20)
                        {
                            Console.WriteLine("The dragon barely missed you!");
                        }
                        //Take damage from dragon
                        else
                        {
                            playerHP -= dragDmg;
                            Console.WriteLine("The dragon slaps you in the face for " + dragDmg + " damage!");
                        }
                    }
                Console.WriteLine("Dragon HP: " + dragonHP);
                Console.WriteLine("Player HP: " + playerHP);
                Console.WriteLine("Attacks: " + attacks + "\n");
            }
        }
    }
}

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
            Console.WindowWidth = 110;
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
            Console.WriteLine(@"______                                                   _  ______                                         
|  _  \                                                 | | |  _  \                                        
| | | |_ __ __ _  __ _  ___  _ __  ___    __ _ _ __   __| | | | | |_   _ _ __   __ _  ___  ___  _ __  ___  
| | | | '__/ _` |/ _` |/ _ \| '_ \/ __|  / _` | '_ \ / _` | | | | | | | | '_ \ / _` |/ _ \/ _ \| '_ \/ __| 
| |/ /| | | (_| | (_| | (_) | | | \__ \ | (_| | | | | (_| | | |/ /| |_| | | | | (_| |  __/ (_) | | | \__ \ 
|___/ |_|  \__,_|\__, |\___/|_| |_|___/  \__,_|_| |_|\__,_| |___/  \__,_|_| |_|\__, |\___|\___/|_| |_|___/ 
                  __/ |                                                         __/ |                      
                 |___/                                                         |___/                        ");
            //Explain the game
            Console.WriteLine("DRAGOOOOONNNNN COMBAAAATTTTTT.\n In tihs game, you are a dungeon trying to kill a dragon. You have 3 options for how to fight the dragon.\n 1. Throw brick (70% hit, 20-35 damage)\n 2. Dust attack (100% hit, 10-15 damage)\n 3. Heal (Repair self for 10-20 HP)\nPlease choose an action.\n");

            //Bool for exiting while loop
            bool playing = true;
            while (playing)
            {
                //Get user input each time
                string choiceString = Console.ReadLine();
                int choice = Convert.ToInt32(choiceString);

                //Stop condition for game
                if (playerHP > 0 || dragonHP > 0)
                {
                    //If user selects attack 1
                    if (choice == 1)
                    {
                        attacks++;
                        //No global RNG values here
                        int brickHitChance = rng.Next(1, 101);
                        int brickDmg = rng.Next(20, 36);

                        //30% chance to miss
                        if (brickHitChance <= 30)
                        {
                            Console.WriteLine("You missed! You're a dungeon... Dungeons don't know how to throw bricks!");
                        }
                        else
                        {
                            //70% of the time, you hit
                            dragonHP = dragonHP - brickDmg;
                            Console.WriteLine("You somehow managed to hit the dragon with a brick, damaging it for " + brickDmg + " damage!");
                        }
                    }
                    //Dust attack, 100% hit
                    else if (choice == 2)
                    {
                        attacks++;
                        int dustDmg = rng.Next(10, 16);

                        //You hit the dragon for between 10-15 damage
                        dragonHP -= dustDmg;
                        Console.WriteLine("Your dust cloud did " + dustDmg + " damage to the dragon!");
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
                    if (playerHP <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("You have lost. Dragons are superior to dungeons.");
                        playing = false;
                    }
                    else if (dragonHP <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("DUNGEONS ARE BETTER THAN DRAGONS.");
                        playing = false;
                    }
                }
                Console.WriteLine("Dragon HP: " + dragonHP);
                Console.WriteLine("Player HP: " + playerHP);
                Console.WriteLine("Attacks: " + attacks + "\n");
            }
        }
    }
}

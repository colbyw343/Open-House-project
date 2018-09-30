using System;
using System.Threading;
using System.Collections.Generic;

namespace OpenHouseProject
{
    class Program
    {

                                                        //Typewriter for all text Method
        static void Writer(string message)
        {
            foreach (char letter in message)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(25);
                Console.Write(letter);
            }
            Console.WriteLine();
        }
                                                            //List of all the rooms
        public static List<Rooms> ListAllRooms = new List<Rooms>();
                                                        //List to display all the rooms
        static void listOfRooms()
        {

            for (int i = 0; i < ListAllRooms.Count; i++)
            {
                Writer(ListAllRooms[i].Name);
            }
        }
                                                            //Living Room Line
        static bool LivingRoomLine()
        {
            Writer("You are a bit dissapointed when you find the living room because it's about the size of a child's room,\nif not a little bigger.");
            Console.ReadLine();
            Writer("As you walk into the living room you notice that this is the only room to have carpeting instead of hard-wood floors.");
            Console.ReadLine();
            Writer("There is one couch, a nice loveseat along with a table next to it, and a fireplace.");
            Writer("Above the fireplace is a mantle with several pictures of what you assume to be the owners of this house.");
            Console.ReadLine();
            Writer("Other than the furniture and the fireplace this room seems bland.");
            return true;
        }
                                                            //Kitchen Text Method
        static bool KitchenLine()
        {
            Writer("You and your spouse walk into the kitchen and find a nice cozy area with lots of cabinets.\n" +
                    "Looking at the sink you find that it's dirty, but when you turn it on it operates like normal.");
            Console.ReadLine();
            Writer("You think you see something in the sink, but cant quite see what exactly it is.\nDo you try and get it?");
            Writer("Yes");
            Writer("No");
            string shinyThing = Console.ReadLine();
                                                            //Something in the sink
            if (shinyThing.ToUpper() == "YES" || shinyThing.ToLower() == "yes")
            {
                Console.Clear();
                Writer("You're thinking that it could be something valuable, so you reach into the sink pipe to try and grab the item,\n" +
                    "but you end up getting your hand stuck.");
                Console.ReadLine();
                Writer("The realtor has to call the fire department to get your hand unstuck from the sink, and the homeowners kick you out.");
                Writer("Your day is ruined.");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Writer("Game Over");
                Console.ReadLine();
                Environment.Exit(-1);
            }
            if (shinyThing.ToUpper() == "NO" || shinyThing.ToLower() == "no")
            {
                Console.Clear();
                Writer("You decide that whatever is in that sink belongs to the homeowners, and its their problem.\n You move on.");
            }
            return true;
        }
                                                            //Dining Room Text Method
        static bool DiningLine()
        {
            Writer("You walk into the dining room and are met with a medium sized table with old looking chairs.\n" +
                    " You're tempted to sit in one of the chairs, but it looks unsafe. What do you do?");
            Writer("Sit");
            Writer("Don't sit");
            string sitChair = Console.ReadLine();
                                                            //Sitting in the old chair
            if (sitChair.ToUpper() == "SIT" || sitChair.ToLower() == "sit")
            {
                Writer("You decide to sit in one of the chairs. \nAs you're seated, you lean back in the chair and accidentally fall down.");
                Writer("You hit your head just the right way to make you dizzy, and then to make you unconscious.");
                Console.ReadLine();
                Writer("The realtor had to call the ambulance to take you to the hospital.");
                Console.ReadLine();
                Writer("Needless to say, you left early that day.");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Writer("Game Over");
                Console.ReadLine();
                Environment.Exit(-1);
            }
            if (sitChair.ToUpper() == "Don't Sit" || sitChair.ToLower() == "don't sit" || sitChair.ToUpper() == "Dont Sit" || sitChair.ToLower() == "dont sit")
            {
                Writer("You don't think it's a good idea to sit in these chairs, so if you do buy this house\n you'll buy some new chairs.");
                Console.ReadLine();
            }
            return true;
        }

                                                                //Kid's Bedroom Text Method
        static bool KidRoom()
        {
            Writer("You wonder around and find some stairs leading to the upper portion of the house." +
                        "\nYou walk upstairs and find a child's bedroom." +
                        "\nYou walk inside.");
            Console.ReadLine();
            Writer("You see a smaller bed, a dresser, a small looking closet, a ceiling fan,\nand a window looking out at the " +
                "backyard.");
            Console.ReadLine();
                                                                        //The BB Gun
            Writer("You spot a Red Ryder BB gun in the corner of the room.\n" +
                " You had one when you were a kid, and you want to take a closer look.\n" +
                " Do you pick it up?");
            Writer("Yes");
            Writer("No");

            string bbResponse = Console.ReadLine();
            if (bbResponse.ToUpper() == "YES" || bbResponse.ToLower() == "yes")
            {
                Console.Clear();
                Writer("You pick up the BB gun and start to have flashbacks of your parents telling you that\n you'll shoot your" +
                    " eye out.");
                Console.ReadLine();
                Writer("As you hear the rattling of BB's inside of the gun, you put it up to your shoulder and aim down the\n" +
                    " sight towards the wall.");
                Console.ReadLine();
                Writer("You then accidentally pull the trigger and the gun fires off a BB, \nbounces off the wall, " +
                    "and hits you in the eye.");
                Writer("Your spouse then takes you to the hospital.");
                Writer("Maybe your parents were right, \"Ralphie\".");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Writer("Game Over");
                Console.ReadLine();
                Environment.Exit(-1);
            }
            if (bbResponse.ToUpper() == "NO" || bbResponse.ToLower() == "no")
            {
                Console.Clear();
                Writer("As your remembering your childhood you remember your parents telling you that you could shoot your eye out.\n " +
                    "You think it would be a bad idea to pick it up...just in case you did hurt yourself.");
            }
            return true;
        }
                                                                //Master Bedroom text method
        static bool MasterLine()
        {
            Writer("While trying to find the master bedroom, you accidentally bumped into another couple looking at the house." +
                " \nYou asked them where the master bedroom was, and they happily pointed you in the right direction." +
                "\n Nice people!");
            Console.ReadLine();
            Writer("You walk into the master bedroom and see the full-size bed pushed up against the back wall, \na mounted TV on the adjacent " +
                "wall, a dresser underneath the TV, and a cool looking wardrobe near the corner of the room.");
            Console.ReadLine();
            //The Wardrobe
            Writer("All things aside, your very curious about this wardrobe. Do you want to take a closer look?");
            Writer("Yes");
            Writer("No");
            string wardrobeResponse = Console.ReadLine();
            if(wardrobeResponse.ToUpper() == "YES"||wardrobeResponse.ToLower() == "yes")
            {
                Console.Clear();
                Writer("You decide to get a closer look at the wardrobe, so you walk over to it and open it up.\n You just see expensive looking " +
                    "coats, but it looks like the wardrobe is abnormally longer than normal wardrobes.");
                Console.ReadLine();
                Writer("Your curiosity doesn't end here, so you push the coats aside and climb inside the wardrobe.\nAs your pushing more and more" +
                    " coats aside you find snow at the back of the wardrobe. This seems familiar...");
                Console.ReadLine();
                Writer("You walk even farther and find a snowy landscape filled with trees.\n You walk past the trees and find a single lampost.\n" +
                    " You look back and you can't see any evidence of where you came from.");
                Console.ReadLine();
                Writer("Wait.");
                Console.ReadLine();
                Writer("You're in Narnia. Good job.");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Writer("Game Over");
                Console.ReadLine();
                Environment.Exit(-1);
                
            }
            if(wardrobeResponse.ToUpper() == "NO"||wardrobeResponse.ToLower() == "no")
            {
                Console.Clear();
                Writer("Yeah, that would be invasion of privacy right? You decide not to mess with the wardrobe.");
            }
            return true;
        }

                                                                    //Basement text method
        static bool BasementLine()
        {
            Writer("You find a door that looks like it could lead to a closet of some sort.\n You open it, and you are met" +
                " with a wooden staircase leading to the lower half of the house.");
            Console.ReadLine();
            Writer("Once you walk down the creaky stairs you find a very nice mancave space.");
            Writer("There's a mounted TV, a refrigerator that you imagine can only be filled with beer, \n" +
                "and a couch accompanied with chairs that are in decent condition.");
            Console.ReadLine();
                                                                        //The TV Remote
            Writer("You see the TV remote control laying on the arm of the couch,\n and you remember that your favorite team is playing today." +
                "\n What do you do?");
            Writer("Turn it on");
            Writer("Leave it");
            string tvResponse = Console.ReadLine();
            if (tvResponse.ToUpper() == "Turn It ON" || tvResponse.ToLower() == "turn it on")
            {
                Console.Clear();
                Writer("You pick up the remote out of curiosity and turn on the TV.\n You flip through channels and finally find the right" +
                    " one.\nYou're just in time to see your team score a touchdown! Sweet!");
                Console.ReadLine();
            }
            if (tvResponse.ToUpper() == "LEAVE IT" || tvResponse.ToLower() == "leave it")
            {
                Console.Clear();
                Writer("You decide to leave it alone, because the homeowners may not want you messing with anything.");
                Console.ReadLine();
            }
            return true;
        }
                                                            //Backyard text method
        static bool BackyardLine()
        {
            Writer("You decide to go to the backyard.\n You find the backdoor nearest the kitchen area, and open the door.");
            Console.ReadLine();
            Writer("You're presented with a fairly large back porch/patio area.\n It looks like its around 20 feet wide, and 25 feet long.\n" +
                " There are chairs along the railing of the porch with some smaller tables accompanying them.");
            Console.ReadLine();
            Writer("Focusing your attention away from the porch, you look at the yard.\nYou notice that the grass has not been cut in what looks " +
                "like several weeks.");
            Console.ReadLine();
            Writer("Other than the grass problem, it's a pretty flat, maintainable looking yard.\nIt looks to be around an acre. Nice.");
            return true;
        }
                                                                //Actual Story
        static void Main(string[] args)
        {

            Rooms livingRoom = new Rooms()
            {
                Name = "Living Room",
                runStory = () => LivingRoomLine()
            }; ListAllRooms.Add(livingRoom);

            Rooms kitchen = new Rooms()
            {
                Name = "Kitchen",
                runStory = () => KitchenLine()
            }; ListAllRooms.Add(kitchen);

            Rooms diningRoom = new Rooms()
            {
                Name = "Dining Room",
                runStory = () => DiningLine()
            }; ListAllRooms.Add(diningRoom);

            Rooms kidsRoom = new Rooms()
            {
                Name = "Kid's Bedroom",
                runStory = () => KidRoom()
            }; ListAllRooms.Add(kidsRoom);

            Rooms masterRoom = new Rooms()
            {
                Name = "Master Bedroom",
                runStory = () => MasterLine()
            }; ListAllRooms.Add(masterRoom);

            Rooms basement = new Rooms()
            {
                Name = "Basement",
                runStory = () => BasementLine()
            }; ListAllRooms.Add(basement);

            Rooms backyard = new Rooms()
            {
                Name = "Backyard",
                runStory = () => BackyardLine()
            }; ListAllRooms.Add(backyard);

            Writer("You and your spouse are going to see an open house today.\nYou arrive and the realtor greets" +
            " you and says \"Hello! Welcome to the open house!\" You all walk\n inside and the realtor asks you,");

            while (ListAllRooms.Count > 0)
            {
                Writer("\"Which room would you like to see?\"");
                //Writer("");
                listOfRooms();

                string response = Console.ReadLine();
                foreach (Rooms room in ListAllRooms)
                {
                    if (response == room.Name)
                    {
                        Console.Clear();
                        room.runStory();
                        ListAllRooms.Remove(room);
                        break;
                    }
                }

            }
            Writer("After looking at all the rooms, you meet back up with the realtor.");
            Console.ReadLine();
            Writer("\"So how did you like the open house?\"she asked.");
            Writer("Well what did you really think of the house?");
            Writer("1)It was awesome");
            Writer("2)It was nice");
            Writer("3)It was average");
            Writer("4)It was bad");
            Writer("5)It was horrible");
            string houseReview = Console.ReadLine();

            if(houseReview.ToUpper() == "IT WAS AWESOME"||houseReview.ToLower() == "it was awesome"||houseReview == "1")
            {
                Writer("\"Well I'm glad you liked it! Let me know if you'd like to make an offer\nand we can get connected with " +
                    "the owners!\"the realtor replied.");
                Writer("Several years later, you find yourself in that very same house.");
                Console.ForegroundColor = ConsoleColor.Green;
                Writer("Game Over");
                Console.ReadLine();
                Environment.Exit(-1);
            }
            if(houseReview.ToUpper() == "IT WAS NICE"||houseReview.ToLower() == "it was nice"||houseReview == "2")
            {
                Writer("\"Well I'm glad you think so! If you're interested, I can get the owners and we can talk about pricing!\"");
                Writer("In the later years you do end up buying that very house, but with a small bit of regret.");
                Console.ForegroundColor = ConsoleColor.Green;
                Writer("Game Over");
                Console.ReadLine();
                Environment.Exit(-1);
            }
            if(houseReview.ToUpper() == "It was average"||houseReview.ToLower() == "IT WAS AVERAGE"||houseReview == "3")
            {
                Writer("\"Well keep in mind the owners did have a short amount of time to get this house ready before today.\nBut if you're interested," +
                    "I can get a hold of the owners and see what price range we can come up with!\"");
                Writer("Some years later you find yourself in that very house, but you wish you hadn't bought it.");
                Console.ForegroundColor = ConsoleColor.Green;
                Writer("Game Over");
                Console.ReadLine();
                Environment.Exit(-1);
            }
            if(houseReview.ToUpper() == "IT WAS BAD"||houseReview.ToLower() == "it was bad"||houseReview == "4")
            {
                Writer("\"I'm sorry to hear that! I'll definitely let the owners know that you weren't pleased with the house!\"");
                Writer("Your hunt for a home continues on.");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Writer("Game Over");
                Console.ReadLine();
                Environment.Exit(-1);
            }
            if (houseReview.ToUpper() == "IT WAS HORRIBLE" || houseReview.ToLower() == "it was horrible"||houseReview == "5")
            {
                Writer("\"I'm terribly sorry to hear that! I'll let the owners know about how you felt about their house!\"");
                Writer("You couldn't believe how terrible that house looked.");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Writer("Game Over");
                Console.ReadLine();
                Environment.Exit(-1);
            }
            Console.ReadLine();
        }
    }
}
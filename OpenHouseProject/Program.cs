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
            foreach(char letter in message)
            {
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
            
            for(int i = 0; i < ListAllRooms.Count; i++)
            {
                Writer(ListAllRooms[i].Name);
            }
        }
                                                            //Kitchen Text Method
        static void KitchenLine()
        {
            Writer("You and your spouse walk into the kitchen and find a nice cozy area with lots of cabinets.\n" +
                    "Looking at the sink you find that it's dirty, but when you turn it on it operates like normal.");
            Console.ReadLine();
            Writer("You think you see something in the sink, but cant quite see what exactly it is.\nDo you try and get it?");
            string shinyThing = Console.ReadLine();
                                                            //Something in the sink
            if (shinyThing.ToUpper() == "YES" || shinyThing.ToLower() == "yes")
            {
                Writer("You're thinking that it could be something valuable, so you reach into the sink pipe to try and grab the item,\n" +
                    "but you end up getting your hand stuck.");
                Console.ReadLine();
                Writer("The realtor has to call the fire department to get your hand unstuck from the sink, and the homeowners kick you out.");
                Writer("Your day is ruined.");
                Console.ReadLine();
                return;
            }
            if (shinyThing.ToUpper() == "NO" || shinyThing.ToLower() == "no")
            {
                Writer("You decide that whatever is in that sink belongs to the homeowners, and its their problem.\n You move on.");
            }
        }
                                                        //Dining Room Text Method
        static void DiningLine()
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
                Console.ReadLine();
                return;
            }
            if (sitChair.ToUpper() == "Don't Sit" || sitChair.ToLower() == "don't sit" || sitChair.ToUpper() == "Dont Sit" || sitChair.ToLower() == "dont sit")
            {
                Writer("You don't think it's a good idea to sit in these chairs, so if you do buy this house\n you'll buy some new chairs.");
                Console.ReadLine();
            }
        }
                                                    //Kid's Bedroom Text Method
        static void KidRoom()
        {
            Writer("You wonder around and find some stairs leading to the upper portion of the house." +
                        "\n You walk upstairs and find a child's bedroom." +
                        "\n You walk inside.");
            Console.ReadLine();
            Writer("You see a smaller bed, a dresser, a small looking closet, a fan on the ceiling, and a window looking at the " +
                "backyard.");
            Console.ReadLine();
                                                            //The BB Gun
            Writer("You spot a Red Ryder BB gun in the corner of the room.\n" +
                " You had one when you were a kid, and you wanna take a closer look.\n" +
                " Do you pick it up?");
            Writer("Yes");
            Writer("No");

            string bbResponse = Console.ReadLine();
            if (bbResponse.ToUpper() == "YES" || bbResponse.ToLower() == "yes")
            {
                Writer("You pick up the BB gun and start to have flashbacks of your parents telling you that\n you'll shoot your" +
                    "eye out.");
                Console.ReadLine();
                Writer("As you hear the rattling of BB's inside of the gun, you put it up to your shoulder and aim down the\n" +
                    " sight towards the wall.");
                Console.ReadLine();
                Writer("You then accidentally pull the trigger and the gun fires off a BB, \nbounces off the wall, " +
                    "and hits you in the eye");
                Writer("Your spouse then takes you to the hospital.");
                Writer("Maybe your parents were right, \"Ralphie\".");
                Console.ReadLine();
                return;
            }
            if(bbResponse.ToUpper() == "NO"||bbResponse.ToLower() == "no")
            {
                Writer("As your remembering your childhood you remember your parents telling you that you could shoot your eye out.\n " +
                    "You think it would be a bad idea to pick it up...just in case you did hurt yourself.");
            }

        }
                                                        //Master Bedroom text method
        static void MasterLine()
        {
            Writer("You find the master bedroom ");
        }
                                                        //Basement text method
        static void BasementLine()
        {
            Writer("You find a door that looks like it could lead to a closet of some sort.\n You open it, and you are met" +
                "with a wooden staircase leading to the lower half of the house.");
            Console.ReadLine();
            Writer("Once you walk down the creaky stairs you find a very nice mancave space.");
            Writer("There's a mounted TV, a refrigerator that you imagine can only be filled with beer, \n" +
                "and a couch accompanied with chairs that are in decent condition.");
            Console.ReadLine();
                                                            //The TV Remote
            Writer("You see the TV remote control laying on the arm of the couch,\n and you remember that your favorite team is playing today." +
                "\n What do you do?");
            Writer("Turn it on?");
            Writer("Leave it");
            string tvResponse = Console.ReadLine();
            if(tvResponse.ToUpper() == "Turn It ON"||tvResponse.ToLower() == "turn it on")
            {
                Writer("You pick up the remote out of curiosity and turn on the TV.\n You flip through channels and finally find the right" +
                    "one. You're just in time to see your team score a touchdown! Sweet!");
                Console.ReadLine();
            }
            if (tvResponse.ToUpper() == "LEAVE IT" || tvResponse.ToLower() == "leave it")
            {
                Writer("You decide to leave it alone, because the homeowners may not want you messing with anything.");
                Console.ReadLine();
            }
        }
                                                        //Backyard text method
        static void BackyardLine()
        {
            Writer("You decide to go to the backyard.\n You find the backdoor nearest the kitchen area, and open the door.");
            Console.ReadLine();
            Writer("You're presented with a fairly large back porch/patio area.\n It looks like its around 20 feet wide, and 25 feet long.\n" +
                " There are chairs along the walls of the porch with some smaller tables accompanying them.");
            Console.ReadLine();
            Writer("");
        }
                                                            //Actual Story
        static void Main(string[] args)
        {
            Rooms kitchen = new Rooms()
            {
                Name = "Kitchen",
                Description = KitchenLine()
            }; ListAllRooms.Add(kitchen);
            
            Rooms diningRoom = new Rooms()
            {
                Name = "Dining Room",
                Description = DiningLine()
            }; ListAllRooms.Add(diningRoom);

            Rooms kidsRoom = new Rooms()
            {
                Name = "Kid's Bedroom",
                Description = KidRoom()
            }; ListAllRooms.Add(kidsRoom);

            Rooms masterRoom = new Rooms()
            {
                Name = "Master Bedroom",
                Description = MasterLine()
            }; ListAllRooms.Add(masterRoom);

            Rooms basement = new Rooms()
            {
                Name = "Basement",
                Description = BasementLine()
            }; ListAllRooms.Add(basement);

            Rooms backyard = new Rooms()
            {
                Name = "Backyard",
                Description = BackyardLine()
            }; ListAllRooms.Add(backyard);
            
            
            Writer("You and your spouse are going to see an open house today.\nYou arrive and the realtor greets" +
                " you and says \"Hello! Welcome to the open house!\" You all walk\n inside and the realtor asks you,\n" +
                "\"Which room would you like to see first?\"");
            listOfRooms();

            string response = Console.ReadLine();
                                                        //Kitchen start path
            if(response.ToUpper() == "Kitchen"||response.ToLower() == "kitchen")
            {
                KitchenLine();
                Console.ReadLine();

                Writer("You decide to leave your spouse with the realtor and do your own exploring.\n You decide to go to the:");
                Writer("Dining Room");
                Writer("Kid's Bedroom");
                Writer("Master Bedroom");
                Writer("Basement");
                Writer("Backyard");

                string response2 = Console.ReadLine();
                                                         //Kitchen start Dining Room path
                if(response2.ToUpper() == "DINING ROOM"||response2.ToLower() == "dining room")
                {
                    DiningLine();
                }
                                                        //Kitchen start, Kid's Bedroom
                if(response2.ToUpper() == "Kid's Bedroom"||response2.ToLower() == "kid's bedroom"||response2.ToUpper() == "KIDS BEDROOM"||response2.ToLower() == "kids bedroom")
                {
                    KidRoom();
                }


            }
                                                            //Dining Room start path
            if(response.ToUpper() == "Dining Room"||response.ToLower() == "dining room")
            {
                DiningLine();
            }
                                                            //Kid Room start path
            if (response.ToUpper() == "Kid's Bedroom" || response.ToLower() == "kid's bedroom" || response.ToUpper() == "KIDS BEDROOM" || response.ToLower() == "kids bedroom")
            {
                KidRoom();
            }
                                                            //Basement start path
            if(response.ToUpper() == "BASEMENT"||response.ToLower() == "basement")
            {
                BasementLine();
            }
                                                                //Backyard start path
            if(response.ToUpper() == "BACKYARD"||response.ToLower() == "backyard")
            {
                BackyardLine();
            }
                Console.ReadLine();
        }
    }
}

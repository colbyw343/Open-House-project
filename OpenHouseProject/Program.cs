using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Net;

namespace OpenHouseProject
{
    class Program
    {
        public static int furnCount = 0;
        public static double newBudget = 0;
        public static List<Rooms> BuilderRooms = new List<Rooms>();
        public static List<string> livingRoomFurn = new List<string>();
        public static List<string> kitchenRoomFurn = new List<string>();
        public static List<string> bathRoomFurn = new List<string>();
        public static List<string> upBedRoomFurn = new List<string>();
        public static List<string> upBathRoomFurn = new List<string>();
        public static List<string> atticRoomFurn = new List<string>();
        public static List<string> backyardRoomFurn = new List<string>();
        public static List<string> masterRoomFurn = new List<string>();
        public static List<string> basementRoomFurn = new List<string>();
        public static List<string> diningRoomFurn = new List<string>();
        //Typewriter for all text Method
        static void Writer(string message, ConsoleColor color = ConsoleColor.Blue, int delay = 25)
        {
            Console.ForegroundColor = color;
            foreach (char letter in message)
            {
                Thread.Sleep(delay);
                Console.Write(letter);
            }
            Console.WriteLine();
        }
        //List of all the rooms
        public static List<Rooms> ListAllRooms = new List<Rooms>();
        //List to display all the rooms
        static void ListOfRooms()
        {

            for (int i = 0; i < ListAllRooms.Count; i++)
            {
                Writer(ListAllRooms[i].Name);
            }
        }

        //Adding More Furniture to Rooms
        static void AddingMoreFurniture()
        {
            if (newBudget < 199.99)
            {
                Writer("Uh-oh, there isnt enough money in the budget to buy furniture!");
                Writer("Looks like we'll have to move on until you can get more money!");
                return;
            }

            FurnitureRepository repo = new FurnitureRepository();
            foreach (Rooms room in BuilderRooms)
            {
                Writer("Here are all the products that you can choose from.");
                repo.ShowAllProducts();

                Writer("Please type the product id of the furniture you would like to put in your house.");
                string productResponse = Console.ReadLine();
                int furnitureResponse = int.Parse(productResponse);
                Furniture furn = new Furniture()
                {
                    Id = furnitureResponse
                };

                Writer("Is this the furniture you want?");
                repo.ShowSpecificFurniture(furnitureResponse);
                string answer = Console.ReadLine();
                if (newBudget == 0)
                {
                    Writer("Uh-oh! You don't have any money left!");
                    Writer("Looks like we can't buy anymore furniture.");
                    Console.ReadLine();
                    return;
                }
                if (newBudget < furn.Price)
                {
                    Writer($"Oops! You only have ${newBudget} and are not able to purchase this furniture.");
                    Writer("Would you like to try again?");
                    string budgetResponse = Console.ReadLine();
                    if (budgetResponse.ToUpper() == "YES")
                    {
                        AddingMoreFurniture();
                    }
                    return;
                }
                if (answer.ToUpper() == "YES")
                {
                    Writer("Please pick the room that you would like to put this furniture in.");
                    for (int i = 0; i < BuilderRooms.Count; i++)
                    {
                        Writer(BuilderRooms[i].Name);
                    }
                    string roomResponse = Console.ReadLine();
                    if (roomResponse.ToUpper() == "LIVING ROOM")
                    {
                        livingRoomFurn.Add(repo.GetNameOfSpecificFurn(furnitureResponse));
                    }
                    if (roomResponse.ToUpper() == "KITCHEN")
                    {
                        kitchenRoomFurn.Add(repo.GetNameOfSpecificFurn(furnitureResponse));
                    }
                    if (roomResponse.ToUpper() == "BATHROOM")
                    {
                        bathRoomFurn.Add(repo.GetNameOfSpecificFurn(furnitureResponse));
                    }
                    if (roomResponse.ToUpper() == "UPSTAIRS BEDROOM")
                    {
                        upBedRoomFurn.Add(repo.GetNameOfSpecificFurn(furnitureResponse));
                    }
                    if (roomResponse.ToUpper() == "UPSTAIRS BATHROOM")
                    {
                        upBathRoomFurn.Add(repo.GetNameOfSpecificFurn(furnitureResponse));
                    }
                    if (roomResponse.ToUpper() == "ATTIC")
                    {
                        atticRoomFurn.Add(repo.GetNameOfSpecificFurn(furnitureResponse));
                    }
                    if (roomResponse.ToUpper() == "BACKYARD")
                    {
                        backyardRoomFurn.Add(repo.GetNameOfSpecificFurn(furnitureResponse));
                    }
                    if (roomResponse.ToUpper() == "MASTER BEDROOM")
                    {
                        masterRoomFurn.Add(repo.GetNameOfSpecificFurn(furnitureResponse));
                    }
                    if (roomResponse.ToUpper() == "BASEMENT")
                    {
                        basementRoomFurn.Add(repo.GetNameOfSpecificFurn(furnitureResponse));
                    }
                    if (roomResponse.ToUpper() == "DINING ROOM")
                    {
                        diningRoomFurn.Add(repo.GetNameOfSpecificFurn(furnitureResponse));
                    }
                    newBudget -= repo.GetPriceOfSpecificFurn(furnitureResponse);
                    Writer($"After purchasing this furniture, the remaining budget is {newBudget}.");
                    furnCount++;
                    Console.ReadLine();
                    Writer("Do you want to add more furniture?");
                    Writer("Maybe to another room?");
                    string addMore = Console.ReadLine();
                    if (addMore.ToUpper() == "YES")
                    {
                        AddingMoreFurniture();
                    }
                    return;
                }
                if (answer.ToUpper() == "NO")
                {
                    Writer("Alright, let's try again from the beginning.");
                    Console.ReadLine();
                    AddingMoreFurniture();
                }
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
                Writer("Game Over", ConsoleColor.DarkRed, 100);
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
                Writer("Game Over", ConsoleColor.DarkRed, 100);
                Console.ReadLine();
                Environment.Exit(-1);
            }
            if (sitChair.ToUpper() == "Don't Sit" || sitChair.ToLower() == "don't sit" ||
                sitChair.ToUpper() == "Dont Sit" || sitChair.ToLower() == "dont sit")
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
                Writer("Game Over", ConsoleColor.DarkRed, 100);
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
            if (wardrobeResponse.ToUpper() == "YES" || wardrobeResponse.ToLower() == "yes")
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
                Writer("Wait.", ConsoleColor.Blue, 100);
                Console.ReadLine();
                Writer("You're in Narnia. Good job.");
                Writer("Game Over", ConsoleColor.DarkRed, 100);
                Console.ReadLine();
                Environment.Exit(-1);

            }
            if (wardrobeResponse.ToUpper() == "NO" || wardrobeResponse.ToLower() == "no")
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

        static bool GuestBathroomLine()
        {
            Writer("You're thinking about what the guest bathroom looks like, so you find the bathroom on the main level close to the living room area.\n " +
                "Other than the hardwood floor, and the shiny mirror right above the sink, theres nothing else particularly exciting about it.\n It comes with a standard " +
                "toilet, a sink, and a mirror (as mentioned before).");
            Console.ReadLine();
            return true;
        }

        static bool MasterBathroomLine()
        {
            Writer("You're curious about the master bathroom, so you go and take a look.");
            Console.ReadLine();
            Writer("As you step into the massive bathroom, you notice that there appears to be a walk-in shower, AND a full-size bathtub. Looks like somebody invested " +
                "a lot into their bathroom...");
            Console.ReadLine();
            Writer("Other than those two features, the bathroom has a nice tile floor, 2 sets of sinks side-by-side, and a towel rack on the adjacent wall from the sinks.");
            Console.ReadLine();
            //The Knob
            Writer("Strange...", ConsoleColor.Blue, 100);
            Writer("You see a door knob inside the walk-in shower!\n As you look at it, you almost feel spooked. Like there's something evil about it.");
            Writer("Do you go investigate?");
            Writer("Yes");
            Writer("No");
            string response = Console.ReadLine();
            if (response.ToUpper() == "YES")
            {
                Console.Clear();
                Writer("You have a shake in your hand as you open the door to the walk-in shower.\n You can't help but feel that this does not lead to anything good.");
                Console.ReadLine();
                Writer("But at the same time, you want to turn the knob, because it could open up to something amazing!");
                Writer("Are you sure you want to turn the knob?");
                string responseAgain = Console.ReadLine();
                if (responseAgain.ToUpper() == "YES")
                {
                    Writer("You make a final decision to turn the knob, so you reach your hand out to turn it and...");
                    Writer("........", ConsoleColor.Blue, 100);
                    Writer("Nothing happened. What a let down.");
                    Console.ReadLine();
                }
                if (responseAgain.ToUpper() == "NO")
                {
                    Writer("No, you can't turn that knob. You're getting really bad vibes from this strange knob, so you decide to not turn it.\n Probably for the better.");
                    Console.ReadLine();
                }
            }
            if (response.ToUpper() == "NO")
            {
                Console.Clear();
                Writer("You think it's a little weird to have a knob in their shower, and that's all that you think about it.");
                Writer("You move on.");
                return true;
            }
            return true;
        }

        //Actual Story
        static void Main(string[] args)
        {
            //Setting up the rooms for the open house
            Rooms livingRoom = new Rooms()
            {
                Name = "Living Room",
                runStory = LivingRoomLine
            }; ListAllRooms.Add(livingRoom);

            Rooms kitchen = new Rooms()
            {
                Name = "Kitchen",
                runStory = KitchenLine
            }; ListAllRooms.Add(kitchen);

            Rooms diningRoom = new Rooms()
            {
                Name = "Dining Room",
                runStory = DiningLine
            }; ListAllRooms.Add(diningRoom);

            Rooms kidsRoom = new Rooms()
            {
                Name = "Kid's Bedroom",
                runStory = KidRoom
            }; ListAllRooms.Add(kidsRoom);

            Rooms masterRoom = new Rooms()
            {
                Name = "Master Bedroom",
                runStory = MasterLine
            }; ListAllRooms.Add(masterRoom);

            Rooms basement = new Rooms()
            {
                Name = "Basement",
                runStory = BasementLine
            }; ListAllRooms.Add(basement);

            Rooms backyard = new Rooms()
            {
                Name = "Backyard",
                runStory = BackyardLine
            }; ListAllRooms.Add(backyard);

            Rooms guestBathroom = new Rooms()
            {
                Name = "Guest Bathroom",
                runStory = GuestBathroomLine
            }; ListAllRooms.Add(guestBathroom);

            Rooms masterBathroom = new Rooms()
            {
                Name = "Master Bathroom",
                runStory = MasterBathroomLine
            }; ListAllRooms.Add(masterBathroom);

            //nice little house
            string midHouse = @" 
           )
         ( _   _._
          |_|-'_~_`-._
       _.-'-_~_-~_-~-_`-._
   _.-'_~-_~-_-~-_~_~-_~-_`-._
  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    |  []  []   []   []  [] |
jgs |           __    ___   |
  ._|  []  []  | .|  [___]  |_._._._._._._._._._._._._._._._._.
  |=|________()|__|()_______|=|=|=|=|=|=|=|=|=|=|=|=|=|=|=|=|=|
^^^^^^^^^^^^^^^ === ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
    _______      ===
   <_4sale_>       ===
      ^|^             ===
       |                 ===";

            string smallHouse = @"
         `'::.
    _________H ,%%&%,
   /\     _   \%&&%%&%
  /  \___/^\___\%&%%&&
  |  | []   [] |%\Y&%'
  |  |   .-.   | ||  
~~@._|@@_|||_@@|~||~~~~~~~~~~~~~
     `   ) )";

            string midToBigHouse = @"
                           ====
                           !!!!
      ==========================
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
  %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
  ||      _____          _____    ||
  ||      | | |          | | |    ||
  ||      |-|-|          |-|-|    ||
  ||      #####          #####    ||
  ||                              ||
  ||      _____   ____   _____    ||
  ||      | | |   @@@@   | | |    ||
  ||      |-|-|   @@@@   |-|-|    ||
  ||      #####   @@*@   #####    ||
  ||              @@@@            ||
******************____****************
**************************************";

            string bigHouse = @"    
    ) )        /\
   =====      /  \
  _|___|_____/ __ \____________
 |::::::::::/ |  | \:::::::::::|
 |:::::::::/  ====  \::::::::::|
 |::::::::/__________\:::::::::|
 |_________|  ____  |__________|
  | ______ | / || \ | _______ |
  ||  |   || ====== ||   |   ||
  ||--+---|| |    | ||---+---||
  ||__|___|| |   o| ||___|___||
  |========| |____| |=========|
 (^^-^^^^^-|________|-^^^--^^^)
 (,, , ,, ,/________\,,,, ,, ,)
','',,,,' /__________\,,,',',;;";


            Writer("You have been saving money for quite a while now, and you would like to purchase a house. You have 2 options.\n1) Go see an open house.\n2) Build a house.");
            string eitherBuildOrSee = Console.ReadLine();
            bool result = Int32.TryParse(eitherBuildOrSee, out int num);
            while (result)
            {
                if (num == 1)
                {
                    //Depending on the users budget, this will delete some rooms
                    Writer("How much are you willing to spend on a house?");
                    Writer("(Type the number that corresponds to the amount)");
                    Writer("1) $0 - $50,000");
                    Writer("2) $50,000 - $100,000");
                    Writer("3) $100,000 - $200,000");
                    Writer("4) $200,000 - $300,000");
                    Writer("5) $300,000 - $500,000");
                    string response = Console.ReadLine();
                    if (response == "1")
                    {
                        Writer("Go get some money.");
                        Console.ReadLine();
                        return;
                    }
                    if (response == "2")
                    {
                        ListAllRooms.Remove(basement);
                        ListAllRooms.Remove(guestBathroom);
                        ListAllRooms.Remove(backyard);
                        Writer(smallHouse);
                    }
                    if (response == "3")
                    {
                        ListAllRooms.Remove(basement);
                        ListAllRooms.Remove(guestBathroom);
                        Writer(midHouse);
                    }
                    if (response == "4")
                    {
                        ListAllRooms.Remove(guestBathroom);
                        Writer(midToBigHouse);
                    }
                    if (response == "5")
                    {
                        Writer(bigHouse);
                    }


                    Writer("You and your spouse are going to see this open house today.\nYou arrive and the realtor greets" +
                    " you and says \"Hello! Welcome to the open house!\" You all walk\n inside and the realtor asks you,");

                    //Every time the user goes to a room, it deletes it from the list of rooms
                    while (ListAllRooms.Count > 0)
                    {
                        Writer("\"Which room would you like to see?\"");

                        Writer("Please type the room you would like to see.");
                        ListOfRooms();

                        string response2 = Console.ReadLine();
                        foreach (Rooms room in ListAllRooms)
                        {
                            if (response2 == room.Name)
                            {
                                Console.Clear();
                                room.runStory();
                                ListAllRooms.Remove(room);
                                break;
                            }
                        }

                    }
                    //Rating the open house
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

                    if (houseReview.ToUpper() == "IT WAS AWESOME" || houseReview.ToLower() == "it was awesome" || houseReview == "1")
                    {
                        Writer("\"Well I'm glad you liked it! Let me know if you'd like to make an offer\nand we can get connected with " +
                            "the owners!\"the realtor replied.");
                        Writer("Several years later, you find yourself in that very same house.");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Writer("Game Over");
                        Console.ReadLine();
                        Environment.Exit(-1);
                    }
                    if (houseReview.ToUpper() == "IT WAS NICE" || houseReview.ToLower() == "it was nice" || houseReview == "2")
                    {
                        Writer("\"Well I'm glad you think so! If you're interested, I can get the owners and we can talk about pricing!\"");
                        Writer("In the later years you do end up buying that very house, but with a small bit of regret.");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Writer("Game Over");
                        Console.ReadLine();
                        Environment.Exit(-1);
                    }
                    if (houseReview.ToUpper() == "It was average" || houseReview.ToLower() == "IT WAS AVERAGE" || houseReview == "3")
                    {
                        Writer("\"Well keep in mind the owners did have a short amount of time to get this house ready before today.\nBut if you're interested," +
                            "I can get a hold of the owners and see what price range we can come up with!\"");
                        Writer("Some years later you find yourself in that very house, but you wish you hadn't bought it.");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Writer("Game Over");
                        Console.ReadLine();
                        Environment.Exit(-1);
                    }
                    if (houseReview.ToUpper() == "IT WAS BAD" || houseReview.ToLower() == "it was bad" || houseReview == "4")
                    {
                        Writer("\"I'm sorry to hear that! I'll definitely let the owners know that you weren't pleased with the house!\"");
                        Writer("Your hunt for a home continues on.");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Writer("Game Over");
                        Console.ReadLine();
                        Environment.Exit(-1);
                    }
                    if (houseReview.ToUpper() == "IT WAS HORRIBLE" || houseReview.ToLower() == "it was horrible" || houseReview == "5")
                    {
                        Writer("\"I'm terribly sorry to hear that! I'll let the owners know about how you felt about their house!\"");
                        Writer("You couldn't believe how terrible that house looked.");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Writer("Game Over");
                        Console.ReadLine();
                        Environment.Exit(-1);
                    }
                    Console.ReadLine();
                    break;
                }

                //The builder path
                if (num == 2)
                {
                    //Setting up the rooms for building a house
                    Rooms builderLivingRoom = new Rooms()
                    {
                        Name = "Living Room",
                        Furniture = livingRoomFurn
                    }; BuilderRooms.Add(builderLivingRoom);

                    Rooms builderKitchen = new Rooms()
                    {
                        Name = "Kitchen",
                        Furniture = kitchenRoomFurn
                    }; BuilderRooms.Add(builderKitchen);

                    Rooms builderBathroom = new Rooms()
                    {
                        Name = "Bathroom",
                        Furniture = bathRoomFurn
                    }; BuilderRooms.Add(builderBathroom);

                    Rooms builderUpBed = new Rooms()
                    {
                        Name = "Upstairs Bedroom",
                        Furniture = upBedRoomFurn
                    }; BuilderRooms.Add(builderUpBed);

                    Rooms builderUpBath = new Rooms()
                    {
                        Name = "Upstairs Bathroom",
                        Furniture = upBathRoomFurn
                    }; BuilderRooms.Add(builderUpBath);

                    Rooms builderAttic = new Rooms()
                    {
                        Name = "Attic",
                        Furniture = atticRoomFurn
                    }; BuilderRooms.Add(builderAttic);

                    Rooms builderBack = new Rooms()
                    {
                        Name = "Backyard",
                        Furniture = backyardRoomFurn
                    }; BuilderRooms.Add(builderBack);

                    Rooms builderMaster = new Rooms()
                    {
                        Name = "Master Bedroom",
                        Furniture = masterRoomFurn
                    }; BuilderRooms.Add(builderMaster);

                    Rooms builderBasement = new Rooms()
                    {
                        Name = "Basement",
                        Furniture = basementRoomFurn
                    }; BuilderRooms.Add(builderBasement);

                    Rooms builderDining = new Rooms()
                    {
                        Name = "Dining Room",
                        Furniture = diningRoomFurn
                    }; BuilderRooms.Add(builderDining);

                    Writer("How much are you willing to spend on building a house?");
                    Writer("(Please type an amount to set your budget)");
                    string response = Console.ReadLine();
                    double userBudget = double.Parse(response);

                    //Based on the user answer, the program tells the user how easy it will be to build a house
                    int roomCount = 0;
                    if (userBudget <= 50000)
                    {
                        Writer("You're gonna need a little more money to build a house.");
                        Console.ReadLine();
                        return;
                    }
                    if (userBudget <= 100000 && userBudget > 50000)
                    {
                        Writer("It's gonna be difficult to build a house with this amount, but doable.");
                        roomCount = 5;
                        Console.ReadLine();
                    }
                    if (userBudget <= 200000 && userBudget > 100000)
                    {
                        Writer("Alright, we could build a smaller, but decent sized house.");
                        roomCount = 6;
                        Console.ReadLine();
                    }
                    if (userBudget <= 300000 && userBudget > 200000)
                    {
                        Writer("Ok, we can build a good looking house with this amount.");
                        roomCount = 7;
                        Console.ReadLine();
                    }
                    if (userBudget <= 500000 && userBudget > 300000)
                    {
                        Writer("With this amount, we can build the best house we can offer you.");
                        roomCount = 10;
                        Console.ReadLine();
                    }
                    if (userBudget > 500000)
                    {
                        Writer("Sorry, but we don't build mansion-sized houses.");
                        Console.ReadLine();
                        return;
                    }
                    //Setting up the room count
                    Writer($"Based on your answer, the amount of rooms in your house will be {roomCount}");
                    Console.ReadLine();
                    if (roomCount == 5)
                    {
                        BuilderRooms.Remove(builderUpBed);
                        BuilderRooms.Remove(builderUpBath);
                        BuilderRooms.Remove(builderAttic);
                        BuilderRooms.Remove(builderBack);
                        BuilderRooms.Remove(builderBasement);
                        Writer($"The rooms that you will have are ");
                        for (int i = 0; i < BuilderRooms.Count; i++)
                        {
                            Writer(BuilderRooms[i].Name);
                        }
                        Console.ReadLine();
                    }
                    if (roomCount == 6)
                    {
                        BuilderRooms.Remove(builderUpBed);
                        BuilderRooms.Remove(builderUpBath);
                        BuilderRooms.Remove(builderBack);
                        BuilderRooms.Remove(builderBasement);
                        Writer($"The rooms that you will have are ");
                        for (int i = 0; i < BuilderRooms.Count; i++)
                        {
                            Writer(BuilderRooms[i].Name);
                        }
                        Console.ReadLine();
                    }
                    if (roomCount == 7)
                    {
                        BuilderRooms.Remove(builderUpBed);
                        BuilderRooms.Remove(builderUpBath);
                        BuilderRooms.Remove(builderBack);

                        Writer($"The rooms that you will have are ");
                        for (int i = 0; i < BuilderRooms.Count; i++)
                        {
                            Writer(BuilderRooms[i].Name);
                        }
                        Console.ReadLine();
                    }
                    if (roomCount == 10)
                    {
                        Writer($"The rooms that you will have are ");
                        for (int i = 0; i < BuilderRooms.Count; i++)
                        {
                            Writer(BuilderRooms[i].Name);
                        }
                        Console.ReadLine();
                    }


                    int houseCost = 0;
                    //Setting up the house cost
                    if (userBudget <= 100000 && userBudget >= 50000)
                    {
                        houseCost = 50000;
                        Writer($"The cost to build just the house alone will be ${houseCost}");
                        newBudget = userBudget - houseCost;
                        Writer($"So after building the house, you have ${newBudget} left.");
                        Console.ReadLine();
                    }
                    if (userBudget <= 200000 && userBudget >= 100000)
                    {
                        houseCost = 100000;
                        Writer($"The cost to build just the house alone will be ${houseCost}.");
                        newBudget = userBudget - houseCost;
                        Writer($"So after building the house, you have ${newBudget} left.");
                        Console.ReadLine();
                    }
                    if (userBudget <= 300000 && userBudget >= 200000)
                    {
                        houseCost = 200000;
                        Writer($"The cost to build the house alone will be ${houseCost}.");
                        newBudget = userBudget - houseCost;
                        Writer($"So after building the house, you have ${newBudget} left.");
                        Console.ReadLine();
                    }
                    if (userBudget <= 500000 && userBudget >= 300000)
                    {
                        houseCost = 300000;
                        Writer($"The cost to build the house alone will be ${houseCost}");
                        newBudget = userBudget - houseCost;
                        Writer($"So after building the house, you have ${newBudget} left.");
                        Console.ReadLine();
                    }

                    Console.Clear();

                    Writer("Now that we have the size of your house, let's put some furniture inside.");

                    if (newBudget < 199.99)
                    {
                        Writer("Uh-oh, there isnt enough money in the budget to buy furniture!");
                    }
                    Console.ReadLine();

                    AddingMoreFurniture();

                    if (furnCount == 0)
                    {
                        Writer("Well, since you don't have any furniture, let's move on.");
                        Console.ReadLine();
                    }
                    if (furnCount > 0)
                    {
                        Writer($"Now that we have {furnCount} pieces of furniture, let's move on.");
                        Console.ReadLine();
                    }
                    Writer("This is the furniture that you have purchased so far:");
                    foreach(Rooms room in BuilderRooms)
                    {
                        foreach(string furn in room.Furniture)
                        {
                            Console.WriteLine(room.Name + ":" + furn);
                        }
                    }
                    Console.ReadLine();
                    break;
                }
            }
            //If the user types random junk
            while (!result)
            {
                Console.WriteLine("That was not a valid answer.");
                Console.ReadLine();
                break;
            }


        }

    }
}
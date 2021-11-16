/*
 * Created by Lucas Larsson.
 * Version: 1.2
 */


using System;
using System.Net.NetworkInformation;

namespace Bus
{
    class Buss
    {
        public int[] passenger = new int[25]; //vektor deklarerad
        public int new_passengers; //int där vi lägger det vi använder från vektorn
        public void Run()

        {
            Console.WriteLine("Welcome to the awesome Buss-simulator by Lucas Larsson");
            Console.WriteLine("***************************************");
			//Int för tal som användaren anger när man väljer allternativ i menyn.
            int tal1; 

            while(true)
            {
                Console.WriteLine("***************************************");
                Console.WriteLine("Välj ett alternativ: ");
                Console.WriteLine("1. Add passenger. ");
                Console.WriteLine("2. Check ages on passengers. ");
                Console.WriteLine("3. Calculate the median age on passengers ");
                Console.WriteLine("4. Calculate the total age of all passengers. ");
                Console.WriteLine("5. Show the oldest passenger. ");
                Console.WriteLine("6. Identify a passenger based on age limit. ");
                Console.WriteLine("0. Exit program. ");
                Console.WriteLine("***************************************");

                tal1 = int.Parse(Console.ReadLine()); //översätter vad användaren skriver in till en int
                switch (tal1) //Metoder för menyval nedan. 
                {
                    case 1:
                		{
                			add_passenger(); //Add passenger.
                			break;
                		}

                    case 2:
                		{
                			print_buss(); //Show all passengers.
                			break;
                		}

                    case 3:
                		{
                			calc_average_age(); //Calc average age.
                			break;
                		}

                    case 4:
                		{
                			calc_total_age(); //Count total age.
                			break;
                		}

                    case 5:
                		{
                			max_age(); //Count max age.
                			break;
                		}

                    case 6:
                		{
                			find_age(); //Find specifix age limit.
                			break;
                		}


                    case 0:
                		{
                			Environment.Exit(0); //Exit program.
                			return;
                		}
                	default:
                		{
                			Console.WriteLine("Please choose something in the menu");
                			break;
                		}
		

                }
            }
        }
		
		//Meny metoder nedan.
        public void add_passenger() 
        {
            Console.WriteLine("How many passengers would you like to add?");
            try //try catch för att vi endast vill ha siffror 
            {
                int size = Convert.ToInt32(Console.ReadLine());
                if (size > 25) //endast siffror under 25 är ok 
                {
                    Console.WriteLine("Maximum ammount of passengers are 25."); 
                }
                else //om de skriver siffror under 25
                {
                    for (int i = 0; i < size; i++) //Lägg till passagerare.
                    {
                        Console.WriteLine("Add a passenger by entering his/hers age: ");
                        int added_passengers = Convert.ToInt32(Console.ReadLine()); 
                        passenger[i] = added_passengers; //Spara i vektorn
                        new_passengers++; //Öka på passagerare med 1.                    
                    }
                }
            }
			//Fånga upp om man skriver annat än en siffra.
            catch
            {
                Console.WriteLine("You can only enter a integear."); 
            }
        }

        public void print_buss() //metod för att skriva ut alla passagerare 
        {
            for (int i = 0; i < new_passengers; i++) //for-loop som kör igenom alla_passagerare-variabeln

            {
                Console.WriteLine("Passengers age are " + passenger[i]);
                Console.WriteLine(" ");
            }
        }
        public void calc_total_age() //metod för att räkna alla passagerares ålder
        {
            int sum = 0;
            for (int i = 0; i < new_passengers; i++) //for-loop som kör igenom alla_passagerare-variabeln
            {
                sum += passenger[i]; //läser in passagerarna från vektorn & adderar och lägger in i variabeln sum
            }
            Console.WriteLine("The total age of all passengers are " + sum + "."); 
            Console.WriteLine(" ");
        }
        public void calc_average_age() //metod för att räkna ut medelåldern
        {
            int sum = 0;
            for (int i = 0; i < new_passengers; i++) 
            {
				//Här sätter vi upp ekvationen..
                sum += passenger[i]; 
            }
            double dsum = Convert.ToDouble(sum); //VI gör om till en double.
            double dsum1 = dsum / new_passengers; //räknar ut medelålder.
            Console.WriteLine("The median age is " + dsum1 + " year/s.");
            Console.WriteLine(" ");
        }
        public int max_age() //metod för att räkna ut maxåldern
        {
            int maxAge = 0; //ny variabel
            for (int i = 0; i < new_passengers; i++) //for-loop som kör igenom alla_passagerare-variabeln
            {
                if (passenger[i] > maxAge) 
                {
                    maxAge = passenger[i]; //lägger alla i vektorn i variabeln maxAge
                }
            }
            Console.WriteLine("The oldes on board is " + maxAge + " years old."); 
            Console.WriteLine(" ");
            return maxAge;
        }

        public void find_age()
        {
            {
                Console.WriteLine("What is the youngest age in the search query?"); //användaren får välja lägsta ålder
                int low = Convert.ToInt32(Console.ReadLine()); //lagrar i int
                Console.WriteLine("What is the highest age in the search query?");
                int high = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Passengers age " + low + " and " + high + " seats on: "); 
                for (int i = 0; i < new_passengers; i++) //for-loop som kör igenom alla_passagerare-variabeln
                {
                    if (passenger[i] > low || passenger[i] > high) //identifierar ålderspann
                    {
                        Console.WriteLine("Seat " + i); //skriver ut sätesnumren
                    }
                }
                Console.WriteLine(" ");
                Console.WriteLine("Total of 25 seats!"); //pga att det börjar på noll... 
            }
        }

        class Program
        {
            public static void Main(string[] args) //programmetoden

            {
                var minbuss = new Buss(); //programmet
                minbuss.Run(); 
                Console.Write("Press any key to continue...");
                Console.ReadKey(true);
            }
        }
    }
}
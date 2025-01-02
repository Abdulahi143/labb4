using System;
using System.Collections.Generic;

namespace labb4
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Hard coding the person for sprint 1*/
            Hair hardcodedHair = new Hair { HairLength = 20.5, HairColor = "Black" };
            Person hardcodedPerson = new Person(Gender.Male, "Brown", new DateOnly(1990, 1, 1), hardcodedHair);
            Console.WriteLine("Hardcoded Person:");
            Console.WriteLine(hardcodedPerson);
            
            
            List<Person> people = new List<Person>();

            /*The program will be open until the user chooses 3*/
            while (true)
            {
                Console.WriteLine("\nAngelic Good Guys Program");
                Console.WriteLine("1. Add a person in the list.");
                Console.WriteLine("2. Get all registered people.");
                Console.WriteLine("3. Close the program.");
                Console.Write("Choose 1, 2, or 3: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Person newPerson = AddPerson();
                        if (newPerson != null)
                        {
                            people.Add(newPerson);
                            Console.WriteLine("Person added successfully!");
                        }
                        break;

                    case "2":
                        Console.WriteLine("\nRegistered People:");
                        if (people.Count == 0)
                        {
                            Console.WriteLine("No people registered yet.");
                        }
                        else
                        {
                            GetPeople(people);
                        }
                        break;

                    case "3":
                        Console.WriteLine("Program closed.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
                        break;
                }
            }
        }

        static Person AddPerson()
        {
            try
            {
                Gender gender;
                while (true)
                {
                    Console.Write("Enter gender (male/female): ");
                    string genderInput = Console.ReadLine().ToLower();
                    if (genderInput == "male" || genderInput == "female")
                    {
                        gender = (Gender)Enum.Parse(typeof(Gender), genderInput, true);
                        break;
                    }
                    Console.WriteLine("Invalid gender. Valid options are 'male' or 'female'.");
                }

                string eyeColor;
                while (true)
                {
                    Console.Write("Enter your eye color (only letters): ");
                    eyeColor = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(eyeColor) && eyeColor.All(char.IsLetter))
                        break;
                    Console.WriteLine("Eye color must contain only alphabetic characters.");
                }

                DateOnly birthDate;
                while (true)
                {
                    Console.Write("Enter birth date (YYYY-MM-DD): ");
                    if (DateOnly.TryParse(Console.ReadLine(), out birthDate))
                        break;
                    Console.WriteLine("Invalid date format. Please use YYYY-MM-DD.");
                }

                double hairLength;
                while (true)
                {
                    Console.Write("Enter hair length (in cm): ");
                    if (double.TryParse(Console.ReadLine(), out hairLength) && hairLength >= 0)
                        break;
                    Console.WriteLine("Hair length must be a non-negative numeric value.");
                }

                string hairColor;
                while (true)
                {
                    Console.Write("Enter hair color (only letters): ");
                    hairColor = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(hairColor) && hairColor.All(char.IsLetter))
                        break;
                    Console.WriteLine("Hair color must contain only alphabetic characters.");
                }

                Hair hair = new Hair
                {
                    HairLength = hairLength,
                    HairColor = hairColor
                };

                return new Person(gender, eyeColor, birthDate, hair);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return null;
            }
        }

        static void GetPeople(List<Person> people)
        {
            /*I want to have person list number beside the persons number ex 1. male... */
            int number = 1;
            Console.WriteLine("-----------");
            foreach (Person eachPerson in people)
            {
                Console.WriteLine($"{number}. {eachPerson}");
                /*Adding 1 after the first number for number to grow to the next number*/
                number++;
            } 
            Console.WriteLine("-----------");
        }
    }
}

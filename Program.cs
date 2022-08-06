using System;
using System.Collections;

namespace ZooParkOfMadness
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfAnimals = GenerateListOfAnimals();
            var foodBasket = GenerateFoodBasket();
            int counter = 0;

            for (int i = 0; i < 5; i++)
            {
                foreach (Animal animal in listOfAnimals)
                {
                    if(animal.CheckIfCanSpeak())
                    {
                        FeedAnimal((string)foodBasket[counter], animal);
                        counter++;
                    }
                }
            }
            Console.WriteLine("======FINAL STATS========");

            foreach (Animal animal in listOfAnimals)
            {
                animal.PrintAnimalStats();
                Console.WriteLine("==============");
            }
        }

        static ArrayList GenerateListOfAnimals()
        {
            var list = new ArrayList();

            for (int i = 0; i < 10; i++)
            {
                list.Add(GenerateRandomAnimal());
            }
            return list;
        }

        static Animal GenerateRandomAnimal()
        {
            switch (new Random().Next(1, 4))
            {
                case 1:
                    return new Predator();

                case 2:
                    return new Vegan();

                case 3:
                    return new Omnivorous();

                default:
                    throw new Exception("ALIEN was produced. EXTERMINATED!");
            }
        }

        static ArrayList GenerateFoodBasket()
        {
            string[] options = new string[] { FoodOptions.MEAT, FoodOptions.VEGETABLE, FoodOptions.POISON };
            var list = new ArrayList();

            for (int i = 0; i < 50; i++)
            {
                list.Add(options[(new Random().Next(0, 3))]);
            }

            return list;
        }

        static void FeedAnimal(string food, Animal animal)
        {
            animal.Eat(food);
            if (animal.CheckIfCanSpeak())
            {
                Console.WriteLine("==============");
                animal.SayWhatIAmEating(food);
                animal.PrintAnimalStats();
                Console.WriteLine("==============");
            }
        }
    }
}

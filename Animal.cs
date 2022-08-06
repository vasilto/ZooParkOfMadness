using System;
using System.Collections.Generic;
using System.Text;
using RandomNameGeneratorLibrary;
namespace ZooParkOfMadness
{
    class Animal
    {
        
        private int hp;
        private bool IsAbleToSpeak;
        private string Name;
        public string TypeOfAnimal;

        public Animal()
        {
            this.hp = 5;
            IsAbleToSpeak = true;
            this.Name = new PersonNameGenerator().GenerateRandomFirstName();
        }

        public int GetHp()
        {
            return this.hp;
        }

        public string GetName()
        {
            return this.Name;
        }

        public String GetTypeOfAnimal()
        {
            return this.TypeOfAnimal;
        }

        bool AmIalive()
        {
            if (hp == 0)
            {
                return false;
            }
            else return true;
        }

        public bool CheckIfCanSpeak()
        {
            return AmIalive();
        }

        public void Eat(string food)
        {
            switch (this.TypeOfAnimal)
            {
                case AnimalTypes.OMNIVOROUS:
                    switch (food)
                    {
                        case "meat":
                            EatGoodFood();
                            break;
                        case "vegetable":
                            EatGoodFood();
                            break;
                        case "poison":
                            EatPoison();
                            break;
                    };
                    break;
                
                case AnimalTypes.PREDATOR:
                    switch (food)
                    {
                        case "meat":
                            EatGoodFood();
                            break;
                        case "vegetable":
                            EatBadFood();
                            break;
                        case "poison":
                            EatPoison();
                            break;
                    };
                    break;

                case AnimalTypes.VEGAN:
                    switch (food)
                    {
                        case "meat":
                            EatBadFood();
                            break;
                        case "vegetable":
                            EatGoodFood();
                            break;
                        case "poison":
                            EatPoison();
                            break;
                    };
                    break;

                default:
                    break;

            }

        }

        public void EatPoison()
        {
            this.hp = 0;
            Console.WriteLine("=========================");
            Console.WriteLine(GetName() + " is DEAD by poison");
            Console.WriteLine("=========================");
        }

        public void EatGoodFood()
        {
            if(this.hp < 5)
            {
                this.hp++;
            }
        }
        public void EatBadFood()
        {
            this.hp--;
            if(this.hp == 0)
            {
                Console.WriteLine("=========================");
                Console.WriteLine(GetName() + " is DEAD by bad food");
                Console.WriteLine("=========================");
            }
        }

        public void SayWhatIAmEating(string food)
        {
            Console.WriteLine("I am eating " + food);
        }

        public void PrintAnimalStats()
        {
            Console.WriteLine("My name is" + GetName());
            Console.WriteLine("My Type is" + GetTypeOfAnimal());
            Console.WriteLine("My HP is " + GetHp());
        }
    }
}

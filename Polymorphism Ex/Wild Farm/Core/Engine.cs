using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;

namespace WildFarm.Core
{
    public class Engine
    {
        private Animal animal;
        private List<Animal> animals;
        public Engine()
        {
            animals = new List<Animal>();
        }
        public void Run()
        {
            while (true)
            {
                var animalInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (animalInfo[0] == "End")
                {
                    break;
                }

                var foodInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                var name = animalInfo[1];
                var weight = double.Parse(animalInfo[2]);
                var foodQuantiti = int.Parse(foodInfo[1]);
                if (animalInfo[0] == "Hen")
                {

                    if (foodInfo[0] == "Fruit" || foodInfo[0] == "Meat" || foodInfo[0] == "Seeds" || foodInfo[0] == "Vegetable")
                    {
                        animal = new Hen(name, weight + 0.35 * foodQuantiti, foodQuantiti, double.Parse(animalInfo[3]));
                        Console.WriteLine(animal.ProducingSound());
                    }
                    else
                    {
                        animal = new Hen(name, weight, 0, double.Parse(animalInfo[3]));
                        Console.WriteLine(animal.ProducingSound());
                        Console.WriteLine($"{animalInfo[0]} does not eat {foodInfo[0]}!");
                    }
                }
                else if (animalInfo[0] == "Owl")
                {
                    if (foodInfo[0] == "Meat")
                    {
                        animal = new Owl(name, weight + 0.25 * foodQuantiti, foodQuantiti, double.Parse(animalInfo[3]));
                        Console.WriteLine(animal.ProducingSound());
                    }
                    else
                    {
                        animal = new Owl(name, weight, 0, double.Parse(animalInfo[3]));
                        Console.WriteLine(animal.ProducingSound());
                        Console.WriteLine($"{animalInfo[0]} does not eat {foodInfo[0]}!");
                    }
                }
                else if (animalInfo[0] == "Mouse")
                {
                    if (foodInfo[0] == "Fruit" || foodInfo[0] == "Vegetable")
                    {
                        animal = new Mouse(name, weight + 0.10 * foodQuantiti, foodQuantiti, animalInfo[3]);
                        Console.WriteLine(animal.ProducingSound());
                    }
                    else
                    {
                        animal = new Mouse(name, weight, 0, animalInfo[3]);
                        Console.WriteLine(animal.ProducingSound());
                        Console.WriteLine($"{animalInfo[0]} does not eat {foodInfo[0]}!");
                    }
                }
                else if (animalInfo[0] == "Cat")
                {
                    if (foodInfo[0] == "Vegetable" || foodInfo[0] == "Meat")
                    {
                        animal = new Cat(name, weight + 0.30 * foodQuantiti, foodQuantiti, animalInfo[3], animalInfo[4]);
                        Console.WriteLine(animal.ProducingSound());
                    }
                    else
                    {
                        animal = new Cat(name, weight, 0, animalInfo[3], animalInfo[4]);
                        Console.WriteLine(animal.ProducingSound());
                        Console.WriteLine($"{animalInfo[0]} does not eat {foodInfo[0]}!");
                    }
                }
                else if (animalInfo[0] == "Dog")
                {
                    if (foodInfo[0] == "Meat")
                    {
                        animal = new Dog(name, weight + 0.40 * foodQuantiti, foodQuantiti, animalInfo[3]);
                        Console.WriteLine(animal.ProducingSound());
                    }
                    else
                    {
                        animal = new Dog(name, weight, 0, animalInfo[3]);
                        Console.WriteLine(animal.ProducingSound());
                        Console.WriteLine($"{animalInfo[0]} does not eat {foodInfo[0]}!");
                    }
                }
                else if (animalInfo[0] == "Tiger")
                {
                    if (foodInfo[0] == "Meat")
                    {
                        animal = new Tiger(name, weight + 1 * foodQuantiti, foodQuantiti, animalInfo[3], animalInfo[4]);
                        Console.WriteLine(animal.ProducingSound());
                    }
                    else
                    {
                        animal = new Tiger(name, weight, 0, animalInfo[3], animalInfo[4]);
                        Console.WriteLine(animal.ProducingSound());
                        Console.WriteLine($"{animalInfo[0]} does not eat {foodInfo[0]}!");
                    }
                }

                animals.Add(animal);
            }

            foreach (var animall in animals)
            {
                Console.WriteLine(animall);
            }
        }
    }
}

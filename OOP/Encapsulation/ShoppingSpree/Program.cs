using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> peopleList = new List<Person>();
            List<Product> productsList = new List<Product>();

            string[] people = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);

            string[] products = Console.ReadLine()
            .Split(';', StringSplitOptions.RemoveEmptyEntries);

            try
            {
                for (int i = 0; i < people.Length; i++)
                {
                    string[] personInfo = people[i].Split('=');
                    peopleList.Add(new Person(personInfo[0], int.Parse(personInfo[1])));
                }

                for (int i = 0; i < products.Length; i++)
                {
                    string[] productInfo = products[i].Split('=');
                    productsList.Add(new Product(productInfo[0], int.Parse(productInfo[1])));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] splittedCommand = command.Split();

                var foundPerson = peopleList.Where(p => p.Name == splittedCommand[0]).FirstOrDefault();
                var foundProduct = productsList.Where(p => p.Name == splittedCommand[1]).FirstOrDefault();

                if (foundPerson.Money - foundProduct.Cost >= 0)
                {
                    foundPerson.Money -= foundProduct.Cost;
                    foundPerson.Products.Add(foundProduct);
                    Console.WriteLine($"{foundPerson.Name} bought {foundProduct.Name}");
                }
                else
                {
                    Console.WriteLine($"{foundPerson.Name} can't afford {foundProduct.Name}");
                }
            }

            foreach (var person in peopleList)
            {
                if (person.Products.Any())
                {
                    Console.Write(person.Name + " - ");
                    Console.WriteLine(string.Join(", ", person.Products));
                }
                else 
                {
                    Console.WriteLine($"{person.Name} - Nothing bought ");
                }
            }
        }
    }
}

using Debtor.Core;
using System;

namespace Debtor
{
    public class DebtorApp
    {
        public BorrowerManager BorrowerManager { get; set; } = new BorrowerManager();

        public void IntroduceDebtorApp()
        {
            Console.WriteLine("APLIKACJA DŁUŻNIK");
        }

        public void AddBorrower()
        {
            Console.WriteLine("Podaj nazwę dłużnika: ");

            var userName = Console.ReadLine();

            Console.WriteLine("Podaj kwotę długu: ");

            var userAmount = Console.ReadLine();

            decimal amountInDecimal = default(decimal);

            while (!decimal.TryParse(userAmount, out amountInDecimal))
            {
                Console.WriteLine("Podano błędną kwotę!");

                Console.WriteLine("Podaj kwotę długu: ");

                userAmount = Console.ReadLine();
            }

            BorrowerManager.AddBorrower(userName, amountInDecimal);
        }

        public void DeleteBorrower()
        {
            Console.WriteLine("Podaj nazwę dłużnika, którego chcesz usunąć: ");

            var userName = Console.ReadLine();

            BorrowerManager.DeleteBorrower(userName);

            Console.WriteLine("Udało się usunąć dłużnika :) ");
        }

        public void ListAllBorrowers()
        {
            Console.WriteLine("Lista Twoich dłużników: ");

            foreach (var borrower in  BorrowerManager.ListBorrowers())
            {
                Console.WriteLine(borrower);
            }
        }

        public void ExitBorrower()
        {

        }

        public void AskForAction()
        {
            Console.WriteLine("Jaką czynność chcesz wykonać: ");

            var userInput = default(string);

            while (userInput != "exit")
            {
                Console.WriteLine("add - Dodać dłużnika");
                Console.WriteLine("del - Usunąć dłużnika");
                Console.WriteLine("list - Wypisanie listy dłużników");
                Console.WriteLine("exit - Wyjście z programu");

                userInput = Console.ReadLine();
                userInput = userInput.ToLower();

                switch (userInput)
                {
                    case "add":
                        AddBorrower();
                        break;
                    case "del":
                        DeleteBorrower();
                        break;
                    case "list":
                        ListAllBorrowers();
                        break;
                    case "exit":
                        ExitBorrower();
                        break;

                    default:
                        Console.WriteLine("Podano złą wartość!");
                        break;
                }
            }
        }
    }
}

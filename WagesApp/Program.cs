//imports
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagesApp
{
    class Program
    {
        //global variables
        static string topEarner = "";
        static int topEarnerHours = -1;

        //methods and/or functions

        static string CheckFlag()
        {
            while (true)
            {
                //get user's choice
                Console.WriteLine("Press <ENTER> to add another employee or type 'XXX' to quit\n");
                string userInput = Console.ReadLine();

                //Convert user input to uppercase
                userInput = userInput.ToUpper();

                if (userInput.Equals("XXX") || userInput.Equals("") )
                {
                    return userInput;
                }
                Console.WriteLine("Error: Please enter a correct  choice.");
            }
        }

        static string CheckName()
        {
            while (true)
            {
                //get name
                Console.WriteLine("Enter the employee's name:\n");
                string name = Console.ReadLine();

                if (!name.Equals(""))
                {
                    //convert employee name to capitalised name
                    name = name[0].ToString().ToUpper() + name.Substring(1);

                    return name;
                }
                Console.WriteLine("Error: You must enter a name for the employee");
            }
        }




            static void CalculateWages(int totalHoursWorked, string employeeName)
        {
            //Display the total weekly hours stored
            Console.WriteLine($"Total hours worked : {totalHoursWorked}hrs");


            //Add 5 hours if sumHours >30
            if (totalHoursWorked >= 30)
            {
                totalHoursWorked += 5;

                //If bonus hours have been given display correct amount
                Console.WriteLine($"5 bonus hours added: {totalHoursWorked}hrs");
            }

            if (totalHoursWorked > topEarnerHours)
            {
                topEarnerHours = totalHoursWorked;
                topEarner = employeeName;

            }

            //Calculate wage at a rate of $22/hr

            int wages = totalHoursWorked * 22;

            float tax = 0.07f;

            //Calculate tax
            if (wages > 450)
            {
                tax = 0.08f;
            }

            //Calculate final pay

            float finalPay = wages - (float)Math.Round(wages * tax,2);

            //Display the results of the calculations followed by two blank lines
            Console.WriteLine($"Weekly Pay: {wages}\n" +
                $"Tax Rate: {tax}\n" +
                $"Tax: {Math.Round(wages * tax, 2)}\n" +
                $"Final Pay: {finalPay}\n\n\n");
        }

        static void OneEmployee()
        {
            List<string> weekDays = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

            //Enter and store employee name
            string employeeName = CheckName();

            Console.Clear();

            Console.WriteLine("----------Employee Summary----------\n");


            //Display employee name
            Console.WriteLine(employeeName);

            Random randGen = new Random();
            int sumHoursWorked = 0;

            //Loop 5 times
            for (int dayIndex = 0; dayIndex < 5; dayIndex++)
            {
                

                //Randomly generate the number of hours worked by a worker each day
                int hoursWorked = randGen.Next(2, 7);


                //Assign the name of the day of the week to a variable called day

                string day = weekDays[dayIndex];

                //Store the total number of hours worked over the five days
                sumHoursWorked += hoursWorked;


                //Display the name of the day and the number of hours generated for each worker
                Console.WriteLine($"\tHours worked on {day}: {hoursWorked}");

            }




            // Call the CalculateWages()
            CalculateWages(sumHoursWorked, employeeName);
        }


        //when run or main process
        static void Main(string[] args)
        {
            Console.WriteLine(" _    _    __    ___  ____  ___      __    ____  ____ \n"+
                @"( \/\/ )  /__\  / __)( ___)/ __)    /__\  (  _ \(  _ \ "+"\n" +
                @" )    (  /(__)\( (_-. )__) \__ \   /(__)\  )___/ )___/ "+"\n" +
                @"(__/\__)(__)(__)\___/(____)(___/  (__)(__)(__)  (__)  "+"\n");

            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine(
                "INTRODUCTION:\n" +
                "Wages App will calculate the wages for each employee\n and display the hours worked for the week." +
                "It will \nproduce an employee summary, showing the tax to be \ndeducted and the total amount owed after tax." +
                "\nLastly, Wages App will display which employee \nworked the most hours for he week.");
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\n");

            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            Console.Clear();

            string flagMain = "";
            while (!flagMain.Equals("XXX"))
            {
                Console.WriteLine("---------- Employee Details ----------\n");
                OneEmployee();


                flagMain = CheckFlag();

                Console.Clear();
            }

            Console.WriteLine($"{topEarner} has the most hours worked: {topEarnerHours}hrs");
            
        }
    }
}

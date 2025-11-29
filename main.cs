// See https://aka.ms/new-console-template for more information
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using System.Text;
namespace Lab3csharp;

public class Lab3
{
    public static void Main(string[] args)
    {  
        int menuControl = 1;
        while(menuControl != 0)
        {   
            Console.WriteLine("Select task for Lab1: ");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Task 1");
            Console.WriteLine("2 - Task 2");
            Console.WriteLine("3 - Task 3");
            string menuInput = Console.ReadLine();
            menuControl = int.Parse(menuInput);
            switch (menuControl)
            {
                case 0: Console.WriteLine ("Exiting"); break;
                case 1: Task1.Exercise1(args); break;
                case 2: Task2.Exercise2(args); break;
                case 3: Task3.Exercise3(args); break;
                default: Console.WriteLine("You chose wrong!!!"); break;
            }
        } 
        
    }
}

//


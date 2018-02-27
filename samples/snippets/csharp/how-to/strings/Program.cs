﻿using System;

namespace HowToStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============================  String.Split examples =================================================");
            Console.WriteLine();
            ParseStringsUsingSplit.Examples();
            Console.WriteLine("============================  String concatenation examples =================================================");
            Console.WriteLine();
            Concatenate.Examples();
            Console.WriteLine("============================  String Searching examples =================================================");
            Console.WriteLine();
            SearchStrings.Examples();
        }
    }
}

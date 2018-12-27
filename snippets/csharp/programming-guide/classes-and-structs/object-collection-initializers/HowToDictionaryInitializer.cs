﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace object_collection_initializers
{
    public class HowToDictionaryInitializer
    {
        // <SnippetHowToDictionaryInitializer>
        class StudentName
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int ID { get; set; }
        }

        public static void Main()
        { 
            Dictionary<int, StudentName> students = new Dictionary<int, StudentName>()
            {
                { 111, new StudentName { FirstName="Sachin", LastName="Karnik", ID=211 } },
                { 112, new StudentName { FirstName="Dina", LastName="Salimzianova", ID=317 } },
                { 113, new StudentName { FirstName="Andy", LastName="Ruth", ID=198 } }
            };

            foreach(var index in Enumerable.Range(111, 3))
            {
                Console.WriteLine($"Student {index} is {students[index].FirstName} {students[index].FirstName}");
            }

            Dictionary<int, StudentName> students2 = new Dictionary<int, StudentName>()
            {
                [111] = new StudentName { FirstName="Sachin", LastName="Karnik", ID=211 },
                [112] = new StudentName { FirstName="Dina", LastName="Salimzianova", ID=317 } ,
                [113] = new StudentName { FirstName="Andy", LastName="Ruth", ID=198 }
            };

            foreach (var index in Enumerable.Range(111, 3))
            {
                Console.WriteLine($"Student {index} is {students[index].FirstName} {students[index].FirstName}");
            }
        }
        // </SnippetHowToDictionaryInitializer>
    }
}

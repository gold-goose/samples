using System;
using System.Collections.Generic;

namespace operators
{
    public static class DelegateOperator
    {
        public static void Examples()
        {
            AnonymousMethod();
            Lambda();
            WithoutParameterList();
        }

        private static void AnonymousMethod()
        {
            // <SnippetAnonymousMethod>
            Func<int, int, int> sum = delegate (int a, int b) { return a + b; };
            Console.WriteLine(sum(3, 4));  // output: 7
            // </SnippetAnonymousMethod>
        }

        private static void Lambda()
        {
            // <SnippetLambda>
            Func<int, int, int> sum = (a, b) => a + b;
            Console.WriteLine(sum(3, 4));  // output: 7
            // </SnippetLambda>
        }

        private static void WithoutParameterList()
        {
            // <SnippetWithoutParameterList>
            Action greet = delegate { Console.WriteLine("Hello!"); };
            greet();
            
            Action<int, double> introduce = delegate { Console.WriteLine("This is world!"); };
            introduce(42, 2.7);

            // Output:
            // Hello!
            // This is world!
            // </SnippetWithoutParameterList>
        }
    }
}
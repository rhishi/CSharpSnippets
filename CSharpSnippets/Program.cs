using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpSnippets
{
    class Program
    {
        static void Main(string[] args)
        {
            // First thing, the Hello World!
            Console.WriteLine("Hello World");

            // Let's try out numeric format printing
            // F, G, #.###, 0.###, N

            var values = new[] { 1.2, 23.345, 45629.1, 3.22819, 3.22889, 0, -12.65389967, 525, 5025, 50025 };

            Console.WriteLine("{0,15} {1,15} {2,15} {3,15} {4,15}", "{0,15:F3}", "{0,15:G4}", "{0,15:#.###}", "{0,15:0.###}", "{0,15:N}");
            foreach (var val in values)
            {
                Console.WriteLine("{0,15:F3} {0,15:G4} {0,15:#.###} {0,15:0.###} {0,15:N}", val);
            }
            Console.WriteLine();

            // Let's test the odd behaviour of loop variable in lambda.
            TestForLoopVariableInLambda();
            TestForEachLoopVariableInLambda();
        }

        static void TestForLoopVariableInLambda()
        {
            // Example taken from Brian's blog post
            // https://lorgonblog.wordpress.com/2008/11/12/on-lambdas-capture-and-mutability/
            // This will print 10, 10, 10, 10, 10.

            List<Func<int>> functions = new List<Func<int>>();
            for (int i = 0; i < 5; ++i)
            {
                functions.Add(() => i * 2);
            }
            foreach (var function in functions)
            {
                Console.WriteLine(function());
            }
            Console.WriteLine();
        }

        static void TestForEachLoopVariableInLambda()
        {
            // ForEach version of example taken from Brian's blog post
            // https://lorgonblog.wordpress.com/2008/11/12/on-lambdas-capture-and-mutability/
            // This will print 0, 2, 4, 6, 8.

            List<Func<int>> functions = new List<Func<int>>();
            foreach (int i in Enumerable.Range(0, 5))
            {
                functions.Add(() => i * 2);
            }
            foreach (var function in functions)
            {
                Console.WriteLine(function());
            }
            Console.WriteLine();
        }
    }
}

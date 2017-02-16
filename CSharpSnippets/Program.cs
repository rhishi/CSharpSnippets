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

            // Let's understand the basics of Nullable<T> type.
            NullableBasics.TryCastingToBool();
            NullableBasics.UnderstandNullable();

            UnderstandEquality();
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

        static void UnderstandEquality()
        {
            object abc = "abc";
            string abcStr = "a" + "b" + "c";
            Console.WriteLine("abc == abcStr           = {0}", abc == abcStr);  // True.  CS0252 warning: possible unintended reference comparison
            Console.WriteLine("abc as string == abcStr = {0}", abc as string == abcStr);  // True
            Console.WriteLine("abc.Equals(abcStr)      = {0}", abc.Equals(abcStr));       // True

            abc = null;
            Console.WriteLine("abc == abcStr           = {0}", abc == abcStr);  // False. CS0252 warning: possible unintended reference comparison
            Console.WriteLine("abc as string == abcStr = {0}", abc as string == abcStr);  // False
            try
            {
                Console.WriteLine("abc.Equals(abcStr)      = {0}", abc.Equals(abcStr));
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("abc.Equals(abcStr)      = {0}", "NullReferenceException");
            }

            object z123 = "0123";
            string z123Str = Enumerable.Range(0, 4).Aggregate(string.Empty, (str, elt) => str + elt);
            Console.WriteLine("z123 == z123Str           = {0}", z123 == z123Str);  // False. CS0252 warning: possible unintended reference comparison
            Console.WriteLine("z123 as string == z123Str = {0}", z123 as string == z123Str);  // True
            Console.WriteLine("z123.Equals(z123Str)      = {0}", z123.Equals(z123Str));       // True
        }
    }
}

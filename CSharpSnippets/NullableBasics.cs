using System;
using System.Collections.Generic;

namespace CSharpSnippets
{
    public static class NullableBasics
    {
        public static void UnderstandNullable()
        {
            // Nullable<bool> is same as bool? and it's a value type.

            var nullableBoolType = typeof(bool?);
            Console.WriteLine("typeof(bool?)                 = {0}", nullableBoolType);              // System.Nullable`1[System.Boolean]
            Console.WriteLine("typeof(bool?).IsValueType     = {0}", nullableBoolType.IsValueType);  // True
            Console.WriteLine();

            // GetType() on Nullable<T> gives T.

            var nullableInt = new Nullable<int>(23);
            Console.WriteLine("nullableInt.GetType() = {0}", nullableInt.GetType());
            Console.WriteLine();

            // For bool? with underlying value true, HasValue returns true,
            // "is" checks against bool and bool? also return true,
            // surprisingly, GetType() returns the undering type, bool, instead of bool?.

            Console.WriteLine("For bool? with value true:");
            var nullableBoolValue = (bool?)true;
            Console.WriteLine("  ReferenceEquals(null, nullableBoolValue)   = {0}", ReferenceEquals(null, nullableBoolValue));  // False
            Console.WriteLine("  ReferenceEquals(nullableBoolValue, null)   = {0}", ReferenceEquals(nullableBoolValue, null));  // False
            Console.WriteLine("  nullableBoolValue.HasValue                 = {0}", nullableBoolValue.HasValue);  // True
            Console.WriteLine("  nullableBoolValue.GetType()                = {0}", nullableBoolValue.GetType()); // System.Boolean
            Console.WriteLine("  nullableBoolValue is bool?                 = {0}", nullableBoolValue is bool?);  // True
            Console.WriteLine("  nullableBoolValue is bool                  = {0}", nullableBoolValue is bool);   // True
            Console.WriteLine("  (bool)nullableBoolValue                    = {0}", (bool)nullableBoolValue);     // True
            Console.WriteLine();

            // Let's assign null to a bool? variable.
            // HasValue returns false, understandably.
            // ReferenceEquals w.r.t. null returns true!
            // That raises questions:
            // 1) Isn't Nullable<bool> a value type, and hence cannot have null value?
            // 2) If the value is null, how does value.HasValue not give a NullReferenceException?!
            // .GetType() causes NullReferenceException.
            // "is" checks against bool? and bool return false.
            // cast to (bool?) works okay.
            // cast to (bool) fails in two different ways: either InvalidOperationException or NullReferenceException.

            Console.WriteLine("For bool? with value null:");
            nullableBoolValue = null;
            Console.WriteLine("  ReferenceEquals(null, nullableBoolValue)   = {0}", ReferenceEquals(null, nullableBoolValue));  // True!!
            Console.WriteLine("  ReferenceEquals(nullableBoolValue, null)   = {0}", ReferenceEquals(nullableBoolValue, null));  // True!!
            Console.WriteLine("  nullableBoolValue.HasValue                 = {0}", nullableBoolValue.HasValue);  // False
            try
            {
                Console.WriteLine("  nullableBoolValue.GetType()                = {0}", nullableBoolValue.GetType());
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("  nullableBoolValue.GetType()                = {0}", "throws NullReferenceException");
            }
            Console.WriteLine("  nullableBoolValue is bool?                 = {0}", nullableBoolValue is bool?);        // False !!!
            Console.WriteLine("  nullableBoolValue is bool                  = {0}", nullableBoolValue is bool);         // False

            Console.WriteLine("  (bool?)nullableBoolValue                   = {0}", (bool?)nullableBoolValue);          // Empty string 
            Console.WriteLine("  (object)nullableBoolValue                  = {0}", (object)nullableBoolValue);         // Empty string
            Console.WriteLine("  (bool?)(object)nullableBoolValue           = {0}", (bool?)(object)nullableBoolValue);  // Empty string
            try
            {
                Console.WriteLine("  (bool)nullableBoolValue                    = {0}", (bool)nullableBoolValue);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("  (bool)nullableBoolValue                    = {0}", "throws InvalidOperationException");
            }
            try
            {
                Console.WriteLine("  (bool)(object)nullableBoolValue            = {0}", (bool)(object)nullableBoolValue);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("  (bool)(object)nullableBoolValue            = {0}", "throws NullReferenceException");
            }
            Console.WriteLine();

            // assigning null is same as assigning new Nullable<bool>().  Same results as above.

            Console.WriteLine("For default Nullable<bool>:");
            var defaultNullableBool = new Nullable<bool>();
            Console.WriteLine("  ReferenceEquals(null, defaultNullableBool) = {0}", ReferenceEquals(null, defaultNullableBool));  // True!!
            Console.WriteLine("  ReferenceEquals(defaultNullableBool, null) = {0}", ReferenceEquals(defaultNullableBool, null));  // True!!
            Console.WriteLine("  defaultNullableBool.HasValue               = {0}", defaultNullableBool.HasValue);  // False
            try
            {
                Console.WriteLine("  defaultNullableBool.GetType()              = {0}", defaultNullableBool.GetType());
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("  defaultNullableBool.GetType()              = {0}", "throws NullReferenceException");
            }
            Console.WriteLine("  defaultNullableBool is bool?               = {0}", defaultNullableBool is bool?);        // False !!!
            Console.WriteLine("  defaultNullableBool is bool                = {0}", defaultNullableBool is bool);         // False

            Console.WriteLine("  (bool?)defaultNullableBool                 = {0}", (bool?)defaultNullableBool);          // Empty string
            Console.WriteLine("  (object)defaultNullableBool                = {0}", (object)defaultNullableBool);         // Empty string
            Console.WriteLine("  (bool?)(object)defaultNullableBool         = {0}", (bool?)(object)defaultNullableBool);  // Empty string
            try
            {
                Console.WriteLine("  (bool)defaultNullableBool                  = {0}", (bool)defaultNullableBool);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("  (bool)defaultNullableBool                  = {0}", "throws InvalidOperationException");
            }
            try
            {
                Console.WriteLine("  (bool)(object)defaultNullableBool          = {0}", (bool)(object)defaultNullableBool);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("  (bool)(object)defaultNullableBool          = {0}", "throws NullReferenceException");
            }
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();

            // System.Boolean i.e. bool value can be converted to (bool?) easily.

            Console.WriteLine("For bool with value true:");
            var boolValue = true;
            Console.WriteLine("  boolValue.HasValue          = {0}", "does not compile" /* boolValue.HasValue */ );
            Console.WriteLine("  boolValue.GetType()         = {0}", boolValue.GetType());        // System.Boolean
            Console.WriteLine("  boolValue is bool?          = {0}", boolValue is bool?);         // True
            Console.WriteLine("  boolValue is bool           = {0}", boolValue is bool);          // True
            Console.WriteLine("  (bool?)boolValue            = {0}", (bool?)boolValue);           // True
            Console.WriteLine();

            // null "is" not of any type.  That's good.

            Console.WriteLine("  null is bool?               = {0}", null is bool?);              // False
            Console.WriteLine("  null is bool                = {0}", null is bool);               // False
            Console.WriteLine("  null is object              = {0}", null is object);             // False
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();
        }

        public static void TryCastingToBool()
        {
            var objects = new Dictionary<string, object>
                {
                    { "nullObject", null },
                    { "falseObject", false },
                    { "intObject", 5 },
                    { "stringObject", "abc" },
                    { "nullableBoolNull", (bool?)null },
                    { "nullableBoolTrue", (bool?)true },
                    { "nullableBoolDefault", new Nullable<bool>() }
                };

            foreach (var kvp in objects)
            {
                var name = kvp.Key;
                var obj = kvp.Value;
                var type = obj?.GetType();
                if (type != null)
                {
                    Console.WriteLine("{0,-20} is {1,-15}: isPrimitive = {2,5}, valueType = {3,5}",
                                      name, type, type.IsPrimitive, type.IsValueType);
                }
                else
                {
                    Console.WriteLine("{0,-20} is {1,-15}: isPrimitive = {2,5}, valueType = {3,5}",
                                      name, "??", "??", "??");
                }
            }
            Console.WriteLine();

            // null object cannot be cast to bool.  You get NullReferenceException.
            try
            {
                var boolValue = (bool)objects["nullObject"];
                Console.WriteLine("FAIL: (bool)nullObject succeeded and returned {0},", boolValue);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("PASS: (bool)nullObject threw NullReferenceException");
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("FAIL: (bool)nullObject threw InvalidCastException");
            }

            // false object can be cast to bool.
            try
            {
                var boolValue = (bool)objects["falseObject"];
                Console.WriteLine("PASS: (bool)falseObject succeeded and returned {0}", boolValue);
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("FAIL: (bool)falseObject threw InvalidCastException");
            }

            // int object cannot be cast to bool.  You get InvalidCastException.
            try
            {
                var boolValue = (bool)objects["intObject"];
                Console.WriteLine("FAIL: (bool)intObject succeeded and returned {0},", boolValue);
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("PASS: (bool)intObject threw InvalidCastException");
            }

            // string object cannot be cast to bool.  You get InvalidCastException.
            try
            {
                var boolValue = (bool)objects["stringObject"];
                Console.WriteLine("FAIL: (bool)stringObject succeeded and returned {0},", boolValue);
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("PASS: (bool)stringObject threw InvalidCastException");
            }

            // (bool?)null object cannot be cast to bool  You get NullReferenceException.
            try
            {
                var boolValue = (bool)objects["nullableBoolNull"];
                Console.WriteLine("FAIL: (bool)nullableBoolNull succeeded and returned {0},", boolValue);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("PASS: (bool)nullableBoolNull threw NullReferenceException");
            }

            // (bool?)true object can be cast to bool.
            try
            {
                var boolValue = (bool)objects["nullableBoolTrue"];
                Console.WriteLine("PASS: (bool)nullableBoolTrue succeeded and returned {0}", boolValue);
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("FAIL: (bool)nullableBoolTrue threw InvalidCastException");
            }

            // new Nullable<bool>() object cannot be cast to bool.  You get NullReferenceException.
            try
            {
                var boolValue = (bool)objects["nullableBoolDefault"];
                Console.WriteLine("FAIL: (bool)nullableBoolDefault succeeded and returned {0},", boolValue);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("PASS: (bool)nullableBoolDefault threw NullReferenceException");
            }

            // new Nullable<bool>(), without loss of type information, cannot be cast to bool.  You get InvalidOperationException.
            try
            {
                var boolValue = (bool)new Nullable<bool>();
                Console.WriteLine("FAIL: (bool)new Nullable<bool>() succeeded and returned {0},", boolValue);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("PASS: (bool)new Nullable<bool>() threw InvalidOperationException");
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        // Empowered by the trials above, we write five variants of Invert method.
        // Upon running IntelliTest on them, we confirm the their input/output behaviour.
        // 
        //           null        object      false
        // Invert1   NullRefEx   InvCastEx   true
        // Invert2   null        InvCastEx   true 
        // Invert3   false       InvCastEx   true
        // Invert4   true        InvCastEx   true
        // Invert5   false       false       true
          
        public static object Invert1(object value)
        {
            return !(bool)value;
        }

        public static object Invert2(object value)
        {
            return !(bool?)value;
        }

        public static object Invert3(object value)
        {
            var boolValue = (bool?)value;
            return boolValue.HasValue && !boolValue.Value;
        }

        public static object Invert4(object value)
        {
            var nullableBoolValue = (bool?)value;
            var boolValue = nullableBoolValue ?? false;
            return !boolValue;
        }

        public static object Invert5(object value)
        {
            var boolValue = value as bool?;
            return boolValue.HasValue && !boolValue.Value;
        }
    }
}

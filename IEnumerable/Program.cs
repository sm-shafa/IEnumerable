using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IEnumerable
{
    class Program
    {
        static int[,] _grid = new int[15, 15];

        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with IEnumerable / IEnumerator *****\n ForEach:");

            Garage carLot = new Garage();
            // Hand over each car in the collection?
            foreach (Car c in carLot)
            {
                Console.WriteLine("{0} is going {1} MPH",
                c.PetName, c.CurrentSpeed);
            }

            Console.WriteLine("Manually work with IEnumerator:");

           
            // Manually work with IEnumerator.
            IEnumerator i = carLot.GetEnumerator();
            while (i.MoveNext())
            {
                //i.MoveNext();
                Car myCar = (Car)i.Current;
                Console.WriteLine("{0} is going {1} MPH", myCar.PetName, myCar.CurrentSpeed);
            }


            //*****************************************
            //Other example of Enumeatratop:

            //1:*
            Console.WriteLine("Other example of IEnumerator:");
            Display(new List<bool> { true, false, true });
            //*

            //2:**
            IEnumerable<int> result = from value in Enumerable.Range(0, 2)
                                      select value;

            // Loop.
            foreach (int value in result)
            {
                Console.WriteLine(value);
            }

            // We can use extension methods on IEnumerable<int>
            double average = result.Average();

            // Extension methods can convert IEnumerable<int>
            List<int> list = result.ToList();
            int[] array = result.ToArray();
            //**

            //3:***
            // Initialize some elements in 2D array.
            _grid[0, 1] = 4;
            _grid[4, 4] = 5;
            _grid[14, 2] = 3;

            // Sum values in 2D array.
            int sum = 0;
            foreach (int value in GridValues())
            {
                sum += value;
            }
            // Write result.
            Console.WriteLine("SUMMED 2D ELEMENTS: " + sum);
            //***


            //4:****
            Example example = new Example(
            new string[] { "cat", "dog", "bird" });
            // The foreach-loop calls the generic GetEnumerator method.
            // ... It then uses the List's Enumerator.
            foreach (string element in example)
            {
                Console.WriteLine(element);
            }
            //****
            Console.ReadLine();
        }

        static void Display(IEnumerable<bool> argument)
        {
            foreach (bool value in argument)
            {
                Console.WriteLine(value);
            }
        }

        public static IEnumerable<int> GridValues()
        {
            // Use yield return to return all 2D array elements.
            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    yield return _grid[x, y];
                }
            }
        }
    }


    /*Sadly, the compiler informs you that the Garage class does not implement a method named GetEnumerator(). 
    This method is formalized by the IEnumerable interface, 
    which is found lurking within the System.Collections namespace.
    Classes or structures that support this behavior advertise that they are able to expose contained subitems to the caller 
    (in this example, the foreach keyword itself). Here is the definition of this standard .NET interface:*/

    // This interface informs the caller
    // that the object's subitems can be enumerated.
    //public interface IEnumerable
    //{
    //    IEnumerator GetEnumerator();
    //}

    /*As you can see, the GetEnumerator() method returns a reference to yet another interface named 
     System.Collections.IEnumerator.This interface provides the infrastructure to allow the 
     caller to traverse the internal objects contained by the IEnumerable-compatible container:*/

    // This interface allows the caller to
    // obtain a container's subitems.
    //public interface IEnumerator
    //{
    //    bool MoveNext(); // Advance the internal position of the cursor.
    //    object Current { get; } // Get the current item (read-only property).
    //    void Reset(); // Reset the cursor before the first member.
    //}

    /*If you want to update the Garage type to support these interfaces, 
        you could take the long road and implement each method manually.
        While you are certainly free to provide customized versions of
        GetEnumerator(), MoveNext(), Current, and Reset(), there is a simpler way.
        As the System.Array type(as well as many other collection classes)
        already implements IEnumerable and IEnumerator, 
        you can simply delegate the request to the System.Array as follows:*/
}

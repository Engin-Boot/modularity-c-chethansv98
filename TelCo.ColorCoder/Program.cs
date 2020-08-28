using System;
using System.Diagnostics;
using System.Drawing;
using TelCo.ColorCoder;
using static TelCo.ColorCoder.Color;

namespace TelCo.ColorCoder
{
    class Program
    {
        public static void Main(string[] args)
        {
            int pairNumber = 4;
            Pair testPair1 = GetColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Color: {1}\n", pairNumber, testPair1);
            Debug.Assert(testPair1.majorColor == Color.White);  
            Debug.Assert(testPair1.minorColor == Color.Brown);

            pairNumber = 5;
            testPair1 = GetColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Color: {1}\n", pairNumber, testPair1);
            Debug.Assert(testPair1.majorColor == Color.White);
            Debug.Assert(testPair1.minorColor == Color.SlateGray);

            pairNumber = 23;
            testPair1 = GetColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Color: {1}\n", pairNumber, testPair1);
            Debug.Assert(testPair1.majorColor == Color.Violet);
            Debug.Assert(testPair1.minorColor == Color.Green);

            Pair testPair2 = new Pair() { majorColor = Color.Yellow, minorColor = Color.Green };
            pairNumber = GetPairNumberFromColor(testPair2);
            Console.WriteLine("[In]Color: {0}, [Out] PairNumber: {1}\n", testPair2, pairNumber);
            Debug.Assert(pairNumber == 18);

            testPair2 = new Pair() { majorColor = Color.Red, minorColor = Color.Blue };
            pairNumber = GetPairNumberFromColor(testPair2);
            Console.WriteLine("[In]Color: {0}, [Out] PairNumber: {1}", testPair2, pairNumber);
            Debug.Assert(pairNumber == 6);
        }
    }
}

using System;
using System.Linq;
class Program
{
    static void Main(string[] args) { 
        int[] array = new int[] { 1, 2, 3, 4, 5 }; array = array.Select(n => n + 2).ToArray(); foreach (var item in array) Console.WriteLine(item); }
}

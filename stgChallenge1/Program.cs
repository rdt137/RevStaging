using System;
using System.Collections.Generic;

namespace stgChallenge1
{
  class Program
  {
    static void Main(string[] args)
    {
      int num;
      int den;

      Console.Write("Enter Num: ");
      int.TryParse(Console.ReadLine(), out num);
      Console.WriteLine();

      Console.Write("Enter Den: ");
      int.TryParse(Console.ReadLine(), out den);

      var result = getFraction(num, den);

      Console.WriteLine("\n" + result);
    }

    static string getFraction(int n, int d)
    {
      var decRepeating = new Dictionary<string, string>();
      var dec = new List<string>();
      int decPart;
      int counter = 0;
      int rem = n % d;

      dec.Add((n / d).ToString());
      dec.Add(".");

      if (ifRepeating(d))
      {
        while (rem != 0 && counter < 10)
        {
          decPart = (rem * 10) / d;

          // if(decRepeating[decPart.ToString()] == "1")
          //   decRepeating[decPart.ToString()] = "> 1";
          
          decRepeating[decPart.ToString()] = "1";
          dec.Add(decPart.ToString());
          rem = (rem * 10) % d;
          counter++;
        }

        return (n / d).ToString() + ".(" + string.Join("", decRepeating.Keys) + ")";
      }
      else
      {
        while (rem != 0 && counter < 10)
        {
          decPart = (rem * 10) / d;
          dec.Add(decPart.ToString());
          rem = (rem * 10) % d;
          counter++;
        }

        return string.Join("", dec);
      }
    }

    static bool ifRepeating(int d)
    {
      int b;
      var primes = new List<int>();
      for (b = 2; d > 1; b++)
      {
        if (d % b == 0)
        {
          int x = 0;
          while (d % b == 0)
          {
            d /= b;
            x++;
          }

          primes.Add(b);
        }
      }

      return !ContainsOnly(primes);
    }

    static bool ContainsOnly(List<int> primes)
    {
      var approved = new List<int> { 2, 5 };
      foreach (var item in primes)
      {
        if (!approved.Contains(item)) { return false; }
      }

      return true;
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCommonSubstring
{
  class Program
  {
    static void Main(string[] args)
    {

      string str1 = "if (data[i].Equals(item))";
      string str2 = "if ((dynamic)data[i] == item)";

      string[,] Memoire = new string[str1.Length, str2.Length];

      string lcs = GetLCS(str1, str2, 0, 0, Memoire);

      foreach (var c in str1)
      {
        if (!lcs.Contains(c))
        {
          Console.BackgroundColor = ConsoleColor.Red;
          Console.ForegroundColor = ConsoleColor.Black;
          Console.Write(c);
          Console.ForegroundColor = ConsoleColor.White;
          Console.BackgroundColor = ConsoleColor.Black;
        }
        else
          Console.Write(c);
      }

      Console.WriteLine();

      foreach (var c in str2)
      {
        if (!lcs.Contains(c))
        {
          Console.BackgroundColor = ConsoleColor.Green;
          Console.ForegroundColor = ConsoleColor.Black;
          Console.Write(c);
          Console.ForegroundColor = ConsoleColor.White;
          Console.BackgroundColor = ConsoleColor.Black;
        }
        else
          Console.Write(c);
      }

      Console.ReadKey();
    }

    public static string GetLCS(string Str1, string Str2, int Index1, int Index2, string[,] Memoire)
    {
      if (Index1 == Str1.Length || Index2 == Str2.Length)
        return "";

      if (!string.IsNullOrEmpty(Memoire[Index1, Index2]))
        return Memoire[Index1, Index2];

      if (Str1[Index1] == Str2[Index2])
      {
        Memoire[Index1, Index2] = Str1[Index1] + GetLCS(Str1, Str2, Index1 + 1, Index2 + 1, Memoire);
        return Memoire[Index1, Index2];
      }

      string s;

      string s1 = GetLCS(Str1, Str2, Index1 + 1, Index2, Memoire);
      string s2 = GetLCS(Str1, Str2, Index1, Index2 + 1, Memoire);

      if (s1.Length > s2.Length)
        s = s1;
      else
        s = s2;
      Memoire[Index1, Index2] = s;
      return Memoire[Index1, Index2];
    }
  }
}

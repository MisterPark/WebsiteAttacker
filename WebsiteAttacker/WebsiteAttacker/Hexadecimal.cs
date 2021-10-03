using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebsiteAttacker
{
  class Hexadecimal
  {
    private ulong value = 0;
    
    public void Increase()
    {
      value++;
    }

    public void Decrease()
    {
      value--;
    }

    public static Hexadecimal From(ulong value)
    {
      Hexadecimal ret = new Hexadecimal();
      ret.value = value;
      return ret;
    }

    public static Hexadecimal From(string value)
    {
      if (value.Length == 0) return null;
      if (value.Length > 16) return null;
      if (Regex.IsMatch(value, @"[^0-9a-fA-F]")) return null;

      ulong sum = 0;
      uint exponent = 0;
      for (int i = value.Length-1; i >= 0 ; i--)
      {
        ulong val = 0;
        if(value[i] < 0x40)
        {
          val = value[i] - (uint)0x30;
        }
        else
        {
          val = CharToUlong(value[i]);
        }

        sum += val * (ulong)Math.Pow(16, exponent);
        exponent++;
      }

      Hexadecimal ret = new Hexadecimal();
      ret.value = sum;
      return ret;
    }

    public ulong ToUlong()
    {
      return value;
    }

    public override string ToString()
    {
      ulong val = value;
      string ret = string.Empty;
      for (int i = 0; i < 16; i++) 
      {
        ulong a = val % 16;
        ret = UlongToChar(a) + ret;
        val = val / 16;
      }
      return ret;
    }

    public string ToString(int count)
    {
      ulong val = value;
      string ret = string.Empty;
      for (int i = 0; i < count; i++)
      {
        ulong a = val % 16;
        ret = UlongToChar(a) + ret;
        val = val / 16;
      }
      return ret;
    }

    private static ulong CharToUlong(char hexa)
    {
      if(hexa == 'a' || hexa == 'A')
      {
        return 10;
      }
      else if(hexa == 'b' || hexa == 'B')
      {
        return 11;
      }
      else if (hexa == 'c' || hexa == 'C')
      {
        return 12;
      }
      else if (hexa == 'd' || hexa == 'D')
      {
        return 13;
      }
      else if (hexa == 'e' || hexa == 'E')
      {
        return 14;
      }
      else if (hexa == 'f' || hexa == 'F')
      {
        return 15;
      }

      return 0;
    }

    private static char UlongToChar(ulong hexa)
    {
      if(hexa < 10)
      {
        return (char)(hexa + 0x30);
      }

      switch(hexa)
      {
        case 10: return 'A';
        case 11: return 'B';
        case 12: return 'C';
        case 13: return 'D';
        case 14: return 'E';
        case 15: return 'F';
      }
      return '-';
    }

  }
}

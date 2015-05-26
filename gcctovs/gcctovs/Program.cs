using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace gcctovs
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                var rgxType1 = new Regex("^([^ ]+):([0-9]+):([0-9]+): (.*)$");
                var rgxType2 = new Regex("^(In file included from )([^ ]+):([0-9]+):([0-9]+):$");
                foreach (var line in args[0].Split('\n'))
                {
                    var error = line.Trim();
                    var match1 = rgxType1.Match(error);
                    var match2 = rgxType2.Match(error);

                    if (match1.Success)
                    {
                        var groups = match1.Groups;
                        Console.WriteLine("{0}({1},{2}) : {3}", groups[1].Value, groups[2].Value, groups[3].Value, groups[4].Value);
                    }
                    else if (match2.Success)
                    {
                        var groups = match1.Groups;
                        Console.WriteLine("{0}({1},{2}) : <==== Included from here (double-click to go to line)", groups[2].Value, groups[3].Value, groups[4].Value);
                    }
                    else
                    {
                        Console.WriteLine("$_");
                    }
                }
            }
            else
            {
                Console.WriteLine("GCCtoVS v1.0 by T. Osakwe");
                Console.WriteLine("\nSyntax: gcctovs [input]");
                Console.WriteLine("\tinput: An input error in GCC format.");
            }
        }
    }
}

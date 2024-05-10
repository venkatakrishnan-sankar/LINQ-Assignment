using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Problem1;
class Program{
    public static void Main(string[] args)
    {
        string start,end;
        char ch;
        string [] cities={"ABU DHABI","AMSTERDAM","ROME","MADURAI","LONDON","NEW DELHI","MUMBAI","NAIROBI"};
        System.Console.WriteLine("ABU DHABI,AMSTERDAM,ROME,MADURAI,LONDON,NEW DELHI,MUMBAI,NAIROBI");
        System.Console.WriteLine("Enter the starting char");
        ch=Convert.ToChar(Console.ReadLine());
        start=ch.ToString();
        System.Console.WriteLine("Enter the ending character");
         ch=Convert.ToChar(Console.ReadLine());
        end=ch.ToString();
        var _result=from x in cities
        
                       where x.StartsWith(start)
                       where x.EndsWith(end)
                       select x;

                       foreach(var city in _result)
                       {
                        System.Console.WriteLine("The city starting with {0} and Ending with {1} is: {2} \n",start,end,city);
                       }        
    }
}
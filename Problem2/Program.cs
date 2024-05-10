using System;
using System.Linq;
namespace Problem2;
class Problem2
{
    public static void Main(string[] args)
    {
        string [] cities={"ABU DHABI","AMSTERDAM","ROME","PARIS","CALIFORNIA","LONDON","NEW DELHI","ZURICH","NAIROBI"};
        System.Console.WriteLine("ABU DHABI,AMSTERDAM,ROME,PARIS,CALIFORNIA,LONDON,NEW DELHI,ZURICH,NAIROBI");
        IEnumerable<string> cityOrder=
             cities.OrderBy(str=>str.Length)
                    .ThenBy(str=> str);

        foreach(string city in cityOrder)
        {
            System.Console.WriteLine(city);
        }
        
                    
    }
}
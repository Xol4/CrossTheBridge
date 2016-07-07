using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossTheBridge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> people = new List<int>() { 10, 5,3, 2, 1 };
            ICrossTheBridge crossing = new CrossTheBridge(people);
            crossing.Solve();
            Console.WriteLine(crossing.GetResult());
            Console.ReadKey();
        }
    }
}

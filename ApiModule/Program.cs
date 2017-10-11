using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModule
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpModule httpModule = new HttpModule();

            for (int i = 0; i < 10; i++)
            {
                httpModule.QueueRequest("http://www.mocky.io/v2/59dd22941000004118ccd59f");
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }
}

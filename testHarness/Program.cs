using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using getJson;

namespace testHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("hello from the console \r\n");
            var jsonGetter = new getJson.DataRetriever();
            Console.Write(jsonGetter.getJson("20150425"));
            Console.Read();
        }
    }
}

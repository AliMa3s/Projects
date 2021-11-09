using DataLayer.Repositories;
using DataLayer.REpositories;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string cs = @"Data Source=NB21-6CDPYD3\SQLEXPRESS;Initial Catalog=Adresbeheer2B;Integrated Security=True";
            GemeenteRepositoryADO repo = new GemeenteRepositoryADO(cs);
            var x=repo.GeefGemeente(10000);
            Console.WriteLine(x);
            StraatRepositoryADO rs = new StraatRepositoryADO(cs);

            foreach (var s in rs.GeefStratenGemeente(10000))
                Console.WriteLine(s);
        }
    }
}

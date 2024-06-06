using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stringConnection = "Data Source=srv2\\PUPILS;Initial Catalog=PicturesStore_326058609;Trusted_Connection=True;TrustServerCertificate=True";
            Ado ado = new Ado();
            while (true)
            {
                Console.WriteLine(ado.InserData(stringConnection));
                Console.WriteLine("Do you want to continue? y/n");
                string stop = Console.ReadLine();
                if (stop == "n")
                    break;
            }
            while (true)
            {
                Console.WriteLine("Do you want to insert category? y/n");
                string stop = Console.ReadLine();
                if (stop == "n")
                    break;
                Console.WriteLine(ado.InserCat(stringConnection));
                Console.WriteLine("Do you want to continue? y/n");
                stop = Console.ReadLine();
                if (stop == "n")
                    break;
            }
            ado.readData(stringConnection);
        }
    }
}

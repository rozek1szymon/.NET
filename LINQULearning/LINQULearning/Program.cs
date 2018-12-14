using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQULearning
{


   public  class Associates
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string LastName { get; set; }
        public Associates(string _Name, int _Age, string _LastName)
        {
            Name = _Name;
            Age = _Age;
            LastName = _LastName;
        }


    }





    class Program
    {






        static void Main(string[] args)
        {

            var worker = new Associates("ala", 12," Kopa");
            var worker1 = new Associates("Jan", 42," Kopa");
            var worker2 = new Associates("wlodek", 72," turpak");
            var worker3 = new Associates("kuba", 13," wielon");
            var worker4 = new Associates("kacper", 52," kawada");
            var worker5 = new Associates("maciek", 86," nostylku");
            var worker6 = new Associates("szymon", 15," weteran");
            var worker7 = new Associates("andrzej", 87," pomidor");
            var worker8 = new Associates("jan", 13," zek");

            List<Associates> associates = new List<Associates>();

            associates.Add(worker);
            associates.Add(worker1);
            associates.Add(worker2);
            associates.Add(worker3);
            associates.Add(worker4);
            associates.Add(worker5);
            associates.Add(worker6);
            associates.Add(worker7);
            associates.Add(worker8);



            ///////////////////////////////////////////SORTOWANIE////////////////////////////////////////////////////////////////////////////////
            
            var sortedAssotiates = associates.OrderBy(s => s.LastName).ThenBy(s => s.Name).ThenBy(r => r.Age).ToList();
            /////////////////////////////////////////////Wypisywanie///////////////////////////////////////////////
            ///
            //sortedAssotiates.ForEach(d => Console.WriteLine("{0},{1}" , d.LastName ,d.Name));

            //////////////////////////////////////////////FILTROWANIE/////////////////////////////////////////////////////////////////
            var filtredEmployees = associates.Where(s => s.Name.StartsWith("m") && s.Age == 86).ToList();
            // filtredEmployees.ForEach(d => Console.WriteLine("{0},{1}", d.LastName, d.Name));

            ////////////////////////////////////WYBIERANIE KONKRETNYCH WARTOŒCI////////////////////////////////////////////
            var SelectedEmployees = associates.Where(s => s.Name.StartsWith("k")).Select(s => s.Age).ToList();
           // SelectedEmployees.ForEach(d => Console.WriteLine(d));
            
            ////////////////////////////////////TYPY ANONIMOWE TWORZONE DYNAMICZNIE//////////////////////////////////////////
            var AnonymousType = associates.Where(s => s.Name.StartsWith("k")).Select(s => new { s.Name, s.Age }).ToList();
            AnonymousType.ForEach(s => Console.WriteLine( s.Name));
            Console.ReadLine();



            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}

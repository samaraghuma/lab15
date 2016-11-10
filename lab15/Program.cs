using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to countries maintenance application,select one of the options: ");
            Console.WriteLine("select 1-see the list of countries, 2-add a country, 3-exit ");

            int userchoice = Convert.ToInt32(Console.ReadLine());
            if (userchoice == 1)
            {
                List<country> countrylist = Readfile();
                foreach (country desh in countrylist)
                {
                    Console.WriteLine(desh.Name);
                }
            }
            else if (userchoice == 2)
            {
                Console.WriteLine("enter country");
                string input = Console.ReadLine();
                writetodatafile(input);

            }
            else
            {
                Console.WriteLine("buh-bye");
            }
        }
        private static List<country> Readfile() //method to read data in the file
        {
            List<country> countrylist = new List<country>();
            string filelocation = "../../textfile1.txt";

            StreamReader reader = new StreamReader(filelocation);

            string data = (reader.ReadToEnd().Trim());

            string[] records = data.Split('\n');

            foreach (string record in records)

            {

                string[] rc = record.Split(',');

                countrylist.Add(new country(rc[0]));

            }

            reader.Close();

            return countrylist;

        }
        private static void writetodatafile(string name) // method to write data to file

        {

            StreamWriter sw = new StreamWriter("../../textfile1.txt", true);

            sw.Write(($"\n{name}"));

            sw.Close();

        }

    }
}




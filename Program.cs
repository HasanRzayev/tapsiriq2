using System;
using System.Linq;

namespace tapsiriq2
{
    class Program
    {
        static void Shuffle(string[][] array,int size)
        {
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                array[i] = array[i].OrderBy(x => rnd.Next(0, 3)).ToArray();
            }
        }
        static bool Check(int choose, string[,] questions, string[][] array, int i)
        {
            if (array[i][choose] == questions[i,1]) return true;
            else return false;
        }
        static void Main(string[] args)
        {

            var size = 10;
            var choose = 0;
            var score = 0;
            var k = 0;
            string[,] questions = new string[,] {
                { "Almanyanin paytaxti haradir ?","Berlin"},
                { "Rusiyanin paytaxti haradir ?","Moskva"},
                { "Ingilterenin paytaxti haradir ?","London"},
                { "Fransa paytaxti haradir ?","Paris"},
                { "Italy paytaxti haradir ?","Roma"},
                { "Azerbaycan paytaxti haradir ?","Baku"},
                { "Norway paytaxti haradir ?","Oslo"},
                { "Spanin paytaxti haradir ?","Madrid"},
                { "Yunanistanin paytaxti haradir ?","Afina"},
                { "Turkiyenin paytaxti haradir ?","Ankara"},


            };
            string[][] answers = new string[10][] {
               new string[] { "Baku", "Berlin", "Gedebey" },
                new string[] { "Cin", "Moskva", "Kurdemir" },
                new string[] { "Pekin", "London", "Qebele" },
                new string[] { "Moskva", "Paris", "Naxcivan" },
                new string[] { "Oslo", "Roma", "Salyan" },
                new string[] { "Roma", "Baku", "Fatmayil" },
                new string[] { "Paris", "Oslo", "Goradil" },
                new string[] { "Ankara", "Madrid", "Naftalan" },
                new string[] { "Madrid", "Afina", "Mingecevir" },
                new string[] { "Afina", "Ankara", "Misir" },

            };


            Shuffle(answers,size);


            while (true) {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                if (k == 10) break;
                Console.WriteLine((k+1)+"-ci sual----"+questions[k, 0]);
                Console.WriteLine("---------------------------------------");

                Console.WriteLine(1 + "-ci variant----" + answers[k][0]);
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(2 + "-ci variant----" + answers[k][1]);
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine(3 + "-ci variant----" + answers[k][2]);
                Console.WriteLine("-----------------------------------------");

                Console.WriteLine("Secim daxil edin-----");
                choose = int.Parse(Console.ReadLine());
                if (choose < 0 || choose > 3)
                {
                    Console.WriteLine("Duzgun daxil edin !!!!");
                    continue;
                }
                if (Check(choose-1, questions,answers, k) == true)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Duzgun cavabladiniz");
                    score += 10;
                }
                else
                {
                    if (score != 0) score -= 10;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Sevh cavabladiniz");

                }
                k++;
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Imtahan bitdi!!!!!"+score);
            Console.WriteLine("Sizin scorunuz----"+score);

        }
    }
}

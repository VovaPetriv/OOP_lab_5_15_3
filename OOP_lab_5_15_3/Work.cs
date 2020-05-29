using System;
using System.IO;

namespace OOP_lab_5_15_1
{
    class Work
    {
        public static void Add()
        {
            StreamWriter file = new StreamWriter("base.txt", true);

            Console.WriteLine("Введiть новi данi");

            Console.Write("Назва: ");

            file.WriteLine(Console.ReadLine());

            Console.Write("Прiзвище скульптора: ");

            file.WriteLine(Console.ReadLine());

        Retry:
            Console.Write("Кiлькiсть вiдвiдувачiв: ");

            try
            {
                file.WriteLine(int.Parse(Console.ReadLine()));
            }
            catch (SystemException)
            {
                Console.WriteLine("Кiлькiсть вiдвiдувачiв має бути вказана лише числом!");

                goto Retry;
            }

            Console.Write("Коментар: ");

            file.WriteLine(Console.ReadLine());

            file.Close();

            Input.ReadBase();
        }

        public static void Remove()
        {
            Console.WriteLine();

            Output.Write();

            Console.Write("Порядковий номер запису для видалення: ");

            bool[] remove = new bool[Program.week.Length];

            for (int i = 0; i < remove.Length; ++i)
            {
                remove[i] = false;
            }

            try
            {
                remove[int.Parse(Console.ReadLine()) - 1] = true;
            }
            catch (SystemException)
            {
                Console.WriteLine("Такого запису не iснує!");
                return;
            }

            StreamWriter file = new StreamWriter("base.txt");

            for (int i = 0; i < Program.week.Length; ++i)
            {
                if (!remove[i])
                {
                    file.WriteLine(Program.week[i].Name);
                    file.WriteLine(Program.week[i].SculptorSurename);
                    file.WriteLine(Program.week[i].VisitorsCount);
                    file.WriteLine(Program.week[i].Coment);
                }
            }

            Console.Write("Видалено.\n");

            file.Close();

            Input.ReadBase();
        }

        public static void Edit()
        {
            Console.WriteLine();

            Output.Write();

            Console.Write("Порядковий номер запису для редагування: ");

            bool[] edit = new bool[Program.week.Length];

            for (int i = 0; i < edit.Length; ++i)
            {
                edit[i] = false;
            }

            try
            {
                edit[int.Parse(Console.ReadLine()) - 1] = true;
            }
            catch (SystemException)
            {
                Console.WriteLine("Такого запису не iснує!");
                return;
            }

            StreamWriter file = new StreamWriter("base.txt");

            for (int i = 0; i < Program.week.Length; ++i)
            {
                if (edit[i])
                {
                    Console.WriteLine("Введiть новi данi");

                    Console.Write("Назва: ");

                    file.WriteLine(Console.ReadLine());

                    Console.Write("Прiзвище скульптора: ");

                    file.WriteLine(Console.ReadLine());

                Retry:
                    Console.Write("Кiлькiсть вiдвiдувачiв: ");

                    try
                    {
                        file.WriteLine(int.Parse(Console.ReadLine()));
                    }
                    catch (SystemException)
                    {
                        Console.WriteLine("Кiлькiсть вiдвiдувачiв має бути вказана лише числом!");

                        goto Retry;
                    }

                    Console.Write("Коментар: ");

                    file.WriteLine(Console.ReadLine());                
                }
                else
                {
                    file.WriteLine(Program.week[i].Name);
                    file.WriteLine(Program.week[i].SculptorSurename);
                    file.WriteLine(Program.week[i].VisitorsCount);
                    file.WriteLine(Program.week[i].Coment);
                }
            }

            Console.Write("Змiни внесено.\n");

            file.Close();

            Input.ReadBase();
        }

        public static void InitialiseBase(int n)
        {
            Program.week = new Day[n];
        }

        public static void Sum()
        {
            int sum = 0;

            for (int i = 0; i < Program.week.Length; ++i)
            {
                sum += Program.week[i].VisitorsCount;
            }

            Console.WriteLine("\nЗагальна кiлькiсть вiдвiдувачiв: {0}.", sum);
        }

        public static void Maximum()
        {
            int maxIndex = 0;

            for (int i = 0; i < Program.week.Length; ++i)
            {
                if (Program.week[maxIndex].VisitorsCount <= Program.week[i].VisitorsCount)
                {
                    maxIndex = i;
                }
            }

            Console.WriteLine("Днi з максимальною кiлькiстю вiдвiдувачiв:");
            Console.WriteLine(Output.Format, "Назва", "Прiзвище скульптора", "День", "Коментар");

            for (int i = 0; i < Program.week.Length; ++i)
            {
                if (Program.week[maxIndex].VisitorsCount == Program.week[i].VisitorsCount)
                {
                    Console.WriteLine(Output.Format, Program.week[i].Name, Program.week[i].SculptorSurename, Program.week[i].VisitorsCount, Program.week[i].Coment);
                }
            }
        }

        public static void LongestComent()
        {
            Console.WriteLine();

            int maxIndex = 0;

            for (int i = 0; i < Program.week.Length; ++i)
            {
                if (Program.week[maxIndex].ComentLength() <= Program.week[i].ComentLength())
                {
                    maxIndex = i;
                }
            }

            Console.WriteLine("Записи з найбiльшою кiлькiстю слiв в коментарi:");
            Console.WriteLine(Output.Format, "Назва", "Прiзвище скульптора", "День", "Коментар");

            for (int i = 0; i < Program.week.Length; ++i)
            {
                if (Program.week[maxIndex].VisitorsCount == Program.week[i].VisitorsCount)
                {
                    Console.WriteLine(Output.Format, Program.week[i].Name, Program.week[i].SculptorSurename, Program.week[i].VisitorsCount, Program.week[i].Coment);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_PROJECT
{
    internal class Program
    {
        static void Groups(int starting_colony, ref int small_group, ref int big_group)
        {
            int digit = starting_colony % 10;
            small_group = 0;
            big_group = 0;
            switch (digit)
            {
                case 0:
                case 5:
                    big_group = starting_colony / 5;
                    break;
                case 3:
                case 6:
                case 9:
                    small_group = digit / 3;
                    big_group = (starting_colony - digit) / 5;
                    break;
                case 2:
                case 7:
                    small_group = 4;
                    big_group = (starting_colony - small_group * 3) / 5;
                    break;
                case 8:
                    small_group = 1;
                    big_group = (starting_colony - 3) / 5;
                    break;
                case 1:
                    small_group = 2;
                    big_group = (starting_colony - small_group * 3) / 5;
                    break;
                case 4:
                    small_group = 3;
                    big_group = (starting_colony - small_group * 3) / 5;
                    break;

            }
        }

        static int Reproduction(int year, int starting_colony, ref int small_group, ref int big_group)
        {
            int cur_year = 0;

            int[] lifespan = new int[4];

            int length_life;

            while (cur_year < year)
            {
                lifespan[0] = starting_colony;

                length_life = lifespan.Length - 1;

                for (int i = lifespan.Length - 1; i > 0; i--)
                {
                    lifespan[length_life] = lifespan[length_life - 1];
                    length_life--;
                }

                Groups(starting_colony, ref small_group, ref big_group);

                starting_colony = starting_colony + (small_group * 5) + (big_group * 9) - lifespan[3];
                cur_year++;
            }
            return starting_colony;
        }

        static int CheckingInputData(int input_data)
        {
            while (input_data < 3)
            {
                Console.Write("\tNumber of robots is too low to start reproduction. Please input appropriate number: ");
                input_data = int.Parse(Console.ReadLine());
            }

            if (input_data == 4 | input_data == 7)
            {
                Console.WriteLine("\tOne of your robots was successfully donated to Armed Forces of Ukraine. Thank you for your cooperation!");
                input_data--;
            }
            return input_data;
        }
        static void Main(string[] args)
        {
            Console.Write("Input number of robots: ");
            int starting_colony = int.Parse(Console.ReadLine()); // не забути подумати за тип числа і обмеження в цьому плані
            starting_colony = CheckingInputData(starting_colony);

            Console.Write("Input current year: ");
            int year = int.Parse(Console.ReadLine());

            int small_group = 0;
            int big_group = 0;


            int cur_colony = Reproduction(year, starting_colony, ref small_group, ref big_group);

            Console.WriteLine($"Current number of robots: {cur_colony}");
            Console.ReadKey();
        }
    }
}

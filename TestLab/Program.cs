using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestLab
{
    class Program
    {
        static System.Diagnostics.Stopwatch stopwatch1 = new System.Diagnostics.Stopwatch();

        static void Main(string[] args)
        {
            int count = 0;
            int count_room = 0;

            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
 

            //Создание главной комнаты
            Room main_room = new Room();
            main_room.XY(0, 0);
            Room.save(main_room);
            Room.setLocation(main_room);
            count = 1;

            //Построение рядов комнат
            for (int i = 0; i < 99; i++)
            {
                count_room = Room.get_rooms().Count;
                count = count_room - count;
                for (int j = count; j < count_room; j++)
                {
                    Room.setLocation(Room.get_rooms()[j]);
                }
            }

            stopwatch.Stop();
            Console.WriteLine("Время построения лабиринта: " + stopwatch.ElapsedMilliseconds + " мс");
            Console.WriteLine("Количество комнат: " + Room.get_rooms().Count);
            Console.WriteLine("Количество комнат: " + Room.z);
            /*foreach (Room room in Room.get_rooms())
            {
                Console.WriteLine(room.x + "; " + room.y);
            }*/
            Console.ReadKey();
        }
    }
}

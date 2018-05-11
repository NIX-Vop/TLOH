using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLab
{
    class Room
    {
        static Random random = new Random();
        private static List<Room> list = new List<Room>();

        public static int z { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public void XY(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool top { get; set; } = false;
        public bool right { get; set; } = false;
        public bool bottom { get; set; } = false;
        public bool left { get; set; } = false;

        public bool[] get_location()
        {
            bool[] mass_l = new bool[] { top, right, bottom, left };
            return mass_l;
        }

        public void set_location(bool t, bool r, bool b, bool l)
        {
            top = t;
            right = r;
            bottom = b;
            left = l;
        }

        static public void save(Room room)
        {
            list.Add(room);
        }

        static public List<Room> get_rooms()
        {
            return list;
        }

        //Поиск комнаты с заданными координатми
        static public bool notSearch(int x, int y)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                if (list[i].x == x)
                {
                    if (list[i].y == y)
                    {
                        z++;
                        return false;
                    }
                }
            }
            return true;
        }

        //Добавление комнаты в список
        static private void addRoom(int x, int y, Room main_room)
        {
            Room room = new Room();
            room.x = x;
            room.y = y;
            list.Add(room);
        }

        static public void setLocation(Room main_room)
        {
            //Top
            main_room.top = Convert.ToBoolean(random.Next(2));
            if (main_room.top)
            {
                if (notSearch(main_room.x, main_room.y + 1))
                    addRoom(main_room.x, main_room.y + 1, main_room);
            }
            //Right
            main_room.right = Convert.ToBoolean(random.Next(2));
            if (main_room.right)
            {
                if (notSearch(main_room.x + 1, main_room.y))
                    addRoom(main_room.x + 1, main_room.y, main_room);
            }
            //Bottom
            main_room.bottom = Convert.ToBoolean(random.Next(2));
            if (main_room.bottom)
            {
                if (notSearch(main_room.x, main_room.y - 1))
                    addRoom(main_room.x, main_room.y - 1, main_room);
            }
            //Left
            main_room.left = Convert.ToBoolean(random.Next(2));
            if (main_room.left)
            {
                if (notSearch(main_room.x - 1, main_room.y))
                    addRoom(main_room.x - 1, main_room.y, main_room);
            }
        }
    }
}

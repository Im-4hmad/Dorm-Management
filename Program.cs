using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project;

namespace DormManagement
{
    class Dorm
    {
        private string name, address;
        private int capacity;
        //private <Student> manager
        //list <Block> blocks;
        public string Name { get; set; }
    }
    class Room
    {
        private int id, floor, capacity;
        // capacity should be <= 6
        //private list<Equipment> equipments
        //private list<Student> students
        //
    }
    class Equipment
    {

        //string array with 5 equipment and use partnumber as index to access
        private int partNumber, id, status;//status is 0 ok 1 damaged 2 fixing and so on
        private Room room;
        //private student owner
    }

    class Blocks
    {
        public string Name;
        public string The_Corresponding_Dormitory;
        public int Floors;
        public int NumRooms;
        public List<Room> rooms = new List<Room>();

        public void AddRoom(Room room)
        {
            rooms.Add(room);
            NumRooms = rooms.Count;
        }

        public bool RemoveRoom(int roomNumber)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].id == roomNumber)
                {
                    rooms.RemoveAt(i);
                    NumRooms = rooms.Count;
                    return true;
                }
            }
            return false;
        }

        public Room FindRoom(int roomNumber)
        {
            foreach (Room room in rooms)
            {
                if (room.id == roomNumber)
                {
                    return room;
                }
            }
            return null;
        }

        public List<Room> EmptyRooms()
        {
            //List<Room> emptyRooms = new List<Room>();
            //foreach (Room room in rooms)
            //{
            //    if (room.IsEmpty)
            //    {
            //        emptyRooms.Add(room);
            //    }
            //}
            //return emptyRooms;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Block name : {Name}");
            Console.WriteLine($"The corresponding dormitory : {The_Corresponding_Dormitory}");
            Console.WriteLine($"Number of floors : {Floors}");
            Console.WriteLine($"Number of Rooms : {NumRooms}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

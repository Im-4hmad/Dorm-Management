using System;
using System.Net;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;
//using 
namespace DormManagement
{
    public class Block
    {
    private int id;
        private int dormId;
    public string Name;
        //public string The_Corresponding_Dormitory;
        public int Floors;
        public int NumRooms;
        public List<Room> rooms = new List<Room>();


        public Block(string name,int floors,int id,int dormId)
    {
            this.dormId = dormId;
        this.Name = name;
        //this.The_Corresponding_Dormitory = the_corresponding_Dormitory;
        this.Floors = floors;
        this.id = id;   
    }   
    public int Id
    {
        get { return id; }  
    }
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

        //public List<Room> EmptyRooms()
        //{
        //    List<Room> emptyRooms = new List<Room>();
        //    foreach (Room room in rooms)
        //    {
        //        if (room.IsEmpty)
        //        {
        //            emptyRooms.Add(room);
        //        }
        //    }
        //    return emptyRooms;
        //}
        //    public void Show()
        //    {
        //    Console.WriteLine("name of Block : " + Name);
        //    Console.WriteLine(" The Corresponding Dormitory : " + The_Corresponding_Dormitory);
        //    Console.WriteLine("number of floors : " + Floors);
        //    Console.WriteLine("manager of dorm : " + " *** TODO ++++ ");

        //    Console.WriteLine("<<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>>");
        //}
        public void showRooms()
        {
            if (rooms.Count == 0)
            {
                Console.WriteLine("no room :(");
                return;
            }
            foreach (Room room in rooms) room.Show();
        }
        public void addRoom(Menu m,int floor=-1)
        {
            int roomId = 1;
            foreach (Room room in rooms)
                roomId += room.id;

            //finding dorm
            Dorm dorm = null;
            foreach(Dorm Dorm in m.dorms)
            {
                if(this.dormId == Dorm.Id)
                {
                    dorm = Dorm;
                    break;
                }
            }
            //calculating capacity of all rooms in this dorm
            int roomCapacity = 0;
            foreach(Block block in dorm.blocks)
            {
                foreach(Room room in block.rooms)
                {
                    roomCapacity += 6;
                }
            }

            //comparing it to the total capacity of dorm to check if it is possible to add a room
            if(roomCapacity == dorm.capacity)
            {
                Console.WriteLine($"can't add a room in dorm {dorm.name} because it is full");
                Console.ReadKey();
                return;
            }
          
            rooms.Add(new Room(roomId, floor, this.id, dormId, 6));
        }
        public void manageRooms(Menu m)
        {
            Console.WriteLine("managing rooms");
            Console.WriteLine("1-Add room");
            Console.WriteLine("2-show rooms");


            int choice = int.Parse(Console.ReadLine().Trim());


         
             if (choice == 1)
            {
                int floor;

                Console.Write("Enter room floor ; ");
                floor = int.Parse(Console.ReadLine());
                if(this.Floors < floor || floor < 0)
                {
                    Console.WriteLine("please enter a valid input");
                    Console.ReadKey();
                    return;
                }
                addRoom(m,floor);

            }
            else if (choice == 2)
            {
                showRooms();
                
            }
            else Console.WriteLine("invalid input");
        }
        public void update()
        {
            Console.WriteLine("choose what u wanna update  : ");
            Console.WriteLine("1- name ");
            Console.WriteLine("2- floor ");
            Console.WriteLine("3- number of room");
 
            int choice = int.Parse(Console.ReadLine());
            if (choice < 0 || choice > 4) return;
            
            if (choice == 1)
            {
                Console.WriteLine("Enter new Name ");
                Name = Console.ReadLine().Trim();
            }
            if (choice == 2)
            {
                Console.WriteLine("Enter new floor count ");
                Floors = int.Parse( Console.ReadLine().Trim());
            }
            if (choice == 3)
            {
           
                Console.WriteLine("Enter new room count ");
                
                int NumRooms = int.Parse(Console.ReadLine().Trim());
           
            }
            Console.WriteLine("updated successfully");
            this.Show();
        }
        public void Show()
        {
        Console.WriteLine($"Block Id : {id}");

        Console.WriteLine($"Block name : {Name}");
            //Console.WriteLine($"The corresponding dormitory : {The_Corresponding_Dormitory}");
            Console.WriteLine($"Number of floors : {Floors}");
        Console.WriteLine($"Number of rooms : {rooms.Count}");
        Console.WriteLine("<<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>>");

        //Console.WriteLine($"Number of Rooms : {NumRooms}");
    }
}

}

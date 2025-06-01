using System;
//using 
//namespace Block
//{
    class Block
    {
    private int id;    
    public string Name;
        //public string The_Corresponding_Dormitory;
        public int Floors;
        public int NumRooms;
        public List<Room> rooms = new List<Room>();


        public Block(string name,int floors,int id)
    {
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
        public void Show()
        {
        Console.WriteLine($"Block Id : {id}");

        Console.WriteLine($"Block name : {Name}");
            //Console.WriteLine($"The corresponding dormitory : {The_Corresponding_Dormitory}");
            Console.WriteLine($"Number of floors : {Floors}");
        Console.WriteLine($"Number of roomes : {rooms.Count}");
        Console.WriteLine("<<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>>");

        //Console.WriteLine($"Number of Rooms : {NumRooms}");
    }
}

//}

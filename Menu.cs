using System;
using System.Linq;
//using Person;
//namespace Menu
//{

class Menu
    {

        List<Dorm> dorms = new List<Dorm>();
        List<Block> blocks = new List<Block>();
        List<Person> people = new List<Person>();
        //list for all Equipments in all dorms
         public static List<Equipment> equipments = new List<Equipment>();
    public static void error()
    {
        Console.WriteLine("please choose a valid option");
    }
    public void addDorm()
        {
            string name, address;
            int capacity;
            Console.Write("Enter Dorm name ; ");
            name = Console.ReadLine();
            Console.Write("Enter Dorm address ; ");
            address = Console.ReadLine();
            Console.Write("Enter Dorm capacity ; ");
            capacity = int.Parse(Console.ReadLine());
        int id = 1;
        foreach (Dorm d in dorms) id += d.Id ;
            dorms.Add(new Dorm(name, address, capacity,id));
        }

    public void showDorms()
    {
        //int cnt = 1;
        foreach (Dorm d in dorms) {
            //Console.WriteLine(d.Id + " - "); s
            d.Show();
            //cnt++;
        }
       
    }
    public void deleteDorm()
    {
        if (dorms.Count == 0)
        {
            Console.WriteLine("NO Dorms available to Delete");
            return;
        }
        Console.WriteLine("choose the id of Dorm to delete");
        
        showDorms();

        int choice = int.Parse(Console.ReadLine());
        //if (choice > dorms.Count || choice < 1) error();
        for(int i=0;i<dorms.Count;i++)
            if (dorms[i].Id == choice)
            {

            dorms.Remove(dorms[i]);
                Console.WriteLine("deletion successful");
                return;
            }
        //dorms.RemoveAt(choice - 1);
        Console.WriteLine("not found the dorm with the corresponding id");

    }
    public void updateDorm()
    {
        if (dorms.Count == 0)
        {
            Console.WriteLine("NO Dorms available to update");
            return;
        }

        Console.WriteLine("1-Edit dorm info");
        Console.WriteLine("2-Blocks management");
        int choice = int.Parse(Console.ReadLine());
        if (choice == 1)
        {

            Console.WriteLine("choose the id of Dorm to update");

            showDorms();

             choice = int.Parse(Console.ReadLine());
           
            foreach (Dorm dorm in dorms)
                if (dorm.
                Id == choice)
                {

                    dorm.update();
                    return;
                }

            Console.WriteLine("not found the dorm with the corresponding id");
        }
        else if (choice == 2) {

            Console.WriteLine("choose the id of Dorm you wanna manage the blocks");

            showDorms();
            choice = int.Parse(Console.ReadLine());

            foreach (Dorm dorm in dorms)
                if (dorm.
                Id == choice)
                {

                    dorm.manageBlocks();
                    return;
                }

            Console.WriteLine("not found the dorm with the corresponding id");

        }


    }
    public void showBlocks()
    {
        //int cnt = 1;
        //foreach (Block b in dorms)
        //{
        //    Console.WriteLine(cnt + " - ");
        //    b.Show();
        //    cnt++;
        //}

    }
    //برای گزارش گیری
    //وضعیت کلی اسکان
    public void GeneralStatus()
    {
        int tmp = 0;
        int accommodated = 0;
        foreach(var person in people)
                {
            if(person.duty != Role.dormMa)
            {
                tmp++;
                if(person.residingRoom != null)
                    accommodated++;
            }

        }
        int numOfRoom = 0;
        foreach(var block in blocks)
        {
            numOfRoom += block.rooms.Count();
        }

        Console.WriteLine($"total number of students: {tmp}");
        Console.WriteLine($"number of accommodated students: {accommodated}");
        Console.WriteLine();
        Console.WriteLine($"number of all dorms: {dorms.Count}");
        Console.WriteLine($"number of all blocks: {blocks.Count}");
        Console.WriteLine($"number of all rooms: {numOfRoom}");
        Console.WriteLine();
        Console.WriteLine($"total capacity of all dorms: {numOfRoom*6}");
        Console.WriteLine($"remaining capacity: {numOfRoom * 6 - accommodated}");

    }
    public void RemainingCapacity()
    {
        foreach (Dorm dorm in dorms)
        {
            Console.WriteLine($"Dorm {dorm.name}:");
            // بررسی ظرفیت باقی مانده خوابگاه
            int counter = 0;
            foreach(var person in people)
            {
                if(person.duty != Role.dormMa)
                {
                    if(person.residingDorm.name == dorm.name) counter++;
                }
            }

            Console.WriteLine($"remaining capacity of dorm: {dorm.capacity - counter}");
            Console.WriteLine();
            foreach(var block in dorm.blocks)
            {
                counter = 0;
                Console.WriteLine($"block {block.Name}:");
                //بررسی ظرفیت باقیمانده بلوک
                foreach(var person in people)
                {
                    if (person.duty != Role.dormMa)
                    {
                        if (person.residingBlock.Name == block.Name) counter++;
                    }
                }

                Console.WriteLine($"remaining capacity of block: {block.rooms.Count() * 6 - counter}");
                Console.WriteLine();
                

            }
            Console.WriteLine("--------------------------------------------");
        }
    }
    public void EquipmentList()
    {
        int Fridge = 0;
        int Closet = 0;
        int Desk = 0;
        int Chair = 0;
        int Bed = 0;
        foreach (var equip in equipments)
        {
            if(equip.type == EquipmentType.Fridge)
            {
                Fridge++;
            }
            if (equip.type == EquipmentType.Closet)
            {
                Closet++;
            }
            if (equip.type == EquipmentType.Desk)
            {
                Desk++;
            }
            if (equip.type == EquipmentType.Chair)
            {
                Chair++;
            }
            if (equip.type == EquipmentType.Bed)
            {
                Bed++;
            }
        }
        Console.WriteLine($"number of fridges: {Fridge}");
        Console.WriteLine($"number of closets: {Closet}");
        Console.WriteLine($"number of beds: {Bed}");
        Console.WriteLine($"number of Chairs: {Chair}");
        Console.WriteLine($"number of Desks: {Desk}");
        
    }
    public void RoomEquipments()
    {
        //اول از کاربر میپرسه اتاق مد نظرش توی کدوم خوابگاهه بعد کدوم بلوک و بعد شماره اتاق ها رو مینویسه تا کاربر انتخاب کنه
        Console.WriteLine("choose the dorm:");
        for (int i =1; i < dorms.Count+1; i++)
        {
            Console.WriteLine($"{i}-{dorms[i-1].name}");
        }
        int n = int.Parse(Console.ReadLine())-1;
        Dorm dorm = dorms[n];
        Console.Clear();
        Console.WriteLine("choose the block:");
        for (int i = 1; i < dorm.blocks.Count + 1; i++)
        {
            Console.WriteLine($"{i}-{dorm.blocks[i-1].Name}");
        }
         n = int.Parse(Console.ReadLine())-1;
        Block block = dorm.blocks[n];
        Console.Clear();
        Console.WriteLine("choose the room:");
        for (int i = 1; i < block.rooms.Count + 1; i++)
        {
            Console.WriteLine($"{i}-room{block.rooms[i - 1].id}");
        }
        n = int.Parse(Console.ReadLine())-1;
        Room room = block.rooms[n];
        Console.Clear();
        foreach(var equipment in room.Equipments)
        {
            Console.WriteLine(equipment.type.ToString());
            Console.WriteLine($"with ID:{equipment.ID}");
            Console.WriteLine("----------------------");
        }
        

    }
    public void StudentEquipments()
    {

        Console.WriteLine("choose the student:");
        for(int i =1; i< people.Count+1; i++)
        {
            if(people[i-1].duty != Role.dormMa)
            {
                Console.WriteLine($"{i}-{people[i - 1].name} with id: {people[i-1].id}");
            }

        }
        int n = int.Parse(Console.ReadLine()) - 1;
        Console.Clear();
        Person person = people[n];
        foreach(var equipment in person.Equipments)
        {
            Console.WriteLine($"one {equipment.type.ToString()}");
            Console.WriteLine($"with id:{equipment.ID}");
            Console.WriteLine("----------------------");

        }

    }
    public void DamagedEquipments()
    {
        Console.WriteLine("damaged equipments list:");
        Console.WriteLine();
        foreach(var equipment in equipments)
        {
            if(equipment.status == 1)
            {
                Console.WriteLine($"a {equipment.type.ToString()}");
                Console.WriteLine($"with id:{equipment.ID}");
                Console.WriteLine("is damaged");
                Console.WriteLine("----------------------");
            }
        }
        Console.WriteLine();
        Console.WriteLine("under repair equipments list:");
        Console.WriteLine();
        foreach (var equipment in equipments)
        {
           if (equipment.status == 2)
            {
                Console.WriteLine($"a {equipment.type.ToString()}");
                Console.WriteLine($"with id:{equipment.ID}");
                Console.WriteLine("is under repair");
                Console.WriteLine("----------------------");
            }
        }
        
    }
    public void RepairRequests()
    {
        foreach (var equipment in equipments)
        {
            if (equipment.status == 2)
            {
                Console.WriteLine($"a {equipment.type.ToString()}");
                Console.WriteLine($"with id:{equipment.ID}");
                Console.WriteLine($"request description: {equipment.Description}");
                Console.WriteLine("--------------------------------");
            }
        }
    }
    public void AccomodationHistory()
    {
        if(people.Count == 0)
        {
            Console.WriteLine("No student available");
            return;
        }
        
        Console.WriteLine("choose the student:");
        Console.WriteLine();
        List<Person> nonDormMa = new List<Person>();
        int num = 1;
        for(int i = 0; i < people.Count; i++)
        {
            if (people[i].duty != Role.dormMa)
            {
                Console.WriteLine($"{num}- {people[i].name}");
                nonDormMa.Add(people[i]);
                num++;
            }
          
        }
        if(nonDormMa.Count == 0)
        {
            Console.WriteLine("No student available");
            return;
        }
        int choice = int.Parse(Console.ReadLine()) -1;
        Console.Clear();
        Person person = nonDormMa[choice];
        if(person.residingDorm == null)
        {
            Console.WriteLine($"{person.name}  has not received accommodation yet.");
            return;
        }
        else
        {
            Console.WriteLine($"The accommodation History of {person.name}:");
            for (int i = 0; i < people.DormHistory.Count; i++)
            {
                Conosle.WriteLine($"Dorm: {person.DormHistory[i].Name}");
                Conosle.WriteLine($"Block: {person.BlockHistory[i].Name}");
                Conosle.WriteLine($"Room: {person.RoomHistory[i].id}");
                Console.WriteLine("----------------------------");
            }

        }


    }

}
//}

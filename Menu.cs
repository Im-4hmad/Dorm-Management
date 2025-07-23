using System;
using System.Collections.Specialized;
using System.Linq;
//using Person;
namespace DormManagement
{

public  class Menu
    {

        public List<Dorm> dorms = new List<Dorm>();
        public List<Block> blocks = new List<Block>();
        public List<Person> people = new List<Person>();
        //list for all Equipments in all dorms
         public  List<Equipment> equipments = new List<Equipment>();
    public static void error()
    {
        Console.WriteLine("please choose a valid option");
    }
        public void updateBlocks()
        {
            blocks.Clear();
            foreach (Dorm dorm in dorms) {
                Console.WriteLine("here");
                foreach (Block b in dorm.blocks)
                {
                    blocks.Add(b);
                }
            }
        }
    public void addDorm()
        {
            string name, address;
            int capacity;
            Console.Write("Enter Dorm name ; ");
            name = Console.ReadLine();
            Console.Write("Enter Dorm address ; ");
            address = Console.ReadLine();
            Console.Write("Enter Dorm capacity(it must be a multiple of six) ; ");
            capacity = int.Parse(Console.ReadLine());
            if(capacity % 6 != 0)
            {
                error();
                Console.ReadKey();
                return;
            }
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

                    dorm.manageBlocks(this);
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
            int temp = 0;
            for(int i = 0;i< dorms.Count; i++)
            {
                temp += dorms[i].capacity;
            }
        Console.WriteLine($"total capacity of all dorms: {temp}");
        Console.WriteLine($"remaining capacity: {temp - accommodated}");

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
                    if(person.residingDorm != null &&person.residingDorm.Id == dorm.Id) counter++;
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
                        if ( person.residingBlock != null &&  person.residingBlock.Id == block.Id) counter++;
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
            for (int i = 0; i < person.DormHistory.Count; i++)
            {
                Console.WriteLine($"Dorm: {person.DormHistory[i].Name}");
                Console.WriteLine($"Block: {person.BlockHistory[i].Name}");
                Console.WriteLine($"Room: {person.RoomHistory[i].id}");
                Console.WriteLine("----------------------------");
            }

        }


    }
        public void ManagePeople()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("People Management:");
                Console.WriteLine("1- Add Person");
                Console.WriteLine("2- Delete Person");
                Console.WriteLine("3- Edit Person");
                Console.WriteLine("4- Show People");
                Console.WriteLine("5- Assign Accommodation to Student");
                Console.WriteLine("0- Back to Main Menu");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 0)
                {
                    Console.Clear();
                    break;
                }

                switch (choice)
                {
                    case 1:
                        AddPerosn();
                        break;
                    case 2:
                        DeletePerson();
                        break;
                    case 3:
                        EditPerson();
                        break;
                    case 4:
                        ShowPeople();
                        break;
                    case 5:
                        AssignAccommodation();
                        break;
                    default:
                        error();
                        break;
                }
            }
        }
        public void AddPerosn()
        {
            Console.Clear();
            Console.WriteLine("Select role:");
            Console.WriteLine("1- Student");
            Console.WriteLine("2- Dorm Manager");
            Console.WriteLine("3- Block Manager");

            int role = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("National ID : ");
            string id = Console.ReadLine();
            Console.Write("Phone number: ");
            string phone = Console.ReadLine();
            Console.Write("Address :");
            string address = Console.ReadLine();

            if (role == 1)
            {
                Console.Write("Student ID: ");
                string studentId = Console.ReadLine();
                Person Student = new Person(name, Role.student, id, phone, address, studentId);
                people.Add(Student);
            }
            else if (role == 2)
            {
                Console.WriteLine("Select Dorm for the manager:");
                for (int i = 0; i < dorms.Count; i++)
                {
                    Console.WriteLine($"{i + 1}- {dorms[i].name}");
                }
                int dormInddex = int.Parse(Console.ReadLine()) - 1;
                Person dormManager = new Person(name, id, phone, address, dorms[dormInddex]);
                people.Add(dormManager);
            }
            else if (role == 3)
            {
                if(blocks.Count==0)
                {
                    Console.WriteLine("first add a block ");
                    return;
                }
                Console.WriteLine("Select Block fot the manager: ");
                for (int i = 0; i < blocks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}- {blocks[i].Name}");
                }
                int blockIndex = int.Parse(Console.ReadLine()) - 1;
                Person p = new Person(name, Role.student, id, phone, address, "");
                p.MakeBlockMa(blocks[blockIndex]);
                people.Add(p);
            }
        }

        public void DeletePerson()
        {
            Console.Clear();
            if(people.Count == 0)
            {
                Console.WriteLine("there is no person");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Select person to delete: ");
            for (int i = 0;i < people.Count;i++)
            {
                Console.WriteLine($"{i + 1}- {people[i].name} ({people[i].duty})");
            }
            string index1 = Console.ReadLine();
            bool isint = int.TryParse(index1, out int index);
            index--;
            if (index >= 0 && index < people.Count)
            {
                people.RemoveAt(index);
                Console.WriteLine("person deleted successfully.");
            }
            else
            {
                error();
            }
        }
        
        public void EditPerson()
        {
            Console.Clear();
            if (people.Count == 0)
            {
                Console.WriteLine("there is no person");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Select person to edit: ");
            for (int i = 0;i < people.Count;i++)
            {
                Console.WriteLine($"{i + 1}- {people[i].name} ({people[i].duty})");
            }
            string index1 = Console.ReadLine();
            bool isint = int.TryParse(index1, out int index);
            index--;
            if (index < 0 || index >= people.Count || !isint)
            {
                error();
                return;
            }
            Person person = people[index];
            Console.WriteLine("\"Enter the field to edit: (name / ID / student ID / phone number / address)\"");
            string field = Console.ReadLine();
            person.Edit(field);
        }

        public void ShowPeople()
        {
            Console.Clear();
            foreach(var p in people)
            {
                Console.WriteLine($"Name: {p.name}, Role: {p.duty}, ID: {p.id}, Phone: {p.pnumber}");
            }
            Console.WriteLine("Press any key to return");
            Console.ReadKey();
        }

        public void AssignAccommodation()
        {
            Console.Clear();
            if (people.Count == 0)
            {
                Console.WriteLine("there is no person");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Select a student to assign accommodation:");
            List<Person> students = new List<Person>();
            foreach (Person p in people)
            {
                if (p.duty == Role.student || p.duty == Role.blockMa)
                {
                    students.Add(p);
                }
            }
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}- {students[i].name}");
            }
            string StudentIndex1 = Console.ReadLine();
            bool isint = int.TryParse(StudentIndex1, out int StudentIndex);
                StudentIndex--;
            if (!isint)
            {

                return;
            }
            Person student = students[StudentIndex];

            Console.WriteLine("Select Dorm:");
            for (int i = 0; i < dorms.Count; i++)
            {
                Console.WriteLine($"{i + 1}- {dorms[i].name}");
            }
            int dormIndex = int.Parse(Console.ReadLine()) - 1;
            student.SetDorm(dorms[dormIndex]);

            Dorm selectedDorm = dorms[dormIndex];
            Console.WriteLine("Select Block:");
            for (int i = 0; i < selectedDorm.blocks.Count; i++)
            {
                Console.WriteLine($"{i + 1}- {selectedDorm.blocks[i].Name}");
            }
            int blockIndex = int.Parse(Console.ReadLine()) - 1;
            student.SetBlock(selectedDorm.blocks[blockIndex]);

            Block selectedBlock = selectedDorm.blocks[blockIndex];
            Console.WriteLine("Select Room:");
            for (int i = 0; i < selectedBlock.rooms.Count; i++)
            {
                Console.WriteLine($"{i + 1}- {selectedBlock.rooms[i].id}");
            }
            int roomIndex = int.Parse(Console.ReadLine()) - 1;
            
            if (selectedBlock.rooms[roomIndex].CanWelcome())
            {
                student.SetRoom(selectedBlock.rooms[roomIndex]);         
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("the room is full!");
                Console.ReadKey();
                return;
            }
            

            Console.WriteLine("Accommodation assigned successfully!");
            Console.ReadKey();
        }

        public void ManageEquipment()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Equipment Management:");
                Console.WriteLine("1- Register new equipment");
                Console.WriteLine("2- Assign to room");
                Console.WriteLine("3- Assign to student");
                Console.WriteLine("4- Move equipment");
                Console.WriteLine("5- Remove personal ownership");
                Console.WriteLine("6- Mark as damaged or under repair");
                Console.WriteLine("7- Show all equipments");
                Console.WriteLine("0- Back");

                int choice = int.Parse(Console.ReadLine());
                if (choice == 0)
                {
                    Console.Clear();
                    break;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            RegisterEquipment();
                            break;
                        case 2:
                            AssignToRoom();
                            break;
                        case 3:
                            AssignToStudent();
                            break;
                        case 4:
                            MoveEquipment();
                            break;
                        case 5:
                            RemoveOwnership();
                            break;
                        case 6:
                            MarkRepair();
                            break;
                        case 7:
                            EquipmentList();
                            Console.ReadKey();
                            break;
                        default:
                            error();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ReadKey();
                }
            }
        }

        public void RegisterEquipment()
        {
            Console.WriteLine("Choose equipment type:");
            foreach (var t in Enum.GetValues(typeof(EquipmentType)))
            {
                Console.Write($"{(int)t}- {t}");
                Console.Write($"(part number:00{(int)t})");
                Console.WriteLine();
               
            }

            EquipmentType type = (EquipmentType)int.Parse(Console.ReadLine());

            Console.WriteLine("Enter 8-character ID (must start with part number):");
            string id = Console.ReadLine();

            Console.WriteLine("Choose dorm for equipment:");
            for (int i = 0; i < dorms.Count; i++)
            {
                Console.WriteLine($"{i + 1}- {dorms[i].name}");
            }
            int dormIndex = int.Parse(Console.ReadLine()) - 1;
            Dorm dorm = dorms[dormIndex];

            new Equipment(type, id, dorm, this);
            Console.WriteLine("Equipment registered successfully!");
        }

        public void AssignToRoom()
        {
            Console.WriteLine("Enter equipment ID:");
            string id = Console.ReadLine();
            Equipment eq = null;
            for (int i = 0;i < equipments.Count; i++)
            {
                if (equipments[i].ID == id)
                {
                    eq = equipments[i];
                    break;
                }
            }
            if (eq == null)
                throw new Exception("Equipment not found");

            Console.WriteLine("Choose dorm:");
            for (int i = 0; i < dorms.Count; i++)
                Console.WriteLine($"{i + 1}- {dorms[i].name}");
            Dorm dorm = dorms[int.Parse(Console.ReadLine()) - 1];

            Console.WriteLine("Choose block:");
            for (int i = 0; i < dorm.blocks.Count; i++)
                Console.WriteLine($"{i + 1}- {dorm.blocks[i].Name}");
            Block block = dorm.blocks[int.Parse(Console.ReadLine()) - 1];

            Console.WriteLine("Choose room:");
            for (int i = 0; i < block.rooms.Count; i++)
                Console.WriteLine($"{i + 1}- Room {block.rooms[i].id}");
            Room room = block.rooms[int.Parse(Console.ReadLine()) - 1];

            eq.AssignEquipTo(room, dorm);
            Console.WriteLine("Assigned to room.");
        }

        public void AssignToStudent()
        {
            Console.WriteLine("Enter equipment ID:");
            string id = Console.ReadLine();
            Equipment eq = null;
            for (int i = 0; i < equipments.Count; i++)
            {
                if (equipments[i].ID == id)
                {
                    eq = equipments[i];
                    break;
                }
            }
            if (eq == null)
                throw new Exception("Equipment not found");

            Console.WriteLine("Select student:");
            List<Person> students = people.Where(p => p.duty != Role.dormMa).ToList();
            for (int i = 0; i < students.Count; i++)
                Console.WriteLine($"{i + 1}- {students[i].name}");
            Person student = students[int.Parse(Console.ReadLine()) - 1];

            eq.AssignEquipTo(student);
            Console.WriteLine("Assigned to student.");
        }

        public void MoveEquipment()
        {
            Console.WriteLine("Enter equipment ID:");
            string id = Console.ReadLine();
            Equipment eq = null;
            for (int i = 0; i < equipments.Count; i++)
            {
                if (equipments[i].ID == id)
                {
                    eq = equipments[i];
                    break;
                }
            }
            if (eq == null)
                throw new Exception("Equipment not found");

            Console.WriteLine("Move to:");
            Console.WriteLine("1- Another room");
            Console.WriteLine("2- Another student");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Choose dorm:");
                for (int i = 0; i < dorms.Count; i++)
                    Console.WriteLine($"{i + 1}- {dorms[i].name}");
                Dorm dorm = dorms[int.Parse(Console.ReadLine()) - 1];

                Console.WriteLine("Choose block:");
                for (int i = 0; i < dorm.blocks.Count; i++)
                    Console.WriteLine($"{i + 1}- {dorm.blocks[i].Name}");
                Block block = dorm.blocks[int.Parse(Console.ReadLine()) - 1];

                Console.WriteLine("Choose room:");
                for (int i = 0; i < block.rooms.Count; i++)
                    Console.WriteLine($"{i + 1}- Room {block.rooms[i].id}");
                Room room = block.rooms[int.Parse(Console.ReadLine()) - 1];

                eq.ReassignEquip(room);
                Console.WriteLine("Equipment moved to another room.");
            }
            else if (choice == 2)
            {
                Console.WriteLine("Select new student:");
                List<Person> students = people.Where(p => p.duty != Role.dormMa).ToList();
                for (int i = 0; i < students.Count; i++)
                    Console.WriteLine($"{i + 1}- {students[i].name}");
                Person student = students[int.Parse(Console.ReadLine()) - 1];

                eq.ReassignEquip(student);
                Console.WriteLine("Equipment reassigned to another student.");
            }
        }

        public void RemoveOwnership()
        {
            Console.WriteLine("Enter equipment ID:");
            string id = Console.ReadLine();
            Equipment eq = null;
            for (int i = 0; i < equipments.Count; i++)
            {
                if (equipments[i].ID == id)
                {
                    eq = equipments[i];
                    break;
                }
            }
            if (eq == null)
                throw new Exception("Equipment not found");

            eq.DeleteOwner();
            Console.WriteLine("Ownership removed.");
        }

        public void MarkRepair()
        {
            Console.WriteLine("Enter equipment ID:");
            string id = Console.ReadLine();
            Equipment eq = null;
            for (int i = 0; i < equipments.Count; i++)
            {
                if (equipments[i].ID == id)
                {
                    eq = equipments[i];
                    break;
                }
            }
            if (eq == null)
                throw new Exception("Equipment not found");

            Console.WriteLine("1- Mark as damaged");
            Console.WriteLine("2- Mark as under repair");

            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Equipment.IsDamaged(id, equipments);
                Console.WriteLine("Marked as damaged.");
            }
            else if (choice == 2)
            {
                Console.Write("Enter repair description: ");
                string desc = Console.ReadLine();
                Equipment.NeedsRepair(id, desc, equipments);
                Console.WriteLine("Marked as under repair.");
            }
        }

        public void Reporting()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Reporting Menu:");
                Console.WriteLine("1- Accommodation Status");
                Console.WriteLine("2- Equipment Status");
                Console.WriteLine("3- Specialized Reports");
                Console.WriteLine("0- Back");

                int choice = int.Parse(Console.ReadLine());
                if (choice == 0) break;

                switch (choice)
                {
                    case 1:
                        AccommodationReports();
                        break;
                    case 2:
                        EquipmentReports();
                        break;
                    case 3:
                        SpecializedReports();
                        break;
                    default:
                        error();
                        break;
                }
            }
        }

        public void AccommodationReports()
        {
            Console.Clear();
            Console.WriteLine("1- General Student Accommodation Statistics");
            Console.WriteLine("2- List of all rooms and their status");
            Console.WriteLine("3- Remaining capacity of each dorm and block");

            int option = int.Parse(Console.ReadLine());
            if (option == 1) GeneralStatus();
            else if (option == 2) ShowAllRooms();
            else if (option == 3) RemainingCapacity();
            else error();

            Console.WriteLine("Press Enter to return");
            Console.ReadLine();
        }

        public void ShowAllRooms()
        {
            foreach (Dorm dorm in dorms)
            {
                Console.WriteLine($"Dorm: {dorm.name}");
                foreach (Block block in dorm.blocks)
                {
                    Console.WriteLine($"  Block: {block.Name}");
                    foreach (Room room in block.rooms)
                    {
                        int studentsInRoom = 0;
                        for (int i = 0; i < people.Count; i++)
                        {
                            if (people[i].residingRoom == room)
                                studentsInRoom++;
                        }
                        Console.WriteLine($"    Room {room.id} - Capacity: 6 - Occupied: {studentsInRoom}");
                    }
                }
                Console.WriteLine("----------------------------------");
            }
        }

        public void EquipmentReports()
        {
            Console.Clear();
            Console.WriteLine("1- Equipment List");
            Console.WriteLine("2- Equipments assigned to each room");
            Console.WriteLine("3- Equipments assigned to each student");
            Console.WriteLine("4- Damaged / Under Repair equipments");

            int option = int.Parse(Console.ReadLine());
            if (option == 1) EquipmentList();
            else if (option == 2) RoomEquipments();
            else if (option == 3) StudentEquipments();
            else if (option == 4) DamagedEquipments();
            else error();

            Console.WriteLine("Press Enter to return");
            Console.ReadLine();
        }

        public void SpecializedReports()
        {
            Console.Clear();
            Console.WriteLine("1- Repair request descriptions");
            Console.WriteLine("2- Student accommodation history");

            int option = int.Parse(Console.ReadLine());
            if (option == 1) RepairRequests();
            else if (option == 2) AccomodationHistory();
            else error();

            Console.WriteLine("Press Enter to return");
            Console.ReadLine();
        }

    }
}

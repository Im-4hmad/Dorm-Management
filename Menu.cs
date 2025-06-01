using System;
//using Person;
//namespace Menu
//{

    class Menu
    {

        List<Dorm> dorms = new List<Dorm>();
        List<Block> blocks = new List<Block>();
        List<Person> people = new List<Person>();
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
}
//}

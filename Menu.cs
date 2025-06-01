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
            dorms.Add(new Dorm(name, address, capacity));
        }

    public void showDorms()
    {
        int cnt = 1;
        foreach (Dorm d in dorms) {
            Console.WriteLine(cnt + " - "); 
            d.Show();
            cnt++;
        }
       
    }
    public void deleteDorm()
    {
        if (dorms.Count == 0)
        {
            Console.WriteLine("NO Dorms available to Delete");
            return;
        }
        Console.WriteLine("choose the index of block to delete");
        
        showDorms();

        int choice = int.Parse(Console.ReadLine());
        if (choice > dorms.Count || choice < 1) error();
        dorms.RemoveAt(choice - 1);
        Console.WriteLine("deletion completed");

    }
    public void updateDorm()
    {
        if (dorms.Count == 0)
        {
            Console.WriteLine("NO Dorms available to update");
            return;
        }
        Console.WriteLine("choose the index of block to Update");

        showDorms();

        int choice = int.Parse(Console.ReadLine());
        if (choice > dorms.Count || choice < 1) error();
        dorms[choice - 1].update();
        //Console.WriteLine("deletion completed");

    }

}
//}

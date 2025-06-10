using System;

using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Equipment;
//namespace Dorm
//{
    class Dorm
    {
    private int id;
    private string name, address;
        private int capacity;
        private Person manager;
        private List <Block> blocks=new List<Block>();
    public string Name { get; set; }
    //list for Equipment Ids needed for Equipment Class
    public List<String> IDs { get; } = new List<String>();
    //list for unassigned equipments
    public List<Equipment> unassignedEquip { get; } = new List<Equipment>();
    //list for assigned equipments
    public List<Equipment> assignedEquip { get; } = new List<Equipment>();
    public int Id
    {
        get { return id; }
    }
    public Dorm(string name,string address,int capacity,int id)
    {
        this.id = id; 
        this.name = name;
        this.address = address;
        this.capacity = capacity;
    }
    public Person Manager
    {
        get { return manager; }
        set { manager = value; }
    }
    public void Show()
    {
        Console.WriteLine("Id of dorm : " + id);

        Console.WriteLine("name of dorm : " + name);
        Console.WriteLine("address of dorm : " + address);
        Console.WriteLine("capacity of dorm : " + capacity);
        Console.WriteLine("manager of dorm : " + Manager.name);

        Console.WriteLine("<<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>>");
        
    }
    public void update()
    {
        Console.WriteLine("choose what u wanna update  : ");
        Console.WriteLine("1- name "  );
        Console.WriteLine("2- address ");
        Console.WriteLine("3- capacity");
        Console.WriteLine("4- Manager");
        int choice = int.Parse(Console.ReadLine());
        if (choice < 0 || choice > 4) return ;
        if (choice == 4)
        {
            Console.WriteLine("you can update manager and their dorm in people management menu");
            return;
        }
    
        if (choice == 1)
        {
            Console.WriteLine("Enter new Name ");
            name = Console.ReadLine().Trim();
        }
        if (choice == 2)
        {
            Console.WriteLine("Enter new address ");
            address = Console.ReadLine().Trim();
        }
        if (choice == 3)
        {
            Console.WriteLine("Enter new capacity ");
            capacity = int.Parse(Console.ReadLine().Trim());
        }
        Console.WriteLine("updated successfully");
        this.Show();
    }
    public void showBlocks()
    {
        if (blocks.Count == 0)
        {
            Console.WriteLine("no blocks :(");
            return;
        }
        foreach (Block block in blocks) block.Show();
    }
    public void manageBlocks()
    {
        Console.WriteLine("managing blocks");
        Console.WriteLine("1-Add Block");
        Console.WriteLine("2-Delete Block");
        Console.WriteLine("3-Edit Block");
        Console.WriteLine("4-show Block");
        int choice =int.Parse(Console.ReadLine().Trim());
        if (choice == 4)
        {
            showBlocks();
        }
        else if (choice == 1)
        {
            int id = 1;
            foreach (Block block in blocks)
                id += block.Id;
            string name;
            int floor;
            Console.Write("Enter Block name ; ");
            name = Console.ReadLine();
            Console.Write("Enter Block floor count ; ");

            floor = int.Parse(Console.ReadLine());
            blocks.Add(new Block(name, floor, id));
        }
        else if (choice == 2)
        {
            showBlocks();
            Console.Write("Enter Block that you wanna delete ; ");
            int id = int.Parse(Console.ReadLine().Trim());
            foreach (Block block in blocks)
                if (block.Id == id)
                {
                    blocks.Remove(block);
                    Console.WriteLine("block deleted");
                    return;
                }
            Console.WriteLine("404 block not found :)");
        }
        else if (choice == 3)
        {

            // update stuff
        }
        else Console.WriteLine("invalid input");
    }
}
//}

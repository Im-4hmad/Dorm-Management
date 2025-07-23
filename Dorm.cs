using System;

using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DormManagement
{
public class Dorm
    {
    private int id;
    public string name, address;
        public int capacity;
        private Person manager;
        public List <Block> blocks=new List<Block>();
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
            this.manager = new Person();
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
            if (Manager.id != "-1")
                Console.WriteLine("manager of dorm : " + Manager.name);
            else Console.WriteLine("no manager asigned yet");

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
    public void manageBlocks(Menu m)
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
            int Blockid = 1;
            foreach (Block block in blocks)
                    Blockid += block.Id;
            string name;
            int floor;
            Console.Write("Enter Block name ; ");
            name = Console.ReadLine();
            Console.Write("Enter Block floor count ; ");

            floor = int.Parse(Console.ReadLine());
            blocks.Add(new Block(name, floor, Blockid, this.id));
                
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

                Console.WriteLine("1-Edit block info");
                Console.WriteLine("2-room management");
                 choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {

                    Console.WriteLine("choose the id of block to update");

                    showBlocks();

                    choice = int.Parse(Console.ReadLine());

                    foreach (Block block in blocks)
                        if (block.
                        Id == choice)
                        {

                            block.update();
                            return;
                        }

                    Console.WriteLine("not found the dorm with the corresponding id");
                }
                else if (choice == 2)
                {

                    Console.WriteLine("choose the id of block you wanna manage the rooms");
                    if(this.blocks.Count == 0)
                    {
                        Console.WriteLine("there is no block :(");
                        return;
                    }
                    showBlocks();
                    choice = int.Parse(Console.ReadLine());


                    foreach (Block block in blocks)
                        if (block.
                        Id == choice)
                        {

                            block.manageRooms(m);
                            return;
                        }

                    

                    Console.WriteLine("not found the block with the corresponding id");

                }

               
            }
            else Console.WriteLine("invalid input");
    }
}
}

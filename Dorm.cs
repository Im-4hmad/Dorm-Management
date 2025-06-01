using System;

using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
//namespace Dorm
//{
    class Dorm
    {
        private string name, address;
        private int capacity;
        private Person manager;
        private List <Block> blocks;
    public string Name { get; set; }

    public Dorm(string name,string address,int capacity)
    {
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
        Console.WriteLine("name of dorm : " + name);
        Console.WriteLine("address of dorm : " + address);
        Console.WriteLine("capacity of dorm : " + capacity);
        Console.WriteLine("manager of dorm : " + " *** TODO ++++ ");

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
}
//}

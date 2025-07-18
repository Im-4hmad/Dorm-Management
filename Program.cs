using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
//using Project;
//using Room;
namespace DormManagement
{
    
    
   
  

    internal class Program
    { 
        public static void test()
             {
          //createran

        }
        public static void error()
        {
            Console.WriteLine("please choose a valid option");
        }
        public static void Neat()
        {
            Console.WriteLine("enter any key to continue");
            Console.ReadLine();
            Console.Clear();
        }
        //Menu m = new Menu();
        static void Main(string[] args)
        {
            Menu m = new Menu();
            //Console.WriteLine(r.id);
            //Console.Read();
            while (true)
            {
                m.updateBlocks();
                try
                {


                    Console.WriteLine("please choose an option: ");
                    Console.WriteLine("1-Dorm management");
                    Console.WriteLine("2-Student management");
                    Console.WriteLine("3-equipment management");
                    Console.WriteLine("4-Reporting");
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 1)
                    {
                        Console.WriteLine("1-Add Dorm");
                        Console.WriteLine("2-Delete Dorm");
                        Console.WriteLine("3-Edit Dorm");
                        Console.WriteLine("4-show Dorms");
                        choice = int.Parse(Console.ReadLine().Trim());

                        if (choice == 1) m.addDorm();
                        else if (choice == 2) m.deleteDorm();
                        else if (choice == 3) m.updateDorm();
                        else if (choice == 4) m.showDorms();
                        else error();
                    }
                    else if (choice == 2)
                    {
                        m.ManagePeople();
                    }
                    else if (choice == 3)
                    {
                        m.ManageEquipment();
                    }
                    else if (choice == 4)
                    {
                        m.Reporting();
                    }
                    else
                        error();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                //Console.Read();
            }
        }
    }
}

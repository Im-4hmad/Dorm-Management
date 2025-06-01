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
        //Menu m = new Menu();
        static void Main(string[] args)
        {
            Menu m = new Menu();
            //Console.WriteLine(r.id);
            //Console.Read();
            while (true)
            {
                try
                {


                    Console.WriteLine("please choose an option: ");
                    Console.WriteLine("1-Drom management");
                    Console.WriteLine("2-Block management");
                    Console.WriteLine("3-Student management");
                    Console.WriteLine("4-equipment management");
                    Console.WriteLine("5-Reporting");
                    int choice = int.Parse(Console.ReadLine().Trim());
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
                        //Console.WriteLine("1-Add Block");
                        //Console.WriteLine("2-Delete Block");
                        //Console.WriteLine("3-Edit Block");
                        //Console.WriteLine("4-show Block");
                        //choice = int.Parse(Console.ReadLine().Trim());
                        //if (choice == 1) m.addBlock();
                        //else if (choice == 2) m.deleteBlock();
                        //else if (choice == 3) m.updateBlock();
                        //else if (choice == 4) m.showBlocks();
                        //else error();
                    }
                    else if (choice == 3)
                    {

                    }
                    else if (choice == 4)
                    {

                    }
                    else if (choice == 5)
                    {

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

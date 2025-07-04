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
                try
                {


                    Console.WriteLine("please choose an option: ");
                    Console.WriteLine("1-Drom management");
                    Console.WriteLine("2-Block management");
                    Console.WriteLine("3-Student management");
                    Console.WriteLine("4-equipment management");
                    Console.WriteLine("5-Reporting");
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

                        //this part must be written with try-catch!! and a loop so that user can assign as many items as he please

                        //تخصیص اموال به اتاق ها:

                        // برای تخصیص اموال به اتاق ها متد آماده در کلاس تجهیزات موجوده

                        //فقط قبلش نیاز به یک زیر منو هست تا لیست تمام خوابگاه ها و سپس بلوک ها رو نمایش بده تا بتونه کاربر اتاق مورد نظرش رو انتخاب کنه

                        //بعدش هم یه زیر منو دیگه که بتونه از بین تجهیزات موجود و اختصاص داده نشده یکی رو اختصاص بده به اتاق

                        //نکته مهم اینه که تجهیزات باید متعلق به همون خوابگاه باشن و توی لیست اون خوابگاه باشن

                        //تخصیص اموال به دانشجویان:


                        //منطق کار اینه تا وقتی وسیله ای توی اتاقی نیومده نمیتونه صاحب شخصی داشته باشه پس تخصیص فقط به دانشجویان حاضر در اون اتاقه

                        //در ضمن در اون لیستی که نمایش داده میشه از بین وسایل یک اتاق تا به دانشجو اختصاص داده بشه اولا وسایل شخصی بقیه دیگه نباید بیان دوما یخچال هم نباید بیاد توی اون لیست

                        //جا به جایی اموال

                        //اول طبق روال پیش میره تا برسیم به اتاقی که میخوایم از توش وسیله برداریم

                        //ما فقط میتونیم از وسایل بدون مالکیت بین اتاق ها جا به جا کنیم(لیستی که توی کلاس خوابگاه هست)

                        //جابه جایی مالکیت شخصی وسایل فقط بین افراد یک اتاق ممکنه

                        //به یک زیر منو برای حذف مالکیت شخصی هم نیاز داریم اینجا

                        //برای ثبت درخواست تعمیرات یه متن هم از کاربر میگیره
                    }
                    else if (choice == 5)
                    {
                        Console.WriteLine("1-Accommodation status");
                        Console.WriteLine("2-Equipments status");
                        console.WriteLine("3-Specialized Report");
                        int n = int.Parse(Console.ReadLine());

                        if (n == 1)
                        {
                            Console.WriteLine("1-General Student Accommodation Statistics");
                            Console.WriteLine("2-List of all rooms");
                            Console.WriteLine("3-Remaining Capacity of Each Dormitory and Block");
                            int temp = int.Parse(Console.ReadLine());
                            if (temp == 1)
                            {
                                m.GeneralStatus();
                                Neat();
                            }
                            else if (temp == 2) { /* این بخش بعدا باید بر اساس کلاس اتاق تکمیل بشه*/}
                            else if (temp == 3)
                            {
                                m.RemainingCapacity();
                                Neat();
                            }
                            else error();

                        }
                        else if (n == 2)
                        {
                            Console.WriteLine("1-Equipment List");
                            Console.WriteLine("2-assigned equipments to each room");
                            Console.WriteLine("3-assigned equipments to each student");
                            Console.WriteLine("4-list of damaged and under repair equipments");
                            int temp = int.Parse(Console.ReadLine());
                            if (temp == 1)
                            {
                                m.EquipmentList();
                                Neat();
                            }
                            else if (temp == 2) 
                                {
                                    m.RoomEquipments();
                                    Neat();
                                }
                             else if (temp == 3)
                                {
                                    m.StudentEquipments();
                                    Neat();
                                }
                                else if (temp == 4)
                                {
                                    m.DamagedEquipments();
                                    Neat();
                                }
                                else error();
                            }
                        else if(n == 3)
                        {
                            Console.WriteLine("1-repair request reports");
                            Console.WriteLine("2-Students Accommodation History");
                            int temp = int.Parse(Console.ReadLine());
                            if(temp == 1)
                            {
                                m.RoomEquipments();
                                Neat();
                            }
                            else if(temp == 2)
                            {
                                m.AccomodationHistory();
                                Neat();
                            }
                        }
                       
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

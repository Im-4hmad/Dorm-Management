using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public enum Role
    {
        dormMa, 
        blockMa,
        student
    }
    internal class Person
    {


        public Role duty { get; set; }
        public String name { get; set; }
        public String id { get; set; }
        public string stID { get; set; }
        public String pnumber { get; set; }
        public String address { get; set; }
        //برای خوابگاه و بلوک تحت مسولیت مسئول ها
        public Dorm resDorm { get; set; }
        public Block resBlock { get; set; }
        // ,هم برای مشخصات اتاق دانشجو هم بلوک اش 
        public Block residingBlock { get; set; }
        //خوابگاه تحت اقامت دانشجو و مسئول بلوک
        public Dorm residingDorm { get; set; }
        //تجهیزات اختصاص داده شده
        public Equipment equipment { get; set; }
        //کانستراکتور برای مسئول خوابگاه
        public Person(string Name,  string ID, string Pnumber, string Address, Dorm dorm)
        {
            name = Name;
            id = ID;
            pnumber = Pnumber;
            address = Address;
            duty = Role.dormMa;
            resDorm = dorm;
        }
        //اگر تغییر قرار بود فقط برای مشخصاتی مثل شماره ملی و ... انجام بشه که از همون متد ادیت جلوتر استفاده میشه ولی برای تغییر خوابگاه تحت مسئولیت این کار اینجا انجام میشه
        public void EditDormMa(Dorm A)
        {
            resDorm = A;
        }
        //فرض رو بر این گذاشتم که ما برای نمایش لیست مسئولان خوابگاه لیستی که اونا توش ذخیره شدن رو به این متد پاس میدیم و اینجا فقط اسم و خوابگاه تحت مسئولیت نمایش داده میشه
        public static void ShowDorMa(List<Person> list)
        {
            foreach(Person person in list)
            {
                Console.WriteLine(person.name);
                person.resDorm.Show();
                Console.WriteLine();
            }
        }
        //برای دانشجو
        public Person(string Name, Role Duty, string ID, string Pnumber, string Address, string StID)
        {
            this.name = Name;
            this.duty = Duty;
            this.id = ID;
            this.pnumber = Pnumber;
            this.address = Address;
            this.stID = StID;
        }
        //تبدیل دانشجو به مسئول بلوک برای تغییر مسئول هم استفاده میشه, البته بلوکی که مسئولش میشه هم با فرض اینکه از کاربر پرسیده شده بهش پاس داده میشه
        //فرض رو بر این گذاشتم که داخل مین بررسی میشه که شخص داخل لیست دانشجو های ثبت شده هست یا نه بعد اگر بود نقشش عوض میشه
        public void MakeBlockMa(Block A)
        {
            duty = Role.blockMa;
            resBlock = A;
        }
        //حذف مسئول بلوک
        public void RemoveRole()
        {
            duty = Role.student;
            resBlock = null;
        }
        //برای مشاهده لیست مسئولان بلوک
        public static void ShowBlockMa(List<Person> list)
        {
            foreach (Person person in list)
            {
                Console.Write(person.name);
                person.resBlock.Show();
                Console.WriteLine() ;
            }
        }
        //این متد، هم برای ثبت نام دانشجو هم جا به جایی دانشجو
        public void SetBlockDorm(Block A, Dorm B)
        {
            residingBlock = A;
            residingDorm = B;
        }
        public void Equip(Equipment A)
        {
            equipment = A;
        }
        public void Show()
        {

            if(resBlock == null)
            {
                Console.WriteLine("Student still doesn't have Block,Dorm and Room");
            }
            else
            {
                //نمایش هم اتاق هم بیوک
                residingBlock.Show();
                //نمایش اطلاعات خوابگاه
                residingDorm.Show();
            }
            if(equipment == null)
            {
                Console.WriteLine("Student still doesn't have any equipment");
            }
            else
            {
                //نمایش تجهیزات اختصاص داده شده
                equipment.Show();
            }
        }
        //برای تغییر مشخصات دانشجو،مسئول بلوک و مسئول خوابگاه
         // فرض رو بر این میزارم داخل برنامه اول از کاربر میپرسه چی رو میخواد تغییر بده از این دانشجو و بعد همون ورودی اش پاس داده میشه به این تابع
        public void Edit(string info)
        {
            if(info == null)
            {
                Console.WriteLine("error: empty input");
                return;
            }
            if(info == "name")
            {
                string newName = Console.ReadLine();
                name = newName;
                Console.WriteLine("successful");
            }
            else if(info == "ID")
            {
                string newID = Console.ReadLine();
                id = newID;
                Console.WriteLine("successful");
            }
            else if(info =="student ID" && (duty == Role.student || duty == Role.blockMa))
            {
                string newStID = Console.ReadLine();
                stID = newStID;
                Console.WriteLine("successful");
            }
            else if(info == "phone number")
            {
                string newPhoneNum = Console.ReadLine();
                pnumber = newPhoneNum;
                Console.WriteLine("successful");
            }
            else if(info == "address")
            {
                string NewAddress = Console.ReadLine();
                address = NewAddress;
                Console.WriteLine("successful");
            }
            else
            {
                Console.WriteLine("not found");
            }
        }
    }
}

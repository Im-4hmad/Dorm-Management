using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DormManagement
{
    public enum Role
    {
        dormMa,
        blockMa,
        student
    }
    public class Person
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
        private List<Equipment> equipments = new List<Equipment>();
        public List<Equipment> Equipments { get { return equipments; } }
        //اتاق تحت اقامت دانشجو
        public Room residingRoom { get; set; }
         //سه لیست برای ذخیره تاریخچه اقامت دانشجو
        public List<Dorm> DormHistory { get; set; } = new List<Dorm>();
       public List<Block> BlockHistory { get; set; } = new List<Block>();
       public List<Room> RoomHistory { get; set; } = new List<Room>();
      //کانستراکتور برای مسئول خوابگاه
    public Person(string Name, string ID, string Pnumber, string Address, Dorm dorm)
        {
            name = Name;
            id = ID;
            pnumber = Pnumber;
            address = Address;
            duty = Role.dormMa;
            resDorm = dorm;
            dorm.Manager = this;
        }
        //اگر تغییر قرار بود فقط برای مشخصاتی مثل شماره ملی و ... انجام بشه که از همون متد ادیت جلوتر استفاده میشه ولی برای تغییر خوابگاه تحت مسئولیت این کار اینجا انجام میشه
        public void EditDormMa(Dorm A)
        {
            resDorm = A;
        }
        //فرض رو بر این گذاشتم که ما برای نمایش لیست مسئولان خوابگاه لیستی که اونا توش ذخیره شدن رو به این متد پاس میدیم و اینجا فقط اسم و خوابگاه تحت مسئولیت نمایش داده میشه
        public static void ShowDormMa(List<Person> list)
        {
            foreach (Person person in list)
            {
                if (person.duty == Role.dormMa)
                    person.Show();
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
            if(person.duty == Role.blockMa)
                {
                person.Show();
                Console.WriteLine();

                }
            }
        }
        //این متد، هم برای ثبت نام دانشجو در بلوک اتاق و خوابگاه هم جا به جایی دانشجو
        public void SetDorm(Dorm B)
        {
            residingDorm = B;
            DormHistory.Add(residingDorm);
        }
        public void SetBlock(Block A)
        {
            residingBlock = A;
            BlockHistory.Add(residingBlock);
        }
        public void SetRoom(Room C)
        {
            residingRoom = C;
            RoomHistory.Add(residingRoom);
        }

         // این متد برای نمایش مشخصات دانشجو هست از حمله نمایش بلوک و خوابگاه اختصاص داده شده
         //متد برای نمایش مشخصات کلی مثل اسم جدا تعریف شده
        public void ShowSt()
        {

            if (residingDorm == null)
            {
                Console.WriteLine("No dorm assigned");
            }
             else
             {
            //نمایش اطلاعات خوابگاه
            Console.WriteLine($"Current residence Dorm: {this.residingDorm.Name}");
             }
            if(residingBlock == null)
        {
            Console.WriteLine("No block assigned");
        }
        else
        {
            //نمایش  بلوک
            Console.WriteLine($"Current residence block: {this.residingBlock.Name}");
        }
            if(residingRoom == null)
        {
            Console.WriteLine("No room assigned");
        }
            else
            {
               // نمایش اتاق دانشجو
                Console.WriteLine($"Current residence room: {this.residingRoom.id}");

            }
            if (equipments.Count == 0)
            {
                Console.WriteLine("No Equipment assigned");
            }
            else
            {
                //نمایش تجهیزات اختصاص داده شده
                //equipment.Show();
            }
        }
    // این متد بیشتر برای متد نمایش لیست مسئولان بلوک و خوابگاه استفاده میشود
    public void Show()
    {
        if(this.duty == Role.blockMa)
        {
            Console.WriteLine(this.name);
            Console.WriteLine(this.pnumber);
            Console.WriteLine(this.id);
            Console.WriteLine(this.address);
            Console.WriteLine($"responsible of block: {resBlock.Name}");
        }
        else if(this.duty == Role.dormMa)
        {
            Console.WriteLine(this.name);
            Console.WriteLine(this.pnumber);
            Console.WriteLine(this.id);
            Console.WriteLine(this.address);
            Console.WriteLine($"responsible of dorm: {resDorm.Name}");
        }
    }
        //برای تغییر مشخصات دانشجو و مسئول بلوک 
        
    // فرض رو بر این میزارم داخل برنامه اول از کاربر میپرسه چی رو میخواد تغییر بده از این دانشجو و بعد همون ورودی اش پاس داده میشه به این تابع

    //بهتره برای استفاده از این متد در برنامه به کاربر بگیم دقیقا چی  وارد کنه(اینکه میخواد چی رو تغییر بده) یا اینکه با اعداد بگیم اگر با اعداد باشه این متد بعدا قراره کمی تغییر کنه
        public void Edit(string info)
        {
            if (info == null)
            {
                Console.WriteLine("error: empty input");
                return;
            }
            if (info == "name")
            {
                string newName = Console.ReadLine();
                name = newName;
                Console.WriteLine("successful");
            }
            else if (info == "ID")
            {
                string newID = Console.ReadLine();
                id = newID;
                Console.WriteLine("successful");
            }
            else if (info == "student ID" && (duty == Role.student || duty == Role.blockMa))
            {
                string newStID = Console.ReadLine();
                stID = newStID;
                Console.WriteLine("successful");
            }
            else if (info == "phone number")
            {
                string newPhoneNum = Console.ReadLine();
                pnumber = newPhoneNum;
                Console.WriteLine("successful");
            }
            else if (info == "address")
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
    public bool CanAcceptEquipment(Equipment e)
    {
        int closetNum = this.Equipments.Count(r => r.type == EquipmentType.Closet);
        int bedNum = this.Equipments.Count(r => r.type == EquipmentType.Bed);
        int chairNum = this.Equipments.Count(r => r.type == EquipmentType.Chair);
        int DeskNum = this.Equipments.Count(r => r.type == EquipmentType.Desk);

        if (closetNum == 1 && e.type == EquipmentType.Closet)
        {
            //throw new Exception("can't assign more closet to this person");
            return false;
        }
        else if (bedNum == 1 && e.type == EquipmentType.Bed)
        {
            //throw new Exception("can't assign more bed to this person");
            return false;
        }
        else if (chairNum == 1 && e.type == EquipmentType.Chair)
        {
            //throw new Exception("can't assign more chair to this person");
            return false;
        }
        else if (DeskNum == 1 && e.type == EquipmentType.Desk)
        {
            //throw new Exception("can't assign more Desk to this person");
            return false;
        }
        return true;
    }
    }
}

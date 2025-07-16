using System;
using System.Linq;
/*using Room;
using Dorm;
using Person;*/
namespace DormManagement
{
public enum EquipmentType
{
    Fridge = 1,
    Closet = 5,
    Desk = 2,
    Chair = 3,
    Bed = 4
}
public class Equipment
{
    public EquipmentType type;
    //string array with 5 equipment and use partnumber as index to access
    public int status;//status 0 is ok 1: damaged 2: fixing and so on
    private string _id;
    public string ID { 
        get 
        {
        return _id;
        }
        
        set {
           
            _id = value;
            
            } 
    }
    //توضیحات کاربر برای درخواست تعمیرات
    public string Description { get; set; }
    private string partNum;
    private Room room;
    private Person owner;
    //private student owner
    //ثبت اموال جدید
    //در menu باید بررسی بشه که کاربر چی میخواد ثبت کنه و خود برنامه فقط کافیه نوع تجهیز رو پاس بده اینجا خودکار پارت نامبر ساخته میشه
    //البته باید از قبل چک شده باشه که شماره اموال مشکلی نداشته باشه و هم خوانی داشتته باشه با پارت نامبر متدش رو توی همین کلاس تعریف میکنم جلوتر
    public Equipment(EquipmentType Type, string id, Dorm d, Menu m)
    {
        this.type = Type;

        if ((int)Type == 1)
        {
            partNum = "001";
        }
        else if ((int)Type == 2)
        {
            partNum = "002";
        }
        else if ((int)Type == 3)
        {
            partNum = "003";
        }
        else if ((int)Type == 4)
        {
            partNum = "004";
        }
        else if ((int)Type == 5)
        {
            partNum = "005";
        }
        if (this.CheckID(id))
        {
                for (int i = 0; i < m.equipments.Count; i++)
                {
                    if (m.equipments[i].ID == id)
                    {
                        throw new Exception("ID must be unique");
                    }

                }
                ID = id;
                
        }
        else
        {
            throw new Exception("ID does no match part number");
        }
        //اضافه کردنش به لیست اموال یک خوابگاه
        d.unassignedEquip.Add(this);
        status = 0;
        //اضافه کردنش به لیست اموال کلی
        m.equipments.Add(this);
    }
    public bool CheckID(string id)
    {
        if(id.Length < 8)
        {
            return false;
        }
        if (id.Substring(0, 3) == this.partNum) 
        {
            return true;       
        }
        else
        {
            return false;
        }
        
    }
    //متد برای تخصیص وسیله به اتاق
    public void AssignEquipTo(Room Room, Dorm d)
    {
        //اول باید چک کنه که یخچال دو تا توی یه اتاق نره بقیه وسایل تا 6 تا میشه

        if (Room.CanAcceptEquipment(this))
        {
            Room.Equipments.Add(this);
            room = Room;
            d.unassignedEquip.Remove(this);
            d.assignedEquip.Add(this);
        }
        else
        {
            throw new Exception("can't assign more of this item to this room");
        }

    }
    //متد برای تخصیص اموال به دانشجو
    public void AssignEquipTo(Person person)
    {

        if (person.CanAcceptEquipment(this))
        {
            this.owner = person;
            person.Equipments.Add(this);
        }
        else
        {
            throw new Exception("can't assign more of this item to this person");
        }
    }
    //متد برای تعویض اتاق وسیله
    public void ReassignEquip(Room Room)
    {
        bool hasItem = Room.Equipments.Any(e => e.type == this.type);
        //مقصد وسیله رو نداره یعنی انتقاله
        if (!hasItem)
        {
            Room.Equipments.Add(this);
            room.Equipments.Remove(this);
            room = Room;
        }
        //جا به جایی
        else
        {
            // ذخیره یکی از اموال غیر شخصی اتاق مقصد که از نوع وسیله جا به جایی هست
            Equipment equip = Room.Equipments.FirstOrDefault(e => e.type == this.type);
            //گرفتن از اتاق مقصد
            Room.Equipments.Remove(equip);
            //گرفتن از اتاق مبدا
            room.Equipments.Remove(this);
            //جا به جایی
            Room.Equipments.Add(this);
            room.Equipments.Add(equip);
            room = Room;
        }

    }
    public void ReassignEquip(Person p)
    {
        //اول چک کنه شخص مقصد اون وسیله رو داره یا نه اگر داشت تعویضه نداشت انتقاله
        bool hasItem = p.Equipments.Any(e => e.type == this.type);
        if (!hasItem)
        {
        
        //از لیست شخص مالکش هم باید پاک بشه
        this.owner.Equipments.Remove(this);
        
        //به شخص مورد نظر اضافه بشه
        p.Equipments.Add(this);

        owner = p;
        }
       
        else
        {
            //دارایی شخص مقصد رو ذخیره کن
            Equipment equip = p.Equipments.FirstOrDefault(e => e.type == this.type);
            //دارایی شخص مقصد رو ازش بگیر
            p.Equipments.Remove(equip);
            //دارایی شخص مبدا رو ذخیره کن
            Equipment equip2 = this;
            //دارایی شخص مبدا رو ازش بگیر
            owner.Equipments.Remove(this);
            // دارایی ها رو جا به جا کن
            p.Equipments.Add(equip2);
            owner.Equipments.Add(equip);
            owner = p;

        }
    }

    //متد برای حذف مالکیت شخصی
    public void DeleteOwner()
    {
        if(owner != null)
        owner.Equipments.Remove(this);
        owner = null;

    }
    
    public static void NeedsRepair(string id, string description, List<Equipment> allEquipments)
    {
        if(id == null || id.Length != 8)
        {
            throw new Exception("ID is not valid");
        }
        if (allEquipments.Count == 0)
        {
            throw new Exception("there are no equipments");
        }
        
        foreach (var equip in allEquipments)
        {
            if(equip.ID == id)
            {
                equip.status = 2;
                description = description;
                return;
            }
        }
        throw new Exception("id was not found");
        
    }
    public static string RepairStatus(string id, List<Equipment> allEquipments)
    {
        foreach (var equip in allEquipments)
        {
            if (equip.ID == id)
            {
                if(equip.status == 0)
                {
                    return "the item is usable";
                }
                else if(equip.status == 1)
                {
                    return "the item is damaged";
                }
                else
                {
                    return "the item is under repair";
                }
            }
        }
            return "the item Doesn't exist";

    }
    //باید لیست تمام تجهیزات داخل کلاس منو هم به عنوان پارامتر داده بشه تا چک کنه 
    public static void IsDamaged(string id,List<Equipment> allEquipments)
    {
        if (id == null || id.Length != 8)
        {
            throw new Exception("ID is not valid");
        }
        if (allEquipments.Count == 0)
        {
            throw new Exception("there are no equipments");
        }

        foreach (var equip in allEquipments)
        {
            if (equip.ID == id)
            {
                equip.status = 1;
                return;
            }
        }
        throw new Exception("id was not found");

    }

}

}

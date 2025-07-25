﻿using System;


 namespace DormManagement
{
    public class Room
    {

        private List<Equipment> equipments = new List<Equipment>();
        public List<Person> people = new List<Person>();
        public List<Equipment> Equipments
        {
            get { return equipments; }
        }
        public void Show(Block block)
        {
            Console.WriteLine($"DormId:{block.dormId}");
            Console.WriteLine($"BlockId:{block.Id}");
            Console.WriteLine($"Room floor:{floor}");
            Console.WriteLine($"room id:{id}");
            Console.WriteLine($"Number of residents:{people.Count}");
            Console.WriteLine("residents:");
            foreach(Person p in people)
            {
                Console.WriteLine($"{p.name} with student id:{p.stID}");

            }
            Console.WriteLine("---------------------------------");

        }
        public int id, floor, capacity;
        public int blockId, dormId;
        // capacity should be <= 6
        //private list<Equipment> equipments
        //private list<Student> students
        //
        public Room(int id, int floor, int blockId, int dormId, int capacity = 6)
        {
            this.id = id;

            this.floor = floor;
            this.capacity = capacity;
            this.blockId = blockId;
            this.dormId = dormId;
        }
        public bool CanAcceptEquipment(Equipment e)
        {
            int closetNum = this.Equipments.Count(r => r.type == EquipmentType.Closet);
            int bedNum = this.Equipments.Count(r => r.type == EquipmentType.Bed);
            int chairNum = this.Equipments.Count(r => r.type == EquipmentType.Chair);
            int DeskNum = this.Equipments.Count(r => r.type == EquipmentType.Desk);
            int FridgeNum = this.Equipments.Count(r => r.type == EquipmentType.Fridge);

            if (FridgeNum == 1 && e.type == EquipmentType.Fridge)
            {
                //throw new Exception("can't assign more Fridge to this room");
                return false;
            }
            else if (closetNum >= 6 && e.type == EquipmentType.Closet)
            {
                //throw new Exception("can't assign more closet to this room");
                return false;
            }
            else if (bedNum >= 6 && e.type == EquipmentType.Bed)
            {
                //throw new Exception("can't assign more bed to this room");
                return false;
            }
            else if (chairNum >= 6 && e.type == EquipmentType.Chair)
            {
                //throw new Exception("can't assign more chair to this room");
                return false;
            }
            else if (DeskNum >= 6 && e.type == EquipmentType.Desk)
            {
                //throw new Exception("can't assign more Desk to this room");
                return false;
            }
            return true;
        }
        public bool CanWelcome()
        {
            if(people.Count == 6)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

}

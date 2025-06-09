using System;
using Equipment;

// namespace Room
//{
    class Room
    {
        private List<Equipment> equipments = new List<Equipment>();
        public List<Equipment> Equipments = { get{return equipments; } } = new List<Equipment>();
        public int id, floor, capacity;
        
        // capacity should be <= 6
        //private list<Equipment> equipments
        //private list<Student> students
        //
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
    }
//}

using System.Collections.Generic;

namespace P04_Hospital
{
    public class Department
    {
        private string name;
        private List<Room> rooms;

        public Department(string name)
        {
            this.Name = name;
            this.Rooms = new List<Room>();
        }

        public List<Room> Rooms
        {
            get { return rooms; }
            set { rooms = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}

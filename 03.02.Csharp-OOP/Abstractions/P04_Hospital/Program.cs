using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        static List<Department> departments;
        static List<Doctor> doctors;
        public static void Main()
        {
            departments = new List<Department>();
            doctors = new List<Doctor>();

            string command = "";
            while ((command = Console.ReadLine()) != "Output")
            {
                string[] split = command.Split();
                var departmentName = split[0];
                var firstName = split[1];
                var lastName = split[2];
                var patient = split[3];

                Department department = GetDepartment(departmentName);
                Doctor doctor = GetDoctor(firstName, lastName);

                bool isEnoughSpace = department.Rooms.Sum(x => x.Patients.Count) < 60;

                if (isEnoughSpace)
                {
                    int targetRoom = 0;

                    doctor.Patients.Add(patient);

                    for (int room = 0; room < department.Rooms.Count; room++)
                    {
                        if (department.Rooms[room].Patients.Count < 3)
                        {
                            targetRoom = room;
                            break;
                        }
                    }
                    department.Rooms[targetRoom].Patients.Add(patient);
                }
            }


            while ((command = Console.ReadLine()) != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    var department = GetDepartment(args[0]);

                    foreach (var room in department.Rooms.Where(x => x.Patients.Count > 0))
                    {
                        foreach (var patient in room.Patients)
                        {
                            Console.WriteLine(patient);
                        }
                    }
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int room))
                {
                    var department = GetDepartment(args[0]);

                    foreach (var name in department.Rooms[room - 1].Patients.OrderBy(x => x))
                    {
                        Console.WriteLine(name);
                    }
                }
                else
                {
                    var firstName = args[0];
                    var lastName = args[1];

                    Doctor doctor = GetDoctor(firstName, lastName);

                    foreach (var patient in doctor.Patients.OrderBy(x => x))
                    {
                        Console.WriteLine(patient);
                    }
                }
            }
        }

        private static Doctor GetDoctor(string firstName, string lastName)
        {
            Doctor doctor = doctors.Where(x => x.FirstName == firstName && x.LastName == lastName).FirstOrDefault();

            if (doctor == null)
            {
                doctor = new Doctor(firstName, lastName);
                doctors.Add(doctor);
            }
            return doctor;
        }

        private static Department GetDepartment(string departmentName)
        {
            Department department = departments.Where(x => x.Name == departmentName).FirstOrDefault();

            if (department == null)
            {
                department = new Department(departmentName);
                departments.Add(department);

                for (int i = 0; i < 20; i++)
                {
                    department.Rooms.Add(new Room());
                }
            }
            return department;
        }
    }
}

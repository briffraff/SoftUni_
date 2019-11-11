using BirthdayCelebrations2.Interfaces;


namespace BirthdayCelebrations2.Models
{
    public class Robot : IIdentifiable
    {
        //mode,id
        private string model;
        private string id;

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model
        {
            get => model;
            private set => model = value;
        }

        public string Id
        {
            get => id;
            private set => id = value;
        }

        public string Birthdate => "";

    }
}

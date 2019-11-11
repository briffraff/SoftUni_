using System;

namespace Mankind
{
    public class Human
    {
        private string firstName;
        private string secondName;


        public Human(string firstName,string secondName)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
        }

        public virtual string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                bool isUpper = char.IsUpper(value[0]);

                if (isUpper == false)
                {
                    throw new ArgumentException("Expected upper case letter! Argument: firstName");
                }

                if (value.Length < 4)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
                }

                firstName = value;
            }
        }

        public virtual string SecondName
        {
            get
            {
                return secondName;
            }
            set
            {
                bool isUpper = char.IsUpper(value[0]);

                if (isUpper == false)
                {
                    throw new ArgumentException("Expected upper case letter! Argument: lastName");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName ");
                }

                secondName = value;
            }
        }


    }
}

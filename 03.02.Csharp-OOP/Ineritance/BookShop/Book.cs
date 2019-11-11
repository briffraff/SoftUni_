using System;
using System.Text;

namespace BookShop
{
    public class Book
    {
        private string author;
        private string title;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public virtual string Author
        {
            get
            {
                return author;
            }
            set
            {
                string[] split = value.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string secondName = split[1];
                bool isDigit = char.IsDigit(secondName[0]);

                if (isDigit == true)
                {
                    throw new ArgumentException("Author not valid!");
                }

                author = value;

            }
        }

        public virtual string Title
        {
            get { return title; }
            set
            {
                if (value.Length >= 3)
                {
                    title = value;
                }
                else
                {
                    throw new ArgumentException("Title not valid!");
                }
            }
        }

        public virtual decimal Price
        {
            get { return price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }

                price = value;
            }
        }

        public override string ToString()
        {
            var resultBuilder = new StringBuilder();
            resultBuilder.AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Title: {this.Title}")
                .AppendLine($"Author: {this.Author}")
                .AppendLine($"Price: {this.Price:f2}");

            string result = resultBuilder.ToString().TrimEnd();
            return result;
        }

    }
}

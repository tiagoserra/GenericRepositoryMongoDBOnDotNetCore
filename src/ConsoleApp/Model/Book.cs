using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Model
{
    public class Book
    {

        public Book(string name, string isbn)
        {
            ID = Guid.NewGuid();
            IsEnabled = true;

            Name = name;
            ISBN = isbn;
        }

        public Guid ID { get; private set; }

        public string Name { get; private set; }

        public string ISBN { get; private set; }

        public bool IsEnabled { get; private set; }

        public void SetEnabled(bool enabled)
        {
            IsEnabled = enabled;
        }

        public void ChangeName(string name)
        {
            Name = name;
        }

        public void ChangeISBN(string isbn)
        {
            ISBN = isbn;
        }

    }
}

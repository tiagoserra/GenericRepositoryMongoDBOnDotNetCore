using ConsoleApp.Model;
using ConsoleApp.Repository;
using System;

namespace ConsoleApp
{
    class Program
    {
        private static BookRepository _repository = new BookRepository();

        static void Main(string[] args)
        {
            var book = new Book("Hello World Save in Mongo DB", "01042017");

            Console.WriteLine("Insert Book");
            _repository.Insert(book);
            Console.WriteLine("Book save: Name..:" + book.Name + "ISBN..:" + book.ISBN + " IsEnabled..:" + book.IsEnabled.ToString());

            book = _repository.GetById(book.ID);

            book.ChangeName("Hello World Save in Mongo DB V2");
            book.ChangeISBN("02042017");
            book.SetEnabled(false);

            Console.WriteLine("Update Book");
            _repository.Update(book);
            Console.WriteLine("Book save: Name..:" + book.Name + "ISBN..:" + book.ISBN + " IsEnabled..:" + book.IsEnabled.ToString());

            Console.WriteLine("Remove Book");
            _repository.Remove(book.ID);

            Console.ReadKey();
        }
    }
}
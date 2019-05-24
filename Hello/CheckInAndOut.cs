﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Hello
{
    class CheckInAndOut
    {
        public static List<Book> GetCheckedOutBooks(List<Book> bookList, User user)
        {
            var checkedOutBookList = new List<Book>();
            foreach (var book in bookList)
            {
                if (book.Owner == user.Name)
                {
                    checkedOutBookList.Add(book);
                }
            }
            return checkedOutBookList;
        }

        public static void UserStatus(List<Book> checkedOutBooks)
        {
            if (!checkedOutBooks.Any())
            {
                Console.WriteLine("You don't currently have anything checked out.");
            }
            else
            {
                Console.WriteLine("You currently have the following books checked out:");
                CheckInBook(checkedOutBooks);
            }
        }

        public static void CheckInBook(List<Book> checkedOutBooks)
        {
            string continueCheck;
            do
            {
                var counter = 1;
                foreach (var book in checkedOutBooks)
                {
                    Console.WriteLine($"{counter} - {book.Title}, due back on {book.Date}");
                    counter++;
                }
                Console.WriteLine("What do you want to check in?");


                var userChoice = int.Parse(Console.ReadLine());
                checkedOutBooks[userChoice - 1].CheckInBook();
                Console.Write("\nWould you like to check out again huh? (y/n)? ");
                continueCheck = Console.ReadLine();
            } while (!continueCheck.Equals("n", StringComparison.OrdinalIgnoreCase));
        }
    }
}
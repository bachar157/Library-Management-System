using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Library_Management_System_class
    {
        Dictionary<int, (string[], bool)> allOfTheBooksInLibrary = new Dictionary<int, (string[], bool)>();
        bool IsAvailable = false;
        string[] bookAttributesName = { "title", "author", "publication year", "genre" };
        int booksNumber = 0;
        int SizeOfTheBookInfoArray = 5;

        /// <summary>
        /// Adds a new book to the library
        /// </summary>
        public void addingBooksToLibrary()
        {
            Console.WriteLine("Adding book to the library");
            try
            {
                readingAndSaveTheUserInput();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Generates a random ID for a new book
        /// </summary>
        /// <returns></returns>
        public int generatRandomID()
        {
            Random random = new Random();
            return random.Next(1000, 10000);
        }

        /// <summary>
        /// Reads user input for new book details and saves it
        /// </summary>
        public void readingAndSaveTheUserInput()
        {
            string[] everySingleBookInfo = new string[5];
            booksNumber++;
            everySingleBookInfo[0] = Convert.ToString(generatRandomID());
            Console.WriteLine($"Your new book ID is: {everySingleBookInfo[0]}");

            try
            {
                for (int i = 1; i < everySingleBookInfo.Length; i++)
                {
                    if (bookAttributesName[i - 1] == "publication year")
                    {
                        everySingleBookInfo[i] = ReadAndValidatePublicationYear();
                    }
                    else
                    {
                        Console.Write($"{bookAttributesName[i - 1]}: ");
                        everySingleBookInfo[i] = Console.ReadLine();
                    }
                }
                IsAvailable = true;
                allOfTheBooksInLibrary[booksNumber] = (everySingleBookInfo, IsAvailable);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading input: {ex.Message}");
            }
        }
        /// <summary>
        /// Validate Publication Year and make sure it is a number 
        /// </summary>
        /// <returns></returns>
        public string ReadAndValidatePublicationYear()
        {
            while (true)
            {
                Console.Write("publication year: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int year))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Please enter a valid publication year.");
                }
            }
        }
        /// <summary>
        /// Provides options to view all books or books by genre
        /// </summary>
        public void ViewBooks()
        {
            Console.WriteLine("Choose an option:\n1. View All Books\n2. View Books By Genre");
            string option = Console.ReadLine();

            try
            {
                if (option == "1")
                {
                    ViewingAllBooksinLibrary();
                }
                else if (option == "2")
                {
                    DisplayBooksByGenre();
                }
                else
                {
                    Console.WriteLine("Invalid option. Please choose 1 or 2.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Displays all books in the library
        /// </summary>
        public void ViewingAllBooksinLibrary()
        {
            foreach (var entry in allOfTheBooksInLibrary)
            {
                int index = 0;
                Console.WriteLine($"BOOK NUMBER : {entry.Key}");
                string[] bookInfo = entry.Value.Item1;
                bool isBookAvailable = entry.Value.Item2;
                foreach (string value in bookInfo)
                {
                    if (index == 0)
                    {
                        Console.WriteLine($"ID:{value} ");
                        index++;
                        continue;
                    }
                    if (index != 0 && index < SizeOfTheBookInfoArray)
                    {
                        Console.Write($"{bookAttributesName[index - 1]}:");
                        Console.WriteLine($"{value}");
                    }
                    index++;
                }
                string availabilityText = isBookAvailable ? "Available" : "Not Available";
                Console.WriteLine($"Availability: {availabilityText}");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Displays books filtered by a specified genre
        /// </summary>
        public void DisplayBooksByGenre()
        {
            Console.WriteLine("Enter the genre:");
            string genre = Console.ReadLine().ToLower();

            try
            {
                bool found = false;
                foreach (var entry in allOfTheBooksInLibrary)
                {
                    string[] bookInfo = entry.Value.Item1;
                    if (bookInfo.Length >= 4 && bookInfo[3].ToLower() == genre)
                    {
                        PrintBookDetails(bookInfo, entry.Value.Item2);
                        found = true;
                    }
                }

                if (!found)
                {
                    Console.WriteLine($"No books found in the '{genre}' genre.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while displaying books: {ex.Message}");
            }
        }

        /// <summary>
        /// Prints details of a book
        /// </summary>
        /// <param name="bookInfo"></param>
        /// <param name="isAvailable"></param>
        public void PrintBookDetails(string[] bookInfo, bool isAvailable)
        {
            for (int i = 0; i < bookInfo.Length; i++)
            {
                if (i < bookAttributesName.Length)
                {
                    Console.WriteLine($"{bookAttributesName[i]}: {bookInfo[i]}");
                }
            }
            Console.WriteLine($"Availability: {(isAvailable ? "Available" : "Not Available")}");
            Console.WriteLine();
        }

        /// <summary>
        /// Allows searching for books by title, author, or ID
        /// </summary>
        public void SearchingBooks()
        {
            Console.Write("Enter title, author, or ID of the book you want to find: ");
            string SearchKeyWord = Console.ReadLine();
            string[] TheBookAfterFindIT = LinearSearchToFindBook(SearchKeyWord);
            PrintTheSearchResult(TheBookAfterFindIT);
        }

        /// <summary>
        /// Linear search for a book in the library
        /// </summary>
        /// <param name="SearchKeyWord"></param>
        /// <returns></returns>
        public string[] LinearSearchToFindBook(string SearchKeyWord)
        {
            string[] BookSearchResult = null;

            foreach (KeyValuePair<int, (string[], bool)> entry in allOfTheBooksInLibrary)
            {
                string[] bookInfo = entry.Value.Item1;

                foreach (string value in bookInfo)
                {
                    if (SearchKeyWord == value)
                    {
                        BookSearchResult = new string[bookInfo.Length + 1];
                        Array.Copy(bookInfo, BookSearchResult, bookInfo.Length);
                        BookSearchResult = BookSearchResult.Append(entry.Value.Item2 ? "Available" : "Not Available").ToArray();
                        break;
                    }
                }

                if (BookSearchResult != null)
                {
                    break;
                }
            }
            return BookSearchResult;
        }
        
        /// <summary>
        /// Prints the result of a book search
        /// </summary>
        /// <param name="TheBookAfterFindIT"></param>
        public void PrintTheSearchResult(string[] TheBookAfterFindIT)
        {
            if (TheBookAfterFindIT == null || TheBookAfterFindIT.Length == 0)
            {
                Console.WriteLine("Book not found in the library.");
                return;
            }

            for (int i = 0; i < TheBookAfterFindIT.Length - 1; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine($"ID: {TheBookAfterFindIT[i]}");
                }
                else if (i - 1 < bookAttributesName.Length)
                {
                    Console.WriteLine($"{bookAttributesName[i - 1]}: {TheBookAfterFindIT[i]}");
                }
            }
            Console.WriteLine($"Availability: {TheBookAfterFindIT[TheBookAfterFindIT.Length - 1]}");
        }

        /// <summary>
        /// Allows a user to borrow a book from the library
        /// </summary>
        public void BorrowingBooks()
        {
            Console.Write("Enter the ID or name of the book you want to borrow: ");
            string bookInfo = Console.ReadLine();

            try
            {
                foreach (var entry in allOfTheBooksInLibrary)
                {
                    if ((entry.Value.Item1[0] == bookInfo || entry.Value.Item1[1] == bookInfo) && entry.Value.Item2)
                    {
                        allOfTheBooksInLibrary[entry.Key] = (entry.Value.Item1, false);
                        Console.WriteLine($"Book '{entry.Value.Item1[1]}' with ID '{entry.Value.Item1[0]}' borrowed successfully.");
                        return;
                    }
                }
                Console.WriteLine("Book not found or is not available.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while borrowing the book: {ex.Message}");
            }
        }

        /// <summary>
        /// Allows a user to return a book to the library
        /// </summary>
        public void ReturningBooks()
        {
            Console.Write("Enter the ID or name of the book you want to return: ");
            string bookInfo = Console.ReadLine();

            try
            {
                foreach (var entry in allOfTheBooksInLibrary)
                {
                    if ((entry.Value.Item1[0] == bookInfo || entry.Value.Item1[1] == bookInfo) && !entry.Value.Item2)
                    {
                        allOfTheBooksInLibrary[entry.Key] = (entry.Value.Item1, true);
                        Console.WriteLine($"Book '{entry.Value.Item1[1]}' with ID '{entry.Value.Item1[0]}' returned successfully.");
                        return;
                    }
                }
                Console.WriteLine("Book not found or was not borrowed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while returning the book: {ex.Message}");
            }
        }
    }
}

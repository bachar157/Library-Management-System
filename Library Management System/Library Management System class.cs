using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Library_Management_System_class
    {
        Dictionary<int, string[]> allOfTheBooksInLibrary = new Dictionary<int, string[]>();
        string[] bookAttributesName = new string[] // this arry to dispaly the book info with no need to writhe all of them in console and do it manwal every time 
        {
            "title",
            "author",
            "publication year",
            "genre",
        };
        HashSet<int> generatedID;
        int booksNumber = 0; // in each time i wanty to add book the number will be increce ++;
        int SizeOfTheBookInfoArray = 5;



        public void addingBooksToLibrary()
        {
            Console.WriteLine(" adding book to the libriry ");
            readingAndSaveTheUserINput();

        }
        public int generatRandomID()
        {
            Random random = new Random();
            int randomNumber = random.Next(1000, 10000);
            return randomNumber;

        }
        public void readingAndSaveTheUserINput()
        {
            string[] everySingleBookInfo = new string[5];
            booksNumber++;


            //to create new arry and add it to the Dictionary and save it asd like a seapert block 

            everySingleBookInfo[0] = Convert.ToString(generatRandomID());
            // to add the ID for the array everySingleBookInfo whoch is will help me in future to find this book

            Console.WriteLine($" Your new book ID is :{everySingleBookInfo[0]} ");
            // generat Random ID for each  becuse  i want to use Dictionary key to count the books not as like a ID
            try
            {
                for (int i = 1; i < everySingleBookInfo.Length; i++)
                {
                    Console.Write($"{bookAttributesName[i - 1]}: ");
                    everySingleBookInfo[i] = Console.ReadLine();

                }
            }
            catch
            {
                throw;
            }
            allOfTheBooksInLibrary[booksNumber] = everySingleBookInfo;
            //  add each arry to the main contaier with is allOfTheBooksInLibrary Dictionary
            // so here every book will be in  a speate block  and all of them in the same Dictionary
            // Dictionary key value is number from 1 to ...  which is not same with ID

        }

        public void ViewingBooksinLibrary()
        {

            foreach (KeyValuePair<int, string[]> entry in allOfTheBooksInLibrary)
            {
                int index = 0;
                Console.WriteLine($"BOOK NUMBER : {entry.Key}");
                foreach (string value in entry.Value)
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
                Console.WriteLine(); // For better readability
            }
        }
    }




}

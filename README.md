# Library Management System

## Overview
This application is a simple console-based library management system. It allows users to add, view, borrow, and return books. Books can be viewed by all available titles or filtered by genre.

## Features
- **Adding Books**: Add new books to the library with details like title, author, publication year, and genre.
- **Viewing Books**: View all books in the library or filter books by a specific genre.
- **Searching Books**: Search for books by title, author, or ID.
- **Borrowing Books**: Borrow a book from the library.
- **Returning Books**: Return a book to the library.

## How to Run
1. Ensure you have a .NET runtime installed on your system.
2. Compile the C# files in your C# development environment or using the command line.
3. Run the compiled executable.

## Special Instructions
- When adding a book, follow the prompts to enter the book's details.
- To borrow or return a book, you will need the book's ID or title.

## Contact
For any additional information or feedback, please contact [Your Name/Contact Information].

# Report 

## Design Decisions
- **Console-Based Interface**: Chosen for simplicity and ease of use.
- **Dictionary Data Structure**: Used for efficient data storage and retrieval of book information.
- **Modular Design**: Each functionality (add, view, search, borrow, return) is encapsulated in separate methods for better maintainability.

## Data Structures
- **Dictionary**: Key-value pairs store book IDs and their details, facilitating quick access and management.
- **String Arrays**: Used to store book details (title, author, etc.)

## Algorithms
- **Linear Search**: Implemented for searching books as the dataset is small and doesn't warrant more complex algorithms.

## Challenges and Solutions
- **User Input Validation**: Ensured robust input handling to prevent crashes.
- **Data Structure Choice**: Initially considered Lists, but Dictionaries provided faster lookups for book management.
- **Exception Handling**: Added try-catch blocks to handle unexpected errors and provide a smooth user experience.

## Conclusion
The Library Management System serves as a basic yet functional tool for managing a small to medium-sized book collection. Future improvements could include a graphical user interface, database integration, and advanced book sorting and filtering features.

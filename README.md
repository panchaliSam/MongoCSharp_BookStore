# MongoCSharp_BookStore
MongoCSharp_BookStore is a C# console application that uses MongoDB to manage a bookstore’s inventory.
It follows a clean, layered architecture with separate entity, repository, and service layers, ensuring maintainable and testable code.
The app automatically creates the database and collection if they don’t exist, seeds sample book data on first run, and supports queries like finding the cheapest book, listing books over a certain page count, and searching by ISBN.

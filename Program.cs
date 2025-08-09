using MongoCSharp_BookStore.data;
using MongoCSharp_BookStore.data.Impl;
using MongoCSharp_BookStore.model;
using MongoCSharp_BookStore.repository;
using MongoCSharp_BookStore.repository.Impl;
using MongoCSharp_BookStore.service;
using MongoCSharp_BookStore.service.Impl;

IMongoContext context = new MongoContext();
IBookStoreRepository repo = new BookStoreRepository(context);
IBookStoreService bookservice = new BookStoreService(repo);

// Ensure collection exists & seed if empty
await bookservice.SeedIfEmptyAsync();

// Demo queries
List<BookStore> all = await bookservice.GetAllAsync();
Console.WriteLine($"Total docs: {all.Count}");

BookStore? cheapest = await bookservice.GetCheapestAsync();
Console.WriteLine($"Cheapest: {cheapest?.BookTitle} ({cheapest?.Price})");

List<BookStore> bigBooks = await bookservice.GetByMinPagesAsync(200);
Console.WriteLine($">200 pages: {bigBooks.Count}");

BookStore? byIsbn = await bookservice.GetByIsbnAsync("6779799933389898yu");
Console.WriteLine($"Find by ISBN 6779799933389898yu: {byIsbn?.BookTitle}");

Console.WriteLine("Done.");
using BookApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;
        public BookRepository(BookContext context)
        {
            _context = context;
        }
        public async Task<Book> Create(Book book)
        {
            var Booke = _context.Books.Add(book);

           await _context.SaveChangesAsync();


            return book;

        }

        public async Task Delete(int id)
        {
          var booke= await _context.Books.FindAsync(id);

            //  _context.Books.Remove()

            _context.Books.Remove(booke);

            await _context.SaveChangesAsync();

            //return Book;
        }

        public async Task<Book> Get(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task Update(Book book)
        {
            _context.Books.UpdateRange(book);

            await _context.SaveChangesAsync();
           
        }
    }
}

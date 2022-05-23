using BookApi.Models;
using BookApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()

        {
            return await _bookRepository.GetBooks();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {

            return await _bookRepository.Get(id);

        }
        [HttpPost]
        public async Task<ActionResult<Book>> Create([FromBody]  Book book)
        {
             await _bookRepository.Create(book);

            return Ok();


        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] Book book)
        {
            await _bookRepository.Update(book);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _bookRepository.Delete(id);
            return NoContent();
        }






    }


}



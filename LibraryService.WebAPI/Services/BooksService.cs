using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryService.WebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.WebAPI.Services
{
    public class BooksService : IBooksService
    {
        private readonly LibraryContext _libraryContext;

        public BooksService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<IEnumerable<Book>> Get(int libraryId, int[] ids)
        {
            var books = await _libraryContext.Books
                                      .Where(b => b.LibraryId == libraryId && ids.Contains(b.Id))
                                      .ToListAsync();

          return books; 
        }

        public async Task<Book> Add(Book book)
        {
             await _libraryContext.Books.AddAsync(book);
              await _libraryContext.SaveChangesAsync();
              return book;
        }

        public async Task<Book> Update(Book book)
        {
         var existingBook = await _libraryContext.Books
         .FirstOrDefaultAsync(b => b.Id == book.Id);

          if (existingBook == null)
           {
         return NotFound();
           }
            existingBook.Name = book.Name;
            existingBook.Category = book.Category;
            existingBook.LibraryId = book.LibraryId; 

         // Save changes to the database
        await _libraryContext.SaveChangesAsync();

         // Return the updated book entity
         return existingBook;
        }

        public async Task<bool> Delete(Book book)
        {
            if (book == null)
             {
              return NotFound();
           }
             var existingBook = await _libraryContext.Books
        .FirstOrDefaultAsync(b => b.Id == book.Id);

          if (existingBook == null)
         {
        return NotFound();
         }

          _libraryContext.Books.Remove(existingBook);

   
         await _libraryContext.SaveChangesAsync();

    
         return true;
        }
    }

    public interface IBooksService
    {
        Task<IEnumerable<Book>> Get(int libraryId, int[] ids);

        Task<Book> Add(Book book);

        Task<Book> Update(Book book);

        Task<bool> Delete(Book book);
    }
}

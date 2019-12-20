using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Http;
using Books.DTOs;
using Books.Models;

namespace Books.Controllers
{
    [RoutePrefix("api/books")]
    [System.Web.Mvc.ValidateInput(false)]
    public class BooksController : ApiController
    {
        private BooksContext db = new BooksContext();

        //Create Queryable data
        private static readonly Expression<Func<Book, BookDto>> AsBookDto =
            x => new BookDto
            {
                Id = x.Id,
                Author = x.Author,
                Title = x.Title,
                Genre = x.Genre,
                Price = x.Price,
                PublishDate = x.PublishDate,
                Description = x.Description
            };

        // GET api/Books
        [Route("")]
        //[ResponseType(typeof(BookDto))]
        public IQueryable<BookDto> GetBooks()
        {
            return db.Books.Select(AsBookDto);
        }
        // GET api/Books/id
        [Route("id")]
        public IQueryable<BookDto> GetBook()
        {
            return db.Books.Select(AsBookDto).OrderBy(b => b.Id);
        }
        // GET api/Books/id/B01
        [Route("id/{id}")]
        public IQueryable<BookDto> GetBook(string id)
        {
            //Split the string so that if you enter api/books/id/B1 it returns B01 too
            if (id.Length == 2)
            {
                string a = id[0].ToString(), c = id[1].ToString();
                return db.Books.Where(b => b.Id.Contains(a) && b.Id.Contains(c))
                        .Select(AsBookDto).OrderBy(b => b.Id);
            }

            return db.Books.Where(b => b.Id.Contains(id)).Select(AsBookDto).OrderBy(b => b.Id);
        }

        // GET api/Books/author
        [Route("author")]
        public IQueryable<BookDto> GetAuthor()
        {
            return db.Books.Select(AsBookDto).OrderBy(b => b.Author);
        }

        // GET api/Books/author/Tim
        [Route("author/{id}")]
        public IQueryable<BookDto> GetAuthor(string id)
        {
            return db.Books.Where(b => b.Author.Contains(id)).Select(AsBookDto).OrderBy(b => b.Author);
        }

        // GET api/Books/title
        [Route("title")]
        public IQueryable<BookDto> GetTitle()
        {
            return db.Books.Select(AsBookDto).OrderBy(b => b.Title);
        }

        // GET api/Books/title/JRuby
        [Route("title/{id}")]
        public IQueryable<BookDto> GetTitle(string id)
        {
            return db.Books.Where(b => b.Title.Contains(id)).Select(AsBookDto).OrderBy(b => b.Title);
        }

        // GET api/Books/genre
        [Route("genre")]
        public IQueryable<BookDto> GetGenre()
        {
            return db.Books.Select(AsBookDto).OrderBy(b => b.Genre);
        }

        // GET api/Books/genre/com
        [Route("genre/{id}")]
        public IQueryable<BookDto> GetGenre(string id)
        {
            return db.Books.Where(b => b.Genre.Contains(id)).Select(AsBookDto).OrderBy(b => b.Genre);
        }

        // GET api/Books/price
        [Route("price")]
        public IQueryable<BookDto> GetPrice()
        {
            return db.Books.Select(AsBookDto).OrderBy(b => b.Price);
        }

        // GET api/Books/author/33.0 OR api/Books/price/30.0&35.0
        [Route("price/{input}")]
        public IQueryable<BookDto> GetPrice(string input)
        {
            //Checks if input has & and seperates it into two numbers to create the price range
            if (input.Contains("&")) {
                string[] s = input.Split('&');

                double pr1 = Convert.ToDouble(s[0]);
                double pr2 = Convert.ToDouble(s[1]);

                return db.Books.Select(AsBookDto).Where(b => b.Price > pr1 && b.Price < pr2).OrderBy(b => b.Price);
            }

            double pr = Convert.ToDouble(input);
            return db.Books.Select(AsBookDto).Where(b => b.Price.Equals(pr)).OrderBy(b => b.Price);
        }

        // GET api/Books/published
        [Route("published")]
        public IQueryable<BookDto> GetPublishedDate()
        {
            return db.Books.Select(AsBookDto).OrderBy(b => b.PublishDate);
        }

        // GET api/Books/published/2012
        [Route("published/{yr}")]
        public IQueryable<BookDto> GetPublishedDate(int yr)
        {
            return db.Books.Where(b => b.PublishDate.Year == yr).Select(AsBookDto).OrderBy(b => b.PublishDate);
        }

        // GET api/Books/published/2012/08
        [Route("published/{yr}/{mnth}")]
        public IQueryable<BookDto> GetPublishedDate(int yr, int mnth)
        {
            return db.Books.Where(b => b.PublishDate.Year == yr && b.PublishDate.Month == mnth).Select(AsBookDto).OrderBy(b => b.PublishDate);
        }

        // GET api/Books/published/2012/08/15
        [Route("published/{yr}/{mnth}/{day}")]
        public IQueryable<BookDto> GetPublishedDate(int yr, int mnth, int day)
        {
            return db.Books.Where(b => b.PublishDate.Year == yr && b.PublishDate.Month == mnth && b.PublishDate.Day == day).Select(AsBookDto).OrderBy(b => b.PublishDate);
        }

        // GET api/Books/description
        [Route("description")]
        public IQueryable<BookDto> GetDescription()
        {
            return db.Books.Select(AsBookDto).OrderBy(b => b.Description);
        }

        // GET api/Books/description/deploy
        [Route("description/{id}")]
        public IQueryable<BookDto> GetDescription(string id)
        {
            return db.Books.Where(b => b.Description.Contains(id)).Select(AsBookDto).OrderBy(b => b.Description);
        }


/*        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBook(string id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.Id)
            {
                return BadRequest();
            }

            db.Entry(book).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        // POST: api/Books
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Books.Add(book);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookExists(book.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> DeleteBook(string id)
        {
            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            await db.SaveChangesAsync();

            return Ok(book);
        }*/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(string id)
        {
            return db.Books.Count(e => e.Id == id) > 0;
        }
    }
}
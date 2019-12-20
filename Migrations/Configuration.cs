namespace Books.Migrations
{
    using global::Books.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.BooksContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.BooksContext context)
        {
            //Get data from books.json using Newtonsoft.Json and then add them items to the db
            JArray o2;
            using (StreamReader file = System.IO.File.OpenText(@"c:\books.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                o2 = (JArray)JToken.ReadFrom(reader);

            }

            IList<Book> ts = o2.ToObject<IList<Book>>();

            context.Books.AddOrUpdate(new Book[] {
                new Book() { Id = ts[0].Id, Author = ts[0].Author, Title= ts[0].Title, Genre = ts[0].Genre,
                PublishDate = new DateTime(2012, 08, 15), Description = ts[0].Description, Price = ts[0].Price },

                new Book() { Id = ts[1].Id, Author = ts[1].Author, Title= ts[1].Title, Genre = ts[1].Genre,
                PublishDate = new DateTime(2000, 12, 16), Description = ts[1].Description, Price = ts[1].Price },

                new Book() { Id = ts[2].Id, Author = ts[2].Author, Title= ts[2].Title, Genre = ts[2].Genre,
                PublishDate = new DateTime(2000, 11, 17), Description = ts[2].Description, Price = ts[2].Price },

                new Book() { Id = ts[3].Id, Author = ts[3].Author, Title= ts[3].Title, Genre = ts[3].Genre,
                PublishDate = new DateTime(2001, 03, 10), Description = ts[3].Description, Price = ts[3].Price },

                new Book() { Id = ts[4].Id, Author = ts[4].Author, Title= ts[4].Title, Genre = ts[4].Genre,
                PublishDate = new DateTime(1985, 09, 10), Description = ts[4].Description, Price = ts[4].Price},

                new Book() { Id = ts[5].Id, Author = ts[5].Author, Title= ts[5].Title, Genre = ts[5].Genre,
                PublishDate = new DateTime(2000, 09, 02), Description = ts[5].Description, Price = ts[5].Price},

                new Book() { Id = ts[6].Id, Author = ts[6].Author, Title= ts[6].Title, Genre = ts[6].Genre,
                PublishDate = new DateTime(2000, 11, 02), Description = ts[6].Description, Price = ts[6].Price},

                new Book() { Id = ts[7].Id, Author = ts[7].Author, Title= ts[7].Title, Genre = ts[7].Genre,
                PublishDate = new DateTime(2000, 12, 06), Description = ts[7].Description, Price = ts[7].Price},

                new Book() { Id = ts[8].Id, Author = ts[8].Author, Title= ts[8].Title, Genre = ts[8].Genre,
                PublishDate = new DateTime(2000, 11, 02), Description = ts[8].Description, Price = ts[8].Price},

                new Book() { Id = ts[9].Id, Author = ts[9].Author, Title= ts[9].Title, Genre = ts[9].Genre,
                PublishDate = new DateTime(2000, 12, 09), Description = ts[9].Description, Price = ts[9].Price},

                new Book() { Id = ts[10].Id, Author = ts[10].Author, Title= ts[10].Title, Genre = ts[10].Genre,
                PublishDate = new DateTime(2007, 12, 01), Description = ts[10].Description, Price = ts[10].Price},

                new Book() { Id = ts[11].Id, Author = ts[11].Author, Title= ts[11].Title, Genre = ts[11].Genre,
                PublishDate = new DateTime(2008, 06, 01), Description = ts[11].Description, Price = ts[11].Price},

                new Book() { Id = ts[12].Id, Author = ts[12].Author, Title= ts[12].Title, Genre = ts[12].Genre,
                PublishDate = new DateTime(2012, 03, 01), Description = ts[12].Description, Price = ts[12].Price},

            });
        }
    }
}

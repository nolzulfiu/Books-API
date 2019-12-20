# Books-API

The books.json file needs to be in the C: drive

Use case examples:
https://host:port/api/books returns all unsorted (B1-B13)
https://host:port/api/books/id returns all sorted by id (B1-B13)
https://host:port/api/books/id/b returns all with id containing 'b' sorted by id (B1-B13)
https://host:port/api/books/id/1 returns all with id containing '1' sorted by id (B1, B10-13)

https://host:port/api/books/author returns all sorted by author (B1-B13)
https://host:port/api/books/author/joe returns all with author containing 'joe' sorted by author (B1)
https://host:port/api/books/author/kut returns all with author containing 'kut' sorted by author (B1)

https://host:port/api/books/title returns all sorted by title (B1-B13)
https://host:port/api/books/title/deploy returns all with title containing 'deploy' sorted by title (B1)
https://host:port/api/books/title/jruby returns all with title containing 'jruby' sorted by title (B1)

https://host:port/api/books/genre returns all sorted by genre (B1-B13)
https://host:port/api/books/genre/com returns all with genre containing 'com' sorted by genre (B1, B10-13)
https://host:port/api/books/genre/ter returns all with genre containing 'ter' sorted by genre (B1, B10-13)

https://host:port/api/books/price returns all sorted by price (B1-B13)
https://host:port/api/books/price/33.0 returns all with price '30.0' (B1)
https://host:port/api/books/price/30.0&35.0 returns all with price between '30.0' och '35.0' sorted by price (B1, B11)

https://host:port/api/books/published returns all sorted by published_date (B1-B13)
https://host:port/api/books/published/2012 returns all from '2012' sorted by published_date (B13, B1)
https://host:port/api/books/published/2012/8 returns all from '2012-08' sorted by published_date (B1)
https://host:port/api/books/published/2012/8/15 returns all from '2012-08-15' sorted by published_date (B1)

https://host:port/api/books/description returns all sorted by description (B1-B13)
https://host:port/api/books/description/deploy returns all with description containing 'deploy' sorted by description (B1, B13)
https://host:port/api/books/description/applications returns all with description containing 'applications' sorted by description (B1)

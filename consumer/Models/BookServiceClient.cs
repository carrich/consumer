
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace consumer.Models
{
    public class BookServiceClient
    {
        ServiceReference1.Service1Client client1 = new ServiceReference1.Service1Client();
        string BASE_URL = "http://localhost:51652/Service1.svc";

        public List<Book> getAllBooks()
        {
             var list = client1.GetAllBooks().ToList();
              var rl = new List<Book>();
              list.ForEach(b => rl.Add(new Book()
              {
                  BookId = b.BookId,
                  ISBN = b.ISBN,
                  Title = b.Title
              }));
              return rl;
            
         /*  var syncClient = new WebClient();
            var content = syncClient.DownloadString(BASE_URL + "Books");
            var json_serializer = new JavaScriptSerializer();
            return json_serializer.Deserialize<List<Book>>(content);
           */
        }
        public Book getBook(int id)
        {
            string   id1 = id.ToString();
            var bookService = client1.GetBookById(id1);
            Book book = new Book {
                BookId = bookService.BookId,
                ISBN = bookService.ISBN,
                Title = bookService.Title
            };
            return book;
        }
        public string AddBook(Book newbook)
        {
            var book = new ServiceReference1.Book()
            {
                BookId = newbook.BookId,
                ISBN = newbook.ISBN,
                Title = newbook.Title
            };
            return client1.AddNewBook(book);
        }
        public string DeleteBook(int id)
        {
            return client1.DeleteBook(Convert.ToString(id));
        }
        public string UpdateBook(Book newBook)
        {
            var book = new ServiceReference1.Book()
            {
                BookId =  newBook.BookId, ISBN = newBook.ISBN, Title = newBook.Title
            };
            return client1.UpdateBook(book);
        }

    }
}
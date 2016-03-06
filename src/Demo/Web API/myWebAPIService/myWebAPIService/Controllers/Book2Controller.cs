using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using myWebAPIService.Models;

namespace myWebAPIService.Controllers
{
    public class Book2Controller : ApiController
    {
        //private myWebAPIServiceContext db = new myWebAPIServiceContext();

        //// GET api/Book2
        //public IEnumerable<Book> GetBooks()
        //{
        //    return db.Books.AsEnumerable();
        //}

        //// GET api/Book2/5
        //public Book GetBook(string id)
        //{
        //    Book book = db.Books.Find(int.Parse(id));
        //    if (book == null)
        //    {
        //        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        //    }

        //    return book;
        //}

        //// PUT api/Book2/5
        //public HttpResponseMessage PutBook(int id, Book book)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }

        //    if (id != book.Id)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }

        //    db.Entry(book).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}

        //// POST api/Book2
        //public HttpResponseMessage PostBook(Book book)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Books.Add(book);
        //        db.SaveChanges();

        //        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, book);
        //        response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = book.Id }));
        //        return response;
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }
        //}

        //// DELETE api/Book2/5
        //public HttpResponseMessage DeleteBook(string id)
        //{
        //    Book book = db.Books.Find(id);
        //    if (book == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    db.Books.Remove(book);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, book);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}
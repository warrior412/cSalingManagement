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
    public class AccountController : ApiController
    {
        private cSalingManagementEntities db = new cSalingManagementEntities();

        // GET api/Account
        public IEnumerable<sp_MUserAccount_GetAll_Result> GetM_UserAccount()
        {
            return db.sp_MUserAccount_GetAll().AsEnumerable();
        }

        // GET api/Account/5
        public M_UserAccount GetM_UserAccount(string id)
        {
            M_UserAccount m_useraccount = db.M_UserAccount.Find(id);
            if (m_useraccount == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return m_useraccount;
        }

        // PUT api/Account/5
        public HttpResponseMessage PutM_UserAccount(string id, M_UserAccount m_useraccount)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != m_useraccount.Username)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(m_useraccount).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Account
        public HttpResponseMessage PostM_UserAccount(M_UserAccount m_useraccount)
        {
            if (ModelState.IsValid)
            {
                db.M_UserAccount.Add(m_useraccount);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, m_useraccount);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = m_useraccount.Username }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Account/5
        public HttpResponseMessage DeleteM_UserAccount(string id)
        {
            M_UserAccount m_useraccount = db.M_UserAccount.Find(id);
            if (m_useraccount == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.M_UserAccount.Remove(m_useraccount);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, m_useraccount);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
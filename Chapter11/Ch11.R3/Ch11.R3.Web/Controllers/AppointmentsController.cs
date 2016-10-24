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
using Ch11.R3.Web.Models;
using System.Data.Entity.Validation;
using System.Text;

namespace Ch11.R3.Web.Controllers
{
    public class AppointmentsController : ApiController
    {
        private AppointmentsContext2 db = new AppointmentsContext2();

        // GET api/Appointments
        public IEnumerable<Person> GetPeople()
        {
            return db.People.AsEnumerable();
        }

        // GET api/Appointments/5
        public Person GetPerson(int id)
        {
            Person peopleiwouldliketomeetmodel = db.People.Find(id);
            if (peopleiwouldliketomeetmodel == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return peopleiwouldliketomeetmodel;
        }

        // PUT api/Appointments/5
        public HttpResponseMessage PutPerson(int id, Person person)
        {
            if (ModelState.IsValid && id == person.PersonId)
            {
                db.Entry(person).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage PutPeople(IEnumerable<Person> people)
        {
            return PostPeople(people);
        }

        // POST api/Appointments
        public HttpResponseMessage PostPeople(IEnumerable<Person> people)
        {
            if (ModelState.IsValid && people != null)
            {

                foreach (var person in people)
                {
                    if (person.PersonId == 0)
                    {
                        db.People.Add(person);
                    }
                    else
                    {
                        db.Entry(person).State = EntityState.Modified;
                    }
                }
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException valError)
                {
                    string errorMessage = createValidationErrorMessage(valError);
                    HttpError err = new HttpError(errorMessage);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError,err);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, people);
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        private string createValidationErrorMessage(DbEntityValidationException valError)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var eve in valError.EntityValidationErrors)
            {
                builder.AppendFormat("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                foreach (var ve in eve.ValidationErrors)
                {
                    builder.AppendFormat("- Property: \"{0}\", Error: \"{1}\"",
                        ve.PropertyName, ve.ErrorMessage);
                }
            }
            return builder.ToString();
        }

        // DELETE api/Appointments/5
        public HttpResponseMessage DeletePerson(int id)
        {
            Person person = db.People.Find(id);
            if (person == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.People.Remove(person);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, person);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
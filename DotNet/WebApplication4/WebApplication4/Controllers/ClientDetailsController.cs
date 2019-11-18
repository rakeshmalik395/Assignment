using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication4.Models;
using AttributeRouting;
using AttributeRouting.Web.Http;
using System.Web.Routing;

namespace WebApplication4.Controllers
{
    public class ClientDetailsController : ApiController
    {
        private WebApplication4Context db = new WebApplication4Context();

        // GET: api/ClientDetails
        //[AcceptVerbs("GET")]
        [Route("search/")]
        public IQueryable<ClientDetails> GetClientDetails()
        {
            return db.ClientDetails.Include(s=> s.clientAddresses).Take(5);
        }

       
        [Route("search/{name}")]
        public IHttpActionResult GetClientDetailsByOneName(string name)
        {
            IList<ClientDetails> clients = null;
            clients = db.ClientDetails.Include(ca => ca.clientAddresses).Where(fn => (fn.FirstName.Contains(name)) || (fn.LastName.Contains(name))).ToList();
            if(clients==null)
            {
                return NotFound();

            }
            return Ok(clients);
        }
        [Route("search/{firstName}/{lastName}")]
        public IHttpActionResult GetClientDetailsByBothName(string firstName,string lastName)
        {
            var clients = db.ClientDetails.Include(ca => ca.clientAddresses).Where(n => n.FirstName == firstName && n.LastName == lastName).ToList();
            if (clients == null)
            {
                return NotFound();
            }

            return Ok(clients);
        }

        // PUT: api/ClientDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClientDetails(int id, ClientDetails clientDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientDetails.ClientId)
            {
                return BadRequest();
            }

            db.Entry(clientDetails).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientDetailsExists(id))
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

        // POST: api/ClientDetails
        [ResponseType(typeof(ClientDetails))]
        public IHttpActionResult PostClientDetails(ClientDetails clientDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClientDetails.Add(clientDetails);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = clientDetails.ClientId }, clientDetails);
        }

        // DELETE: api/ClientDetails/5
        [ResponseType(typeof(ClientDetails))]
        public IHttpActionResult DeleteClientDetails(int id)
        {
            ClientDetails clientDetails = db.ClientDetails.Find(id);
            if (clientDetails == null)
            {
                return NotFound();
            }

            db.ClientDetails.Remove(clientDetails);
            db.SaveChanges();

            return Ok(clientDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientDetailsExists(int id)
        {
            return db.ClientDetails.Count(e => e.ClientId == id) > 0;
        }
    }
} 


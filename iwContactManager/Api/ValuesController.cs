using iwContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Xml.Linq;

namespace iwContactManager.Api
{
    public class ValuesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Winner> Get()
        {

            //return new string[] { "value1", "value2" };

            string xmlDataFile = HttpContext.Current.Server.MapPath("~/App_Data/RecentWinners.xml");
            XElement xml = XElement.Load(xmlDataFile);

            var nodes = from c in xml.Elements("Winner")
                        select new Winner()
                        {
                            Name = c.Element("Name").Value,
                            City = c.Element("City").Value,
                            State = c.Element("State").Value,
                            WinDate = Convert.ToDateTime(c.Element("WinDate").Value),
                            Prize = c.Element("Prize").Value
                        };
            var winners = nodes.ToList<Winner>();
            return winners;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
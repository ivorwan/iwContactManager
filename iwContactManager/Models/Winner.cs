using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iwContactManager.Models
{
    public class Winner
    {
        public DateTime WinDate { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Prize { get; set; }

        public Winner()
        {
            //
            // TODO: Add constructor logic here
            //


        }
    }
}
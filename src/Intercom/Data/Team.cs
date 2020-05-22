using System;
using System.Collections.Generic;
using Intercom.Core;
using Intercom.Data;


using Intercom.Clients;

using Intercom.Exceptions;


namespace Intercom.Data
{
    public class Team : Model
    {
        public string name { get; set; }
        public List<string> admin_ids { get; set; }

        public Team()
        {
        }
    }
}
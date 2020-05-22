using System;
using Intercom.Core;
using Intercom.Data;


using Intercom.Clients;

using Intercom.Exceptions;

using System.Collections.Generic;

using System.Collections;

namespace Intercom.Data
{
    public class Teams : Models
    {
        public List<Team> teams { set; get; }

        public Teams ()
        {
        }
    }
}
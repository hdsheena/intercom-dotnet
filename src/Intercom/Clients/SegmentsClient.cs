﻿using System;
using Library.Core;
using Library.Data;


using Library.Clients;

using Library.Exceptions;

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Library.Core;
using RestSharp;

namespace Library.Clients
{
    public class SegmentsClient: Client
    {
        private const String SEGMENTS_RESOURCE = "segments";

        public SegmentsClient(Authentication authentication)
            : base(INTERCOM_API_BASE_URL, SEGMENTS_RESOURCE, authentication)
        {
        }

        public SegmentsClient(String intercomApiUrl, Authentication authentication)
            : base(String.IsNullOrEmpty(intercomApiUrl) ? INTERCOM_API_BASE_URL : intercomApiUrl, SEGMENTS_RESOURCE, authentication)
        {
        }

        public Segments List(bool company = false)
        {
            ClientResponse<Segments> result = null;

            if (company)
            {
                Dictionary<String, String> parameters = new Dictionary<string, string>();
                parameters.Add(Constants.TYPE, Constants.COMPANY);
                result = Get<Segments>(parameters: parameters);
            }
            else
            {
                result = Get<Segments>();
            }

            return result.Result;
        }

        public Segment View(String id)
        {
            if (String.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("'id' argument is null or empty.");
            }

            ClientResponse<Segment> result = null;
            result = Get<Segment>(resource: SEGMENTS_RESOURCE + Path.DirectorySeparatorChar + id);
            return result.Result;
        }

        public Segment View(Segment segment)
        {
            if (segment == null)
            {
                throw new ArgumentNullException("'segment' argument is null.");
            }

            if (String.IsNullOrEmpty(segment.id))
            {
                throw new ArgumentNullException("you must provide value for 'segment.id'.");
            }

            ClientResponse<Segment> result = null;
            result = Get<Segment>(resource: SEGMENTS_RESOURCE + Path.DirectorySeparatorChar + segment.id);
            return result.Result;  
        }
    }
}
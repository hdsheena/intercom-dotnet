using System;
using Intercom.Core;
using Intercom.Data;
using Intercom.Clients;
using Intercom.Exceptions;
using RestSharp;

namespace Intercom.Exceptions
{
    public class ApiException : IntercomException
    {
        public int StatusCode { set; get; }
        public String StatusDescription { set; get; }
        public String ApiResponseBody { set; get; }
        public Errors ApiErrors { set; get; }

        public ApiException ()
            :base()
        {
        }

        public ApiException (String message, Exception innerException) 
            :base(message, innerException)
        {
        }

        public ApiException (int statusCode, String statusDescription, Errors apiErrors, String apiResponseBody)
            :base()
        {
            this.StatusCode = statusCode;
            this.StatusDescription = statusDescription;
            this.ApiErrors = apiErrors;
            this.ApiResponseBody = apiResponseBody;
        }

        public ApiException (String message, Exception innerException, int statusCode, String statusDescription, Errors apiErrors, String apiResponseBody)
            :base(message, innerException)
        {
            this.StatusCode = statusCode;
            this.StatusDescription = statusDescription;
            this.ApiErrors = apiErrors;
            this.ApiResponseBody = apiResponseBody;
        }

       
        /// <remarks>
        /// Adding our api error information to this exception similar to how System.IO.FileNotFoundException is done.
        /// This allows our api error to be logged without abusing the <see cref="Message"/> property
        /// https://stackoverflow.com/a/155606/255194
        /// https://github.com/dotnet/runtime/blob/6072e4d3a7a2a1493f514cdf4be75a3d56580e84/src/libraries/System.Private.CoreLib/src/System/IO/FileNotFoundException.cs
        /// </remarks>
        public override string ToString()
        {
            string s = GetType().ToString() + ": " + Message;

            foreach (var error in ApiErrors?.errors)
            {
                s += Environment.NewLine + error.message;
            }

            if (InnerException != null)
            {
                s += Environment.NewLine + " >" + InnerException.ToString();
            }

            if (StackTrace != null)
            {
                s += Environment.NewLine + StackTrace;
            }

            return s;
        }

    }
}
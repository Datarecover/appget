using System;

namespace AppGet.Http
{
    public class HttpException : Exception
    {
        public HttpRequest Request { get; private set; }
        public HttpResponse Response { get; private set; }

        public HttpException(HttpRequest request, HttpResponse response)
            : base(string.Format("HTTP request failed: [{0}:{1}] [{2}] at [{3}]", (int)response.StatusCode, response.StatusCode, request.Method, request.Url.ToString()))
        {
            Request = request;
            Response = response;
        }

        public HttpException(HttpResponse response)
            : this(response.Request, response)
        {

        }

        public override string ToString()
        {
            if (Response != null)
            {
                return base.ToString() + System.Environment.NewLine + Response.Content;
            }

            return base.ToString();
        }
    }
}
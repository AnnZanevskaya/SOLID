using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BecomeSolid.Day1
{
    public class ResponceService
    {
        private string Url { get; set; }
        private readonly ICommand _command;
        public ResponceService(string url, ICommand _command)
        {
            Url = url;
            this._command = _command;
        }

        public string GetResponse()
        {
            string info = String.Empty;
            if (Url.StartsWith("http"))
            {
                WebRequest request = WebRequest.Create(Url);
                WebResponse response = request.GetResponse();
                info = _command.GetInfo(response);
            }
            else
                info = _command.GetInfo(Url);
            return info;
        }
    }
}

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
        private readonly IEntity entity;
        public ResponceService(string url, IEntity entity)
        {
            Url = url;
            this.entity = entity;
        }

        public string GetResponse()
        {        
            WebRequest request = WebRequest.Create(Url);
            WebResponse response = request.GetResponse();

            string info = entity.GetInfo(response);

            return info;
        } 
    }
}

using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace OverlordCore
{
    public class Server
    {
        public readonly string ServerLocation;
        public readonly string Port;

        public Server(string serverLocation, string port)
        {
            Port = port;
            ServerLocation = serverLocation;
        }

        public int Register(Machine m)
        {
            var client = new RestClient(ServerLocation + ":" + Port);
            var request = new RestRequest("api/machine", Method.POST);
            request.AddJsonBody(m);

            var response = client.Execute(request);

            return Convert.ToInt32(response.Content);
        }

        public string CheckIn(CheckIn checkIn)
        {
            var client = new RestClient(ServerLocation + ":" + Port);
            var request = new RestRequest("api/checkin", Method.POST);
            request.AddJsonBody(checkIn);

            var response = client.Execute(request);

            return response.Content;
        }
    }
}

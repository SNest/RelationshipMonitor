using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RelationshipMonitor.BOL.Entities;
using RestSharp;

namespace Starter
{
    class Program
    {
        readonly static RestClient client = new RestClient("http://localhost:19099/API%20services/Concrete/UserHelperService.svc") { FollowRedirects = false };
        static void Main()
        {
            Console.ReadKey();
            CreateUser(new User() { FirstName = "IVAN", LastName = "TIHOMIROV", Email = "sfga", Password = "asdg" });
            //GetUserById(5);
            //User u = GetUserById(7);
            //u.FirstName = "Lesha";
            //EditUser(u);


            //User use = GetUserById(10);
            //DeleteUser(use.Id);

            //CreateUser(new User() { FirstName = "IVAN", LastName = "TIHOMIROV", Email = "sfga", Password = "asdg"});
            Console.ReadKey();
        }

        static void CreateUser(User user)
        {
            RestRequest request = new RestRequest("api/user/create", Method.PUT) { RequestFormat = DataFormat.Json };
            request.AddBody(user);
            client.Execute(request);
        }

        static private void EditUser(User user)
        {
            RestRequest request = new RestRequest("api/user/edit", Method.POST) { RequestFormat = DataFormat.Json };
            request.RequestFormat = DataFormat.Json;
            request.AddBody(user);
            client.Execute(request);
        }

        static void DeleteUser(int id)
        {
            var request = new RestRequest("UserHelperApi/{id}", Method.DELETE);
            request.AddParameter("id", id);
            client.Execute(request);
        }

        static User GetUserById(int id)
        {
            RestRequest request = new RestRequest("UserHelperApi/{id}", Method.GET);
            request.AddParameter("id", id);
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<User>(response.Content);
        }

       
        static IEnumerable<User> GetAllUsers()
        {
            RestRequest request = new RestRequest("UserHelperApi", Method.GET);
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<IEnumerable<User>>(response.Content);
        }
    }
}

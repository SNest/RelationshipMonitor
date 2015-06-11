using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RelationshipMonitor.BOL.Entities;
using RestSharp;

namespace Starter
{
    class Program
    {
        readonly static RestClient client = new RestClient("http://localhost:19099/API%20services/Concrete/UserHelperService.svc") { FollowRedirects = false };
        readonly static RestClient client2 = new RestClient("http://localhost:19099/API%20services/Concrete/ActivityHelperService.svc") { FollowRedirects = false };
        readonly static RestClient client3 = new RestClient("http://localhost:19099/API%20services/Concrete/RelationHelperService.svc") { FollowRedirects = false };
        static void Main()
        {
            Console.ReadKey();
            Console.WriteLine("ok");

            //UserHelper uh = new UserHelper();

            //uh.Create(new User() { FirstName = "K", LastName = "D", Email = "S", Password = "R", Role = "Dd", Sex = "CC" });

            //CreateUser(new User() { FirstName = "J", LastName = "D", Email = "S", Password = "R", Role = "Dd", Sex = "CC" });
            //GetUserById(1);
            //User u = GetUserById(1);
            //u.FirstName = "Lesha";
            //EditUser(u);

            CreateActivity(new Activity() { Date = Convert.ToDateTime("5/5/2015 12:00:00 AM"), Type = "Gift", CreatorId = 4, RecipientId = 5, Description = "dfgd", Estimate = 5});

            List<User> users = new List<User>();

            users = GetAllUsers();

            List<Activity> activities = new List<Activity>();

            activities = GetAllActivity();

            //User use = GetUserById(10);
            //DeleteUser(use.Id);

            //CreateUser(new User() { FirstName = "IVAN", LastName = "TIHOMIROV", Email = "sfga", Password = "asdg"});
            Console.WriteLine("press something");
            Console.ReadKey();
        }

        static void CreateUser(User user)
        {
            RestRequest request = new RestRequest("api/user/create", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(user);
            client.Execute(request);
        }

        static void CreateActivity(Activity activity)
        {
            RestRequest request = new RestRequest("api/activity/create", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(activity);
            client2.Execute(request);
        }

        static private void EditUser(User user)
        {
            RestRequest request = new RestRequest("api/user/edit", Method.PUT) { RequestFormat = DataFormat.Json };
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


        static List<User> GetAllUsers()
        {
            RestRequest request = new RestRequest("api/user/getall", Method.GET);
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<IEnumerable<User>>(response.Content).ToList();
        }

        static List<Activity> GetAllActivity()
        {
            RestRequest request = new RestRequest("api/activity/getall", Method.GET);
            IRestResponse response = client2.Execute(request);

            List<Activity> d = JsonConvert.DeserializeObject<IEnumerable<Activity>>(response.Content).ToList();
            return d;
        }
    }
}

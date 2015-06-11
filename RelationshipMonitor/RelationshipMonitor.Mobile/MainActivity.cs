using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Newtonsoft.Json;
using RelationshipMonitor.Mobile.Models;
using RestSharp;
using Activity = Android.App.Activity;

namespace RelationshipMonitor.Mobile
{
    [Activity(Label = "RelationshipMonitor.Mobile", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        readonly static RestClient client = new RestClient("http://localhost:19099/API%20services/Concrete/UserHelperService.svc") { FollowRedirects = false };

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button1 = FindViewById<Button>(Resource.Id.MyButton);
            Button button2 = FindViewById<Button>(Resource.Id.UserCreateButton);

            button1.Click += delegate { button1.Text = string.Format("{0} shits!", count++); };

            button2.Click += delegate
            {
                CreateUser(new User() { FirstName = "J", LastName = "D", Email = "S", Password = "R", Role = "Dd", Sex = "CC" });
                User u = GetUserById(1);
                button1.Text = string.Format(u.Email);
            };
        }

        static void CreateUser(User user)
        {
            RestRequest request = new RestRequest("api/user/create", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(user);
            client.Execute(request);
        }

        static User GetUserById(int id)
        {
            RestRequest request = new RestRequest("UserHelperApi/{id}", Method.GET);
            request.AddParameter("id", id);
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<User>(response.Content);
        }
    }
}


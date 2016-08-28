using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Facebook;
using Facebook.Client;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace DroneAidWP81.Layouts
{
    public partial class PFacebookLogin : PhoneApplicationPage
    {
        public PFacebookLogin()
        {
            InitializeComponent();
            this.Loaded += PFacebookLogin_Loaded;
        }

        private async void PFacebookLogin_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.isAuthenticated)
            {
                App.isAuthenticated = true;
                await Authenticate();
            }
        }
        private string savedImagePath = string.Empty;
        private FacebookSession session;

        private async Task Authenticate()
        {
            string message = String.Empty;
            try
            {
                session = await App.FacebookSessionClient.LoginAsync("user_about_me,read_stream,email");
                App.AccessToken = session.AccessToken;
                App.FacebookId = session.FacebookId;

                Dispatcher.BeginInvoke(() =>
                {
                    LoadUserInfo();
                });
            }
            catch (InvalidOperationException e)
            {
                message = "Login failed! Exception details: " + e.Message;
                MessageBox.Show(message);
            }
        }
        private async void LoadUserInfo()
        {
            var fb = new FacebookClient(App.AccessToken);

            fb.GetCompleted += (async (o, e) =>
            {
                if (e.Error != null)
                {
                    Dispatcher.BeginInvoke(async () => MessageBox.Show(e.Error.Message));
                    App.isAuthenticated = false;
                    return;
                }

                var result = (IDictionary<string, object>)e.GetResultData();

               IsolatedStorageSettings.ApplicationSettings["FirstName"] = (string)result["first_name"];
               IsolatedStorageSettings.ApplicationSettings["LastName"] = (string)result["last_name"];
               IsolatedStorageSettings.ApplicationSettings["Id"] = (string)result["id"];
               IsolatedStorageSettings.ApplicationSettings["Email"] = (string)result["Email"];

                Dispatcher.BeginInvoke(async () =>
                {
                    var profilePictureUrl = string.Format("https://graph.facebook.com/{0}/picture?type={1}&access_token={2}", App.FacebookId, "square", App.AccessToken);

                    WebClient client = new WebClient();
                    client.OpenReadCompleted += async (s, args) =>
                    {
                        using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
                        {
                            using (
                                IsolatedStorageFileStream fileStream = new IsolatedStorageFileStream("profilepicture.jpg",
                                    FileMode.Create, storage))
                            {
                                await args.Result.CopyToAsync(fileStream);
                                savedImagePath = fileStream.Name;
                            }
                        }
                    };
                    client.OpenReadAsync(new Uri(profilePictureUrl, UriKind.Absolute));

                    App.isAuthenticated = false;
                    NavigationService.Navigate(new Uri("/Layouts/MainPage.xaml", UriKind.Relative));
                });
            });

            fb.GetTaskAsync("me?fields=first_name,last_name,id,email,age_range,link, gender, locale, picture, timezone, updated_time, verified");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinLoginPage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUpPage : ContentPage
	{
		public SignUpPage ()
		{
			InitializeComponent ();
		}

        private async void OnLoginButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        async void OnSignUpButton_Clicked(object sender, EventArgs e)
        {
            var user = new User
            {
                Username = UsernameEntry.Text,
                Password = PasswordEntry.Text,
                Email = EmailEntry.Text
            };

            var signUpSucceed = AreDetailsValid(user);

            if (signUpSucceed)
            {
                var rootpage = Navigation.NavigationStack.FirstOrDefault();
                Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.FirstOrDefault());
                await Navigation.PopToRootAsync();
            }

            else
            {
                errortext.Text = "SignUpError";
            }
        }

        bool AreDetailsValid(User user)
        {
            return (!string.IsNullOrWhiteSpace(user.Username) && !string.IsNullOrWhiteSpace(user.Password) && !string.IsNullOrWhiteSpace(user.Email) && user.Email.Contains("@"));
        }
    }
}
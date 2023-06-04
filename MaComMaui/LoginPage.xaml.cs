using MaComMaui.Services;

namespace MaComMaui;

public partial class LoginPage : ContentPage
{
  public event EventHandler<string> OnError;

  public LoginPage()
	{
		InitializeComponent();
	}

  public string Password
  {
    get
    {
      return password.Text;
    }
    set
    {
      password.Text = value;
    }
  }

  public string Username
  {
    get
    {
      return username.Text;
    }
    set
    {
      username.Text = value;
    }
  }

  async void Button_Clicked(System.Object sender, System.EventArgs e)
  {
    if (emailValidator.IsNotValid)
    {
      foreach (var error in emailValidator.Errors)
      {
        await DisplayAlert("Error", error.ToString(), "OK");
      }

      return;
    }

    if (passwordValidator.IsNotValid)
    {
      await DisplayAlert("Error", "Password is required", "OK");
      return;
    }

    var response = await ApiService.Login(Username, Password);
    if (response)
    {
      await Shell.Current.GoToAsync("homeView");
    }
    else
    {
      await DisplayAlert("", "Oops something went wrong.", "Cancel");
    }

  }
}

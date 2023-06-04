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
        OnError?.Invoke(sender, error.ToString());
      }

      return;
    }

    if (passwordValidator.IsNotValid)
    {
      OnError?.Invoke(sender, "Password is required.");
      return;
    }

    await Shell.Current.GoToAsync("homeView");
  }
}

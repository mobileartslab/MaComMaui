namespace MaComMaui;

public partial class LoginPage : ContentPage
{
  public event EventHandler<string> OnError;

  public LoginPage()
	{
		InitializeComponent();
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

    if (nameValidator.IsNotValid)
    {
      OnError?.Invoke(sender, "Name is required.");
      return;
    }

    await Shell.Current.GoToAsync("homeView");
  }
}

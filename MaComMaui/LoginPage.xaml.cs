﻿using MaComMaui.Services;

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
    get { return password.Text; }
    set { password.Text = value; }
  }

  public string Username
  {
    get { return username.Text; }
    set { username.Text = value; }
  }



  async void Button_Clicked(System.Object sender, System.EventArgs e) {
    usernameError.Text = "";
    passwordError.Text = "";
    submitError.Text = "";


    if (emailValidator.IsNotValid) {
      usernameError.Text = emailValidator.Errors[0].ToString();
      return;
    }

    if (passwordValidator.IsNotValid) {
      passwordError.Text = "Password is required";
      return;
    }

    var response = await ApiService.Login(Username, Password);

    if (response != null) {
      var authStatus = response.user.authStatus;
      if (authStatus == 1)
      {
        await Shell.Current.GoToAsync("homeView");
      }
      else if (authStatus == 0) {
        submitError.Text = "User not found";
      } 
      else if (authStatus == -1) {
        submitError.Text = "Invalid login";
      } 
    }
    else {
      submitError.Text = "Server Error";
    }

  }
}

/*
  const validate = () => {
    let isValid = true
    resetErrors()

    if (!fields.email) {
      isValid = false
      errors.email = 'Email Required'
    }

    if (fields.email && !ValidationConstants.EMAIL.test(fields.email)) {
      isValid = false
      errors.email = 'Please enter a valid email'
    }

    if (!fields.password) {
      isValid = false
      errors.password = 'Password Required'
    }

    if (!isValid) {
      const newErrors = errors
      setErrors({ ...errors, ...newErrors })
    }

    return isValid
  }
*/
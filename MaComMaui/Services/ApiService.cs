using System;
using System.Text;
using Newtonsoft.Json;
using MaComMaui.Models;
using System.Net.Http.Headers;

namespace MaComMaui.Services
{
	public class ApiService
	{
		public ApiService() 
		{
		}

    public static async Task<bool> Login(string email, string password)
    {
      var login = new Login()
      {
        username = email,
        password = password
      };

      var httpClient = new HttpClient();
      var json = JsonConvert.SerializeObject(login);
      var content = new StringContent(json, Encoding.UTF8, "application/json");
      var response = await httpClient.PostAsync(AppSettings.ApiUrl + "/public/login", content);
      if (!response.IsSuccessStatusCode) return false;
      var jsonResult = await response.Content.ReadAsStringAsync();
      var result = JsonConvert.DeserializeObject<LoginResult>(jsonResult);
      return true;
    }
  }
}


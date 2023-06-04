using System;
using Newtonsoft.Json;

namespace MaComMaui.Models
{
	public class LoginResult
	{
		public LoginResult()
		{
		}

    public string error { get; set; }
    [JsonProperty("result")]
    public LoginUser user { get; set; }
  }
}


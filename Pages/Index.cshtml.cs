using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using web_api_hello.Models;

namespace web_api_hello.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private readonly HttpClient httpClient = new HttpClient();

		public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
			Users = new RandomUsers();
		}


		public RandomUsers Users { get; set; }

		public async Task<IActionResult> OnGetAsync()
		{
			RandomUsers? data = new RandomUsers();
			HttpResponseMessage responseMessage = await httpClient
			.GetAsync("https://randomuser.me/api/?results=3");
			_logger.Log(LogLevel.Information, "test");
			if (responseMessage.IsSuccessStatusCode)
			{
				var dataj = await responseMessage.Content.ReadAsStreamAsync();
				data = await JsonSerializer.DeserializeAsync<RandomUsers>(
					dataj,
					new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
				);
				if (data == null)
				{
					data = new RandomUsers();
				}
				_logger.Log(LogLevel.Information, data.ToString() ?? "no data");
			}
			Users = data;
			return Page();
		}

	}
}

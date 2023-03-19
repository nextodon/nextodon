using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mastodon.Pages
{
    public class AuthorizeModel : PageModel
    {
        private readonly ILogger<AuthorizeModel> _logger;

        public AuthorizeModel(ILogger<AuthorizeModel> logger)
        {
            _logger = logger;
        }

        public async Task OnPostSubmit(AuthorizeModelData model)
        {
            await Task.Yield();
        }
    }

    public class AuthorizeModelData
    {
        [BindProperty]
        public string Mnemonic { get; set; } = default!;
    }
}
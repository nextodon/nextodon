using Microsoft.AspNetCore.Mvc;

namespace Nextodon.Controllers;

[Route("api/v1/media")]
[ApiController]
public sealed class MediaController : ControllerBase
{
    private readonly ILogger<MediaController> _logger;
    private readonly Data.DataContext _db;

    public MediaController(ILogger<MediaController> logger, DataContext db)
    {
        _logger = logger;
        _db = db;
    }

    [Authorize]
    [HttpPost("~/api/v1/media")]
    [HttpPost("~/api/v2/media")]
    public async void Upload()
    {
        var context = this.HttpContext;

        var accountId = context.GetAuthToken(true);
        var form = await context.Request.ReadFormAsync();

        foreach (var f in form.Files)
        {
            using var stream = f.OpenReadStream();
            using var memory = new MemoryStream();

            await stream.CopyToAsync(memory);

            var media = new Nextodon.Data.Media
            {
                AccountId = accountId!,
                Content = memory.ToArray()
            };

            await _db.Media.InsertOneAsync(media);

            var url = context.GetUrlPath($"/api/v1/media/{media.Id}");

            var mediaAttachment = new
            {
                Id = media.Id,
                Type = "image",
                Url = $"{url}/original",
                PreviewUrl = $"{url}/preview",
                Blurhash = "LGF5?xYk^6#M@-5c,1J5@[or[Q6.",
            };

            await context.Response.WriteAsJsonAsync(mediaAttachment);
            break;
        }
    }

    [HttpGet("{mediaId}/original")]
    [HttpGet("{mediaId}/preview")]
    public async Task<IActionResult> GetPreview([FromRoute] string mediaId)
    {
        var media = await _db.Media.FindByIdAsync(mediaId);

        if (media == null)
        {
            return NotFound();
        }

        return File(media.Content, "image/png");
    }
}

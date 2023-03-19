using Microsoft.AspNetCore.Mvc;

namespace Mastodon.Controllers;

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
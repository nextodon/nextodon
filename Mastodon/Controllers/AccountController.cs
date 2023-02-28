using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Text.Json;

namespace Mastodon.Controllers;

[Route("api/v1/accounts")]
[ApiController]
[Authorize]
public sealed class AccountController : ControllerBase {
    private readonly ILogger<AccountController> _logger;
    private readonly Data.DataContext _db;

    public AccountController(ILogger<AccountController> logger, DataContext db) {
        _logger = logger;

        _db = db;
    }

    [HttpPatch("update_credentials")]
    public async Task<IActionResult> UpdateCredentials([FromForm] UpdateCredentialsRequest request) {
        var accountId = this.Request.HttpContext.GetAccountId(true);

        var filter = Builders<Data.Account>.Filter.Eq(x => x.Id, accountId);
        var updates = new List<UpdateDefinition<Data.Account>>();

        if (request.Bot != null) {
            var u = Builders<Data.Account>.Update.Set(x => x.Bot, request.Bot);
            updates.Add(u);
        }

        if (request.Locked!=null) {
            var u = Builders<Data.Account>.Update.Set(x => x.Locked, request.Locked);
            updates.Add(u);
        }

        if (request.Note != null) {
            var u = Builders<Data.Account>.Update.Set(x => x.Note, request.Note);
            updates.Add(u);
        }

        //if (request.HasDiscoverable) {
        //    var u = Builders<Data.Account>.Update.Set(x => x.Discoverable, request.Discoverable);
        //    updates.Add(u);
        //}

        if (request.DisplayName != null) {
            var u = Builders<Data.Account>.Update.Set(x => x.DisplayName, request.DisplayName);
            updates.Add(u);
        }

        //if (request.Ha) {
        //    var u = Builders<Data.Account>.Update.Set(x => x.DisplayName, request.DisplayName);
        //    updates.Add(u);
        //}

        var update = Builders<Data.Account>.Update.Combine(updates);

        var account = await _db.Account.FindOneAndUpdateAsync(filter, update);

        var c = account.ToGrpc();

        var formatter = new Google.Protobuf.JsonFormatter(Google.Protobuf.JsonFormatter.Settings.Default);
        var json = formatter.Format(c);

        

        return Ok(json);
    }


    public sealed class UpdateCredentialsRequest {
        /// <summary>
        /// The display name to use for the profile.
        /// </summary>
        [BindProperty(Name = "display_name")]
        public string? DisplayName { get; set; }

        /// <summary>
        /// The account bio.
        /// </summary>
        [BindProperty(Name = "note")]
        public string? Note { get; set; }

        /// <summary>
        /// Avatar image encoded using multipart/form-data.
        /// </summary>
        [BindProperty(Name = "avatar")]
        public IFormFile? Avatar { get; set; }

        /// <summary>
        /// Header image encoded using multipart/form-data.
        /// </summary>
        [BindProperty(Name = "header")]
        public IFormFile? Header { get; set; }

        /// <summary>
        /// Whether manual approval of follow requests is required.
        /// </summary>
        [BindProperty(Name = "locked")]
        public bool? Locked { get; set; }

        // Whether the account has a bot flag.
        [BindProperty(Name = "bot")]
        public bool? Bot { get; set; }

        /// <summary>
        /// Whether the account should be shown in the profile directory.
        /// </summary>
        [BindProperty(Name = "discoverable")]
        public bool? Discoverable { get; set; }

        [BindProperty(Name = "fields_attributes")]
        public List<Types.FieldAttribute>? FieldsAttributes { get; set; }

        [BindProperty(Name = "source")]
        public Types.Source? Source { get; set; }

        public static class Types {

            public sealed class FieldAttribute {
                public required string Name;
                public required string Value;
            }


            public sealed class Source {
                /// <summary>
                /// Default post privacy for authored statuses. Can be public, unlisted, or private.
                /// </summary>
                public required string Privacy;

                /// <summary>
                /// Whether to mark authored statuses as sensitive by default.
                /// </summary>
                public required bool Sensitive;

                /// <summary>
                /// Default language to use for authored statuses (ISO 6391)
                /// </summary>
                public required string Language;
            }
        }
    }
}
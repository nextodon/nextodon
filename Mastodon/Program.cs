using Mastodon;
using Mastodon.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;


builder.Services.Configure<Mastodon.Data.MongoDbSettings>(builder.Configuration.GetSection("MongoDb"));

builder.Services.AddGrpc().AddJsonTranscoding(options => {
    options.JsonSettings.WriteIndented = true;
    options.JsonSettings.IgnoreDefaultValues = false;
});

builder.Services.AddGrpcReflection();
builder.Services.AddSingleton<DataContext>();

builder.Services.Configure<ForwardedHeadersOptions>(options => { options.ForwardedHeaders = ForwardedHeaders.All; });


var jwtOptions = config.GetSection("JwtSettings").Get<JwtOptions>()!;

var key = Encoding.UTF8.GetBytes(jwtOptions.SecretKey);
builder.Services.AddAuthentication(x => {
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x => {
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddAuthorization();

builder.Services.AddCors(o => {
    o.AddDefaultPolicy(
    builder => {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });

    //o.AddDefaultPolicy(
    //builder =>
    //{
    //    builder.WithOrigins("https://app.fordem.org")
    //                        .AllowAnyHeader()
    //                        .AllowAnyMethod();
    //});
});


builder.Services.AddScoped((s) => new Mastodon.Client.MastodonClient(new Uri("https://mastodon.lol")));

var app = builder.Build();

app.Use((context, next) => {
    var contentType = context.Request.Headers.ContentType;
    var contentLength = context.Request.Headers.ContentLength ?? 0;

    if (contentType.Count == 0 || string.IsNullOrWhiteSpace(contentType.ToString())) {
        if (context.Request.Path.StartsWithSegments("/api/v1", StringComparison.OrdinalIgnoreCase)) {
            if (contentLength == 0) {
                context.Request.Body = new MemoryStream("{}"u8.ToArray());
                context.Request.Headers.ContentType = new Microsoft.Extensions.Primitives.StringValues("application/json");
            }
        }
    }

    return next();
});

app.UseCors();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseForwardedHeaders();
//app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseGrpcWeb();

app.MapGrpcService<AccountApiService>().EnableGrpcWeb();
app.MapGrpcService<AppsService>().EnableGrpcWeb();
app.MapGrpcService<AuthenticationService>().EnableGrpcWeb();
app.MapGrpcService<BookmarkApiService>().EnableGrpcWeb();
app.MapGrpcService<DirectoryService>().EnableGrpcWeb();
app.MapGrpcService<InstanceService>().EnableGrpcWeb();
app.MapGrpcService<OAuthService>().EnableGrpcWeb();
app.MapGrpcService<PollService>().EnableGrpcWeb();
app.MapGrpcService<SearchService>().EnableGrpcWeb();
app.MapGrpcService<StatusApiService>().EnableGrpcWeb();
app.MapGrpcService<TimelineService>().EnableGrpcWeb();
app.MapGrpcService<TrendsService>().EnableGrpcWeb();


app.MapGrpcReflectionService().EnableGrpcWeb();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");

app.MapPost("/auth/sign_in", async (context) => {
    var q = context.Request;

    var url = context.Request.GetEncodedUrl();
    var b = new UriBuilder(url);
    b.Host = "mastodon.lol";
    b.Scheme = "https";
    b.Port = 443;

    var cookieContainer = new CookieContainer();
    using var handler = new HttpClientHandler { CookieContainer = cookieContainer };

    var client = new HttpClient(handler);

    var cookie = string.Join(";", q.Cookies.Select(x => $"{x.Key}={x.Value}"));
    try {
        client.DefaultRequestHeaders.UserAgent.TryParseAdd(context.Request.Headers.UserAgent.FirstOrDefault());
        client.DefaultRequestHeaders.TryAddWithoutValidation("Cookie", cookie);

        var formData = await context.Request.ReadFormAsync();
        var formDictionary = formData.ToDictionary(x => x.Key, x => x.Value.FirstOrDefault());

        var form = new FormUrlEncodedContent(formDictionary);
        form.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(context.Request.ContentType ?? "");

        var response = await client.PostAsync(b.ToString(), form);
        var content = await response.Content.ReadAsStringAsync();
        var utf8 = Encoding.UTF8.GetBytes(content);

        context.Response.StatusCode = (int)response.StatusCode;

        var d = context.Response.Cookies;
        foreach (var ck in cookieContainer.GetAllCookies().ToList()) {
            d.Append(ck.Name, ck.Value);
        }

        await context.Response.BodyWriter.WriteAsync(utf8);
    }
    catch (Exception) {
        //
    }
});

app.MapPost("/oauth/authorize", async (context) => {
    var q = context.Request;

    var url = context.Request.GetEncodedUrl();
    var b = new UriBuilder(url);
    b.Host = "mastodon.lol";
    b.Scheme = "https";
    b.Port = 443;

    var cookieContainer = new CookieContainer();
    using var handler = new HttpClientHandler { CookieContainer = cookieContainer };

    var client = new HttpClient(handler);

    var cookie = string.Join(";", q.Cookies.Select(x => $"{x.Key}={x.Value}"));
    try {
        client.DefaultRequestHeaders.UserAgent.TryParseAdd(context.Request.Headers.UserAgent.FirstOrDefault());
        client.DefaultRequestHeaders.TryAddWithoutValidation("Cookie", cookie);

        var formData = await context.Request.ReadFormAsync();
        var formDictionary = formData.ToDictionary(x => x.Key, x => x.Value.FirstOrDefault());

        var form = new FormUrlEncodedContent(formDictionary);
        form.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(context.Request.ContentType ?? "");

        var response = await client.PostAsync(b.ToString(), form);
        var content = await response.Content.ReadAsStringAsync();
        var utf8 = Encoding.UTF8.GetBytes(content);

        context.Response.StatusCode = (int)response.StatusCode;
        context.Response.Headers.Location = new Microsoft.Extensions.Primitives.StringValues(response.Headers.Location?.ToString());

        var d = context.Response.Cookies;
        foreach (var ck in cookieContainer.GetAllCookies().ToList()) {
            d.Append(ck.Name, ck.Value);
        }

        await context.Response.BodyWriter.WriteAsync(utf8);
    }
    catch (Exception) {
        //
    }
});

app.MapGet("/oauth/authorize", async (context) => {
    var url = context.Request.GetEncodedUrl();
    var b = new UriBuilder(url) {
        Host = "mastodon.lol",
        Scheme = "https",
        Port = 443
    };

    var cookieContainer = new CookieContainer();
    using var handler = new HttpClientHandler { CookieContainer = cookieContainer };

    var client = new HttpClient(handler);

    try {
        client.DefaultRequestHeaders.UserAgent.TryParseAdd(context.Request.Headers.UserAgent.FirstOrDefault());
        var content = await client.GetStringAsync(b.ToString());
        var utf8 = Encoding.UTF8.GetBytes(content);

        var d = context.Response.Cookies;
        foreach (var cookie in cookieContainer.GetAllCookies().ToList()) {
            d.Append(cookie.Name, cookie.Value);
        }

        await context.Response.BodyWriter.WriteAsync(utf8);
    }
    catch (Exception) {
        //
    }
});

app.MapPost("/api/v1/media", async (HttpContext context, DataContext db) => {
    var accountId = context.GetAccountId(true);
    var form = await context.Request.ReadFormAsync();

    foreach (var f in form.Files) {
        using var stream = f.OpenReadStream();
        using var memory = new MemoryStream();

        await stream.CopyToAsync(memory);

        var media = new Mastodon.Data.Media {
            AccountId = accountId!,
            Content = memory.ToArray()
        };

        await db.Media.InsertOneAsync(media);

        var mediaAttachment = new Mastodon.Models.MediaAttachment {
            Id = media.Id,
            Type = "image",
            Url = $"https://m.com/{media.Id}",
            PreviewUrl = $"https://m.com/{media.Id}",
        };

        await context.Response.WriteAsJsonAsync(mediaAttachment);

        break;
    }
});

app.MapPost("/api/v2/media", async (HttpContext context, DataContext db) => {
    var accountId = context.GetAccountId(true);
    var form = await context.Request.ReadFormAsync();

    foreach (var f in form.Files) {
        using var stream = f.OpenReadStream();
        using var memory = new MemoryStream();

        await stream.CopyToAsync(memory);

        var media = new Mastodon.Data.Media {
            AccountId = accountId!,
            Content = memory.ToArray()
        };

        await db.Media.InsertOneAsync(media);

        var mediaAttachment = new Mastodon.Models.MediaAttachment {
            Id = media.Id,
            Type = "image",
            Url = $"https://m.com/{media.Id}",
            PreviewUrl = $"https://m.com/{media.Id}",
        };

        await context.Response.WriteAsJsonAsync(mediaAttachment);
        break;
    }
});

app.MapFallback(async context => {
    var logger = ((IApplicationBuilder)app).ApplicationServices.GetService<ILogger<Program>>();
    var content = $"{context.Request.Method}: {context.Request.GetDisplayUrl()}";

    using var stream = context.Request.BodyReader.AsStream(true);
    using var reader = new StreamReader(stream, Encoding.UTF8, leaveOpen: true);

    var body = await reader.ReadToEndAsync();

    context.Response.StatusCode = 404;

    if (body != null && body.Length > 0) {
        content += "\r\n" + body;
    }

    logger?.LogError(content);
    await context.Response.WriteAsync(content);
});

app.Run();

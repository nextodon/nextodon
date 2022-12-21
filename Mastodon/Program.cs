using Mastodon.Services;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<Mastodon.Data.MongoDbSettings>(builder.Configuration.GetSection("MongoDb"));

builder.Services.AddGrpc().AddJsonTranscoding(options =>
{
    options.JsonSettings.WriteIndented = true;
    options.JsonSettings.IgnoreDefaultValues = false;
});

builder.Services.AddGrpcReflection();
builder.Services.AddSingleton<DataContext>();

builder.Services.Configure<ForwardedHeadersOptions>(options => { options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto; });

builder.Services.AddCors(o =>
{
    o.AddDefaultPolicy(
    builder =>
    {
        builder.WithOrigins("https://app.fordem.org")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
    });
});


builder.Services.AddScoped((s) => new Mastodon.Client.MastodonClient(new Uri("https://mastodon.lol")));

var app = builder.Build();

app.UseCors();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseForwardedHeaders();
//app.UseHttpsRedirection();

app.UseRouting();
app.UseGrpcWeb();

app.MapGrpcService<AccountApiService>().EnableGrpcWeb();
app.MapGrpcService<AppsService>().EnableGrpcWeb();
app.MapGrpcService<DirectoryService>().EnableGrpcWeb();
app.MapGrpcService<InstanceService>().EnableGrpcWeb();
app.MapGrpcService<OAuthService>().EnableGrpcWeb();
app.MapGrpcService<StatusApiService>().EnableGrpcWeb();
app.MapGrpcService<TimelineService>().EnableGrpcWeb();
app.MapGrpcService<TrendsService>().EnableGrpcWeb();


app.MapGrpcReflectionService().EnableGrpcWeb();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");

app.MapPost("/auth/sign_in", async (context) =>
{
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
    try
    {
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
        foreach (var ck in cookieContainer.GetAllCookies().ToList())
        {
            d.Append(ck.Name, ck.Value);
        }

        await context.Response.BodyWriter.WriteAsync(utf8);
    }
    catch (Exception ex)
    {
        //
    }
});

app.MapPost("/oauth/authorize", async (context) =>
{
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
    try
    {
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
        foreach (var ck in cookieContainer.GetAllCookies().ToList())
        {
            d.Append(ck.Name, ck.Value);
        }

        await context.Response.BodyWriter.WriteAsync(utf8);
    }
    catch (Exception ex)
    {
        //
    }
});

app.MapGet("/oauth/authorize", async (context) =>
{
    var url = context.Request.GetEncodedUrl();
    var b = new UriBuilder(url);
    b.Host = "mastodon.lol";
    b.Scheme = "https";
    b.Port = 443;

    var cookieContainer = new CookieContainer();
    using var handler = new HttpClientHandler { CookieContainer = cookieContainer };

    var client = new HttpClient(handler);

    try
    {
        client.DefaultRequestHeaders.UserAgent.TryParseAdd(context.Request.Headers.UserAgent.FirstOrDefault());
        var content = await client.GetStringAsync(b.ToString());
        var utf8 = Encoding.UTF8.GetBytes(content);

        var d = context.Response.Cookies;
        foreach (var cookie in cookieContainer.GetAllCookies().ToList())
        {
            d.Append(cookie.Name, cookie.Value);
        }

        await context.Response.BodyWriter.WriteAsync(utf8);
    }
    catch (Exception ex)
    {
        //
    }
});

app.MapFallback(async context =>
{
    var logger = ((IApplicationBuilder)app).ApplicationServices.GetService<ILogger<Program>>();
    var content = $"{context.Request.Method}: {context.Request.GetDisplayUrl()}";

    using var stream = context.Request.BodyReader.AsStream(true);
    using var reader = new StreamReader(stream, Encoding.UTF8, leaveOpen: true);

    var body = await reader.ReadToEndAsync();

    context.Response.StatusCode = 404;

    if (body != null && body.Length > 0)
    {
        content += "\r\n" + body;
    }

    logger?.LogError(content);
    await context.Response.WriteAsync(content);
});

app.Run();

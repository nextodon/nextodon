using Mastodon.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc().AddJsonTranscoding(options =>
{
    options.JsonSettings.WriteIndented = true;
    options.JsonSettings.IgnoreDefaultValues = false;
});

builder.Services.AddGrpcReflection();

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


builder.Services.AddSingleton(new Mastodon.Client.MastodonClient(new Uri("https://mastodon.lol")));

var app = builder.Build();

app.UseCors();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseForwardedHeaders();
//app.UseHttpsRedirection();

app.UseRouting();


app.UseGrpcWeb();

app.MapGrpcService<MastodonService>().EnableGrpcWeb();
app.MapGrpcService<TrendsService>().EnableGrpcWeb();
app.MapGrpcReflectionService().EnableGrpcWeb();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");

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

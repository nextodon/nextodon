using Mastodon;
using Mastodon.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;


builder.Services.Configure<Mastodon.Data.MongoDbSettings>(builder.Configuration.GetSection("MongoDb"));

builder.Services.AddControllers();

builder.Services.AddGrpc().AddJsonTranscoding(options =>
{
    options.JsonSettings.WriteIndented = true;
    options.JsonSettings.IgnoreDefaultValues = false;
});

builder.Services.AddGrpcReflection();
builder.Services.AddSingleton<DataContext>();

builder.Services.Configure<ForwardedHeadersOptions>(options => { options.ForwardedHeaders = ForwardedHeaders.All; });


var jwtOptions = config.GetSection("JwtSettings").Get<JwtOptions>()!;

var key = Encoding.UTF8.GetBytes(jwtOptions.SecretKey);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddAuthorization();

builder.Services.AddCors();

var app = builder.Build();

app.Use((context, next) =>
{
    var contentType = context.Request.Headers.ContentType;
    var contentLength = context.Request.Headers.ContentLength ?? 0;

    if (contentType.Count == 0 || string.IsNullOrWhiteSpace(contentType.ToString()))
    {
        if (context.Request.Path.StartsWithSegments("/api/v1", StringComparison.OrdinalIgnoreCase))
        {
            if (contentLength == 0)
            {
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
app.MapGrpcService<MarkerService>().EnableGrpcWeb();
app.MapGrpcService<MediaApiService>().EnableGrpcWeb();
app.MapGrpcService<NotificationApiService>().EnableGrpcWeb();
app.MapGrpcService<OAuthService>().EnableGrpcWeb();
app.MapGrpcService<PollService>().EnableGrpcWeb();
app.MapGrpcService<SearchService>().EnableGrpcWeb();
app.MapGrpcService<StatusApiService>().EnableGrpcWeb();
app.MapGrpcService<StreamingService>().EnableGrpcWeb();
app.MapGrpcService<TimelineService>().EnableGrpcWeb();
app.MapGrpcService<TrendsService>().EnableGrpcWeb();

app.MapGrpcReflectionService().EnableGrpcWeb();

app.MapControllers();

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

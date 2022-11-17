using ForDem;
using ForDem.Data;
using ForDem.Services;
using Microsoft.AspNetCore.Authentication.DigitalSignature;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

//var settings = config.GetSection("MongoDb").Get<MongoDbSettings>()!;
//builder.Services.AddSingleton(new ForDem.Data.DataContext(settings.ConnectionString, settings.DatabaseName));

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

builder.Services.Configure<ForwardedHeadersOptions>(options => { options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto; });

var key = Encoding.UTF8.GetBytes("0102030405060708");
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = DigitalSignatureDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = DigitalSignatureDefaults.AuthenticationScheme;
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
}).AddDigitalSignature(x => { });

builder.Services.AddAuthorization();

builder.Services.AddCors(o =>
{
    o.AddDefaultPolicy(
    builder =>
    {
        builder.WithOrigins("https://grpcui.dev", "https://app.grpcui.dev", "https://*.mangoriver-4d99c329.canadacentral.azurecontainerapps.io")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
    });

    o.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding", "X-Grpc-Web", "User-Agent");
    });
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseForwardedHeaders();
//app.UseHttpsRedirection();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.UseGrpcWeb();
app.UseCors();

app.MapGrpcService<AuthenticationService>().EnableGrpcWeb().RequireAuthorization();
app.MapGrpcService<WallService>().EnableGrpcWeb().RequireAuthorization();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");

app.MapGrpcReflectionService().EnableGrpcWeb();

app.Run();

using ForDem.Data;
using ForDem.Services;
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

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseForwardedHeaders();
//app.UseHttpsRedirection();

app.UseRouting();

//app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.UseGrpcWeb();

app.MapGrpcService<WallService>().EnableGrpcWeb().RequireAuthorization();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");

app.MapGrpcReflectionService().EnableGrpcWeb();

app.Run();

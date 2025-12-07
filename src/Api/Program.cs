using Hababk.Modules.Identities.Application.Commands;
using Hababk.Modules.Identities.Infrastructure.Configurations;
using Hababk.Modules.Stores.Application.Commands;
using Hababk.Modules.Stores.Infrastructure.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(cfg =>
{
    cfg.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Type= Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme= "Bearer",
        BearerFormat= "JWT",
    });
    cfg.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference= new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type= Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id= "Bearer"
                }
            },
            new string[]{}
        }
    });

});
builder.Services.AddMediatR(cfg =>
{
    cfg.LicenseKey =
    "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxNzkzNzUwNDAwIiwiaWF0IjoiMTc2MjI4OTI5OCIsImFjY291bnRfaWQiOiIwMTlhNTA5ZWY4Y2Y3ZGEyYmMxY2IwMWI4NTE0MDZiNSIsImN1c3RvbWVyX2lkIjoiY3RtXzAxazk4YTFhcnhqYnpqcjNhZDA5OTRxbWZ0Iiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.pidsoJENvU5s7cMLhpOmzjLA7lkRYhJ9YmqZE4yPf7ON8nrp_gV3qkWqe69K0jenmAoh9L8xsABA2KUSZxOd-ZI-AyhyCh-S8vECot1Fxen0DZRxhMEg3bEVcT9J5AQSwQjGTU-KIC0stP5oDCq3kO_iSbbb42ybcyVTn-aKw14_yDphkeiTQFmkwQ2FqSKj-frJ8D8G-0mCk-qQ75TXXVCOfw0zgftQDu0lcUFS6ZuahV7QNM9HJC3YjiUCtN-zzRdp0vZ3Am2_HLtTbG3Wtz73mgqaOPohg7ApUoL60VW88qpR-Jtz2lNbAC4vcC9lN43wYX5imIhhFoDFdx33Hw";
    cfg.RegisterServicesFromAssemblies(
        [
            typeof(Program).Assembly, 
            typeof(CreateStoreCommand).Assembly, 
            typeof(CreateUserCommand).Assembly
        ]);    
});
builder.Services.AddStoreDbContext(builder.Configuration);
builder.Services.AddStoreRepositories();
builder.Services.RegisterdIdentityDatabase(builder.Configuration);
builder.Services.RegisterdIdentityRepositoriesAndServices(builder.Configuration);
builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "localhost:5051",
        ValidAudience = "localhost:5051",
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
});
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
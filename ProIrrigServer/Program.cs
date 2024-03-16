using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using ProIrrigServer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<FirebaseAdmin.Auth.FirebaseAuth>(sp => FirebaseAdmin.Auth.FirebaseAuth.DefaultInstance);
builder.Services.AddScoped<FirebaseAuthService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var defaultApp = FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile("firebase.json")
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
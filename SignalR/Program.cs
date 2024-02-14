using SignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(option => option.AddDefaultPolicy(policy =>
{
    policy.AllowAnyHeader()
    .AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(origin => true);
        
}));
builder.Services.AddSignalR();


var app = builder.Build();
app.UseCors();
app.MapHub<TestHub>("/testhub");

app.Run();

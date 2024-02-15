using SignalR.Business;
using SignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(option => option.AddDefaultPolicy(policy =>
{
    policy.AllowAnyHeader()
    .AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(origin => true);
        
}));
builder.Services.AddScoped<TestBusiness>();
builder.Services.AddSignalR();
builder.Services.AddControllers();

var app = builder.Build();
app.UseCors();
app.MapHub<TestHub>("/testhub");
app.MapControllers();

app.Run();

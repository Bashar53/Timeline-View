using Microsoft.EntityFrameworkCore;
using TimeLineViwer.Data;
using TimeLineViwer.Hub;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TimeLineDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddCors(options => {
    options.AddPolicy("CORSPolicy", builder => builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed((hosts) => true));
});
builder.Services.AddControllers()
             .AddJsonOptions(options =>
             {
                 // Disabled Camel Case in JSON serialization and deserialization
                 options.JsonSerializerOptions.PropertyNamingPolicy = null;
             });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CORSPolicy");
app.UseRouting();


app.UseAuthorization();
app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
    endpoints.MapHub<MessageHub>("/posts");
});
app.UseHttpsRedirection();
app.MapControllers();

app.Run();

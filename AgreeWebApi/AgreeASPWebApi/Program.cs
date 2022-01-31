using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;


var MyAllowSpecificOrigins = "EnableCORS";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins, builder =>
    {

        builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();

    });
});

builder.Services.AddCors();
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(MyAllowSpecificOrigins,
//        builder =>
//        {
//            builder
//                //.WithOrigins(config.GetSection("AllowedOrigins").Get<List<string>>().ToArray())
//                .AllowAnyOrigin()
//                .AllowAnyHeader()
//                .AllowAnyMethod()
//                .SetIsOriginAllowed(origin => true);
//        });
//});
// services.AddResponseCaching();


builder.Services.AddControllersWithViews().
    AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling =
    Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
    = new DefaultContractResolver());


builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Photos")),
    RequestPath = "/Photos"
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors(x => x
           .AllowAnyMethod()
           .AllowAnyHeader()
           .SetIsOriginAllowed(origin => true) // allow any origin
           .AllowCredentials());


app.UseAuthorization();


app.UseEndpoints(x => x.MapControllers());
//app.MapControllers();

app.Run();



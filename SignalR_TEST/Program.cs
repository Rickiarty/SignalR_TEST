using SignalR_TEST.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting()
    .UseAuthorization()
    .UseEndpoints(endpoints =>
    {
        _ = endpoints.MapHub<ChatHub>("/ChatHub");
        _ = endpoints.MapRazorPages();
    });

app.Run();

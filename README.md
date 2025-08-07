# Run docker compose to provision Mongo DB container
docker-compose up -d

# Run the dotnet api app (server)
cd DynamicFormAPI
dotnet run
http://localhost:5297/swagger

# Run the Blazor client
cd DynamicFormClient/Client
dotnet run
http://localhost:5239/create

If you are using different url and port for blazor app, update the CORS in server app - program.cs
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient", policy =>
    {
        policy.WithOrigins("http://localhost:5239") // your Blazor port
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

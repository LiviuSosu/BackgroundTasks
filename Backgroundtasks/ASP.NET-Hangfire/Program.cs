using Hangfire;
using Hangfire.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

GlobalConfiguration.Configuration
               .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
               .UseColouredConsoleLogProvider()
               .UseSimpleAssemblyNameTypeSerializer()
               .UseRecommendedSerializerSettings()
               .UseSqlServerStorage("Data Source = DESKTOP-M80MDUC\\SQLEXPRESS;Initial Catalog=BackgroundTasks;Integrated Security = True;", new SqlServerStorageOptions
               {
                   CommandBatchMaxTimeout = TimeSpan.FromSeconds(3),
                   SlidingInvisibilityTimeout = TimeSpan.FromSeconds(2),
                   QueuePollInterval = TimeSpan.Zero,
                   UseRecommendedIsolationLevel = true
               });

var manager = new RecurringJobManager();

manager.AddOrUpdate("easyjob", () => Console.Write("Easy!"), Cron.Minutely);
manager.Trigger("easyjob");
//BackgroundJob.Enqueue(() => Console.WriteLine("Hello, world!"));

//using (var server = new BackgroundJobServer())
//{
//    Console.ReadLine();
//}

app.UseAuthorization();

app.MapControllers();

app.Run();

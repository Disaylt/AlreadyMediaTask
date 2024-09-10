using NasaAsteroid.Application;
using NasaAsteroid.Infrastructure;
using NasaAsteroid.Processor.Backgrounds;
using NasaAsteroid.Processor.Jobs;
using Quartz;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddOpenTelemetry();
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(builder.Configuration);

builder.Services.AddHostedService<AutoMigrationBackgroundService>();

builder.Services.AddQuartz(opt =>
{
    JobKey asteroidsUplodingJobkey = new JobKey("AsteroidsUplodingJob");
    opt.AddJob<AsteroidsUplodingJob>(x => x.WithIdentity(asteroidsUplodingJobkey));

    opt.AddTrigger(tgOpt => tgOpt
        .ForJob(asteroidsUplodingJobkey)
        .WithIdentity($"{asteroidsUplodingJobkey.Name}-t")
        .StartAt(DateTime.Now.AddSeconds(10))
        .WithSimpleSchedule(scheduleOpt => scheduleOpt
        .WithIntervalInSeconds(120)
        .RepeatForever()));
});

builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

var host = builder.Build();
host.Run();

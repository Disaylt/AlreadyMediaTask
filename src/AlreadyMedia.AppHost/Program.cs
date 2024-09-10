var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("redis");
var postgres = builder.AddPostgres("postgres")
    .WithImage("ankane/pgvector")
    .WithImageTag("latest");

var nasaAsteroidsDb = postgres.AddDatabase("nasaAsteroids");

var nasaAsteroidProcessor = builder.AddProject<Projects.NasaAsteroid_Processor>("nasa-asteroid-processor")
    .WithReference(redis)
    .WithReference(nasaAsteroidsDb);

builder.AddProject<Projects.NasaAsteroid_WebApi>("nasa-asteroid-webapi");

builder.Build().Run();

using CommandLine;
using Microsoft.AspNetCore.Server.Kestrel.Core;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        var parseResult = Parser.Default.ParseArguments<CLIOptions>(Environment.GetCommandLineArgs());

        switch (parseResult.Tag)
        {
            case ParserResultType.Parsed:
                var parsed = (Parsed<CLIOptions>)parseResult;
                if (parsed == null)
                {
                    Environment.Exit(-1);
                }

                var opt = parsed.Value;
                services.AddSingleton(opt);
                services.AddControllers();
                services.AddEndpointsApiExplorer();
                services.AddSwaggerGen();
                break;

            case ParserResultType.NotParsed:
                var notParsed = parseResult as NotParsed<CLIOptions>;
                Environment.Exit(-1);
                break;
        }
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CLIOptions cliOptions)
    {

        // Configure the HTTP request pipeline.
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
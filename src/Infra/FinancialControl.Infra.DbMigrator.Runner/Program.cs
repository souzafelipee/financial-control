using CommandLine;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace FinancialControl.Infra.DbMigrator.Runner;

public class Program
{
    static void Main(string[] args)
    {
        ExecuteMigrationConsole(args, typeof(Baseline).Assembly);
    }
    private static void ExecuteMigrationConsole(string[] args, Assembly migrationAssembly)
    {
        Parser.Default.ParseArguments<Options>(args)
            .WithParsed(o =>
            {
                var _serviceProvider = new ServiceCollection()
                    .AddFluentMigratorCore()
                    .Configure<AssemblySourceOptions>(x => x.AssemblyNames = new[] {migrationAssembly.GetName().Name})
                    .ConfigureRunner(rb => rb
                        .AddSqlServer()
                        .WithGlobalCommandTimeout(new TimeSpan(0,0, 30))
                        .WithGlobalConnectionString(o.ConnectionString)
                        .ScanIn(migrationAssembly).For.Migrations()
                        .ScanIn(typeof(MigrationZero).Assembly).For.Migrations()
                    )
                    .AddLogging(lb => lb.AddFluentMigratorConsole())
                    .Configure<FluentMigratorLoggerOptions>(options =>
                    {
                        options.ShowSql = true;
                        options.ShowElapsedTime = true;
                    })
                    .Configure<SelectingProcessorAccessorOptions>(opt => opt.ProcessorId = "SqlServer")
                    .BuildServiceProvider(false);

                using var scope = _serviceProvider.CreateScope();
                var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
                
                runner.MigrateUp();
            });

    }
}    
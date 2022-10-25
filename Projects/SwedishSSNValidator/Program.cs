using Microsoft.Extensions.DependencyInjection;
using SwedishSSNValidator;
using SwedishSSNValidator.ValidityChecks;
using SwedishSSNValidator.ValidityChecks.Interfaces;

var serviceProvider = new ServiceCollection()
    .AddSingleton<ILuhnsChecksumValidityCheck, LuhnsChecksumValidityCheck>()
    .AddSingleton<IDateValidityCheck, DateValidityCheck>()
    .AddSingleton<ISammordningsNrDateValidityCheck, SammordningsNrDateValidityCheck>()
    .AddSingleton<ISammordningsNrValidityCheck, SammordningsNrValidityCheck>()
    .AddSingleton<IPersonNrValidityCheck, PersonNrValidityCheck>()
    .AddSingleton<IOrgNrValidityCheck, OrgNrValidityCheck>()
    .AddSingleton<Runner>()
    .BuildServiceProvider();

var runner = serviceProvider.GetRequiredService<Runner>();
runner.Run();

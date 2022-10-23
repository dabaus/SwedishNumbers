using Microsoft.Extensions.DependencyInjection;
using SwedishSSNValidator.ValidityChecks;
using SwedishSSNValidator;

var serviceProvider = new ServiceCollection()
    .AddSingleton<ILuhnsChecksumValidityCheck, LuhnsChecksumValidityCheck>()
    .AddSingleton<IDateValidityCheck, DateValidityCheck>()
    .AddSingleton<ISammordningsNrDateValidityCheck, SammordningsNrDateValidityCheck>()
    .AddSingleton<ISammordningsNrValidityCheck, SammordningsNrValidityCheck>()
    .AddSingleton<IPersonnummerValidityCheck, PersonNrValidityCheck>()
    .AddSingleton<IOrgNrValidityCheck, OrgNrValidityCheck>()
    .AddSingleton<Runner>()
    .BuildServiceProvider();

var runner = serviceProvider.GetRequiredService<Runner>();
runner.Run();

using Explorer.BuildingBlocks.Infrastructure.Database;
using MedicalEquipmentCompany.Authentication;
using MedicalEquipmentCompany.Data;
using MedicalEquipmentCompany.Mappers;
using MedicalEquipmentCompany.Model;
using MedicalEquipmentCompany.Repository;
using MedicalEquipmentCompany.Repository.Interface;
using MedicalEquipmentCompany.Service;
using MedicalEquipmentCompany.Service.Crud.Interface;
using MedicalEquipmentCompany.Service.Interface;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;

namespace Explorer.Tours.Infrastructure;

public static class AppStartup
{
    public static IServiceCollection ConfigureModule(this IServiceCollection services)
    {
        // Registers all profiles since it works on the assembly
        services.AddAutoMapper(typeof(MapperProfile).Assembly);
        services.AddControllersWithViews();
        SetupCore(services);
        SetupInfrastructure(services);
        services.AddSwaggerGen();
        return services;
    }

    private static void SetupCore(IServiceCollection services)
    {

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<ITokenGenerator, JwtGenerator>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<ICompanyAdministratorProfileService, CompanyAdministratorProfileService>();
        services.AddScoped<IEquipmentService, EquipmentService>();
        services.AddScoped<IEquipmentPickupService, EquipmentPickupService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IEquipmentPickupService, EquipmentPickupService>();
        services.AddScoped<IEquipmentReservationService, EquipmentReservationService>();
        services.AddScoped<ICompanyWorkingHoursService, CompanyWorkingHoursService>();
    }

    private static void SetupInfrastructure(IServiceCollection services)
    {
        services.AddScoped(typeof(ICrudRepository<User>), typeof(CrudDatabaseRepository<User, ApplicationDbContext>));
        services.AddScoped<ICrudRepository<Account>, CrudDatabaseRepository<Account, ApplicationDbContext>>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICrudRepository<Person>, CrudDatabaseRepository<Person, ApplicationDbContext>>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<ICrudRepository<Company>, CrudDatabaseRepository<Company, ApplicationDbContext>>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();

        services.AddScoped<ICrudRepository<CompanyAdministratorProfile>, CrudDatabaseRepository<CompanyAdministratorProfile, ApplicationDbContext>>();
        services.AddScoped<ICompanyAdministratorProfileRepository, CompanyAdministratorProfileRepository>();

        services.AddScoped<ICrudRepository<Equipment>, CrudDatabaseRepository<Equipment, ApplicationDbContext>>();
        services.AddScoped<IEquipmentRepository, EquipmentRepository>();
        services.AddScoped<ICrudRepository<EquipmentPickup>, CrudDatabaseRepository<EquipmentPickup, ApplicationDbContext>>();
        services.AddScoped<IEquipmentPickupRepository, EquipmentPickupRepository>();
        services.AddScoped<ICrudRepository<EquipmentReservation>, CrudDatabaseRepository<EquipmentReservation, ApplicationDbContext>>();
        services.AddScoped<IEquipmentReservationRepository, EquipmentReservationRepository>();
        services.AddScoped<ICrudRepository<CompanyWorkingHours>, CrudDatabaseRepository<CompanyWorkingHours, ApplicationDbContext>>();
        services.AddScoped<ICompanyWorkingHoursRepository, CompanyWorkingHoursRepository>();
        services.AddSingleton<ConnectionFactory>(new ConnectionFactory
        {
            HostName = "localhost", // Set your RabbitMQ server details
        });

        // SignalR Hub Configuration
        services.AddSignalR();
        services.AddHostedService<MessageService>();
        // DbContext Configuration
        services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseNpgsql("MedicalEquipmentCompanyDb", x =>
                x.MigrationsHistoryTable("__EFMigrationsHistory", "public")));
    }
}
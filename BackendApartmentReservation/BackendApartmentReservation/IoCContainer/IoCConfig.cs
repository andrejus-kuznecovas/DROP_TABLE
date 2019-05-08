using Autofac;
using BackendApartmentReservation.Managers;

namespace BackendApartmentReservation.Infrastructure.Containers
{
    using Repositories.Checklist;

    using Repositories;

    public class IoCConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Managers
            builder.RegisterType<EmployeeManager>()
                .As<IEmployeeManager>();
            builder.RegisterType<ChecklistManager>()
                .As<IChecklistManager>();
            builder.RegisterType<OfficeManager>()
                .As<IOfficeManager>();
            builder.RegisterType<TripInformationManager>()
                .As<ITripInformationManager>();
            builder.RegisterType<GroupManager>()
                .As<IGroupManager>();
            builder.RegisterType<TripManager>()
                .As<ITripManager>();

            // Repositories
            builder.RegisterType<CarRentRepository>()
                .As<ICarRentRepository>();
            builder.RegisterType<FlightRepository>()
                .As<IFlightRepository>();
            builder.RegisterType<ChecklistRepository>()
                .As<IChecklistRepository>();
            builder.RegisterType<EmployeeRepository>()
                .As<IEmployeeRepository>();
            builder.RegisterType<LivingPlaceRepository>()
                .As<ILivingPlaceRepository>();
            builder.RegisterType<ApartmentRepository>()
                .As<IApartmentRepository>();
            builder.RegisterType<HotelRepository>()
                .As<IHotelRepository>();
            builder.RegisterType<OfficeRepository>()
                .As<IOfficeRepository>();
            builder.RegisterType<TripRepository>()
                .As<ITripRepository>();
            builder.RegisterType<GroupRepository>()
                .As<IGroupRepository>();
        }
    }
}
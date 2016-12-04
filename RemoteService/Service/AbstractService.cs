using AutoMapper;
using Data;
using DomainModel;
using DomainModel.DTO;
using MongoDB.Driver;

namespace Service
{
    public abstract class AbstractService
    { 
        protected IAmenityRepository<BathroomType> _bathroomTypeRepository;

        protected IAmenityRepository<BedType> _bedTypeRepository;

        protected IBedroomRepository _bedroomRepository;

        protected ICheckInRepository _checkInRepository;

        protected IGuestRepository _guestRepository;

        protected IUserRepository _userRepository;

        protected IMapper _mapper;

        private IMongoDatabase _db;

        public AbstractService()
        {
            _db = PersistenceFactory.GetDatabase();
            CreateRepositories();
            ConfigureMapper();
        }

        private void ConfigureMapper()
        {
            MapperConfiguration mapperConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<BathroomType, BathroomTypeDTO>();
                cfg.CreateMap<BathroomTypeDTO, BathroomType>()
                    .ConstructUsing(x => new BathroomType(_bathroomTypeRepository));
                cfg.CreateMap<BedType, BedTypeDTO>();
                cfg.CreateMap<BedTypeDTO, BedType>()
                    .ConstructUsing(x => new BedType(_bedTypeRepository));
                cfg.CreateMap<Bedroom, BedroomDTO>();
                cfg.CreateMap<BedroomDTO, Bedroom>()
                    .ConstructUsing(x => new Bedroom(_bedroomRepository, _bathroomTypeRepository, _bedTypeRepository));
                cfg.CreateMap<CheckIn, CheckInDTO>();
                cfg.CreateMap<CheckInDTO, CheckIn>()
                    .ConstructUsing(x => new CheckIn(
                        _checkInRepository, _guestRepository, _bedroomRepository, _bathroomTypeRepository, _bedTypeRepository));
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Guest, GuestDTO>();
                cfg.CreateMap<GuestDTO, Guest>()
                    .ConstructUsing(x => new Guest(_guestRepository));
            });

            _mapper = mapperConfig.CreateMapper();
        }

        private void CreateRepositories()
        {
            _bathroomTypeRepository = new BathroomTypeRepository(_db);
            _bedTypeRepository = new BedTypeRepository(_db);
            _bedroomRepository = new BedroomRepository(_db);
            _checkInRepository = new CheckInRepository(_db);
            _guestRepository = new GuestRepository(_db);
            _userRepository = new UserRepository(_db);
        }
    }
}
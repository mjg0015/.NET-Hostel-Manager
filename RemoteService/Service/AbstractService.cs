using AutoMapper;
using Data;
using DomainModel;
using DomainModel.DataContracts;
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
                cfg.CreateMap<BathroomType, BathroomTypeDto>();
                cfg.CreateMap<BathroomTypeDto, BathroomType>()
                    .ConstructUsing(x => new BathroomType(_bathroomTypeRepository));
                cfg.CreateMap<BedType, BedTypeDto>();
                cfg.CreateMap<BedTypeDto, BedType>()
                    .ConstructUsing(x => new BedType(_bedTypeRepository));
                cfg.CreateMap<Bedroom, BedroomDto>();
                cfg.CreateMap<BedroomDto, Bedroom>()
                    .ConstructUsing(x => new Bedroom(_bedroomRepository, _bathroomTypeRepository, _bedTypeRepository));
                cfg.CreateMap<CheckIn, CheckInDto>();
                cfg.CreateMap<CheckInDto, CheckIn>()
                    .ConstructUsing(x => new CheckIn(
                        _checkInRepository, _guestRepository, _bedroomRepository, _bathroomTypeRepository, _bedTypeRepository));
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<UserDto, User>().ConstructUsing(x => new User(_userRepository));
                cfg.CreateMap<Guest, GuestDto>();
                cfg.CreateMap<GuestDto, Guest>()
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
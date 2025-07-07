using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Domain.Interfaces;

namespace CarWorkshop.Application.Services
{
    public class CarWorkshopService : ICarWorkshopService
    {
        private readonly ICarworkshopRepository _carworkshopRepository;
        private readonly IMapper _mapper;

        public CarWorkshopService(ICarworkshopRepository carworkshopRepository, IMapper mapper)
        {
            _carworkshopRepository = carworkshopRepository;
            _mapper = mapper;
        }

        public async Task Create(CarWorkshopDto carWorkshopDto)
        {
            var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(carWorkshopDto);

            carWorkshop.EncodeName();

            await _carworkshopRepository.Create(carWorkshop);
        }
    }
}

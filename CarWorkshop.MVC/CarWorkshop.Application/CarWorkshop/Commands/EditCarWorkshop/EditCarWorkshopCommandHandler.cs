using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop
{
    public class EditCarWorkshopCommandHandler : IRequestHandler<EditCarWorkshopCommand>
    {
        private readonly ICarworkshopRepository _repository;

        public EditCarWorkshopCommandHandler(ICarworkshopRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(EditCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _repository.GetByEncodedName(request.Name!);

            carWorkshop.Description = request.Description;
            carWorkshop.About = request.About;

            carWorkshop.ContactDetails.City = request.ContactDetails.City;
            carWorkshop.ContactDetails.PhoneNumber = request.ContactDetails.PhoneNumber;
            carWorkshop.ContactDetails.PostalCode = request.ContactDetails.PostalCode;
            carWorkshop.ContactDetails.Street = request.ContactDetails.Street;

            await _repository.Commit();

            return Unit.Value;
        }
    }
}

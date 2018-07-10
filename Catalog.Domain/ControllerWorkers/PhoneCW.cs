using Catalog.Domain.DTO;
using Catalog.Infrastructure.DTO;
using Catalog.Infrastructure.DTO.Mappers;
using Catalog.Infrastructure.Factories;
using Catalog.Infrastructure.Models;
using Catalog.Infrastructure.Models.Catalog.Infrastructure.Models;
using Catalog.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalog.Domain.ControllerWorkers
{
    public class PhoneCW: IPhoneCW
    {
        private UnitOfWork<PhoneContext> Uow = new UnitOfWork<PhoneContext>(new PhoneContextFactory());
        private readonly IRepository<Phone> _phoneRepository;

        public PhoneCW()
        {
            _phoneRepository = Uow.GetRepository<Phone>();
        }

        public PhoneCW(IRepository<Phone> mockRepository)
        {
            _phoneRepository = mockRepository;
        }

        public List<PhoneDto> getAllPhones()
        {
            try
            {
                List<PhoneDto> result;

                result = _phoneRepository.FindAll().Select(x => DTOMapper.Phone_To_PhoneDto(x)).ToList();

                return result;
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        public PhoneDto getPhoneById(int id)
        {
            try
            {
                PhoneDto result = null;
                var data = _phoneRepository.FindById(id);
                if (data != null) { result = DTOMapper.Phone_To_PhoneDto(data); }
                return result;
            }
            catch (Exception ex)
            {           
                throw ex;
            }
        }

        public List<PhonePriceDto> getPricesByIds(List<int> ids)
        {
            try
            {
                List<PhonePriceDto> data = _phoneRepository.FindAll(x => ids.Any(y => y == x.Id))
                                                                 .Select(z => new PhonePriceDto { PhoneId= z.Id, PhonePrice= z.Price }).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

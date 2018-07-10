using Catalog.Domain.DTO;
using Catalog.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.ControllerWorkers
{
    public interface IPhoneCW 
    {
        List<PhoneDto> getAllPhones();

        PhoneDto getPhoneById(int id);

        List<PhonePriceDto> getPricesByIds(List<int> ids);
    }
}

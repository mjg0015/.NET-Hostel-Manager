using DomainModel.DTO;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Service
{
    [ServiceContract]
    public interface IAmenityService
    {
        [OperationContract]
        Task<IList<BedTypeDTO>> GetAllBedTypesAsync();

        [OperationContract]
        Task<IList<BathroomTypeDTO>> GetAllBathroomTypesAsync();

        [OperationContract]
        Task<bool> CreateBedTypeAsync(BedTypeDTO bedTypeDTO);

        [OperationContract]
        Task<bool> CreateBathroomTypeAsync(BathroomTypeDTO bathroomTypeDTO);
    }
}

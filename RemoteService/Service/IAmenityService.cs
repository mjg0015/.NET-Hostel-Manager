using DomainModel.DataContracts;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Service
{
    [ServiceContract]
    public interface IAmenityService
    {
        [OperationContract]
        Task<IList<BedTypeDto>> GetAllBedTypesAsync();

        [OperationContract]
        Task<IList<BathroomTypeDto>> GetAllBathroomTypesAsync();

        [OperationContract]
        Task<bool> CreateBedTypeAsync(BedTypeDto bedTypeDto);

        [OperationContract]
        Task<bool> CreateBathroomTypeAsync(BathroomTypeDto bathroomTypeDto);
    }
}

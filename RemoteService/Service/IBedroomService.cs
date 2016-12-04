using DomainModel.DTO;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Service
{
    [ServiceContract]
    public interface IBedroomService
    {
        [OperationContract]
        Task<IList<BedroomDTO>> GetAllAsync();

        [OperationContract]
        Task<IList<BedroomDTO>> GetAvailableAsync();

        [OperationContract]
        Task<bool> CreateOrUpdateAsync(BedroomDTO bedroomDTO);

        [OperationContract]
        Task<bool> RemoveAsync(BedroomDTO bedroomDTO);
    }
}

using DomainModel.DataContracts;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Service
{
    [ServiceContract]
    public interface IBedroomService
    {
        [OperationContract]
        Task<IList<BedroomDto>> GetAllAsync();

        [OperationContract]
        Task<IList<BedroomDto>> GetAvailableAsync();

        [OperationContract]
        Task<bool> CreateOrUpdateAsync(BedroomDto bedroomDto);

        [OperationContract]
        Task<bool> RemoveAsync(BedroomDto bedroomDto);
    }
}

using Workplace.Shared;

namespace Workplace.Client.Data
{
    public interface IDataService
    {
        Task<IEnumerable<TaskItemDTO>> GetAllAsync();
        Task UpdateAsync(TaskItemDTO dto);
        Task DeleteAsync(int Id);
        Task<TaskItemDTO> GetTaskItemAsync(int Id);
    }
}

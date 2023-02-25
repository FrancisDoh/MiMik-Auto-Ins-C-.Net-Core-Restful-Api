using MiMik_Auto_Ins_RestfulApi.Models.Domain;
using System.Drawing;

namespace MiMik_Auto_Ins_RestfulApi.Repositories
{
    public interface IPolicy
    {
       // Task<IEnumerable<Policy>> GetAllAsync(); // Get all 
       // Task<Policy> GetAsync(int policyID); // Get a single one based on its {id}
        Task<Policy> AddAsync(Policy policy); // Add a new 
       // Task<Policy> DeleteAsync(int policyID); // Delete a single
       // Task<Policy> UpdateAsync(int policyID, Policy policy);// Update a single
    }
}

using Shapping.DTO.Branch;
using Shapping.Model;

namespace Shapping.Reprostary
{
    public interface IBranchesRepository
    {
        Branches GetBracheById(int branchesId);

        //decimal GetCostFromBranchToCity(int branchId, int cityId);
        List<Branches> GetBranches();
        void AddBranches (AddBranchDto branches);
        void UpdateBranches (UpdateBranchDto branches);
        void DeleteBranches (int id);
        public void ChangeStatusBranch(int id);
        void SaveChages();


    }
}

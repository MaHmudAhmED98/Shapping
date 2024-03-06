using Shapping.DTO.Branch;

namespace Shapping.Handler.BranchesHandler
{
    public interface IBranchesHandler
    {
        List<getBranchByIdDto> GetBranches();
        void CreateBranchAsync(AddBranchDto branchDto);
        void UpdateBranchAsync(UpdateBranchDto branchDto);
        void DeleteBranchAsync(int id);
        void ChangeStatusBranchAsync(int id);
        public getBranchByIdDto GetBranchById(int id);
    }
}

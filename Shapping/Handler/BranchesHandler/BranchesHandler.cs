using Shapping.DTO.Branch;
using Shapping.Model;
using Shapping.Reprostary;

namespace Shapping.Handler.BranchesHandler
{
    public class BranchesHandler :IBranchesHandler
    {
        private readonly IBranchesRepository repository;

        public BranchesHandler(IBranchesRepository repository) 
        {
            this.repository = repository;
        }


        public void ChangeStatusBranchAsync(int id)
        {
            repository.ChangeStatusBranch(id);
            repository.SaveChages();
        }

        public void CreateBranchAsync(AddBranchDto branchDto)
        {
            if (branchDto == null)
            {
                throw new ExceptionLogic("Empty");
            }
            repository.AddBranches(branchDto);
            repository.SaveChages();

        }

        public void DeleteBranchAsync(int id)
        {
            repository.DeleteBranches(id);
            repository.SaveChages();
        }

        public List<getBranchByIdDto> GetBranches()
        {
            var branches= repository.GetBranches();
            List<getBranchByIdDto> result= new List<getBranchByIdDto>();
            foreach (var branch in branches)
            {
                result.Add(new getBranchByIdDto
                {
                    Name = branch.Name,
                    status = branch.status,
                    DateTime = branch.DateTime,
                    isDeleted = branch.isDeleted,
                });
            }
            return result;
        }
        public getBranchByIdDto GetBranchById(int id)
        {
            var branche = repository.GetBracheById(id);
            return new getBranchByIdDto { Name = branche.Name, status = branche.status, DateTime = branche.DateTime };
        }

        public void UpdateBranchAsync(UpdateBranchDto branchDto)
        {
            if(branchDto == null)
                throw new ExceptionLogic("Empty");
            repository.UpdateBranches(branchDto);
            repository.SaveChages();
        }
    }
}

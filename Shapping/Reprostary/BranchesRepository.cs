using Microsoft.EntityFrameworkCore;
using Shapping.DTO.Branch;
using Shapping.Model;

namespace Shapping.Reprostary
{
    public class BranchesRepository : IBranchesRepository
    {
        private readonly ShapingContext context;

        public BranchesRepository(ShapingContext context) {
            this.context = context;
        }

        public void AddBranches(AddBranchDto branches)
        {
            context.Branches.Add(new Branches { Name = branches.Name });
        }

        public void ChangeStatusBranch(int id)
        {
            var branch = GetBracheById(id);
            branch.status = false;
            context.Update(branch);
        }

        public void DeleteBranches(int id)
        {
            var branch = GetBracheById(id);
            branch.isDeleted = true;
            context.Update(branch);
        }

        public Branches GetBracheById(int branchesId)
        {
            return context.Branches.FirstOrDefault(b => b.Id == branchesId);
        }

        public List<Branches> GetBranches()
        {
            return context.Branches.ToList();
        }

        public void SaveChages()
        {
            context.SaveChanges();
        }

        public void UpdateBranches(UpdateBranchDto branches)
        {
            var branch = GetBracheById(branches.Id);
            branch.Name = branches.Name;

            context.Update(branch);
        }

        //public decimal GetCostFromBranchToCity(int branchId, int cityId)
        //{
        //    //var orderCost = context
        //    //    .costOrders
        //    //    .Where(o => o.FromCountryId == branchId && o.ToCityId == cityId)
        //    //    .FirstOrDefault();
        //    if (orderCost is null)
        //    {
        //        // can not null, should added all confguration from branches to citys in db
        //        return 0;
        //    }

        //    return orderCost.Price;
        //}
    }
}

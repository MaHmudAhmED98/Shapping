using System.ComponentModel.DataAnnotations.Schema;

namespace Shapping.Model
{
    public enum Status
    {
        New,
        Pending,
        RepresentitiveDelivered,
        ClientDelivered,
        UnReachable,
        Postponed,
        PartiallyDelivered,
        ClientCanceled,
        RejectWithPaying,
        RejectWithPartialPaying,
        RejectFromEmployee,
    }
    public enum TypeOfDelevery
    {
        NormalDelvery =1,
        FastDelvery=2,
        DelveryOfSomeDays =3,
    }
    public enum TypeOfPaying
    {
        PreDelvery=1,
        AfterDelvery=2
    }
    public enum OrderType
    {
        ReceiveFromTheBranch=1,
        ReceiveFromTheTrader=2

    }
    public class Order
    {
        public int Id { get; set; }
        public string? ClientName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public double Price { get; set; }
        public Status status { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }

        public string? Notes { get; set; }

        public bool isDeleted { get; set; } = false;
        public double OrderShippingTotalCost { get; set; }
        public double Weight { get; set; }
        public OrderType orderType { get; set; }
        public TypeOfDelevery typeOfDelevery { get; set; }
        public TypeOfPaying typeOfPaying { get; set; }
        public virtual List<Product> Products { get; set; } = new List<Product>();
        [ForeignKey("Governorate")]
        public int GovernorateId { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }
        public virtual Governorate? Governorate { get; set; }
        public virtual City? City { get; set; }
        [ForeignKey("Branches")]
        public int BrancheId { get;set; }
        public Branches? Branches { get; set; }
        [ForeignKey("Merchant")]
        public int MerchantId { get; set; }
        [ForeignKey("Representative")]
        public int? RepresentativeId { get; set; }
        public virtual Representative? Representative { get; set; }
        public virtual Marchant? Merchant { get; set; }
    }
}

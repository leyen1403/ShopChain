namespace ShopChain.Core.Entities
{
    public class Store
    {
        public int StoreID { get; set; }

        public string StoreCode { get; set; } = null!;

        public string StoreName { get; set; } = null!;

        public string StoreAddress { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string TaxID { get; set; } = null!;

        public string LegalRepresentative { get; set; } = null!;

        public string ManagerName { get; set; } = null!;

        public DateTime? OpenDate { get; set; }

        public DateTime? CloseDate { get; set; }

        public string ActiveStatus { get; set; } = null!;

        public string LogoUrl { get; set; } = null!;

        public string Note { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

        public string UpdatedBy { get; set; } = null!;
    }
}

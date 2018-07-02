using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class Company
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required(AllowEmptyStrings = false)]
        public string ExternalId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string TradingName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public int CompanyType { get; set; }

        public bool Unused { get; set; }

        public bool IsForwarder { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        public int? AddressId { get; set; }

        public int? MailAddressId { get; set; }

        public bool IsCustomClarance { get; set; }

        public bool IsActive { get; set; }

        public bool IsCarrier { get; set; }

        public bool IsWarehouse { get; set; }

        public string ChamberOfCommerce { get; set; }

        public string ChamberOfCommerceCi { get; set; }

        public string CountryVAT { get; set; }

        public bool IsExchangeBroker { get; set; }
    }
}

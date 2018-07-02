using System.ComponentModel.DataAnnotations;

namespace Data.ViewModel
{
    public class CompanyViewModel
    {
        public string ExternalId { get; set; }
        
        public string TradingName { get; set; }
        
        public int CompanyType { get; set; }

        public bool IsWarehouse { get; set; }

        public bool IsForwarder { get; set; }
        
        public string Phone { get; set; }
        
        public string Fax { get; set; }
    }
}

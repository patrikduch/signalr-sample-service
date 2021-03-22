using System.ComponentModel.DataAnnotations;

namespace SignalRSampleService.Models
{
    public class CompanyModel
    {
        [Key]
        public int CompanyId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

    }
}

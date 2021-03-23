using System;

namespace SignalRSampleService.Models
{
    public class CompanyModel
    {
        public CompanyModel()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }
    }
}

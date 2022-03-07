namespace chaptertestesunitarios.business.Customer.Models.Request
{
    public class CustomerPostRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string LegalId { get; set; }


        public static explicit operator infraestructure.Models.Customer(CustomerPostRequest v)
        {
            return new infraestructure.Models.Customer
            {
                Id = v.Id,
                Name = v.Name,
                LastName = v.LastName,
                LegalId = v.LegalId,
            };
        }
    }
}

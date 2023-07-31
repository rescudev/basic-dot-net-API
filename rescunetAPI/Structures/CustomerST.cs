using rescunetAPI.Models.DTO;

namespace rescunetAPI.Structures
{
    public static class CustomerST
    {
        public static List<CustomerDTO> customers = new List<CustomerDTO>
            {
                new CustomerDTO{ IdCustomer=1, UserName="testuser1", Balance=0},
                new CustomerDTO{ IdCustomer=2, UserName="testuser2", Balance=25}
            };
    }
}

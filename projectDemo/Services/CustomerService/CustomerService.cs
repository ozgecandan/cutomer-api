namespace projectDemo.Services.CustomerService
{

    //methodların hepsini bir kere implement ediyoruz
    public class CustomerService : ICustomerService
    {
        private static List<Customer> Customers = new List<Customer> {
                new Customer
                {
                    Id = 1,
                    FirstName = "Şükran",
                    LastName = "Ongun",
                    EmailAddress = "sukran@gmail.com",
                    MobilePhone = "555222333",
                    Password = "abc123"
                },

                  new Customer
                {
                    Id = 2,
                    FirstName = "Nasibe",
                    LastName = "Aktaş",
                    EmailAddress = "nasibe@gmail.com",
                    MobilePhone = "222444666",
                    Password = "abcd1234"
                }


            };
        public List<Customer> AddCustomer(Customer singleCustomer)
        {
            Customers.Add(singleCustomer);
            return (Customers);
        }

        public List<Customer>? DeleteCustomer(int id)
        {
            var singleCustomer = Customers.Find(x => x.Id == id);
            if (singleCustomer is null)
                return null;

            Customers.Remove(singleCustomer);

            return Customers;
        }

        public List<Customer> GetAllCustomers()
        {
            return Customers;
        }

        public Customer? GetSingleCustomer(int id)
        {
            var singleCustomer = Customers.Find(x => x.Id == id);
            if (singleCustomer is null)
                return null;
            return singleCustomer;
        }

        public List<Customer>? UpdateCustomer(int id, Customer request)
        {
            var singleCustomer = Customers.Find(x => x.Id == id);
            if (singleCustomer is null)
                return null;

            singleCustomer.FirstName = request.FirstName;
            singleCustomer.LastName = request.LastName;
            singleCustomer.EmailAddress = request.EmailAddress;
            singleCustomer.MobilePhone = request.MobilePhone;
            singleCustomer.Password = request.Password;

            return Customers;
        }
    }
}

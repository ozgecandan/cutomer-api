using Microsoft.AspNetCore.Mvc;

namespace projectDemo.Services.CustomerService
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();

        Customer? GetSingleCustomer(int id);

        List<Customer> AddCustomer(Customer singleCustomer);

        List<Customer>? UpdateCustomer(int id, Customer request);


        List<Customer>? DeleteCustomer(int id);


    }
}

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace vue_dotnet_example.Models
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerModel> GetAll();
        
        CustomerModel Add(CustomerModel customer);

        CustomerModel Modify(CustomerModel nameFirst);


        IEnumerable<CustomerModel> DeleteAll();



        CustomerModel DeleteOne(CustomerModel firstname);

    }
}
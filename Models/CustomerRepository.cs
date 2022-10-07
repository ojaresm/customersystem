using System;
using System.Collections.Generic;
using System.Text.Json;

namespace vue_dotnet_example.Models
{
    public class CustomerRepository: ICustomerRepository
    {
        private List<CustomerModel> customers = new List<CustomerModel>();
        private int _nextId = 1;

        private CustomerModel modelToRetrun;

        private int IdOfModified = -1;

        public CustomerRepository()
        {
            Add(new CustomerModel { firstName= "Bob", lastName="Smith", email="bobsmith@gmail.com",phone="123456",location="Usa",customertype="Normal",numberofprojects="1",previousfirstname=""});
            Add(new CustomerModel { firstName= "Alice", lastName="Green", email="alicegreen@yahoo.com",phone="56789",location="Sweden",customertype="Normal",numberofprojects="2",previousfirstname=""});
            Add(new CustomerModel { firstName= "John", lastName="Doe", email="jd@gmail.com",phone="050 1010101",location="Poland",customertype="Premium",numberofprojects="3",previousfirstname=""});
        }

        public IEnumerable<CustomerModel> GetAll()
        {
            return customers;
        }


        public IEnumerable<CustomerModel> DeleteAll()
        {
            customers.Clear();
            
            return customers;
        }


        public CustomerModel DeleteOne(CustomerModel firstname) {
            int index =0;
            foreach (CustomerModel modelInstance in customers)
            {
                if (modelInstance.firstName == firstname.firstName) {
                    customers.RemoveAt(index);
                    modelInstance.lastName = firstname.firstName;
                    modelToRetrun = modelInstance;
                    break;
                }
                index++;
                
            }
            index =0;
            return modelToRetrun;
        }

        public CustomerModel Add(CustomerModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            customers.Add(item);
            return item;
        }


        





        public CustomerModel Modify(CustomerModel model) {
            int i = 0;
            foreach (CustomerModel modelInstance in customers)
            {
                i++;
                if (modelInstance.firstName == model.previousfirstname || modelInstance.firstName == model.firstName) {

                    modelInstance.firstName = model.firstName;
                    modelInstance.lastName = model.lastName;
                    modelInstance.email = model.email;
                    modelInstance.phone = model.phone;
                    modelInstance.location = model.location;
                    modelInstance.customertype = model.customertype;
                    modelInstance.numberofprojects = model.numberofprojects;
                    modelToRetrun = modelInstance;
                    
                }
            }
            return modelToRetrun;
        }
    }
}
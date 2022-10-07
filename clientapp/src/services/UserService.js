export async function getAllCustomers() {

  const response = await fetch('/api/customers');
  return await response.json();
}

export async function createCustomer(data) {


  const response = await fetch(`/api/customer`, {
      method: 'POST',
      headers: {'Content-Type': 'application/json'},
      body: JSON.stringify(data)
    })
  return await response.json();
}



export async function deleteCustomers() {
  


  const response = await fetch(`/api/deletecustomers`);
  return await response.json();
}




export async function deleteSingleCustomer(data) {
  

  
  const response = await fetch(`/api/deletecustomer`, {
    method: 'POST',
    headers: {'Content-Type': 'application/json'},


    body: JSON.stringify(data)
      
    })
  
  //return await JSON.parse(JSON.stringify(response));
  return await response.json()
}



export async function modifyCustomer(data) {
  

  
  const response = await fetch(`/api/modifycustomer`, {
    method: 'POST',
    headers: {'Content-Type': 'application/json'},

    body: JSON.stringify(data)
      
    })
  return await response.json();
}





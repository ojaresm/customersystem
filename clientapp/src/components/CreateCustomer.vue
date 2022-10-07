<template>
  <div class="container createCustomer">
    <div class="row">
        <div class="col-md-7 mrgnbtm">
        <h2>New Customer</h2>
        <br>
        <br>
            <form>
                <div class="row">
                    <div class="form-group col-md-6">
                        <label htmlFor="exampleInputEmail1">First Name</label>
                        <input type="text" class="form-control" v-model="firstName" name="firstname" id="firstname" aria-describedby="emailHelp" placeholder="First Name" />
                    </div>
                    <div class="form-group col-md-6">
                        <label htmlFor="exampleInputPassword1">Last Name</label>
                        <input type="text" class="form-control" v-model="lastName" name="lastname" id="lastname" placeholder="Last Name" />
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-md-12">
                        <label htmlFor="exampleInputEmail1">Email</label>
                        <input type="text" class="form-control" v-model="email" name="email" id="email" aria-describedby="emailHelp" placeholder="Email" />
                    </div>
                    <div class="form-group col-md-12">
                        <label htmlFor="exampleInputNumber">Phone</label>
                        <input type="text" class="form-control" v-model="phone" name="phone" id="phone" aria-describedby="emailHelp" placeholder="+358 123456" />
                    </div>
                    <div class="form-group col-md-12">
                        <label htmlFor="exampleInputNumber">Location</label>
                        <input type="text" class="form-control" v-model="location" name="location" id="location" aria-describedby="emailHelp" placeholder="Location" />
                    </div>
                    
                   
                    <div class="form-group col-md-12">
                        <label htmlFor="exampleInputNumber">Customer type</label>
                        <br/>
                        <select v-model = "customertype" class="form-control" name="customertype" id="customertype" aria-describedby="emailHelp" >

                            <option disabled value = "">Please select one</option>
                            <option>Normal</option>
                            <option>Premium</option>
                            <option>Owner</option>
                            
                        </select>
                    </div>
                    <div class="form-group col-md-12">
                        <label htmlFor="exampleInputNumber">Number of projects</label>
                        <input type="number" class="form-control" v-model="numberofprojects" placeholder=1 aria-describedby="emailHelp" id="numberofprojects" name="numberofprojects" min="1" max="5" />
                    </div>
                    

                </div>
                <button type="button" @click='createUser()' class="btn btn-danger">Add</button>
            </form>
        </div>
    </div>
    </div>
</template>

<script>
export default {
  name: 'CreateUser',
  data() {
    return {
      firstName: '',
      lastName: '',
      email: '',
      phone: '',
      location: '',
      customertype: '',
      numberofprojects: 1,
      
    }
  },
  methods: {
      createUser() {
          if (this.CheckForm()) {
            const payload = {
              firstName: this.firstName,
              lastName: this.lastName,
              email: this.email,
              phone:this.phone,
              location:this.location,
              customertype:this.customertype,
              numberofprojects:this.numberofprojects.toString()
          }
          this.$emit('createUser', payload)
          this.clearForm();
          }
          
      },
      clearForm() {
          this.firstName = "";
          this.lastName = "";
          this.email = "";
          this.phone='';
          this.location='';
          this.customertype='';
          this.numberofprojects='';
      },
      CheckForm() {
        if (this.firstName=='' ||this.lastName=='' ||this.email=='' ||this.phone=='' ||this.location=='' ||this.customertype=='' ) {
            return false
        }
        return true
      }
  }
}
</script>
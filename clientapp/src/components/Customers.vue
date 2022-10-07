<template>
    <div class="customers container">
        <h2>Customers</h2>
        <table class="table table-bordered">
            <thead>
            <tr>
                <th>Customer Id</th>
                <th v-if="ShowAll">Firstname</th>
                <th v-if="ShowAll">Lastname</th>
                <th v-if="ShowAll">Email</th>
                <th v-if="ShowAll">Phone</th>
                <th v-if="(Showlocations == true && ShowCustomerTypes == false && ShowNumberOfProjects==false) || ShowAll">Location</th>
                <th v-if="(ShowCustomerTypes== true &&Showlocations == false && ShowNumberOfProjects==false) || ShowAll">Customer type</th>
                <th v-if="(ShowNumberOfProjects== true && Showlocations == false && ShowCustomerTypes==false) || ShowAll"># of projects in</th>
                <th v-if="ShowAll">OPTIONS</th>

            </tr>
            </thead>
            <tbody>
              <tr v-for="(item, index) in users" :key="index">
                  <td>{{ index + 1 }}</td>
                  <td v-if="ShowAll &&IndexOfModifiedRow!=index" >{{ item.firstName }}</td>
                  <td v-if="IsModifying &&IndexOfModifiedRow==index">
                    <input type="text" class="form-control" v-model="this.firstName" name="firstname" id="firstname" aria-describedby="emailHelp" placeholder="First name" />
                  </td>


                  <td v-if="ShowAll &&IndexOfModifiedRow!=index">{{ item.lastName }}</td>
                  <td v-if="IsModifying&&IndexOfModifiedRow==index">
                    <input  type="text" class="form-control" v-model="this.lastName"  name="lastname" id="lastname" placeholder="Last name" />
                  </td>

                  


                  <td v-if="ShowAll &&IndexOfModifiedRow!=index">{{ item.email }}</td>
                  <td v-if="IsModifying&&IndexOfModifiedRow==index">
                    <input type="text" class="form-control" v-model="this.email" name="email" id="email" aria-describedby="emailHelp" placeholder="Email" />
                  </td>



                  <td v-if="ShowAll &&IndexOfModifiedRow!=index">{{ item.phone }}</td>
                  <td v-if="IsModifying&&IndexOfModifiedRow==index">
                    <input type="text" class="form-control" v-model="this.phone" name="phone" id="phone" aria-describedby="emailHelp" placeholder="+358 123456" />
                  </td>



                  <td v-if="(ShowCustomerTypes== false &&Showlocations == true && ShowNumberOfProjects==false) ||ShowAll &&IndexOfModifiedRow!=index">{{ item.location }}</td>
                  <td v-if="IsModifying&&IndexOfModifiedRow==index">
                    <input type="text" class="form-control" v-model="this.location" name="location" id="location" aria-describedby="emailHelp" placeholder="Location" />
                  </td>



                  <td v-if="(ShowCustomerTypes== true &&Showlocations == false && ShowNumberOfProjects==false) ||ShowAll &&IndexOfModifiedRow!=index">{{ item.customertype }}</td>
                  <td v-if="IsModifying&&IndexOfModifiedRow==index">
                    <select v-model = "this.customertype" class="form-control" name="customertype" id="customertype" aria-describedby="emailHelp" >

                        <option disabled value = "">Please select one</option>
                        <option>Normal</option>
                        <option>Premium</option>
                        <option>Owner</option>

                    </select>           
                    </td>



                  <td v-if="(ShowNumberOfProjects== true && Showlocations == false && ShowCustomerTypes==false) ||ShowAll &&IndexOfModifiedRow!=index">{{ item.numberofprojects }}</td>
                  <td v-if="IsModifying&&IndexOfModifiedRow==index">
                    <input type="number" class="form-control" v-model="this.numberofprojects" placeholder=1 aria-describedby="emailHelp" id="numberofprojects" name="numberofprojects" min="1" max="5" />
                  </td>



                  <td v-if="!IsModifying &&ShowAll">
                    <button @click='StartModifying(index)' class="btn btn-warning" type="button" >modify</button>
                    <button class="btn btn-warning" style="margin-top: 20px; margin-bottom: 20px;margin-left: 5px;" @click='DeleteCustomer(item.firstName)' type="button" >delete</button>


                  </td>
                  <td v-if="IsModifying&&IndexOfModifiedRow==index">
                    <button @click='ModifyUser()' type="button" class="btn btn-warning" >apply</button>


                  </td>
                  


              </tr>
            </tbody>
        </table>
    </div>
</template>

<script>

    export default {
        name: 'Customers',
        props: {
            users : {
                type: Array
            },
            ShowAll : {
                type: Boolean,
                default:true
            },
            Showlocations : {
                type: Boolean,
                default:false
            },
            ShowCustomerTypes : {
                type: Boolean,
                default:false
            },
            ShowNumberOfProjects : {
                type: Boolean,
                default:false
            },
            IsModifying : {
                type: Boolean,
                default:true
            },
            IndexOfModifiedRow : {
                type: Number,
                default:-1
            }
        },


        methods: {
            StartModifying(index) {

                
                this.PreviousFirstName = this.firstName
                
                for (let i = 0; i < this.users.length; i++) {
                        if (index==this.users[i].id-1) {
                            this.PreviousFirstName = this.users[i].firstName
                        }
                }

                this.$emit('StartingModified',index)

            },
            ModifyUser() {

                
                if (this.CheckForm()) {
                    const payload = {
                    index:    this.IndexOfModifiedRow,
                    firstName: this.firstName,
                    lastName: this.lastName,
                    email: this.email,
                    phone:this.phone,
                    location:this.location,
                    customertype:this.customertype,
                    numberofprojects:this.numberofprojects.toString(),
                    previousfirstname:this.PreviousFirstName
                }
                this.$emit('UsersModified',payload)
                }
                
            },

            DeleteCustomer(firstnamefromuser) {


                const payload = {
                    index:    this.IndexOfModifiedRow,
                    firstName: firstnamefromuser.toString(),
                    lastName: this.lastName,
                    email: this.email,
                    phone:this.phone,
                    location:this.location,
                    customertype:this.customertype,
                    numberofprojects:this.numberofprojects.toString(),
                    previousfirstname:this.PreviousFirstName
                }

                this.$emit('UserDeleted',payload)

            },
            CheckForm() {
                if (this.firstName=='' ||this.lastName=='' ||this.email=='' ||this.phone=='' ||this.location=='' ||this.customertype=='' ) {
                    
                    return false
                }
                 return true
      }
            
            
        },


        data() {
            return {
                numberOfUsers: 0,

                id:0,
                firstName: '',
                lastName: '',
                email: '',
                phone: '',
                location: '',
                customertype: '',
                numberofprojects: 1,

                PreviousFirstName:'',
                
                


                
                
        }
  },
     }
</script>
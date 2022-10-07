<template>
  <div class="hello" >
    <Header />
    <div class="container mrgnbtm">
          <div class="row">
            <div class="col-md-8">
                <CreateUser v-if="showusers==false" @createUser="userCreate($event)" />
            </div>
            
           <div class="col-md-4">
                <DisplayBoard v-if="showusers==false" :numberOfUsers="numberOfUsers" @getAllUsers="getUsers(), SwitchView(),HideTotalCustomers()" @deleteAllUsers="DeleteUsers()" />
            </div>
          </div>
    </div>
    <div class="row mrgnbtm">
        <SelectOptions v-if="showusers &&users.length>0" :showlocations="showlocations" :Ismodifying="IsModifyingBool" @getAllUsers="ChangeToShowAll()" @Locations="ChangeToLocations()" @CustomerTypes="ChangeToCustomerTypes()" @NumberOfProjects="ChangeToNumberOfProjects()" />

    </div>
    <div class="row mrgnbtm">
        <Users v-if="showusers " :users="users" :ShowAll="showall" :Showlocations="showlocations" :ShowCustomerTypes="showcustomertypes" :ShowNumberOfProjects="shownumberofprojects" @UsersModified="Modify($event)" @StartingModified="StartModifying($event)" @UserDeleted="DeleteSingleUser($event)" :IsModifying="IsModifyingBool" :IndexOfModifiedRow="IndexOfModified"/>

    </div>
    <div class="row mrgnbtm">
        <MoreUsers v-if="showusers && users.length>0" @switchview="SwitchView()" />

    </div>

    
    
    
  </div>
</template>

<script>
import Header from './Header.vue'
import CreateUser from './CreateCustomer.vue'
import DisplayBoard from './DisplayBoard.vue'
import Users from './Customers.vue'
import SelectOptions from './SelectOptions'
import MoreUsers from './MoreCustomers'
import { getAllCustomers, createCustomer, deleteCustomers,deleteSingleCustomer,modifyCustomer } from '../services/UserService'


export default {
  name: 'Dashboard',
  components: {
    Header,
    CreateUser,
    DisplayBoard,
    Users,
    SelectOptions,
    MoreUsers,
    //GoogleChart
  },
  data() {
      return {
          users: [],
          numberOfUsers: 0,
          showusers: false,
          createUsers:true,
          totalcustomers:true,
          showall:true,
          showlocations:false,
          showcustomertypes:false,
          shownumberofprojects:false,
          IsModifyingBool:false,
          IndexOfModified : -1
      }
  },
  methods: {
    
    ChangeToShowAll() {
        this.showall = true;
        this.showlocations = false;
        this.showcustomertypes = false;
        this.shownumberofprojects = false;
    },
    ChangeToLocations() {
        this.showall = false;
        this.showlocations = true;
        this.showcustomertypes = false;
        this.shownumberofprojects = false;
    },
    ChangeToCustomerTypes() {
        this.showall = false;
        this.showlocations = false;
        this.showcustomertypes = true;
        this.shownumberofprojects = false;
    },
    ChangeToNumberOfProjects() {
        this.showall = false;
        this.showlocations = false;
        this.showcustomertypes = false;
        this.shownumberofprojects = true;
    },
    SwitchView() {
      this.showusers = !this.showusers;
    },
    HideTotalCustomers() {
      this.totalcustomers = false;
    },
    getUsers() {
      getAllCustomers().then(res => {
        
        this.users = res;
        this.numberOfUsers = this.users.length
      });
    },
    userCreate(data) {
      createCustomer(data).then(res => {
        this.getUsers();
        console.log('res:::', res);
      });
    },
    DeleteUsers(data) {
      deleteCustomers(data).then(res => {
        this.users = res;
        this.numberOfUsers = this.users.length
        


      })
      
    },
    DeleteSingleUser(data) {

      deleteSingleCustomer(data).then(res => {
        console.log('res:::', res);
        this.getUsers();
        this.numberOfUsers = this.users.length
        if (this.numberOfUsers <= 1) {
          this.SwitchView();
        }


      })

    },
    Modify(data) {
      this.IndexOfModified = -1
      this.IsModifyingBool = false

      modifyCustomer(data).then(res => {
        this.getUsers();
        console.log('res:::', res);
      });
    },
    StartModifying(key) {
      this.IndexOfModified = key
      this.IsModifyingBool = true

    }
  },
  mounted () {
    this.getUsers();
  }
}
</script>
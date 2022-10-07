<template>
    <div v-if="!Ismodifying" class="container">
      <div class="row">
          <div class="col-md-7 mrgnbtm">
          <h2>Select view</h2>
          <button @click='getAllUsers()' type="button" class="btn btn-warning" >Show all info</button>
          <button @click='ShowLocations()' type="button" class="btn btn-warning" >Show locations</button>
          <button @click='ShowCustomerTypes()' type="button" class="btn btn-warning" >Show customer types</button>
          <button @click='ShowNumberOfProjects()' type="button" class="btn btn-warning" >Show number of projects</button>
          
          </div>
      </div>
      </div>
  </template>

<script>
    export default {
        name: 'SelectOptions',
        props: {

            Ismodifying : {
                type: Boolean,
                default:false
            }


        },
        methods: {
            getAllUsers() {
                this.$emit('getAllUsers')
            },
            
            ShowLocations() {
                this.$emit('Locations')
            },
            ShowCustomerTypes() {
                this.$emit('CustomerTypes')
            },
            ShowNumberOfProjects() {
                this.$emit('NumberOfProjects')
            }
        }
    }
</script>
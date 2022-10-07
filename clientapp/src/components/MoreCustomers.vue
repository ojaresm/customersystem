<template>
    <div class="container">
      <div class="row">
          <div class="col-md-7 mrgnbtm">
          
          <button @click='getAllUsers()' type="button" class="btn btn-warning">Add more customers</button>
          
          
          </div>
      </div>
      </div>
  </template>

<script>
    export default {
        name: 'MoreCustomers',
        
        methods: {
            getAllUsers() {
                this.$emit('switchview')
            }
        }
    }
</script>
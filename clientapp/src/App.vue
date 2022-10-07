<template>
  <div class="customerApp" :style="{backgroundImage:'url(https://purepng.com/public/uploads/large/canada-6tz.png)'}">
    <Dashboard />
    
  </div>
</template>

<script>
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'


import Dashboard from './components/Dashboard.vue'

export default {
  name: 'App',
  components: {
    Dashboard
    
  }
}
</script>

<style>
  @import './assets/styles/global.css';
</style>
<template>
    <div class="display-board">
        <h4>Customers in system</h4>
        <div class="number">
        {{numberOfUsers}}
        </div>
        <div class="row btn">
            <button style="margin-left: 0px;" v-if="numberOfUsers>0" @click='getAllUsers()' type="button" class="btn btn-warning">Get Customers</button>
            <button style="color: red;margin-left: 13px;" v-if="numberOfUsers>0" @click='DeleteAllUsers()' type="button" class="btn btn-warning">Delete All Customers</button>

        </div>
        
    </div>
</template>

<script>
    export default {
        name: 'DisplayBoard',
        props: ['numberOfUsers'],
        methods: {
            getAllUsers() {
                this.$emit('getAllUsers')
            },

            DeleteAllUsers() {
                this.$emit('deleteAllUsers')
            }
        }
    }
</script>
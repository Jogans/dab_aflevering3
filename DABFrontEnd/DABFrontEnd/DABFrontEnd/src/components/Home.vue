<template>
    <div class="home">
        <router-link to="/" class="btn_Register" tag="button">Home</router-link>

        <router-link to="/Register" class="btn_Register" tag="button">Login / Register</router-link>
        <!--<router-link to="/Login" class="btn_Register" tag="button">Login</router-link>-->
        <router-link to="/Data" class="btn_Register" tag="button">Values</router-link>
        <router-link to="/Comment" class="btn_Register" tag="button">Comments</router-link>
        <router-link to="/Post" class="btn_Register" tag="button">Posts</router-link>

    </div>
</template>

<script>
    export default {
        name: 'Home',
        data: function () {
            return {
                info: null,
                searchParameter: null
            }
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>


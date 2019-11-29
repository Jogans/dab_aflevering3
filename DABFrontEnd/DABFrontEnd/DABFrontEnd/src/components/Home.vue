<template>
    <div class="home">
        <h1>Choose from menu</h1>
        <router-link to="/" class="btn_Register" tag="button">Home</router-link>

        <router-link to="/Register" class="btn_Register" tag="button">Login / Register</router-link>
        <!--<router-link to="/Login" class="btn_Register" tag="button">Login</router-link>-->
        <router-link to="/Comment" class="btn_Register" tag="button">Comments</router-link>
        <router-link to="/Post" class="btn_Register" tag="button">Posts</router-link>
        <router-link to="/Feed" class="btn_Register" tag="button">Feed</router-link>
        <router-link to="/Wall" class="btn_Register" tag="button">Wall</router-link>
        <router-link to="/CircleConfig" class="btn_Register" tag="button">Circle Config</router-link>

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


<style scoped>
    button{
        font-size: 20px;
    }
</style>


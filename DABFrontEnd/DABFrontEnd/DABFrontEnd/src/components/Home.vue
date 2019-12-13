<template>
    <div class="home">
        <h1>Choose from menu</h1>
        <router-link to="/" class="btn_Register" tag="button">Home</router-link>

        <router-link to="/Register" class="btn_Register" tag="button">Login / Register</router-link>
        <router-link to="/Post" class="btn_Register" tag="button">Create post</router-link>
        <router-link to="/Feed" class="btn_Register" tag="button">Feed</router-link>
        <router-link to="/Wall" class="btn_Register" tag="button">Wall</router-link>
        <router-link to="/CircleConfig" class="btn_Register" tag="button">Circle Config</router-link>
        <router-link to="/BanList" class="btn_Register" tag="button">Ban List</router-link>
        <router-link to="/Subscribe" class="btn_Register" tag="button">Subscribe</router-link>

        <p> <strong> Welcome to our Social Site! In this header you can choose among the functions on the site</strong></p>
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
        margin: 5px;
    }
</style>


<template>
    <div class="home">
        <div class="SearchBar">
            <input style="height: 32px; width: 704px;" type="text" v-model="searchParameter" placeholder="Search..." required>
        </div>
        <button class="test_btn" @click="created">Test</button>
        <br />
        <br />
        <br />
        <router-link to="/" class="btn_Register" tag="button">Home</router-link>

        <router-link to="/Register" class="btn_Register" tag="button">Register</router-link>
        <router-link to="/Login" class="btn_Register" tag="button">Login</router-link>

        <br />
        <br />
        <br />
        <span v-html="info">{{info}}</span>
    </div>
</template>

<script>
    export default {
        name: 'Home',
        data: function () {
            return {
                test: 'Det virker',
                info: null,
                searchParameter: null
            }
        },
        methods: {
            created() {
                this.$http.get('https://localhost:44341/api/values?id=5', {
                    headers: {
                        'Access-Control-Allow-Origin': '*',
                    },
                }).then(response => (this.info = response.data))
            }
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>


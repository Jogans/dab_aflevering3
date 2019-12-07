<template>
    <div>
        

        <label for="email"><b>Name</b></label>
        <br />
        <input type="text" placeholder="Skriv navn" v-bind="searchParameter" required>
        <br />
        <button class="test_btn" @click="created">Login</button>
        <br />
        <br />
        <br />
        <span v-html="info">{{info}}</span>


    </div>
</template>

<script>
    export default {
        name: 'Login',
        data: function () {
            return {
                info: null,
                searchParameter: null
            }
        },
        methods: {
            created() {
                this.$http.get('https://localhost:44341/api/user?id=' + this.searchParameter, {
                    headers: {
                        'Access-Control-Allow-Origin': '*',
                    },
                }).then(response => (this.info = response.data))
            }
        }
    };
</script>

<style scoped>
</style>
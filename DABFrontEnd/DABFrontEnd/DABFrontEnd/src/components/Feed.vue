<template>

    <div class="container">
        <h1><b>Find Feed</b></h1>
        <input type="text" placeholder="Write your name" v-model="owwName" required>
        <br />
        <button class="test_btn" @click="getFeed">Find Feed</button>
        <br />
        <span v-html="info">{{info}}</span>
    </div>
</template>

<script>
    export default {
        name: 'Feed',
        data: function () {
            return {
                info: null,
                owwName: null
            }
        },
        methods: {
            getFeed() {
                this.$http.get('https://localhost:44341/api/wall?name=' + this.owwName, {
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
        input {
        margin: 5px;
        font-size: 18px;
    }

    button {
        font-size: 20px;
    }
</style>

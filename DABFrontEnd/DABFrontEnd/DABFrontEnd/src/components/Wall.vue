<template>
    <div>
        <h1><b>Find wall</b></h1>
        <input type="text" placeholder="Write your name" v-bind="owwName" required>
        <input type="text" placeholder="Write name of other user" v-bind="otherName" required>
        <br />
        <button class="test_btn" @click="getWall">Find wall</button>
        <br />
        <span v-html="info">{{info}}</span>
    </div>
</template>

<script>
    export default {
        name: 'Wall',
        data: function () {
            return {
                info: null,
                owwName: null,
                otherName: null,
            }
        },
        methods: {
            getWall() {
                this.$http.get('https://localhost:44341/api/user?id=' + this.owwName + '&id=' + this.otherName, {
                    headers: {
                        'Access-Control-Allow-Origin': '*',
                    },
                }).then(response => (this.info = response.data))
            }
        }
    };
</script>

<style scoped>
    input {
        margin: 5px;
        font-size: 18px;
    }

    button {
        font-size: 20px;
    }
</style>
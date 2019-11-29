<template>
    <div>
        <h1><b>Add user to circle</b></h1>
        <input type="text" placeholder="Write your name" v-model="owwName" required>
        <input type="text" placeholder="Write name of other user" v-model="otherName" required>
        <input type="text" placeholder="Write name of the circle" v-model="circleName" required>

        <br />
        <button class="test_btn" @click="getWall">Find wall</button>
        <br />
        <span v-html="info">{{info}}</span>
    </div>
</template>

<script>
    export default {
        name: 'CircleConfig',
        data: function () {
            return {
                info: null,
                owwName: null,
                otherName: null,
                circleName: null,
            }
        },
        methods: {
            getWall() {
                this.$http.get('https://localhost:44341/api/wall?Visitorname=' + this.owwName + '&HostName=' + this.otherName, {
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
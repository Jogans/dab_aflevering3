<template>
    <div>
        <h1><b>Add user to circle</b></h1>
        <input type="text" placeholder="Write your name" v-model="myName1" required>
        <input type="text" placeholder="Write name of other user" v-model="otherUserName1" required>
        <input type="text" placeholder="Write name of the circle" v-model="circleName1" required>
        <br />
        <button class="test_btn" @click="addToCircle">Add to circle</button>
        <br />
        <span v-html="info1">{{info1}}</span>
        <br />
        <h1><b>Remove from circle</b></h1>
        <input type="text" placeholder="Write your name" v-model="myName2" required>
        <input type="text" placeholder="Write name of other user" v-model="otherUserName2" required>
        <input type="text" placeholder="Write name of the circle" v-model="circleName2" required>
        <br />
        <button class="test_btn" @click="deleteFromCircle">Remove from circle</button>
        <br />
        <span v-html="info2">{{info2}}</span>
        <h1><b>Create circle</b></h1>
        <input type="text" placeholder="Write your name" v-model="myName3" required>
        <input type="text" placeholder="Name of the new circle" v-model="circleName3" required>
        <br />
        <button class="test_btn" @click="createToCircle">Create new circle</button>
        <br />
        <span v-html="info3">{{info3}}</span>
    </div>
</template>

<script>
    export default {
        name: 'CircleConfig',
        data: function () {
            return {
                info1: null,
                info2: null,
                info3: null,
                myName1: null,
                myName2: null,
                myName3: null,
                otherUserName1: null,
                otherUserName2: null,
                circleName1: null,
                circleName2: null,
                circleName3: null,
            }
        },
        methods: {
            addToCircle() {
                this.$http.get('https://localhost:44341/api/circle?myName=' + this.myName1 + '&otherUserName=' + this.otherUserName1 + '&circleName=' + this.circleName1, {
                    headers: {
                        'Access-Control-Allow-Origin': '*',
                    },
                }).then(response => (this.info1 = response.data))
            },
            deleteFromCircle() {
                this.$http.delete('https://localhost:44341/api/circle?myName=' + this.myName2 + '&otherUserName=' + this.otherUserName2 + '&circleName=' + this.circleName2, {
                    headers: {
                        'Access-Control-Allow-Origin': '*',
                    },
                }).then(response => (this.info2 = response.data))
            },
            createToCircle() {
                this.$http.post('https://localhost:44341/api/circle?myName=' + this.myName3 + '&circleName=' + this.circleName3, {
                    headers: {
                        'Access-Control-Allow-Origin': '*',
                    },
                }).then(response => (this.info3 = response.data))
            },
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
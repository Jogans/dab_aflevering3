<template>
    <div>
        <h1><b>Add user to ban list</b></h1>
        <input type="text" placeholder="Write your name" v-model="myName1" required>
        <input type="text" placeholder="Write name of other user" v-model="otherUserName1" required>
        <br />
        <button class="test_btn" @click="addToBanList">Add to ban list</button>
        <br />
        <span v-html="info1">{{info1}}</span>
        <br />
        <h1><b>Remove from ban list</b></h1>
        <input type="text" placeholder="Write your name" v-model="myName2" required>
        <input type="text" placeholder="Write name of other user" v-model="otherUserName2" required>
        <br />
        <button class="test_btn" @click="deleteFromBanList">Remove from ban list</button>
        <br />
        <span v-html="info2">{{info2}}</span>
    </div>
</template>

<script>
    export default {
        name: 'BanList',
        data: function () {
            return {
                info1: null,
                info2: null,
                myName1: null,
                otherUserName1: null,
                circleName1: null,
                myName2: null,
                otherUserName2: null,
                circleName2: null,
            }
        },
        methods: {
            addToBanList() {
                this.$http.get('https://localhost:44341/api/BanList?myName=' + this.myName1 + '&banName=' + this.otherUserName1, {
                    headers: {
                        'Access-Control-Allow-Origin': '*',
                    },
                }).then(response => (this.info1 = response.data))
            },
            deleteFromBanList() {
                this.$http.delete('https://localhost:44341/api/BanList?myName=' + this.myName2 + '&banName=' + this.otherUserName2, {
                    headers: {
                        'Access-Control-Allow-Origin': '*',
                    },
                }).then(response => (this.info2 = response.data))
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
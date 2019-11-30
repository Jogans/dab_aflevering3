<template>
    <div>
        <h1><b>Find wall</b></h1>
        <input type="text" placeholder="Write your name" v-model="owwName" required>
        <input type="text" placeholder="Write name of other user" v-model="otherName" required>
        <input type="text" placeholder="Write post id" v-model="postId" required>
        <input class="commentInput" type="text" placeholder="Write your Comment" v-model="comment" required>
        <button class='test_btn' @click='sendComment'>Comment on post</button>
        <br />
        <button class="test_btn" @click="getWall">Find wall</button>
        <br />
        <span v-html="info2">{{info2}}</span>
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
                info2: null,
                owwName: null,
                otherName: null,
                comment: null,
                postId: null,
            }
        },
        methods: {
            getWall() {
                this.$http.get('https://localhost:44341/api/wall?Visitorname=' + this.owwName + '&HostName=' + this.otherName, {
                    headers: {
                        'Access-Control-Allow-Origin': '*',
                    },
                }).then(response => (this.info = response.data))
            },
            sendComment() {
                this.$http.post('https://localhost:44341/api/Comments?comment=' + this.comment + '&myName=' + this.owwName + '&postId=' + this.postId, {
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
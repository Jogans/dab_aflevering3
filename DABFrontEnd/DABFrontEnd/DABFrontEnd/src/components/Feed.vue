<template>

    <div class="container">
        <h1><b>Find Feed</b></h1>
        <input type="text" placeholder="Write your name" v-model="owwName" required>
        <input type="text" placeholder="Write post id" v-model="postId" required>
        <input class="commentInput" type="text" placeholder="Write your Comment" v-model="comment" required>
        <button class='test_btn' @click='sendComment'>Comment on post</button>
        <br />
        <button class="test_btn" @click="getFeed">Find Feed</button>
        <br />
        <span v-html="info2">{{info2}}</span>
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
                owwName: null,
                comment: null,
                postId: null,
                info2: null,
            }
        },
        methods: {
            getFeed() {
                this.$http.get('https://localhost:44341/api/feed?name=' + this.owwName, {
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

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
        input {
        margin-right: 50px;
        font-size: 20px;
    }

    button {
        font-size: 20px;
    }
    .commentInput{
        width: 1500px;
    }
</style>

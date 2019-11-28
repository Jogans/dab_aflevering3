<template>

    <div class="container">

        <div class="containerGet">
            <h1>Get Posts</h1>

            <label for="id"><b>Indtast Id</b></label>
            <br />
            <input type="text" v-model="id" placeholder="Skriv id" name="id" required>

            <div class="clearfix">
                <button class="get" @click="getData">Get</button>
            </div>

        </div>

        <div class="containerPost">
            <h1>Post Posts</h1>

            <label for="id"><b>Post Data</b></label>
            <br />
            <input type="text" v-model="id" placeholder="Ved endnu ikke hvad der skal være her?" name="id" required>

            <div class="clearfix">
                <button class="post" @click="postData">Post</button>
            </div>

        </div>

        <div class="containerPut">
            <h1>Update Posts</h1>

            <label for="id"><b>Update Data</b></label>
            <br />
            <input type="text" v-model="id" placeholder="Ved endnu ikke hvad der skal være her?" name="id" required>

            <div class="clearfix">
                <button class="update" @click="updateData">Update</button>
            </div>

        </div>


        <div class="container">
            <h1>Delete Posts</h1>

            <label for="id"><b>Delete Data</b></label>
            <br />
            <input type="text" v-model="id" placeholder="Skriv id" name="id" required>

            <div class="clearfix">
                <button class="delete" @click="sletData">Delete</button>
            </div>

        </div>
    </div>
</template>

<script>
    export default {
        name: 'Post',
        data: function () {
            return {
                info: null,
                searchParameter: null
            }
        },
        methods: {
            getData() {
                this.$http.get('https://localhost:44341/api/Posts?id=' + this.searchParameter, {
                    headers: {
                        'Access-Control-Allow-Origin': '*',
                    },
                }).then(response => (this.info = response.data))
            },
            postData() {
                this.$http.post('https://localhost:44341/api/Posts?id=' + this.searchParameter, {
                    headers: {
                        'Access-Control-Allow-Origin': '*',
                    },
                }).then(response => (this.info = response.data))
            },
            updateData() {
                this.$http.put('https://localhost:44341/api/Posts?id=' + this.searchParameter, {
                    headers: {
                        'Access-Control-Allow-Origin': '*',
                    },
                }).then(response => (this.info = response.data))
            },
            sletData() {
                this.$http.delete('https://localhost:44341/api/Posts?id=' + this.searchParameter, {
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

<template>

    <div class="container">

        <div class="containerPost">
            <h1>Create Post</h1>

            <label><b>Post Data</b></label>
            <br />
            <input type="text" v-model="ownName" placeholder="Own name">
            <input type="text" v-model="content" placeholder="Post text">
            <br />
            <button @click="addRow1">Add circle</button>
            <br />
            <br />
            <ul>
                <li v-for="(input1, index1) in inputs1" v-bind:key="input1">
                    <input type="text" placeholder="Circle Name" v-model="input1.one" />
                    <button class="btn_delete" @click="deleteRow1(index1)">Slet</button>
                </li>
            </ul>
            <div class="clearfix">
                <br />
                <button class="post" @click="createPost">Post</button>
            </div>
            <br />
            <span v-html="info">{{info}}</span>
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
                inputs1: [],
                info: null,
                searchParameter: null,
                ownName: null,
                content: null,
                i: 0,
                circleString: "",
            }
        },
        methods: {
            addRow1() {
                if (this.inputs1.length < 7) {
                    this.i++;
                    this.inputs1.push({
                        one: null,
                    })
                }
            },
            deleteRow1(index1) {
                this.i--;
                this.inputs1.splice(index1, 1)
            },
            circleList() {
                var j = 0;
                this.circleString = "";
                for (j = 0; j < this.i; j++) {
                    this.circleString += this.inputs1[j].one + ";";
                }
                return this.circleString;
            },
            createPost() {
                this.$http.post('https://localhost:44341/api/Post?myName=' + this.ownName + '&content=' + this.content + '&circleNamesList=' + this.circleList(), {
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
    input {
        margin: 5px;
        font-size: 20px;
    }

    button {
        font-size: 22px;
    }

    b {
        font-size: 20px;
    }
</style>

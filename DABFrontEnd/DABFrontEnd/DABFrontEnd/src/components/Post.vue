<template>

    <div class="container">

        <div class="containerPost">
            <h1>Create Post</h1>


            <label><b>Post Data</b></label>
            <br />
            <input type="text" v-model="ownName" placeholder="Own name">
            <input type="text" v-model="content" placeholder="Post text">
            <input type="text" v-model="img" placeholder="Image link">
            <br />
            <button @click="addRow1">Add circle</button>
            <br />
            <br />
            <ul>
                <li v-for="(input1, index1) in inputs1" v-bind:key="input1">
                    <input type="text" placeholder="Circle Name" v-model="input1.one" />
                    <button class="btn_delete" @click="deleteRow1(index1)">Remove Circle</button>
                </li>
            </ul>
            <div class="clearfix">
                <br />
                <button class="post" @click="createPost">Post</button>
            </div>
            <br />
            <span v-html="info">{{info}}</span>
            <h3>Instructions</h3>
            <p>
                To create a post, first enter your full registred name in the input field "Own Name"
                <br /> Thereafter enter either a Post text or enter an image URL or both in the two input fields.
                <br /> Now press the button "Add Circle" and a new input field appears. Here you can enter the name of cirles, you want to post your Post input.
                <br /> The button "Add Cirles" can be pressed multiple times to make a post appear in several Circles
              
                <br /> An undesired additional circle can be remove by pressing the button Remove circle

                <br /> To create the post in the desired circles press the button "Post"
                <br /> This function requires full registered name and correct use of upper or lower case in the Input fields "Own name" and "Circle name"
                <br/> To create a Post, the user must be included in the circles, in order to successfully create a post.
            </p>

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
                img: null
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
                this.$http.post('https://localhost:44341/api/Post?myName=' + this.ownName + '&content=' + this.content + '&circleNamesList=' + this.circleList() + '&img=' + this.img, {
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

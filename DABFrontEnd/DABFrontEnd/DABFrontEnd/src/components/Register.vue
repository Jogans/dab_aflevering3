<template>
    <div class="Register">
        <div class="Login">
            <div class="container1">
                <h1>Login</h1>


                <label for="email"><b>Name</b></label>
                <br />
                <input type="text" placeholder="Skriv navn" v-bind="searchParameter" required>
                <br />
                <button class="test_btn" @click="created">Login</button>
                <br />
                <br />
                <br />
                <span v-html="info">{{info}}</span>


                <h1>Register</h1>

                <label for="name1"><b>Name</b></label>
                <br />
                <input type="text" v-model="name1" placeholder="Skriv navn" name="name1" required>
                <br />
                <br />

                <label for="gender"><b>Choose gender</b></label>
                <br />
                <div class="slidecontainer">
                    Male
                    <input type="range" min="1" max="1000" value="500" class="slider" id="myRange">
                    Female
                </div>
                <!--<select class="gender" id="gender_id" name="gender">
                    <option value="Mand">Mand</option>
                    <option value="Din mor">Din mor</option>
                </select>-->
                <br />
                <br />
                <label for="age1"><b>Age</b></label>
                <br />
                <input type="text" placeholder="Skriv alder" name="age1" required>


                <br />
                <br />

                <div class="clearfix">
                    <button class="register" @click="register">Tilmeld</button>
                </div>

            </div>

            <div class="container2">
                <h1>Update data</h1>

                <label for="name2"><b>Name</b></label>
                <br />
                <input type="text" v-model="name2" placeholder="Skriv navn" name="name2" required>
                <br />
                <br />

                <label for="gender"><b>Fra mand til kvinde vælg hvor du ligger</b></label>
                <br />
                <div class="slidecontainer">
                    Male
                    <input type="range" min="1" max="1000" value="500" class="slider" id="myRange">
                    Female
                </div>
                <!--<select class="gender" id="gender_id" name="gender">
        <option value="Mand">Mand</option>
        <option value="Din mor">Din mor</option>
    </select>-->
                <br />
                <br />
                <label for="age2"><b>Age</b></label>
                <br />
                <input type="text" placeholder="Skriv alder" name="age2" required>


                <br />
                <br />

                <div class="clearfix">
                    <button class="update" @click="update">Update</button>
                </div>

            </div>

            <div class="container2">
                <h1>Delete user</h1>

                <label for="id"><b>Indtast Id</b></label>
                <br />
                <input type="text" v-model="id" placeholder="Skriv navn" name="id" required>

                <div class="clearfix">
                    <button class="delete" @click="slet">Delete</button>
                </div>

            </div>

        </div>
    </div>
</template>

<script>
    export default {
        name: 'Register',
        data: function () {
            return {
                info: null,
                searchParameter: null
            }
        },
        methods: {
            created() {
                this.$http.get('https://localhost:44341/api/user?id=' + this.searchParameter, {
                    headers: {
                        'Access-Control-Allow-Origin': '*',
                    },
                }).then(response => (this.info = response.data))
            },
            register() {
                this.$http.post('https://localhost:44341/api/user?get=' + this.searchParameter, {
                    headers: {
                        'Access-Control-Allow-Origin': '*',
                    },
                }).then(response => (this.info = response.data))
            },
            update() {
                this.$http.put('https://localhost:44341/api/user?get=' + this.searchParameter, {
                    headers: {
                        'Access-Control-Allow-Origin': '*',
                    },
                }).then(response => (this.info = response.data))
            },
            slet() {
                this.$http.delete('https://localhost:44341/api/user?get=' + this.searchParameter, {
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

    select {
        font-size: 20px;
    }
.slider {
  width: 50%; /* Full-width */
  height: 25px; /* Specified height */
  background: #d3d3d3; /* Grey background */
  outline: none; /* Remove outline */
  opacity: 0.7; /* Set transparency (for mouse-over effects on hover) */
  -webkit-transition: .2s; /* 0.2 seconds transition on hover */
  transition: opacity .2s;
}
</style>
<template>
    <div class="Register">
        <div class="Login">
            <div class="container1">
                <h1>Login</h1>


                <label for="email"><b>Name</b></label>
                <br />
                <input type="text" placeholder="Skriv navn" v-model="loginName" required>
                <br />
                <button class="test_btn" @click="Login">Login</button>
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
                <select class="gender" id="gender_id" v-model="gender1" name="gender">
                    <option value="Male">Male</option>
                    <option value="Female">Female</option>
                </select>
                <br />
                <br />
                <label for="age1"><b>Age</b></label>
                <br />
                <input type="text" placeholder="Skriv alder" v-model="age1" name="age1" required>


                <br />
                <br />

                <div class="clearfix">
                    <button class="register" @click="register">Register</button>
                </div>
                <br />
                <span v-html="info1">{{info1}}</span>

                <h3>Instructions</h3>
                <p>
                    To login enter the name of an already registered user (Full registered name and correct use of upper and lower case applies)
                    <br /> This function only returns the user name if the user is registered in the database
                    <br />
                    <br /> To Register fill out the input fields and press the button "Register"
                    <br /> The user will now appear in the database. 
                </p>

            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'Register',
        props: {
        },
        data: function () {
            return {
                info: null,
                info1: null,
                loginName: null,
                searchParameter: null,
                gender1: null,
                gender2: null,
                name1: null,
                name2: null,
                age1: null,
                age2: null
            }
        },
        methods: {
            Login() {
                this.$http.get('https://localhost:44341/api/user?name=' + this.loginName, {
                    headers: {
                        'Access-Control-Allow-Origin': '*',
                    },
                }).then(response => (this.info = response.data))
            },
            register() {
                this.$http.post('https://localhost:44341/api/user?name=' + this.name1 + '&gender=' + this.gender1 + '&age=' +this.age1, {
                    headers: {
                        'Access-Control-Allow-Origin': '*',
                    },
                }).then(response => (this.info1 = response.data))
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
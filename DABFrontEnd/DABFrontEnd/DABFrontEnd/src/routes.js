import Register from './components/Register.vue';
import Login from './components/Login.vue';
import Comment from './components/Comment.vue';
import Feed from './components/Feed.vue';
import Post from './components/Post.vue';
import Wall from './components/Wall.vue';
import CircleConfig from './components/CircleConfig.vue';
import BanList from './components/BanList.vue';
import Subscribe from './components/Subscribe.vue';



const routes = [
    { path: '/Register', component: Register },
    { path: '/Login', component: Login },
    { path: '/Comment', component: Comment },
    { path: '/Feed', component: Feed },
    { path: '/Wall', component: Wall },
    { path: '/Post', component: Post },
    { path: '/CircleConfig', component: CircleConfig },
    { path: '/BanList', component: BanList },
    { path: '/Subscribe', component: Subscribe }
];

export default routes;


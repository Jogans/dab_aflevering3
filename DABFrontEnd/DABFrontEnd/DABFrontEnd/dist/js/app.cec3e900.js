(function(e){function t(t){for(var n,s,i=t[0],l=t[1],u=t[2],p=0,f=[];p<i.length;p++)s=i[p],Object.prototype.hasOwnProperty.call(a,s)&&a[s]&&f.push(a[s][0]),a[s]=0;for(n in l)Object.prototype.hasOwnProperty.call(l,n)&&(e[n]=l[n]);c&&c(t);while(f.length)f.shift()();return o.push.apply(o,u||[]),r()}function r(){for(var e,t=0;t<o.length;t++){for(var r=o[t],n=!0,i=1;i<r.length;i++){var l=r[i];0!==a[l]&&(n=!1)}n&&(o.splice(t--,1),e=s(s.s=r[0]))}return e}var n={},a={app:0},o=[];function s(t){if(n[t])return n[t].exports;var r=n[t]={i:t,l:!1,exports:{}};return e[t].call(r.exports,r,r.exports,s),r.l=!0,r.exports}s.m=e,s.c=n,s.d=function(e,t,r){s.o(e,t)||Object.defineProperty(e,t,{enumerable:!0,get:r})},s.r=function(e){"undefined"!==typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})},s.t=function(e,t){if(1&t&&(e=s(e)),8&t)return e;if(4&t&&"object"===typeof e&&e&&e.__esModule)return e;var r=Object.create(null);if(s.r(r),Object.defineProperty(r,"default",{enumerable:!0,value:e}),2&t&&"string"!=typeof e)for(var n in e)s.d(r,n,function(t){return e[t]}.bind(null,n));return r},s.n=function(e){var t=e&&e.__esModule?function(){return e["default"]}:function(){return e};return s.d(t,"a",t),t},s.o=function(e,t){return Object.prototype.hasOwnProperty.call(e,t)},s.p="/";var i=window["webpackJsonp"]=window["webpackJsonp"]||[],l=i.push.bind(i);i.push=t,i=i.slice();for(var u=0;u<i.length;u++)t(i[u]);var c=l;o.push([0,"chunk-vendors"]),r()})({0:function(e,t,r){e.exports=r("56d7")},"56d7":function(e,t,r){"use strict";r.r(t);var n=r("2b0e"),a=function(){var e=this,t=e.$createElement,r=e._self._c||t;return r("div",{attrs:{id:"app"}},[r("Home",{attrs:{msg:"Hello world!"}})],1)},o=[],s=function(){var e=this,t=e.$createElement,r=e._self._c||t;return r("div",{staticClass:"home"},[r("div",{staticClass:"SearchBar"},[r("input",{directives:[{name:"model",rawName:"v-model",value:e.searchParameter,expression:"searchParameter"}],staticStyle:{height:"32px",width:"704px"},attrs:{type:"text",placeholder:"Search...",required:""},domProps:{value:e.searchParameter},on:{input:function(t){t.target.composing||(e.searchParameter=t.target.value)}}})]),r("button",{staticClass:"test_btn",on:{click:e.created}},[e._v("Test")]),r("br"),r("br"),r("br"),r("router-link",{staticClass:"btn_Register",attrs:{to:"/Register",tag:"button"}},[e._v("Register")]),r("br"),r("br"),r("br"),r("span",{domProps:{innerHTML:e._s(e.info)}},[e._v(e._s(e.info))])],1)},i=[],l={name:"Home",data:function(){return{test:"Det virker",info:null,searchParameter:null}},methods:{created:function(){var e=this;this.$http.get("https://localhost:44341/api/values?id=5",{headers:{"Access-Control-Allow-Origin":"*"}}).then(function(t){return e.info=t.data})}}},u=l,c=r("2877"),p=Object(c["a"])(u,s,i,!1,null,"cb724b00",null),f=p.exports,d={name:"app",components:{Home:f}},h=d,v=Object(c["a"])(h,a,o,!1,null,null,null),b=v.exports,m=r("8c4f"),g=function(){var e=this,t=e.$createElement;e._self._c;return e._m(0)},_=[function(){var e=this,t=e.$createElement,r=e._self._c||t;return r("div",{staticClass:"Register"},[r("p",[e._v("Hej")])])}],y={name:"Register",props:{}},w=y,O=Object(c["a"])(w,g,_,!1,null,"6890ff80",null),P=O.exports,j=[{path:"/Register",component:P}],x=j,S=r("bc3a"),$=r.n(S);n["a"].prototype.$http=$.a,n["a"].config.productionTip=!0,n["a"].use(m["a"]);var k=new m["a"]({routes:x});new n["a"]({router:k,render:function(e){return e(b)}}).$mount("#app")}});
//# sourceMappingURL=app.cec3e900.js.map
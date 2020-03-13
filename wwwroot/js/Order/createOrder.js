// Write your Javascript code.
import myForwarderComponent from "./forwarderComponent.js";

// var show = (function() {
//   var init = function() {};

//   return {
//     init: init
//   };
// })();

var mycomponent = {
  data: function() {
    return {
      count: 0
    };
  },
  template: `
    <div class="col-md-6">
      <button v-on:click="count++">You clicked me {{ count }} times.</button>
    </div>
    `
};

var app = new Vue({
  el: "#components-demo",
  components: {
    "mycomponent-wasd": mycomponent,
    "my-forwarder-component": myForwarderComponent()
  }
});

export default function() {
  return app;
}

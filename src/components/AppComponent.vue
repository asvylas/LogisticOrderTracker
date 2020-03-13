<template>
  <div class="col-md6">
    <h1>Hello from the AppComponentawdaadawdawawawdwddwa</h1>
    <button v-on:click="count++">{{count}}</button>
    <div class="well">
      <p>{{greeting}}</p>
    </div>
  </div>
</template>

<script>
export default {
  data: function() {
    return {
      greeting: "Hello World",
      count: 0
    };
  }
};
</script>



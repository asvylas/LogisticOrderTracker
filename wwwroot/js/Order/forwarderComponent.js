export default function myForwarderComponent() {
  return {
    data: function() {
      return {
        count: 0
      };
    },
    template: `
        <div class="col-md-6">
          <button v-on:click="count++">This is a forwarder component. You clicked me {{ count }} times.</button>
        </div>
        `
  };
}

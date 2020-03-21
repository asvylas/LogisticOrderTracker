import Vue from "vue";
import AddressComponent from "./components/addressComponent.vue";
import OrderComponent from "./components/orderComponent.vue";
import ForwarderComponent from "./components/forwarderComponent.vue";
import ShipmentComponent from "./components/shipmentComponent.vue";

new Vue({
  components: {
    "address-comp": AddressComponent,
    "order-comp": OrderComponent,
    "forwarder-comp": ForwarderComponent,
    "shipment-comp": ShipmentComponent
  },
  data() {
    return {
      count: 0
    };
  }
}).$mount("#app");

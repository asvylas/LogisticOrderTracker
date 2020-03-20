import Vue from "vue";
import SenderComponent from "./components/senderComponent.vue";
import ReceiverComponent from "./components/receiverComponent.vue";
import ShipmentComponent from "./components/shipmentComponent.vue";
import OrderComponent from "./components/orderComponent.vue";
import ForwarderComponent from "./components/forwarderComponent.vue";

new Vue({
  components: {
    "sender-comp": SenderComponent,
    "receiver-comp": ReceiverComponent,
    "shipment-comp": ShipmentComponent,
    "order-comp": OrderComponent,
    "forwarder-comp": ForwarderComponent
  },
  data() {
    return {
      count: 0
    };
  }
}).$mount("#app");

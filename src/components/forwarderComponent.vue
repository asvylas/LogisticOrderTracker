<template>
  <div>
    <h3>Forwarder</h3>
    <hr />
    <div asp-validation-summary="ModelOnly" class="text-danger"></div>

    <div class="form-group">
      <label asp-for="@Model.ForwarderId" class="control-label"
        >Forwarder</label
      >
      <select name="" id="" class="form-control" v-model="selectedForwarderId">
        <option
          v-for="forwarder in forwarders"
          v-bind:key="forwarder.id"
          v-bind:value="forwarder.id"
          >{{ forwarder.name }}</option
        >
      </select>
    </div>

    <div class="form-group">
      <label asp-for="Order.DriverPhone" class="control-label"
        >Driver Phone</label
      >
      <input v-model="driverPhone" class="form-control" />
      <span asp-validation-for="Order.DriverPhone" class="text-danger"></span>
    </div>

    <div class="form-group">
      <label asp-for="Order.TruckNumber" class="control-label"
        >Truck Number</label
      >
      <input v-model="truckNumber" class="form-control" />
      <span asp-validation-for="Order.TruckNumber" class="text-danger"></span>
    </div>

    <div class="form-group">
      <label asp-for="Order.TransportType" class="control-label"
        >Transport Type</label
      >
      <select
        name=""
        id=""
        class="form-control"
        v-model="selectedTransportTypeId"
      >
        <option
          v-for="type in transportTypes"
          v-bind:key="type.value"
          v-bind:value="type.value"
          >{{ type.key }}</option
        >
      </select>
      <span asp-validation-for="Order.TransportType" class="text-danger"></span>
    </div>
  </div>
</template>

<script>
import HttpService from "../services/http.service";
export default {
  data: function() {
    return {
      greeting: "Hello World",
      count: 0,
      driverPhone: "",
      truckNumber: "",
      forwarders: [],
      transportTypes: [],
      selectedForwarderId: 0,
      selectedTransportTypeId: 0
    };
  },
  methods: {
    getForwarders: function(event) {
      HttpService.getAll("forwarders")
        .then(res => {
          this.forwarders = res.data;
          this.selectedForwarderId = this.forwarders[0].id;
          console.log(res.data);
        })
        .catch(err => {
          console.log(err);
        });
    },
    getTransportTypes: function() {
      HttpService.getAll("general/transporttypes")
        .then(res => {
          if (res.data.length > 0) {
            this.transportTypes = res.data;
            this.selectedTransportTypeId = this.transportTypes[0].value;
            console.log(this.transportTypes);
          } else {
            throw Error("No product managers found!");
          }
        })
        .catch(err => {
          console.log(err);
        });
    }
  },
  mounted: function() {
    this.getForwarders();
    this.getTransportTypes();
  }
};
</script>

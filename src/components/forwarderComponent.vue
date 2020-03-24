<template>
  <div>
    <h3>Forwarder</h3>
    <hr />
    <div asp-validation-summary="ModelOnly" class="text-danger"></div>

    <div class="form-group">
      <label asp-for="@Model.ForwarderId" class="control-label"
        >Forwarder</label
      >
      <select name="" id="" class="form-control">
        <option
          value=""
          v-for="forwarder in forwarders"
          v-bind:key="forwarder.id"
          >{{ forwarder.name }}</option
        >
      </select>
      <span asp-validation-for="@Model.ForwarderId" class="text-danger"></span>
    </div>

    <div class="form-group">
      <label asp-for="Order.DriverPhone" class="control-label"
        >Driver Phone</label
      >
      <input asp-for="Order.DriverPhone" class="form-control" />
      <span asp-validation-for="Order.DriverPhone" class="text-danger"></span>
    </div>

    <div class="form-group">
      <label asp-for="Order.TruckNumber" class="control-label"
        >Truck Number</label
      >
      <input asp-for="Order.TruckNumber" class="form-control" />
      <span asp-validation-for="Order.TruckNumber" class="text-danger"></span>
    </div>

    <div class="form-group">
      <label asp-for="Order.TransportType" class="control-label"
        >Transport Type</label
      >
      <select
        asp-for="Order.TransportType"
        class="form-control"
        asp-items="Html.GetEnumSelectList<LogisticOrderTracker.Models.TransportType>()"
      ></select>
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
      forwarders: []
    };
  },
  methods: {
    getForwarders: function(event) {
      HttpService.getAll("forwarders")
        .then(res => {
          this.forwarders = res.data;
          console.log(res.data);
        })
        .catch(err => {
          console.log(err);
        });
    }
  },
  mounted: function() {
    this.getForwarders();
  }
};
</script>

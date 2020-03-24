<template>
  <div>
    <h3>Order</h3>
    <hr />
    <div asp-validation-summary="ModelOnly" class="text-danger"></div>

    <div class="form-group">
      <label class="control-label">Shipment Ready</label>
      <input type="date" class="form-control" />
    </div>

    <div class="form-group">
      <label class="control-label">Shipment Arriving</label>
      <input type="date" class="form-control" />
    </div>

    <div class="form-group">
      <label class="control-label">Product Manager</label>
      <select class="form-control" v-model="selectedProductManagerId">
        <option
          v-bind:value="manager.id"
          v-for="manager in productManagers"
          v-bind:key="manager.id"
        >
          {{ manager.name }} / {{ manager.jobTitle }}
        </option>
      </select>
    </div>

    <div class="form-group">
      <label class="control-label">Shipment Value</label>
      <input type="number" class="form-control" />
      <span asp-validation-for="Order.ShipmentValue" class="text-danger"></span>
    </div>

    <div class="form-group">
      <label asp-for="Order.Incoterms" class="control-label">Incoterms</label>
      <select
        asp-for="Order.Incoterms"
        class="form-control"
        asp-items="Html.GetEnumSelectList<LogisticOrderTracker.Models.Incoterms>()"
      ></select>
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
      productManagers: [],
      selectedProductManagerId: 0
    };
  },
  methods: {
    getProductManagers: function(event) {
      HttpService.getAll("productmanagers")
        .then(res => {
          this.productManagers = res.data;
          console.log(this.productManagers);
        })
        .catch(err => {
          console.log(err);
        });
    }
  },
  mounted: function() {
    this.getProductManagers();
  }
};
</script>

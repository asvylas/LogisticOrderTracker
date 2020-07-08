<template>
  <div>
    <h3>Order</h3>
    <hr />
    <div asp-validation-summary="ModelOnly" class="text-danger"></div>

    <div class="form-group">
      <label class="control-label">Shipment Ready</label>
      <input type="date" class="form-control" v-model="shipmentReady" />
    </div>

    <div class="form-group">
      <label class="control-label">Shipment Arriving</label>
      <input type="date" class="form-control" v-model="shipmentArriving" />
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
      <input type="number" class="form-control" v-model="shipmentValue" />
    </div>

    <div class="form-group">
      <label asp-for="Order.Incoterms" class="control-label">Incoterms</label>
      <select class="form-control" v-model="selectedIncotermsId">
        <option
          v-bind:value="terms.value"
          v-for="terms in incoterms"
          v-bind:key="terms.value"
        >
          {{ terms.key }}
        </option>
      </select>
    </div>
  </div>
</template>

<script>
import HttpService from "../services/http.service";
import Moment from "moment";
export default {
  data: function() {
    return {
      greeting: "Hello World",
      count: 0,
      productManagers: [],
      incoterms: [],
      selectedProductManagerId: 0,
      selectedIncotermsId: 0,
      shipmentReady: Moment().format("YYYY-MM-DD"),
      shipmentArriving: Moment().format("YYYY-MM-DD"),
      shipmentValue: 0
    };
  },
  methods: {
    getProductManagers: function() {
      HttpService.getAll("productmanagers")
        .then(res => {
          if (res.data.length > 0) {
            this.productManagers = res.data;
            this.selectedProductManagerId = this.productManagers[0].id;
            console.log(this.productManagers);
          } else {
            throw Error("No product managers found!");
          }
        })
        .catch(err => {
          console.log(err);
        });
    },
    getIncoterms: function() {
      HttpService.getAll("general/incoterms")
        .then(res => {
          if (res.data.length > 0) {
            this.incoterms = res.data;
            this.selectedIncotermsId = this.incoterms[0].value;
            console.log(this.incoterms);
          } else {
            throw Error("No incoterms found!");
          }
        })
        .catch(err => {
          console.log(err);
        });
    }
  },
  mounted: function() {
    this.getProductManagers();
    this.getIncoterms();
  }
};
</script>

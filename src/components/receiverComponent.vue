<template>
  <div class="col-md-6">
    <h3>Receiver</h3>
    <hr />
    <div class="text-danger"></div>

    <div class="form-group">
      <label asp-for="@Model.SenderId" class="control-label">Select Receiver</label>
      <select class="form-control" v-model="selectedAddress" @change="getAddressContacts">
        <option value v-for="address in addresses" v-bind:key="address.id">
          {{
          address.name
          }}
        </option>
      </select>
      <span asp-validation-for="@Model.SenderId" class="text-danger"></span>
    </div>

    <div
      class="well well-sm"
      id="receiver-well"
      v-for="contact in contacts"
      v-bind:key="contact.id"
    >
      <div class="card">
        <h5 class="card-header">Featured</h5>
        <div class="card-body">
          <h5 class="card-title">Special title treatment</h5>
          <p
            class="card-text"
          >With supporting text below as a natural lead-in to additional content.</p>
          <a href="#" class="btn btn-primary">Go somewhere</a>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import HttpService from "../services/http.service";
import httpService from "../services/http.service";
export default {
  data: function() {
    return {
      greeting: "Hello World",
      count: 0,
      addresses: [],
      selectedAddress: {},
      contacts: []
    };
  },
  methods: {
    getAddresses: function(event) {
      HttpService.getAll("addresses")
        .then(res => {
          this.addresses = res.data;
          console.log(res.data);
        })
        .catch(err => {
          console.log(err);
        });
    },
    getAddressContacts: function(event) {
      httpService
        .get("addresscontacts", 1)
        .then(res => {
          this.contacts = res.data;
          console.log(res.data);
        })
        .catch(err => {
          console.log(err);
        });
    }
  },
  mounted: function() {
    this.getAddresses();
  }
};
</script>

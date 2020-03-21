<template>
  <div class="col-md-6">
    <h3>{{ this.addressTitle }}</h3>
    <hr />
    <div class="text-danger"></div>

    <div class="form-group">
      <label class="control-label">Select {{ this.addressTitle }}</label>
      <select
        class="form-control"
        v-model="selectedAddressId"
        @change="getAddressContacts"
      >
        <option
          v-bind:value="address.id"
          v-for="address in addresses"
          v-bind:key="address.id"
        >
          {{ address.name }}
        </option>
      </select>
      <span class="text-danger"></span>
    </div>

    <div v-if="selectedAddress.length > 0">
      <div
        class="well well-sm"
        id="receiver-address-well contact-select"
        @click="selectContact"
      >
        <div class="card">
          <h5 class="card-header">{{ selectedAddress[0].name }}</h5>
          <div class="card-body">
            <div class="card-text">
              <div>Street: {{ selectedAddress[0].street }}</div>
              <div>City: {{ selectedAddress[0].city }}</div>
              <div>Zip: {{ selectedAddress[0].zip }}</div>
              <div>Country: {{ selectedAddress[0].country }}</div>
            </div>
            <br />
          </div>
        </div>
      </div>
    </div>

    <div v-if="contacts.length > 0">
      <div
        class="well well-sm contact-select"
        id="receiver-well"
        v-for="contact in contacts"
        v-bind:key="contact.id"
      >
        <div class="card">
          <h5 class="card-header">{{ contact.name }}</h5>
          <div class="card-body">
            <div class="card-text">
              <div>Job Title: {{ contact.jobTitle }}</div>
              <div>Phone: {{ contact.phone }}</div>
              <div>Email: {{ contact.email }}</div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import HttpService from "../services/http.service";
export default {
  props: ["addressTitle"],
  data: function() {
    return {
      addresses: [],
      selectedAddressId: 0,
      contacts: [],
      addresss: {}
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
      this.contacts = this.addresses.filter(
        e => e.id == this.selectedAddressId
      )[0].contacts;
    },
    selectContact: function(event) {}
  },
  computed: {
    // a computed getter
    selectedAddress: function() {
      // `this` points to the vm instance
      return this.addresses.filter(e => e.id == this.selectedAddressId);
    }
  },
  mounted: function() {
    this.getAddresses();
  }
};
</script>

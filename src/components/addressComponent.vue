<template>
  <div>
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
        <optgroup
          v-for="country in countriesList"
          v-bind:label="country"
          v-bind:key="country"
        >
          <option
            v-bind:value="address.id"
            v-for="address in addresses.filter(e => e.country == country)"
            v-bind:key="address.id"
          >
            {{ address.name }}/{{ address.city }}/{{ address.zip }}
          </option>
        </optgroup>
      </select>
      <span class="text-danger"></span>
    </div>

    <div v-if="selectedAddress.length > 0">
      <div class="well well-sm active" id="receiver-address-well">
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
      <div>
        <label class="control-label"
          >Select {{ this.addressTitle }} Contact</label
        >
      </div>

      <div
        class="col-md-5 well well-sm contact-select"
        id="receiver-well"
        v-for="contact in contacts"
        v-bind:key="contact.id"
        v-bind:class="[contact.id == selectedContactId ? 'active' : '']"
        @click="selectContact(contact)"
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
      selectedContactId: 0,
      contacts: [],
      addresss: {}
    };
  },
  methods: {
    getAddresses: function(event) {
      HttpService.getAll("addresses")
        .then(res => {
          this.addresses = res.data;
          this.addresses.forEach(element => {
            element.contacts.forEach(e => {
              e.clicked == false;
            });
          });
          console.log(res.data);
        })
        .catch(err => {
          console.log(err);
        });
    },
    getAddressContacts: function(event) {
      var contacts = this.addresses.filter(
        e => e.id == this.selectedAddressId
      )[0].contacts;
      this.contacts = contacts;
      this.selectedContactId = contacts[0].id;
    },
    selectContact: function(contact) {
      this.selectedContactId = contact.id;
      console.log(contact);
    }
  },
  computed: {
    countriesList: function() {
      var countries = this.addresses.map(e => e.country);
      return [...new Set(countries.sort())];
    },
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

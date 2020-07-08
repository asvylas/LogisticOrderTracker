<template>
  <div>
    <h3>Packages</h3>
    <hr />
    <div class="form-group">
      <label class="control-label">Select Package</label>
      <select
        class="form-control"
        @change="addPackage"
        v-model="selectedPackageId"
      >
        <option selected disabled value="disabled-select"
          >-Click to select packages.-</option
        >
        <optgroup
          v-for="type in packageTypes"
          v-bind:label="type.key"
          v-bind:key="type.value"
        >
          <option
            v-bind:value="e.id"
            v-for="e in packages.filter(s => s.type == type.value)"
            v-bind:key="e.id"
          >
            {{ e.length }}x{{ e.width }}x{{ e.height }} - {{ e.weight }} kg
          </option>
        </optgroup>
      </select>
    </div>
    <div v-if="addedPackages.length > 0">
      <div><label class="control-label">Selected Packages</label></div>
      <div
        id="receiver-well"
        class="col-md-2 well well-sm contact-select active"
        v-for="e in addedPackages"
        v-bind:key="e.id"
      >
        <div class="card">
          <div class="card-body">
            <div class="card-text">
              <div class="form-group">
                <label class="control-label">Package Information</label>
                <div>
                  Type: {{ packageTypes.find(f => f.value == e.type).key }}
                </div>
                <div>
                  Dimensions: {{ e.length }}x{{ e.width }}x{{ e.height }}
                </div>
                <div>Weight: {{ e.weight }} kg</div>
              </div>
              <div class="form-group">
                <label class="control-label">Quantity</label>
                <input
                  type="number"
                  v-bind:value="e.quantity"
                  class="form-control"
                />
              </div>
              <div class="form-group">
                <input
                  type="submit"
                  id="submit-order"
                  value="Remove"
                  class="btn btn-default"
                />
              </div>
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
  data: function() {
    return {
      greeting: "Hello World",
      count: 0,
      packages: [],
      packageTypes: [],
      selectedPackageId: "disabled-select",
      addedPackages: []
    };
  },
  methods: {
    getPackages: function() {
      HttpService.getAll("packages")
        .then(res => {
          if (res.data.length > 0) {
            this.packages = res.data;
            console.log(this.packages);
          } else {
            throw Error("No product managers found!");
          }
        })
        .catch(err => {
          console.log(err);
        });
    },
    getPackageTypes: function() {
      HttpService.getAll("general/packagetypes")
        .then(res => {
          if (res.data.length > 0) {
            this.packageTypes = res.data;
            console.log(this.packageTypes);
          } else {
            throw Error("No product managers found!");
          }
        })
        .catch(err => {
          console.log(err);
        });
    },
    addPackage: function(event) {
      var packageInSelection = this.packages.find(
        e => e.id == this.selectedPackageId
      );
      if (!this.addedPackages.some(e => e.id === packageInSelection.id)) {
        packageInSelection.quantity = 0;
        this.addedPackages.push(packageInSelection);
      } else {
        return;
      }
    }
  },
  mounted: function() {
    this.getPackages();
    this.getPackageTypes();
  }
};
</script>

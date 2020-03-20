<template>
  <div class="col-md-6">
    <h3>Sender</h3>
    <hr />
    <div asp-validation-summary="ModelOnly" class="text-danger"></div>

    <div class="form-group">
      <label asp-for="@Model.SenderId" class="control-label">
        Select Sender</label
      >
      <select class="form-control">
        <option value="" v-for="address in addresses" v-bind:key="address.id">{{
          address.name
        }}</option>
      </select>
      <span asp-validation-for="@Model.SenderId" class="text-danger"></span>
    </div>

    <div class="well well-sm" id="sender-well"></div>
  </div>
</template>

<script>
import HttpService from "../services/http.service";
export default {
  data: function() {
    return {
      greeting: "Hello World",
      count: 0,
      addresses: []
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
    }
  },
  mounted: function() {
    this.getAddresses();
  }
};
</script>

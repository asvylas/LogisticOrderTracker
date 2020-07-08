<template>
  <div>
    <h3>Shipment</h3>
    <hr />
    <div asp-validation-summary="ModelOnly" class="text-danger"></div>
    <div class="form-group">
      <label class="control-label">Loading Instructions</label>
      <textarea
        v-model="loadingInstructions"
        type="text"
        class="form-control"
        rows="4"
        style="resize: none;"
      ></textarea>
      <span class="text-danger"></span>
    </div>
    <div class="form-group">
      <label class="control-label">Unloading Instructions</label>
      <textarea
        v-model="unloadingInstructions"
        class="form-control"
        rows="4"
        style="resize: none;"
      ></textarea>
      <span class="text-danger"></span>
    </div>
    <div class="form-group">
      <label class="control-label">Loading Reference</label>
      <input v-model="loadingReference" class="form-control" />
      <span class="text-danger"></span>
    </div>
    <div class="form-group">
      <label class="control-label">Unloading Reference</label>
      <input v-model="unloadingReference" class="form-control" />
      <span class="text-danger"></span>
    </div>
  </div>
</template>

<script>
export default {
  data: function() {
    return {
      greeting: "Hello World",
      count: 0,
      loadingInstructions: "",
      unloadingInstructions: "",
      loadingReference: "",
      unloadingReference: ""
    };
  }
};
</script>

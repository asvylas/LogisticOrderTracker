<template>
  <div>
    <h3>Shipment</h3>
    <hr />
    <div asp-validation-summary="ModelOnly" class="text-danger"></div>
    <div class="form-group">
      <label asp-for="Order.LoadingInstructions" class="control-label"
        >Loading Instructions</label
      >
      <textarea
        asp-for="Order.LoadingInstructions"
        type="text"
        class="form-control"
        rows="4"
        style="resize: none;"
      ></textarea>
      <span
        asp-validation-for="Order.LoadingInstructions"
        class="text-danger"
      ></span>
    </div>
    <div class="form-group">
      <label asp-for="Order.UnloadingInstructions" class="control-label"
        >Unloading Instructions</label
      >
      <textarea
        asp-for="Order.UnloadingInstructions"
        class="form-control"
        rows="4"
        style="resize: none;"
      ></textarea>
      <span
        asp-validation-for="Order.UnloadingInstructions"
        class="text-danger"
      ></span>
    </div>
    <div class="form-group">
      <label asp-for="Order.LoadingReferences" class="control-label"
        >Loading Reference</label
      >
      <input asp-for="Order.LoadingReferences" class="form-control" />
      <span
        asp-validation-for="Order.LoadingReferences"
        class="text-danger"
      ></span>
    </div>
    <div class="form-group">
      <label asp-for="Order.UnloadingReferences" class="control-label"
        >Unloading Reference</label
      >
      <input asp-for="Order.UnloadingReferences" class="form-control" />
      <span
        asp-validation-for="Order.UnloadingReferences"
        class="text-danger"
      ></span>
    </div>
  </div>
</template>

<script>
export default {
  data: function() {
    return {
      greeting: "Hello World",
      count: 0
    };
  }
};
</script>

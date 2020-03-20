<template>
  <div class="col-md-4">
    <h3>Shipment</h3>
    <hr />
    <div asp-validation-summary="ModelOnly" class="text-danger"></div>

    <div class="form-group">
      <label asp-for="Order.ShipmentValue" class="control-label"></label>
      <input asp-for="Order.ShipmentValue" class="form-control" />
      <span asp-validation-for="Order.ShipmentValue" class="text-danger"></span>
    </div>
    <div class="form-group">
      <label asp-for="Order.LoadingInstructions" class="control-label"></label>
      <textarea
        asp-for="Order.LoadingInstructions"
        type="text"
        class="form-control"
        rows="4"
        style="resize: none;"
      ></textarea>
      <span asp-validation-for="Order.LoadingInstructions" class="text-danger"></span>
    </div>
    <div class="form-group">
      <label asp-for="Order.UnloadingInstructions" class="control-label"></label>
      <textarea
        asp-for="Order.UnloadingInstructions"
        class="form-control"
        rows="4"
        style="resize: none;"
      ></textarea>
      <span asp-validation-for="Order.UnloadingInstructions" class="text-danger"></span>
    </div>
    <div class="form-group">
      <label asp-for="Order.LoadingReferences" class="control-label"></label>
      <input asp-for="Order.LoadingReferences" class="form-control" />
      <span asp-validation-for="Order.LoadingReferences" class="text-danger"></span>
    </div>
    <div class="form-group">
      <label asp-for="Order.UnloadingReferences" class="control-label"></label>
      <input asp-for="Order.UnloadingReferences" class="form-control" />
      <span asp-validation-for="Order.UnloadingReferences" class="text-danger"></span>
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



<template>
  <div class="col-md-4">
    <h3>Order</h3>
    <hr />
    <div asp-validation-summary="ModelOnly" class="text-danger"></div>

    <div class="form-group">
      <label asp-for="Order.ShipmentReady" class="control-label"></label>
      <input asp-for="Order.ShipmentReady" class="form-control" />
      <span asp-validation-for="Order.ShipmentReady" class="text-danger"></span>
    </div>

    <div class="form-group">
      <label asp-for="Order.ShipmentArriving" class="control-label"></label>
      <input asp-for="Order.ShipmentArriving" class="form-control" />
      <span asp-validation-for="Order.ShipmentArriving" class="text-danger"></span>
    </div>

    <div class="form-group">
      <label asp-for="@Model.ProductManagerId" class="control-label"></label>
      <select
        asp-for="@Model.ProductManagerId"
        class="form-control"
        asp-items="Model.ProductManagers"
      ></select>
      <span asp-validation-for="@Model.ProductManagerId" class="text-danger"></span>
    </div>

    <div class="form-group">
      <label asp-for="Order.Incoterms" class="control-label"></label>
      <select
        asp-for="Order.Incoterms"
        class="form-control"
        asp-items="Html.GetEnumSelectList<LogisticOrderTracker.Models.Incoterms>()"
      ></select>
      <span asp-validation-for="Order.Incoterms" class="text-danger"></span>
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



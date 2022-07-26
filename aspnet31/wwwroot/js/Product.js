$(document).ready(function () {
    $('#tableProduct').DataTable({
        "ajax": {
            "url": "https://localhost:44318/api/Product",
            "dataType": "json",
            "dataSrc": "data"
        },
        "columns": [
            {
                "data": "id",
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                "data": "name"
            },
            {
                "data": "suppliers.name"
            },
            {
                data: null,
                orderable: false,
                render: function (data, type, row) {
                    return `<button class="btn btn-warning" asp-action="Edit" asp-route-id="@item.Id">Edit</button> 
                    <button class="btn btn-info" asp-action="Details" asp-route-id="@item.Id">Details</button> 
					<button class="btn btn-danger" asp-action="Delete" asp-route-id="@item.Id">Delete</button`
                }
            }
        ]
    });
});
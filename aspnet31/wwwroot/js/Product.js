$(document).ready(function () {
    $('#tableProduct').DataTable({

        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'copy',
                exportOptions: {
                    columns: [0, 1, 2]
                }
            },
            {
                extend: 'excel',
                exportOptions: {
                    columns: [0, 1, 2]
                }
            },
            {
                extend: 'csv',
                exportOptions: {
                    columns: [0, 1, 2]
                }
            },
            {
                extend: 'pdf',
                exportOptions: {
                    columns: [0, 1, 2]
                }
            }
        ],
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
                    idRow = row['id']
                    return `<a class="btn btn-warning" href="https://localhost:44321/Product/Edit/${idRow}">Edit</a>
                     <button onclick="detailProduct('https://localhost:44318/api/Product/${idRow}')" type="button" class="btn btn-info" data-toggle="modal" data-target="#modalDetails">Detail</button>
                    <a class="btn btn-danger" href="https://localhost:44321/Product/Delete/${idRow}">Delete</a>`
                }
            }
        ]
    });
});

function detailProduct(urlDetails) {
    $.ajax({
        url: urlDetails
    }).done((result) => {
        console.log(result.data);
        let dataDetails = result.data;
        inpId = `<input value="${dataDetails.id}" type="text" readonly class="form-control">`;
        inpName = `<input value="${dataDetails.name}" type="text" readonly class="form-control">`;
        inpSupName = `<input value="${dataDetails.suppliers.name}" type="text" readonly class="form-control">`;
        $("#inpId").html(inpId);
        $("#inpName").html(inpName);
        $("#inpSupName").html(inpSupName);
    }).fail((error) => {

    });
}
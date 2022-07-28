$(document).ready(function () {
    $('#tableSupplier').DataTable({
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'copy',
                exportOptions: {
                    columns: [0, 1]
                }
            },
            {
                extend: 'excel',
                exportOptions: {
                    columns: [0, 1]
                }
            },
            {
                extend: 'csv',
                exportOptions: {
                    columns: [0, 1]
                }
            },
            {
                extend: 'pdf',
                exportOptions: {
                    columns: [0, 1]
                }
            }
        ],
        "ajax": {
            "url": "https://localhost:44318/api/Supplier",
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
                data: null,
                orderable: false,
                render: function (data, type, row) {
                    idRow = row['id']
                    return `<button onclick="EditSupplier('https://localhost:44318/api/Supplier/${idRow}')" type="button" class="btn btn-warning" data-toggle="modal" data-target="#modalEdit">Edit</button>
                     <button onclick="detailSupplier('https://localhost:44318/api/Supplier/${idRow}')" type="button" class="btn btn-info" data-toggle="modal" data-target="#modalDetails">Detail</button>
                    <a class="btn btn-danger" href="https://localhost:44321/Supplier/Delete/${idRow}">Delete</a>`
                }
            }
        ]
    });

    var forms = document.getElementsByClassName('needs-validation');
    var validation = Array.prototype.filter.call(forms, function (form) {
        form.addEventListener('submit', function (event) {
            if (form.checkValidity() === false) {
                event.preventDefault();
                event.stopPropagation();
            } else {
                event.preventDefault();
                let objC = {};
                objC.name = $("#supplierNameCreate").val();

                console.log(objC);

                //Create
                $.ajax({
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    url: "https://localhost:44318/api/Supplier",
                    type: "POST",
                    dataType: "json",
                    data: JSON.stringify(objC),
                    success: function (data) {
                        $("#tableSupplier").DataTable().ajax.reload();
                        $('#modalCreate').modal('hide');
                        Swal.fire({
                            icon: 'success',
                            text: 'Data has been saved'
                        })
                    },
                    error: function (errormessage) {
                        Swal.fire({
                            icon: 'error',
                            title: 'Oops...',
                            text: 'Error Code ' + errormessage.responseJSON.status + ' With ' + errormessage.responseJSON.title
                        })

                    }
                });

                //Edit
                let objE = {};
                objE.id = parseInt($("#supplierIdEdit").val());
                objE.name = $("#supplierNameEdit").val();

                console.log(objE);

                $.ajax({
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    url: "https://localhost:44318/api/Supplier",
                    type: "PUT",
                    dataType: "json",
                    data: JSON.stringify(objE),
                    success: function (data) {
                        $("#tableSupplier").DataTable().ajax.reload();
                        $('#modalEdit').modal('hide');
                        Swal.fire({
                            icon: 'success',
                            text: 'Data has been saved'
                        })
                    },
                    error: function (errormessage) {
                        console.log(errormessage)
                        Swal.fire({
                            icon: 'error',
                            title: 'Oops...',
                            text: 'Error Code ' + errormessage.responseJSON.status + ' With ' + errormessage.responseJSON.title
                        })

                    }
                });
            }
            form.classList.add('was-validated');
        }, false);
    });
});

function detailSupplier(urlDetails) {
    $.ajax({
        url: urlDetails
    }).done((result) => {
        console.log(result.data);
        let dataDetails = result.data;
        inpId = `<input value="${dataDetails.id}" type="text" readonly class="form-control">`;
        inpName = `<input value="${dataDetails.name}" type="text" readonly class="form-control">`;
        $("#inpId").html(inpId);
        $("#inpName").html(inpName);
    }).fail((error) => {

    });
}

function EditSupplier(urlDetails) {
    $.ajax({
        url: urlDetails
    }).done((result) => {
        let dataDetails = result.data;
        console.log(dataDetails);
        text1 = `<label for="supplierIdEdit">Supplier Id</label>
              <input value="${dataDetails.id}" type="text" class="form-control" id="supplierIdEdit" readonly>`;
        text2 = `<label for="supplierNameEdit">Supplier Name</label>
              <input value="${dataDetails.name}" type="text" class="form-control" id="supplierNameEdit" placeholder="Supplier name" required>
              <div class="valid-feedback">
                Looks good!
              </div>
              <div class="invalid-feedback">
                Please insert Supplier name.
              </div>`;
        $("#suppIdEdit").html(text1);
        $("#suppNameEdit").html(text2);
    }).fail((error) => {

    });
}
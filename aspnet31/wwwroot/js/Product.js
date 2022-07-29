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
                    return meta.row + 1;
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
                    return `<button onclick="EditProduct('https://localhost:44318/api/Product/${idRow}')" type="button" class="btn btn-warning" data-toggle="modal" data-target="#modalEditPro">Edit</button>
                     <button onclick="detailProduct('https://localhost:44318/api/Product/${idRow}')" type="button" class="btn btn-info" data-toggle="modal" data-target="#modalDetails">Detail</button>
                     <button onclick="deleteProduct('https://localhost:44318/api/Product/${idRow}')" type="button" class="btn btn-danger">Delete</button>`
                }
            }
        ]
    });
    callCreateButton();
    var forms = document.getElementsByClassName('needs-validation-createProduct');
    var validation = Array.prototype.filter.call(forms, function (form) {
        form.addEventListener('submit', function (event) {
            if (form.checkValidity() === false) {
                event.preventDefault();
                event.stopPropagation();
            } else {
                event.preventDefault();
                let objCPro = {};
                objCPro.name = $("#productNameCreate").val();
                objCPro.supplierId = parseInt($("#supplierDDCreate").val());

                console.log(objCPro);

                //Create
                $.ajax({
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    url: "https://localhost:44318/api/Product",
                    type: "POST",
                    dataType: "json",
                    data: JSON.stringify(objCPro),
                    success: function (data) {
                        $("#tableProduct").DataTable().ajax.reload();
                        $('#modalCreatePro').modal('hide');
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
            }
            form.classList.add('was-validated');
        }, false);
    });

    var forms = document.getElementsByClassName('needs-validation-editProduct');
    var validation = Array.prototype.filter.call(forms, function (form) {
        form.addEventListener('submit', function (event) {
            if (form.checkValidity() === false) {
                event.preventDefault();
                event.stopPropagation();
            } else {
                event.preventDefault();

                //Edit
                let objEPro = {};
                objEPro.id = parseInt($("#productIdEdit").val());
                objEPro.name = $("#productNameEdit").val();
                objEPro.suppliers = {
                    id: parseInt($("#supplierDDEdit").val()),
                    name: $("#supplierDDEdit option:selected").html()
                };
                objEPro.supplierId = parseInt($("#supplierDDEdit").val());

                console.log(objEPro);

                $.ajax({
                    headers: {
                        'Accept': 'text/plain',
                        'Content-Type': 'application/json'
                    },
                    url: "https://localhost:44318/api/Product",
                    type: "PUT",
                    dataType: "json",
                    data: JSON.stringify(objEPro),
                    success: function (data) {
                        $("#tableProduct").DataTable().ajax.reload();
                        $('#modalEditPro').modal('hide');
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

function deleteProduct(urlDetails) {
    $.ajax({
        url: urlDetails
    }).done((result) => {
        console.log(result.data);
        let dataDetails = result.data;
        const swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-success',
                cancelButton: 'btn btn-danger'
            },
            buttonsStyling: false
        })

        swalWithBootstrapButtons.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes, delete it!',
            cancelButtonText: 'No, cancel!',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                let objDPro = {};
                objDPro.id = parseInt(dataDetails.id);
                objDPro.name = dataDetails.name;
                objDPro.suppliers = {
                    id: parseInt(dataDetails.supplierId),
                    name: dataDetails.suppliers.name
                };
                objDPro.supplierId = parseInt(dataDetails.supplierId);

                console.log(objDPro);

                $.ajax({
                    headers: {
                        'Accept': 'text/plain',
                        'Content-Type': 'application/json'
                    },
                    url: "https://localhost:44318/api/Product",
                    type: "Delete",
                    dataType: "json",
                    data: JSON.stringify(objDPro),
                    success: function (data) {
                        $("#tableProduct").DataTable().ajax.reload();
                        $('#modalDelete').modal('hide');
                        swalWithBootstrapButtons.fire(
                            'Deleted!',
                            'Your file has been deleted.',
                            'success'
                        )
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
            } else if (
                /* Read more about handling dismissals below */
                result.dismiss === Swal.DismissReason.cancel
            ) {
                swalWithBootstrapButtons.fire(
                    'Cancelled',
                    'Your data is safe, Have a Nice day! :)',
                    'error'
                )
            }
        })
    }).fail((error) => {

    });
    
}

function EditProduct(urlDetails) {
    $.ajax({
        url: urlDetails
    }).done((result) => {
        console.log(result.data);
        let dataDetails = result.data;
        editName = `<label for="productNameEdit">Product Name</label>
                 <input value="${dataDetails.name}" type="text" class="form-control" id="productNameEdit" placeholder="Product name" required>
                 <div class="valid-feedback">
                   Looks good!
                 </div>
                 <div class="invalid-feedback">
                   Please insert Product name.
                 </div>`;
        editId = `<label for="productIdEdit">Product Id</label>
                 <input value="${dataDetails.id}" type="text" class="form-control" id="productIdEdit" readonly>
                 <input value="${dataDetails.supplierId}" type="hidden" class="form-control" id="suppIdEditPro" readonly>`;
        $("#proIdEdit").html(editId);
        $("#proNameEdit").html(editName);
        getSupplier("https://localhost:44318/api/Supplier/", result.data);
    }).fail((error) => {

    });
}

function getSupplier(urlSupplier, data) {
    $.ajax({
        url: urlSupplier 
    }).done((result) => {
        console.log(result.data);
        console.log(data);
        let textSDD = `<option>~Select Supplier Name~</option>`;
        $.each(result.data, function (key, val) {
            if (val.name == data.suppliers.name) {
                textSDD += `<option selected value="${val.id}">${val.name}</option>`;
            } else {
                textSDD += `<option value="${val.id}">${val.name}</option>`;
            }
        })
        $("#supplierDDEdit").html(textSDD);
    }).fail((error) => {

    });
}

function callCreateButton() {
    text = `<button onclick="CreateProduct()" type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalCreatePro">Create</button>`;
    $("#createButton").html(text);
}

function CreateProduct() {
    $.ajax({
        url: "https://localhost:44318/api/Supplier/"
    }).done((result) => {
        let textSDD = `<option selected>~Select Supplier Name~</option>`;
        $.each(result.data, function (key, val) {
            textSDD += `<option value="${val.id}">${val.name}</option>`;
        })
        $("#supplierDDCreate").html(textSDD);
    }).fail((error) => {

    });
}

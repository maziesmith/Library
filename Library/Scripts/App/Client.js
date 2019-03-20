$(document).ready(function () {
    $("#clientTable").DataTable({
        ajax: {
            url: '/Client/GetClients',
            type: 'GET',
            dataSrc: ""
        }, columns:
            [
                { data: "Name" },
                { data: "City" },
                { data: "Address" },
                { data: "Phone" },
                {
                    data: "Id", render: function (data) {
                        return `<div class="buttonHolder btn-group">
                                        <button type="button" onclick="EditClient(` + data + `);" class='btn btn-primary'>Edit</button>
                                        <button type="button" onclick="DetailsClient(` + data + `);" class="btn btn-info">Details</button>
                                        <button type="button" onclick="DeleteClient(`+ data + `, this);" class="btn btn-danger delete"><span class="glyphicon glyphicon-remove" />Delete</button>
                                    </div>`;
                    }

                }
            ]


    })
    $("#NewCliModal").on('hidden.bs.modal', function () {
        $("#Name").val("");
        $("#City").val("");
        $("#Address").val("");
        $("#Id").val("");
        $("#Phone").val("");
    });

})
function Error(data) {
    console.log(data.errors);

}

function AddedNew(data) {
    console.log(data);

    if (data.success == false) { }
    else {
        $("#NewCliModal").modal("hide");
        $("#clientTable").DataTable().ajax.reload();
    }

}

function AddNewClient() {
    $("#NewCliModal").modal("show");
    $("#NewCliModal").on('hidden.bs.modal', function () {
        $("#Name").val("");
        $("#City").val("");
        $("#Address").val("");
        $("#Id").val("");
        $("#Phone").val("");
    });
}

function DetailsClient(id) {
    $.ajax({
        type: "GET",
        url: '/Client/Details/' + id,
        success: function (data) {
            $("#DetCliModal").modal("show");
            $("#ClientName").html(data.Name);
            $("#ClientCity").html(data.City);
            $("#ClientAddress").html(data.Address);
            $("#ClientPhone").html(data.Phone);
        },
    })
}

function EditClient(id) {
    $.ajax({
        type: "GET",
        url: '/Client/Edit/' + id,
        success: function (data) {
            console.log(data);
            $("#NewCliModal").modal("show");
            $("#Id").val(data.Id);
            $("#Name").val(data.Name);
            $("#City").val(data.City);
            $("#Address").val(data.Address);
            $("#Phone").val(data.Phone);
        }
    });
}

function DeleteClient(id, input) {
    var tr = input.parentNode.parentNode.parentNode;
    tr.classList.add("selected");
    var Con = confirm("Are you sure?");
    if (Con == true) {
        $.ajax({
            type: "GET",
            url: '/Client/Delete/' + id,
            success: function (data) {
                $(".selected").remove();
                $("#clientTable").DataTable().ajax.reload();

            },
            error: function (data) {
                $(".selected").removeClass("selected");
            }
        });
    }

}

$(document).ready(function () {
    $("#publisherTable").DataTable({
        ajax: {
            url: '/Publisher/GetPublishers',
            type: 'GET',
            dataSrc: ""
        }, columns:
            [
                { data: "Name" },
                { data: "Country" },
                { data: "BookNr" },
                {
                    data: "Id", render: function (data) {
                        return `<div class="buttonHolder btn-group">
                                        <button type="button" onclick="EditPublisher(` + data + `);" class='btn btn-primary'>Edit</button>
                                        <button type="button" onclick="DetailsPublisher(` + data + `);" class="btn btn-info">Details</button>
                                        <button type="button" onclick="DeletePublisher(`+ data + `, this);" class="btn btn-danger delete"><span class="glyphicon glyphicon-remove" />Delete</button>
                                    </div>`;
                    }
                    
                }
            ]


    })
    $("#NewPubModal").on('hidden.bs.modal', function () {
        $("#Name").val("");
        $("#Country").val("");
        $("#BookNr").val("");
        $("#Id").val("");
    });

})
function Error(data) {
    console.log(data.errors);

}

function AddedNew(data) {
    console.log(data);

    if (data.success == false) { }
    else {
        $("#NewPubModal").modal("hide");
        $("#publisherTable").DataTable().ajax.reload();
    }

}

function AddNewPublisher() {
    $("#NewPubModal").modal("show");
    $("#NewPubModal").on('hidden.bs.modal', function () {
        $("#Name").val("");
        $("#Country").val("");
        $("#BookNr").val("");
        $("#Id").val("");
    });
}

function DetailsPublisher(id) {
    $.ajax({
        type: "GET",
        url: '/Publisher/Details/' + id,
        success: function (data) {
            $("#DetPubModal").modal("show");
            $("#PublisherName").html(data.Name);
            $("#PublisherCountry").html(data.Country);
            $("#PublisherBookNr").html(data.BookNr);
        },
    })
}

function EditPublisher(id) {
    $.ajax({
        type: "GET",
        url: '/Publisher/Edit/' + id,
        success: function (data) {
            console.log(data);
            $("#NewPubModal").modal("show");
            $("#Id").val(data.Id);
            $("#Name").val(data.Name);
            $("#Country").val(data.Country);
        }
    });
}

function DeletePublisher(id, input) {
    var tr = input.parentNode.parentNode.parentNode;
    tr.classList.add("selected");
    var Con = confirm("Are you sure?");
    if (Con == true) {
        $.ajax({
            type: "GET",
            url: '/Publisher/Delete/' + id,
            success: function (data) {
                $(".selected").remove();
                $("#publisherTable").DataTable().ajax.reload();

            },
            error: function (data) {
                $(".selected").removeClass("selected");
            }
        });
    }

}

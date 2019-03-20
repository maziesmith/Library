
$(document).ready(function () {
    $("#table-book").DataTable({
        ajax: {
            url: '/Book/GetBooks',
            type: "GET",
            dataSrc: ""
        }, columns:
            [
            
                { data: "Title" },
                { data: "YearOfIssue" },
                { data: "NumberOfPages" },
                { data: "Publisher" },
                { data: "BookNr" },
                {
                    data: "Id", render: function (data) {
                        return `<div class="buttonHolder btn-group">
                                        <button type="button" onclick="EditBook(` + data + `);" class='btn btn-primary'>Edit</button>
                                        <button type="button" onclick="DetailsBook(` + data + `);" class='btn btn-info'>Details</button>
                                        <button type="button" onclick="DeleteBook(` + data + `, this);" class='btn btn-danger delete'>Delete</button>
                                    </div>`;

                    }
                }

            ]
    })

    $("#NewBookModal").on('hidden.bs.modal', function () {
        $("#Title").val("");
        $("#YearOfIssue").val("");
        $("#NumberOfPages").val("");
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
        $("#NewBookModal").modal("hide");
        $("#table-book").DataTable().ajax.reload();
    }
}

function AddNewBook() {
    $("#NewBookModal").modal("show");
    $("#NewBookModal").on('hidden.bs.modal', function () {
        $("#Title").val("");
        $("#YearOfIssue").val("");
        $("#NumberOfPages").val("");
        $("#Id").val("");
    });
}

function DetailsBook(id) {
    $.ajax({
        type: "GET",
        url: '/Book/Details/' + id,
        success: function (data) {
            $("#DetBookModal").modal("show");
            $("#BookTitle").html(data.Title);
            $("#BookYearOfIssue").html(data.YearOfIssue);
            $("#BookNrOfPages").html(data.NumberOfPages);
            $("#BookNr").html(data.BookNr);
        },
    })
}

function EditBook(id) {
    $.ajax({
        type: "GET",
        url: '/Book/Edit/' + id,
        success: function (data) {
            console.log(data);
            $("#NewBookModal").modal("show");
            $("#Title").val(data.Title);
            $("#YearOfIssue").val(data.YearOfIssue);
            $("#NumberOfPages").val(data.NumberOfPages);
            $("#Id").val(id);
        }
    });
}

function DeleteBook(id, input) {
    var tr = input.parentNode.parentNode.parentNode;
    tr.classList.add("selected");
    console.log(tr);
    var con = confirm('Are you sure?');
    if (con == true) {
        $.ajax({
            type: "GET",
            url: '/Book/Delete/' + id,
            success: function (data) {
                $(".selected").remove();
                $("#table-book").DataTable().ajax.reload();
            },
            error: function (data) {
                $(".selected").removeClass("selected");
            }
        });
    }

}
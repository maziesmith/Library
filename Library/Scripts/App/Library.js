
$(document).ready(function () {
    $("#table-library").DataTable({
        ajax: {
            url: '/Library/GetLibraries',
            type: "GET",
            dataSrc: ""
        }, columns:
            [
                { data: "Name" },
                { data: "City" },
                { data: "Address" },
                //{ data: "BookNr" },
                {
                    data: "Id", render: function (data) {
                        return `<div class="buttonHolder btn-group">
                                        <button type="button" onclick="Edit(` + data + `);" class='btn btn-primary'>Edit</button>
                                        <button type="button" onclick="DetailsLibrary(` + data + `);" class="btn btn-info">Details</button>
                                        <button type="button" onclick="DeleteLibrary(`+ data + `, this);" class="btn btn-danger delete"><span class="glyphicon glyphicon-remove" />Delete</button>
                                    </div>`;
                    }
                }
            ]
    })
})
        function Error(data) {
            debugger
    console.log(data.errors);
}
        function AddedNew(data) {
        console.log(data);



    if (data.success == false) {}
    else {
        $("#NewLibModal").modal("hide");
    $("#table-library").DataTable().ajax.reload();

  }

}
        function AddNewLibrary() {

        $("#NewLibModal").modal("show");
    $("#NewLibModal").on('hidden.bs.modal', function () {
        $("#Name").val("");
    $("#Address").val("");
    $("#City").val("");
    $("#Id").val("");

   
});

}
        $(document).ready(function () {
        $("#NewLibModal").on('hidden.bs.modal', function () {
            $("#Name").val("");
            $("#Address").val("");
            $("#City").val("");
            $("#Id").val("");
            });
        $("#DetLibModal").on('hidden.bs.modal', function () {
            $("#BookName").val("");
            $("#NrOfCopies").val(0);
            
        });
    })

        function DetailsLibrary(id) {
            $.ajax({

                type: "GET",
                url: '/Library/Details/' + id,
                success: function (data) {
                    $("#DetLibModal").modal("show");
                    $("#LibraryName").html(data.Name);
                    $("#LibraryCity").html(data.City);
                    $("#LibraryAddress").html(data.Address);
                    $("#LibraryBookNr").html(data.BookNr);
                    $("#LibraryId").val(id);
                    $("#LibraryBookTable").DataTable({
                        "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]],
                        ajax: {
                            url: '/Book/GetBooksForLibrary?LibraryID=' + id,
                            type: "GET",
                            dataSrc: ""
                        }, columns:
                            [

                                { data: "Title" },
                                { data: "YearOfIssue" },
                                { data: "BookNr" },
                                { data: "LendingsNr" },
                                {
                                    data: "Id", render: function (data) {
                                        return `<div class="buttonHolder btn-group">
                                        <button type="button" onclick="Add(` + data + `);" class='btn btn-primary' style="width: auto;">Add</button>
                                        <button type="button" onclick="DetailsBook(` + data + `);" class='btn btn-info' style="width: auto;">Details</button>
                                    </div>`;

                                    }

                                }

                            ]

                    });
                   
                    $("#LibraryBooks").DataTable({
                        "lengthMenu": [[2, -1], [2, "All"]],
                        ajax: {
                            url: '/Book/GetBooksInLibrary/' + id,
                            type: "GET",
                            dataSrc: ""
                        }, columns: [
                            { data: "Title" },
                            { data: "YearOfIssue" },
                            { data: "NumberOfPages" },
                            { data: "FK_Publisher" },
                            {
                                
                                data: "BookID", render: function (data) {
                                    return `<div class="buttonHolder btn-group">
                                    <button type="button" onclick="DeleteFromLibrary(` + data + `, this);" class="btn btn-danger delete" style="width: -webkit-fill-available;"><span class="glyphicon glyphicon-remove" />Delete</button>   
                                    </div>`;

                                }
                            }
                        ]
                    })
                },
                
            })
            $("#LibraryBookTable").dataTable().fnDestroy();
            $("#LibraryBooks").dataTable().fnDestroy();
        }

    function Edit(id) {
        $.ajax({
            type: "GET",
            url: '/Library/Edit/' + id,
            success: function (data) {
                console.log(data);
                $("#NewLibModal").modal("show");
                $("#Name").val(data.Name);
                $("#Address").val(data.Address);
                $("#City").val(data.City);
                $("#Id").val(data.Id);
            }
        });
    }

function DeleteLibrary(id, input) {
    var tr = input.parentNode.parentNode.parentNode;

    tr.classList.add("selected");
    console.log(tr);
    var Con = confirm("Are you sure?");
    if (Con == true) {
        $.ajax({
            type: 'GET',
            url: '/Library/Delete/' + id,
            success: function (data) {
                $(".selected").remove();
                $('#table-library').DataTable().ajax.reload();
            },
            error: function (data) {
                $(".selected").removeClass("selected");
            }
        });
    }
}
function AddBookLib() {
    //let id = $("#LibraryId").val();
    $.ajax({
        type: "GET",
        url: "/Book/GetBooks/",
        success: function (data) {
            $("#BookLibModal").modal("show");
            
        }
    });
}

function DetailsBook(id) {
    $.ajax({
        type: "GET",
        url: '/Book/Details/' + id,
        success: function (data) {
            console.log(data);
            $("#DetaBookModal").modal("show");
            $("#TitleBook").html(data.Title);
            $("#YearOfIssueBook").html(data.YearOfIssue);
            $("#NrOfPagesBook").html(data.NumberOfPages);
            $("#NrBook").html(data.BookNr);
          
        },
    })
}
function Add(id) {
   // let id = $("#LibraryId").val();
    let LibId = $("#LibraryId").val();
    $.ajax({
        type: "GET",
        cache: false,
        url: '/Library/AddBook/' + id + "?LibId=" + LibId,
        success: function (data) {
            $('#LibraryBookTable > Id').append(data);
            //$(Book.Title).html(data.Title);
            //$("#NrBook").html(data.BookNr);
            alert("Knigata so id=" + id + " e dodadena!");
            
        },
        error: function (data) {
            alert("Error");
        }
    })
}
function AddNewBook() {
    //$.ajax({
    //    url: '/Book/Index.cshtml',
    //    dataType: 'text',
    //    success: function (data) {
            $("#NewBookModal").modal("show");
    //    }
    //});
}

function DeleteFromLibrary(id, input) {
    var tr = input.parentNode.parentNode.parentNode;
    tr.classList.add("selected");
    console.log(tr);
    var con = confirm('Are you sure?');
    if (con == true) {
        $.ajax({
            type: "GET",
            url: '/Library/DeleteBookCopy/' + id,
            success: function (data) {
                $(".selected").remove();
            },
            error: function (data) {
                $(".selected").removeClass("selected");
                alert("Ne se izbrisa");
            }
        });
    }
}
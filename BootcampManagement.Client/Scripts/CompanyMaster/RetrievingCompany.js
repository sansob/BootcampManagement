$(document).ready(function () {
    LoadIndexCompany();
    $('#table').DataTable({
        "ajax": LoadIndexCompany()
    })
    ClearScreen();
})

function LoadIndexCompany() {
    debugger;
    $.ajax({
        type: "GET",
        url: "http://localhost:12280/api/Companies",
        async: false,
        dataType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.Address + '</td>';
                html += '<td>' + val.Village.Name + '</td>';
                html += '<td> <a href="#" class="fa fa-pencil" onclick="return GetById(' + val.Id + ')"></a>';
                html += ' | <a href="#" class="fa fa-trash" onclick="return Delete(' + val.Id + ')"></a> </td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}

function Save() {
    var company = new Object();
    company.name = $('#Name').val();
    company.address = $('#Address').val();
    company.Village_Id = $('#District').val();
    $.ajax({
        url: 'http://localhost:12280/api/Companies',
        type: 'POST',
        dataType: 'json',
        data: company,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    window.location.href = '/Companies/Index/';
                });
            LoadIndexCompany();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
}

function Edit() {
    var company = new Object();
    company.id = $('#Id').val();
    company.name = $('#Name').val();
    company.address = $('#Address').val();
    company.Village_Id = $('#District').val();
    $.ajax({
        url: "http://localhost:12280/api/Companies/" + $('#Id').val(),
        data: company,
        type: "PUT",
        dataType: "json",
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    window.location.href = '/Companies/Index/';
                });
            LoadIndexCompany();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
}

function GetById(Id) {
    $.ajax({
        url: "http://localhost:12280/api/Companies/" + Id,
        type: "GET",
        dataType: "json",
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            $('#Address').val(result.Address);
            $('#Village_Id').val(result.Village_Id);

            $('#myModal').modal('show');
            $('#Update').show();
            $('#Save').hide();
        }
    })
}

function Delete() {
    swal({
        title: "Are you sure?",
        text: "You will not be able to recover this imaginary file!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        closeOnConfirm: false
    }, function () {
        $.ajax({
            url: "http://localhost:12280/api/Companies/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        window.location.href = '/Companies/Index/';
                    });
            },
            error: function (response) {
                swal("Oops", "We couldn't connect to the server!", "error");
            }
        });
    });
}

function ClearScreen() {
    $('#Name').val('');
    $('#Address').val('');
    $('#Village').val(0);
    $('#Id').val('');
    $('#Update').hide();
    $('#Save').show();
}

var Villages = []
function LoadVillage(element) {
    if (Villages.length == 0) {
        $.ajax({
            type: "GET",
            url: "http://localhost:12280/api/Villages",
            success: function (data) {
                Villages = data;
                renderVillage(element);
            }
        })
    }
    else {
        renderVillage(element);
    }
}

function renderVillage(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Village'));
    $.each(Villages, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.Name));
    })
}
LoadVillage($('#Village'));
ClearScreen();
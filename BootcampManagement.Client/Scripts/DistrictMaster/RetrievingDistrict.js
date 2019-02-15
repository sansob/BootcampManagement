$(document).ready(function () {
    LoadIndexDistrict();
    $('#table').DataTable({
        "ajax": LoadIndexDistrict()
    })
    ClearScreen();
})

function LoadIndexDistrict() {
    $.ajax({
        type: "GET",
        url: "http://localhost:12280/api/Districts",
        async: false,
        dataType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.Regency.Name + '</td>';
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
    var district = new Object();
    district.name = $('#Name').val();
    district.Regency_Id = $('#Regency').val();
    $.ajax({
        url: 'http://localhost:12280/api/Districts',
        type: 'POST',
        dataType: 'json',
        data: district,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    window.location.href = '/Districts/Index/';
                });
            LoadIndexDistrict();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
}

function Edit() {
    var district = new Object();
    district.id = $('#Id').val();
    district.name = $('#Name').val();
    district.Regency_Id = $('#Regency').val();
    $.ajax({
        url: "http://localhost:12280/api/Districts/" + $('#Id').val(),
        data: district,
        type: "PUT",
        dataType: "json",
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    window.location.href = '/Districts/Index/';
                });
            LoadIndexDistrict();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
}

function GetById(Id) {
    $.ajax({
        url: "http://localhost:12280/api/Districts/" + Id,
        type: "GET",
        dataType: "json",
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            $('#Regency').val(result.Regency_Id);

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
            url: "http://localhost:12280/api/Districts/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        window.location.href = '/Districts/Index/';
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
    $('#Regency').val(0);
    $('#Id').val('');
    $('#Update').hide();
    $('#Save').show();
}

var Regencies = []
function LoadRegency(element) {
    if (Regencies.length == 0) {
        $.ajax({
            type: "GET",
            url: "http://localhost:12280/api/Regencies",
            success: function (data) {
                Regencies = data;
                renderRegency(element);
            }
        })
    }
    else {
        renderRegency(element);
    }
}

function renderRegency(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Regency'));
    $.each(Regencies, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.Name));
    })
}
LoadRegency($('#Regency'));
ClearScreen();
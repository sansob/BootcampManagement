﻿$(document).ready(function () {
    LoadIndexVillage();
    $('#table').DataTable({
        "ajax": LoadIndexVillage()
    })
    ClearScreen();
})

function LoadIndexVillage() {
    $.ajax({
        type: "GET",
        url: "http://localhost:12280/api/Villages",
        async: false,
        dataType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.District.Name + '</td>';
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
    var village = new Object();
    village.name = $('#Name').val();
    village.District_Id = $('#District').val();
    $.ajax({
        url: 'http://localhost:12280/api/Villages',
        type: 'POST',
        dataType: 'json',
        data: village,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    window.location.href = '/Villages/Index/';
                });
            LoadIndexVillage();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
}

function Edit() {
    var village = new Object();
    village.id = $('#Id').val();
    village.name = $('#Name').val();
    village.District_Id = $('#District').val();
    $.ajax({
        url: "http://localhost:12280/api/Villages/" + $('#Id').val(),
        data: village,
        type: "PUT",
        dataType: "json",
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    window.location.href = '/Villages/Index/';
                });
            LoadIndexVillage();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
}

function GetById(Id) {
    $.ajax({
        url: "http://localhost:12280/api/Villages/" + Id,
        type: "GET",
        dataType: "json",
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            $('#District').val(result.District_Id);

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
            url: "http://localhost:12280/api/Villages/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        window.location.href = '/Villages/Index/';
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
    $('#District').val(0);
    $('#Id').val('');
    $('#Update').hide();
    $('#Save').show();
}

var Districts = []
function LoadDistrict(element) {
    if (Districts.length == 0) {
        $.ajax({
            type: "GET",
            url: "http://localhost:12280/api/Districts",
            success: function (data) {
                Districts = data;
                renderDistrict(element);
            }
        })
    }
    else {
        renderDistrict(element);
    }
}

function renderDistrict(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select District'));
    $.each(Districts, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.Name));
    })
}
LoadDistrict($('#District'));
ClearScreen();
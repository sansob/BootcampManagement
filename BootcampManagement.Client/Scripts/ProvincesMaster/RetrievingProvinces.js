﻿$(document).ready(function () {
    LoadIndexProvince();
    $('#table').DataTable({
        "ajax": LoadIndexProvince()
    });
})

function Save() {
    var province = new Object();
    province.name = $('#Name').val();
    $.ajax({
        url: "/Provinces/InsertOrUpdate/",
        data: province,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                window.location.href = '/Provinces/Index/';
            });
            LoadIndexProvince();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function LoadIndexProvince() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Provinces/LoadProvince/",
        dateType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';   
                html += '<td>' + val.Name + '</td>';
                html += '<td> <a href="#" class="fa fa-pencil" onclick="return GetById(' + val.Id + ')"></a>';
                html += ' | <a href="#" class="fa fa-trash" onclick="return Delete(' + val.Id + ')"></a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}

function Edit() {
    var province = new Object();
    province.id = $('#Id').val();
    province.name = $('#Name').val();
    $.ajax({
        url: "/Provinces/InsertOrUpdate/",
        data: province,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                window.location.href = '/Provinces/Index/';
            });
            LoadIndexProvince();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function GetById(Id) {
    $.ajax({
        url: "/Provinces/GetById/",
        type: "GET",
        dataType: "json",
        data: { id : Id },
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);

            $('#myModal').modal('show');
            $('#Update').show();
            $('#Save').hide();
        }
    })
}

function Delete(Id) {
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
            url: "/Provinces/Delete/",
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        window.location.href = '/Provinces/Index/';
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
    $('#Id').val('');
    $('#Update').hide();
    $('#Save').show();
}

function Validate() {
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        swal("Oops", "Please Insert Name", "error")
    } else if ($('#Id').val() == "") {
        Save();
    } else {
        Edit();
    }
}
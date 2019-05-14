$(document).ready(function () {
    LoadIndexRegency();
    $('#table').DataTable({
        "ajax": LoadIndexRegency()
    })
    ClearScreen();
})

function Save() {
    var regency = new Object();
    regency.name = $('#Name').val();
    regency.Province_Id = $('#Province').val();
    console.log(regency);
    $.ajax({
        url: '/Regencies/InsertOrUpdate/',
        type: 'POST',
        dataType: 'json',
        data: regency,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    window.location.href = '/Regencies/Index/';
                });
            LoadIndexRegency();
            $('#myModal').modal('hide');
            ClearScreen();
        },
        error: function () {
            $('#Update').hide();
            $('#Save').show();
        }
    });
};

function LoadIndexRegency() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Regencies/LoadRegency/",
        dateType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                $.ajax({
                    url: "/Provinces/GetById/",
                    data: { id: val.Province_Id },
                    success: function (result) {
                        html += '<tr>';
                        html += '<td>' + i + '</td>';
                        html += '<td>' + val.Name + '</td>';
                        html += '<td>' + result.Name + '</td>';
                        html += '<td> <a href="#" onclick="return GetById(' + val.Id + ')">Edit</a>';
                        html += ' | <a href="#" onclick="return Delete(' + val.Id + ')">Delete</a> </td>';
                        html += '</tr>';
                        i++;
                        $('.tbody').html(html);
                    }

                });

            });
        }
    });
}

function Edit() {
    var regency = new Object();
    regency.id = $('#Id').val();
    regency.name = $('#Name').val();
    regency.Province_Id = $('#Province').val();
    $.ajax({
        url: "/Regencies/InsertOrUpdate/",
        data: regency,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    window.location.href = '/Regencies/Index/';
                });
            LoadIndexRegency();
            $('#myModal').modal('hide');
            $('#Update').hide();
            $('#Save').show();
            ClearScreen();
        },
        error: function () {
            $('#Update').hide();
            $('#Save').show();
        }
    });
};

function GetById(Id) {
    $.ajax({
        url: "/Regencies/GetById/",
        type: "GET",
        data: { id: Id },
        dataType: "json",
        success: function (result) {
            console.log(result);
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            $('#Province').val(result.Province_Id);

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
            url: "/Regencies/Delete/",
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        window.location.href = '/Regencies/Index/';
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
    $('#Province').val(0);
    $('#Update').hide();
    $('#Save').show();
}

var Provinces = []
function LoadProvince(element) {
    if (Provinces.length == 0) {
        $.ajax({
            type: "GET",
            url: "/Provinces/LoadProvince/",
            success: function (data) {
                Provinces = data;
                renderProvince(element);
            }
        })
    }
    else {
        renderProvince(element);
    }
}

function renderProvince(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Province'));
    $.each(Provinces, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.Name));
    })
}
LoadProvince($('#Province'));
$('#Update').hide();
$('#Save').show();
ClearScreen();

function Validate() {
    debugger;
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        swal("Oops", "Please Insert Name", "error")
    } else if ($('#Province').val() == 0) {
        swal("Oops", "Please Choose Province", "error")
    } else if ($('#Id').val() == "") {
        Save();
    } else {
        Edit();
    }
}
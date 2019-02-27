$(function() {
    $('#startdate').datepicker({
        daysOfWeekDisabled: [0, 6]
    });
    $("#enddate").datepicker();
});

function getEndDate() {
    var day = moment($("#startdate").val(), 'MM/DD/YYYY');
   
    day.add(2, 'months');

    $("#enddate").val(day.format("MM/DD/YYYY"));
}

$(document).ready(function () {
    LoadIndexBatch();
    $('#table').DataTable({
        "ajax": LoadIndexBatch()
    })
})

function Save() {
    var batch = new Object();
    batch.name = $('#Name').val();
    batch.startdate = $('#startdate').val();
    batch.enddate = $('#enddate').val();
    $.ajax({
        url: 'http://localhost:12280/api/Batches',
        type: 'POST',
        dataType: 'json',
        data: batch,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    window.location.href = '/Batches/Index/';
                });
            LoadIndexBatch();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function LoadIndexBatch() {
    $.ajax({
        type: "GET",
        async: false,
        url: "http://localhost:12280/api/Batches",
        dateType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                StartDate = moment(val.StartDate).format('DD/MM/YYYY');
                EndDate = moment(val.EndDate).format('DD/MM/YYYY');
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + StartDate + '</td>';
                html += '<td>' + EndDate + '</td>';
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
    var batch = new Object();
    batch.id = $('#Id').val();
    batch.startdate = $('#startdate').val();
    batch.enddate = $('#enddate').val();
    $.ajax({
        url: "http://localhost:12280/api/Batches/" + $('#Id').val(),
        data: batch,
        type: "PUT",
        dataType: "json",
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    window.location.href = '/Batches/Index/';
                });
            LoadIndexBatch();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function GetById(Id) {
    $.ajax({
        url: "http://localhost:12280/api/Batches/" + Id,
        type: "GET",
        dataType: "json",
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
            url: "http://localhost:12280/api/Batches/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        window.location.href = '/Batches/Index/';
                    });
            },
            error: function (response) {
                swal("Oops", "We couldn't connect to the server!", "error");
            }
        });
    });
}

function ClearScreen() {
    $('#startdate').val('');
    $('#enddate').val('');
    $('#Id').val('');
    $('#Name').val('');
    $('#Update').hide();
    $('#Save').show();
}
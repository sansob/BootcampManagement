$(document).ready(function () {
    LoadIndexLesson();
    $('#table').DataTable({
        "ajax": LoadIndexLesson()
    })
})

function Save() {
    var lesson = new Object();
    lesson.name = $('#Name').val();
    $.ajax({
        url: '/Lesson/InsertOrUpdate/',
        type: 'POST',
        dataType: 'json',
        data: lesson,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                window.location.href = '/Lessons/Index/';
            });
            LoadIndexLesson();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function LoadIndexLesson() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Lessons/LoadLesson/",
        dateType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>'
                html += '<td>' + val.Name + '</td>';
                html += '<td> <a href="#" class="fa fa-pencil" onclick="return GetById(' + val.Id + ')"></a>';
                html += ' | <a href="#" class="fa fa-trash" onclick="return Delete(' + val.Id + ')"></a> </td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}

function Edit() {
    var lesson = new Object();
    lesson.id = $('#Id').val();
    lesson.name = $('#Name').val();
    $.ajax({
        url: "/Lessons/InsertOrUpdate",
        data: lesson,
        type: "PUT",
        dataType: "json",
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                window.location.href = '/Lessons/Index/';
            });
            LoadIndexLesson();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function GetById(Id) {
    $.ajax({
        url: "/Lessons/GetById/",
        type: "GET",
        data: { id : Id }, 
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
            url: "/Lessons/Delete",
            data: { id : Id },
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        window.location.href = '/Lessons/Index/';
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
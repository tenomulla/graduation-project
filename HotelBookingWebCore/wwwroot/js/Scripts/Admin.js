// On load function
$(document).ready(function () {
    ViewAllAdmin();
});

// View Admin list function
function ViewAllAdmin() {
    $.get("/Admin/GetAllAdmins", function (res) {
        var html = "";
        var pagin = "";
        for (var i = 0; i < res.length; i++) {
            html += '<tr>';
            html += '<td>' + res[i].id + '</td>';
            html += '<td>' + res[i].fullName + '</td>';
            html += '<td>' + res[i].userName + '</td>';
            html += '<td>' + res[i].userType + '</td>';
            html += '<td id="' + res[i].id +'" onclick="FetchUserById(this.id)"><i class="far fa-pen"></i></td>';
            html += '<td id="' + res[i].id +'" onclick="OpenDeleteModal(this.id)"><i class="far fa-trash-alt"></i></td>';
            html += '</tr>';
        }
        $('#Tbody_AdminList').html(html);
        pagin += '<i class="fas fa-angle-left btn1" ></i>';
        pagin += '<h4 class="btn2">1</h4>';
        pagin += '<h4 class="btn3">2</h4>';
        pagin += '<h4 class="btn4">3</h4>';
        pagin += '<h4 class="btn5">...</h4>';
        pagin += '<h4 class="btn6">13</h4>';
        pagin += '<i class="fas fa-angle-right btn7"></i>';
        $('.pagination').html(pagin);
    });
}

// Open Delete Admin Modal
function OpenDeleteModal(Id) {
    $('#UserId_del').val(Id);
    OpenModalFunction("deleteAdminModal");
}

// Delete Admin 
function DeleteAdmin() {
    var UserDeleteId = $('#UserId_del').val();
    $.get("/Admin/DeleteAdminById?UserId=" + UserDeleteId, function (res) {
        if (res == "Deleted") {
            toastr.success("Admin Deleted Successfully");
            CloseOpenedModal("deleteAdminModal");
            ViewAllAdmin();
        }
        else {
            toastr.error("Something went wrong", "Warning");
        }
    });
}

// Adding new user
function AddNewUser() {
    var data = {
        usertype: $('#status').val(),
        Sno: $('#id').val(),
        fullname: $('#name').val(),
        username: $('#username').val(),
        pass: $('#pass').val()
    };

    $.post("/Admin/AddNewUser", data, function (res) {
        if (res == "Added") {
            toastr.success("New User Created Successfully", "Message");
            ViewAllAdmin();
            CloseOpenedModal("addAdmin-modal");
        }
        else if (res == "Already") {
            toastr.error("User Name Already Existed", "Warning");
            $('#username').css("border", "1px solid red");
        }
        else {
            toastr.error("Something Went Wrong", "Warning");
        }
    });
}

// Fetching User by Id
function FetchUserById(Id) {
    $.get("/Admin/FetchUserById?Id=" + Id, function (res) {
        $('#id_edit').val(res.id);
        $('#status_edit').val(res.userType);
        $('#name_edit').val(res.fullName);
        $('#username_edit').val(res.userName);
        $('#pass_edit').val(res.password);
        OpenModalFunction("editAdmin-modal");
    });
}

// Updateing User
function UpdateAdmin() {
    var data = {
        id: $('#id_edit').val(),
        usertype: $('#status_edit').val(),
        fullname: $('#name_edit').val(),
        username: $('#username_edit').val(),
        password: $('#pass_edit').val()
    };

    $.post("/Admin/UpdateUserById", data, function (res) {
        if (res == "Updated") {
            toastr.success("User Updated Successfully", "Message");
            CloseOpenedModal("editAdmin-modal");
            ViewAllAdmin();
        }
        else {
            toastr.error("Something Went Wrong", "Warning");
        }
    });
}
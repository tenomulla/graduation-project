// On load function
$(document).ready(function () {
    ViewRoomList();
});

var fileValue = [];

$('#ImgFile').on("change", function () {
    var files = document.getElementById("ImgFile").files[0];
    fileValue.push(files);
});

// Edit
$('#ImgFile_edit').on("change", function () {
    var files = document.getElementById("ImgFile_edit").files[0];
    fileValue.push(files);
});

// View Room List function
function ViewRoomList() {
    $.get("/Room/GetAllRooms", function (res) {
        var html = "";
        var pagin = "";
        for (var i = 0; i < res.length; i++) {
            html += '<tr>';
            html += '<td>' + res[i].id + '</td>';
            html += '<td class="arabic" >' + res[i].name + '</td>';
            html += '<td>';
            for (var x = 0; x < res[i].pList.length; x++) {
                html += '<div class="price">' + res[i].pList[x].noOfRoom + '-' + res[i].pList[x].price +'</div>';
            }
            html += '</td>';
            html += '<td class="arabic" style="width: 29rem; padding: 10px; text-align: justify;">' + res[i].roomStory + '</td>';
            html += '<td id="' + res[i].id + '" onclick="FetchRoomListById(this.id)"><i class="far fa-pen"></i></td>';
            html += '<td id="' + res[i].id + '" onclick="OpenDeleteRoomModal(this.id)"><i class="far fa-trash-alt"></i></td>';
            html += '</tr>';
        }
        $('#TbodyRoomsList').html(html);
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
function OpenDeleteRoomModal(Id) {
    $('#Id_del').val(Id);
    OpenModalFunction("deleteRoomModal");
}

// Delete Room 
function DeleteRoom() {
    var RoomDeleteId = $('#Id_del').val();
    $.get("/Room/DeleteRoomById?Id=" + RoomDeleteId, function (res) {
        if (res == "Deleted") {
            toastr.success("Room Deleted Successfully","Success");
            CloseOpenedModal("deleteRoomModal");
            ViewRoomList();
        }
        else {
            toastr.error("Something went wrong", "Warning");
        }
    });
}

// Add New Room
function AddNewRoom(ImagePath) {
    var noOfRoom = [];
    var prices = [];
    $('.number').each(function () {
        noOfRoom.push($(this).text());
    });
    $('.hash').each(function () {
        prices.push($(this).val());
    });
    var noofPlayers = $('#noOfPlayers').val();
    var langauge = $('#language').val();
    var colorcode = $('#background1').val();
    var data = {
        name: $('#name').val(),
        roomStory: $('#roomStory').val(),
        noOfRoom: noOfRoom,
        price: prices,
        imagePath: ImagePath,
        NoofPlayers: noofPlayers,
        colorCode: colorcode,
        langauge: langauge
    };
    $.post("/Room/AddNewRoom", data, function (res) {
        if (res == "Added") {
            toastr.remove();
            toastr.success("New Room Added Successfully", "Success");
            CloseOpenedModal("addRoom-modal");
            ViewRoomList();
        }
        else {
            toastr.remove();
            toastr.error("Something Went Wrong", "Warning");
        }
    });
}

// Uploading File
function UploadImageFile() {
    var file = fileValue[0];
    if (file !== undefined) {
        var formData = new FormData();
        formData.append(file.name, file);
        $.ajax({
            url: "/Room/AddNewImage",
            type: "POST",
            cache: false,
            contentType: false,
            processData: false,
            data: formData,
            success: function (res) {
                AddNewRoom(res);
            }
        });
    }
    else {
        toastr.error("Make sure you have selected a valid file", "Warning");
    }
}

function UploadImageFileForUpdate() {
    var file = fileValue[0];
    if (file !== undefined) {
        var formData = new FormData();
        formData.append(file.name, file);
        $.ajax({
            url: "/Room/AddNewImage",
            type: "POST",
            cache: false,
            contentType: false,
            processData: false,
            data: formData,
            success: function (res) {
                UpdateRoom(res);
            }
        });
    }
    else {
        toastr.error("Make sure you have selected a valid file", "Warning");
    }
}

// Open Update Room Function 
function FetchRoomListById(Id) {
    $.get("/Room/FetchRoomListById?Id=" + Id, function (res) {
        var priceFields = '';
        console.log(res);
        $('#Id_edit').val(res.id);
        $('#name_edit').val(res.name);
        $('#roomStory_edit').val(res.roomStory);
        $('#noOfPlayers_edit').val(res.noofPlayers);
        $('#language_edit').val(res.langauge);
        $('#background2').val(res.colorCode);
        var x = 2;
        for (var i = 0; i < res.pList.length; i++) {
            priceFields += '<div class="hash-number"><span class="number">' + x + '</span><input id="room' + x + '_edit" value="' + res.pList[i].price + '" class="hash" type="text"></div>';
            x++;
        }
        $('#editPortion').html(priceFields);
        $('#Id_edit').attr("disabled", true);
        $('#Id_edit').css("cursor", "no-drop");
        OpenModalFunction("editRoom-modal");
    });
}

// Updateing Room
function UpdateRoom(ImagePath) {
    var noOfRoom = [];
    var prices = [];
    $('#editPortion .hash-number span.number').each(function () {
        noOfRoom.push($(this).text());
    });
    $('#editPortion .hash-number input.hash').each(function () {
        prices.push($(this).val());
    });

    var noofPlayers = $('#noOfPlayers_edit').val();
    var langauge = $('#language_edit').val();
    var colorcode = $('#background2').val();
    var data = {
        id: $('#Id_edit').val(),
        name: $('#name_edit').val(),
        roomStory: $('#roomStory_edit').val(),
        noOfRoom: noOfRoom,
        price: prices,
        imagePath: ImagePath,
        ColorCode: colorcode,
        NoofPlayers: noofPlayers,
        Language: langauge
    };
    $.post("/Room/UpdateRoom", data, function (res) {
        if (res == "Updated") {
            toastr.remove();
            toastr.success("Room Updated Successfully", "Success");
            CloseOpenedModal("editRoom-modal");
            ViewRoomList();
        }
        else {
            toastr.remove();
            toastr.error("Something Went Wrong", "Warning");
        }
    });
}
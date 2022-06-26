$(document).ready(function (res) {
    GetTodaysBooking();
    GetTomorrowsBooking();
});

// View Todays Booking
function GetTodaysBooking() {
    $.get("/Home/GetTodaysBooking", function (res) {
        var html = "";
        var pagin = "";
        for (var i = 0; i < res.length; i++) {
            html += '<tr>';
            html += '<td>' + res[i].id + '</td>';
            html += '<td>' + res[i].room + '</td>';
            html += '<td>' + moment(res[i].bookedDate).format("YYYY-MM-DD") + '</td>';
            html += '<td>' + res[i].time + '</td>';
            html += '<td>' + res[i].guestName + '</td>';
            html += '<td>' + res[i].phoneNo + '</td>';
            html += '<td>' + res[i].size + '</td>';
            html += '<td>';
            html += '<select onchange="ChangeStatus(this.id)" id="' + res[i].id + '">';
            html += '<option class="blue" value="' + res[i].status + '" selected>' + res[i].status + '</option>';
            html += '<option class="blue" value="Confirmed">Confirmed</option>';
            html += '<option value="Select Status" disabled>Select Status</option>';
            html += '<option class="red" value="UnConfirmed">UnConfirmed</option>';
            html += '<option class="green" value="Paid">Paid</option>';
            html += '<option class="grey" value="Canceled">Canceled</option>';
            html += '</select>';
            html += '</td>';
            html += '<td>' + res[i].total + '</td>';
            html += '<td id="' + res[i].id + '" onclick="OpenBookingDetailModal(this.id)"><i class="fas fa-ellipsis-h"></i></td>';
            html += '</tr>';
        }
        $('#TbodyTodaysBooking').html(html);
        //$('#status_show_edit').val($('#status').val());
    });
}
// View Tomorrows Booking
function GetTomorrowsBooking() {
    $.get("/Home/GetTomorrowsBooking", function (res) {
        var html = "";
        var pagin = "";
        for (var i = 0; i < res.length; i++) {
            html += '<tr>';
            html += '<td>' + res[i].id + '</td>';
            html += '<td>' + res[i].room + '</td>';
            html += '<td>' + moment(res[i].bookedDate).format("YYYY-MM-DD") + '</td>';
            html += '<td>' + res[i].time + '</td>';
            html += '<td>' + res[i].guestName + '</td>';
            html += '<td>' + res[i].phoneNo + '</td>';
            html += '<td>' + res[i].size + '</td>';
            html += '<td>';
            html += '<select onchange="ChangeStatus(this.id)" id="' + res[i].id + '_' + res[i].status + '">';
            html += '<option class="blue" value="' + res[i].status + '" selected>' + res[i].status + '</option>';
            html += '<option class="blue" value="Confirmed">Confirmed</option>';
            html += '<option value="Select Status" disabled>Select Status</option>';
            html += '<option class="red" value="UnConfirmed">UnConfirmed</option>';
            html += '<option class="green" value="Paid">Paid</option>';
            html += '<option class="grey" value="Canceled">Canceled</option>';
            html += '</select>';
            html += '</td>';
            html += '<td>' + res[i].total + '</td>';
            html += '<td id="' + res[i].id + '" onclick="OpenBookingDetailModal(this.id)"><i class="fas fa-ellipsis-h"></i></td>';
            html += '</tr>';
        }
        $('#TomorrowsBookingTbody').html(html);
    });
}

//Open Booking Modal
function OpenBookingDetailModal(BookingId) {
    //OpenModalFunction("bookingListModal");
    $.get("/Home/GetBookingById?BookingId=" + BookingId, function (res) {
        $('#show_ModalBooking').html(res);
        $('#status_show').val($('#StatusValue').val());
        OpenModalFunction("bookingModal");
    });
}

//Update Booking
function UpdateBookingDetails() {
    var data = {
        guestName: $('#name_show').val(),
        phoneNo: $('#phoneNo_show').val(),
        size: $('#size_show').val(),
        category: $('#category_show').val(),
        comment: $('#comment').val(),
        id: $('#id_show').val(),
        Status: $('#status_show').val()
    };
    $.post("/Home/UpdateBooking", data, function (res) {
        if (res == "Updated") {
            toastr.success("Booking Updated Successfully", "Message");
            CloseOpenedModal("bookingModal");
            GetTodaysBooking();
            GetTomorrowsBooking();
        }
        else {
            toastr.error("Something Went Wrong", "Warning");
        }
    });
}

function OpenDeleteModalBookingList(BookigId) {
    OpenModalFunction("deleteModal");
    //$('#DelBookingId').val(BookigId);
}

// Deleting Booking
function DeleteBookingList() {
    var id = $('#DelBookingId').val();
    $.get("/Home/DeleteBookingList?BookedId=" + id, function (res) {
        if (res == "Deleted") {
            toastr.success("Booking Deleted Successfully", "Warning");
            CloseOpenedModal("deleteModal");
            CloseOpenedModal("bookingModal");
            GetTodaysBooking();
            GetTomorrowsBooking();
        }
        else {
            toastr.error("Something went wrong", "Warning");
        }
    });
}

// Deleting Booking and making it available
function DeleteBookingAndMakeitAvailable() {
    var id = $('#DelBookingId').val();
    $.get("/Home/DeleteBookingAndMakeitAvailable?BookedId=" + id, function (res) {
        if (res == "Deleted") {
            toastr.success("Booking Deleted Successfully", "Warning");
            CloseOpenedModal("deleteModal");
            CloseOpenedModal("bookingModal");
            GetTodaysBooking();
            GetTomorrowsBooking();
        }
        else {
            toastr.error("Something went wrong", "Warning");
        }
    });
}

// Change Status 
function ChangeStatus(bookingId) {
    var status = $('#' + bookingId).val();
    $.get("/Home/UpdateStatus?BookingId=" + bookingId + "&Status=" + status, function (res) {
        toastr.success("Status Updated", "Success");
        GetTodaysBooking();
        GetTomorrowsBooking();
    });
    status();
}
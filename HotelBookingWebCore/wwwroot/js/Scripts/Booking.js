$(document).ready(function () {
    GetAllBookings();
});
// View All Bookings
function GetAllBookings() {
    $.get("/Booking/GetAllBookings", function (res) {
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
            html += '<select onchange="status(this.id)" name="status1" id="' + res[i].id + '">';
            html += '<option class="blue" value="' + res[i].status +'" selected>' + res[i].status +'</option>';
            html += '<option class="blue" value="Confirmed">Confirmed</option>';
            html += '<option value="Select Status" disabled>Select Status</option>';
            html += '<option class="red" value="UnConfirmed">UnConfirmed</option>';
            html += '<option class="green" value="Paid">Paid</option>';
            html += '<option class="grey" value="Canceled">Canceled</option>';
            html += '</select>';
            html += '</td>';
            html += '<td>' + res[i].amount + '</td>';
            html += '<td id="' + res[i].id + '" onclick="OpenBookingUpdateModal(this.id)"><i class="fas fa-ellipsis-h"></i></td>';
            html += '</tr>';
            //$('#status_show_edit' + i).val(res[i].status);
        }
        $('#BookingTbody').html(html);
        pagin += '<i class="fas fa-angle-left btn1"></i>';
        pagin += '<h4 class="btn2">1</h4>';
        pagin += '<h4 class="btn3">2</h4>';
        pagin += '<h4 class="btn4">3</h4>';
        pagin += '<h4 class="btn5">...</h4>';
        pagin += '<h4 class="btn6">13</h4>';
        pagin += '<i class="fas fa-angle-right btn7"></i>';
        $(".pagination").html(pagin);
    });
}

function OpenBookingUpdateModal(BookingId) {
    //OpenModalFunction("bookingListModal");
    $.get("/Booking/GetBookingById?BookingId=" + BookingId, function (res) {
        $('#BookingListModalShow').html(res);
        $('#status_show').val($('#StatusValue').val());
        OpenModalFunction("bookingListModal");
    });
}

// Add Reservation or Booking
function AddBooking() {
    var hours = $('#hours').val();
    var minutes = $('#minutes').val();
    var AmPm = $('#AmPm').val();
    var time = hours + ":" + minutes + " " + AmPm;
    var data = {
        guestName: $('#name').val(),
        phoneNo: $('#phone').val(),
        size: $('#size').val(),
        category: $('#category').val(),
        status: $('#status').val(),
        Room: $('#Room').val(),
        bookedDate: $('#bookingDate').val(),
        time: time
    };
    // Posting Data to the controller for inserting in to Database
    $.post("/Booking/AddBooking", data, function (res) {
        if (res == "Added") {
            toastr.success("Reservation Added Successfully", "Message");
            CloseOpenedModal("addreservation-modal");
            GetAllBookings();
        }
        else {
            toastr.error("Something Went Wrong", "Warning");
        }
    });
}

//Update Booking
function UpdateBooking() {
    var data = {
        guestName: $('#name_show').val(),
        phoneNo: $('#phoneNo_show').val(),
        size: $('#size_show').val(),
        category: $('#category_show').val(),
        comment: $('#comment').val(),
        id: $('#id_show').val(),
        Status: $('#status_show').val()
    };
    $.post("/Booking/UpdateBooking", data, function (res) {
        if (res == "Updated") {
            toastr.success("Booking Updated Successfully", "Message");
            CloseOpenedModal("bookingListModal");
            GetAllBookings();
        }
        else {
            toastr.error("Something Went Wrong", "Warning");
        }
    });
}

// Open Delete Booking Modal
function OpenDeleteBookingModal(id) {
    OpenModalFunction("deleteListModal");
    $('#DelBookingId').val(id);
}

// Deleting Booking
function DeleteBookingList() {
    var id = $('#DelBookingId').val();
    $.get("/Booking/DeleteBookingList?BookedId=" + id, function (res) {
        if (res == "Deleted") {
            toastr.success("Booking Deleted Successfully", "Warning");
            CloseOpenedModal("deleteListModal");
            GetAllBookings();
        }
        else {
            toastr.error("Something went wrong", "Warning");
        }
    });
}

// Deleting Booking and making it available
function DeleteBookingAndMakeitAvailable() {
    var id = $('#DelBookingId').val();
    $.get("/Booking/DeleteBookingAndMakeitAvailable?BookedId=" + id, function (res) {
        if (res == "Deleted") {
            toastr.success("Booking Deleted Successfully", "Warning");
            CloseOpenedModal("deleteListModal");
            CloseOpenedModal("bookingModal");
            GetTodaysBooking();
            GetTomorrowsBooking();
        }
        else {
            toastr.error("Something went wrong", "Warning");
        }
    });
}

function ChangeStatus(bookingId) {
    var status = $('#' + bookingId).val();
    $.get("/Booking/UpdateStatus?BookingId=" + bookingId + "&Status=" + status, function (res) {
        toastr.success("Status Updated", "Success");
        GetTodaysBooking();
        GetTomorrowsBooking();
    });
    status();
}
// On Load / Ready Function
$(document).ready(function () {
    ViewAllAppoinments();
});

// View All Appoinment Times
function ViewAllAppoinments() {
    $.get("/Appoinment/GetAllAppoinment", function (res) {
        var timeSlots = '';
        for (var i = 0; i < res.length; i++) {
            timeSlots += '<button id="' + res[i].id + '" onclick="OpenEditAppoinmentModal(this.id)" class="time">' + res[i].time + '</button>';
        }
        $('#appoinment_times_list').html(timeSlots);
    });
}

// Open Edit Appoinment Modal
function OpenEditAppoinmentModal(Id) {
    $('#status_edit').val("Select Status");
    $('#fromDate_edit').val("dd/mm/yyyy");
    $('#toDate_edit').val("dd/mm/yyyy");
    $('input[name="checkBoxRoom"]').attr("checked", false);
    $('#AppoinmentId').val(Id);
    $.get("/Appoinment/FetchAppoinmentById?Id=" + Id, function (res) {
        if (res.roomArr.length > 0) {
            for (var i = 0; i < res.roomArr.length; i++) {
                if (res.roomArr[i].room == "العم صالح") {
                    $('#UncleSaleh').attr("checked", true);
                }
                else if (res.roomArr[i].room == "الهرم") {
                    $("#Pyramid").attr("checked", true);
                }
                else {
                    $('#Ward23').attr("checked", true);
                }
            }
            
            if (res.roomArr[0].status == null || res.roomArr[0].status == "") {
                $('#status_edit').val("Select Status");
            }
            else {
                $('#status_edit').val(res.roomArr[0].status);
            }
            var fromDate = moment(res.roomArr[0].fromDate).format("yyyy-MM-DD");
            var toDate = moment(res.roomArr[0].toDate).format("yyyy-MM-DD");
            $('#fromDate_edit').val(fromDate);
            $('#toDate_edit').val(toDate);
        }
        OpenModalFunction("editappointment-modal");
    });
}


// Adding Time Slots
function AddTimeSlots() {
    var hours = $('#hours').val();
    var minutes = $('#minutes').val();
    var AmPm = $('#AmPm').val();
    var Time = hours + ":" + minutes + AmPm;

    $.get("/Appoinment/AddNewAppoinment?Time=" + Time, function (res) {
        if (res == "Added") {
            toastr.remove();
            toastr.success("Appoinment Added Successfully", "Success");
            ViewAllAppoinments();
            CloseOpenedModal("addappointment-modal");
        }
        else {
            toastr.remove();
            toastr.error("Something Went Wrong", "Waning");
        }
    });
}

// Update Appoinment
function UpdateAppoinment() {
    var roomArr = [];
    $('input[type="checkbox"]:checked').each(function () {
        roomArr.push($(this).val());
    });
    var data = {
        id: $('#AppoinmentId').val(),
        roomArr: roomArr,
        status: $('#status_edit').val(),
        fromDate: $('#fromDate_edit').val(),
        toDate: $('#toDate_edit').val()
    };
    // Hiting on Controller
    $.post("/Appoinment/UpdateAppoinment", data, function (res) {
        if (res == "Updated") {
            toastr.remove();
            toastr.success("Appoinment Updated Successfully", "Success");
            CloseOpenedModal("editappointment-modal");
            ViewAllAppoinments();
            $('#status_edit').val("Select Status");
            $('#fromDate_edit').val("dd/mm/yyyy");
            $('#toDate_edit').val("dd/mm/yyyy");
            $('input[name="checkBoxRoom"]').attr("checked", false);
        }
        else {
            toastr.remove();
            toastr.error("Something Went Wrong", "Warning");
        }
    });
}
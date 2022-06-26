// On Load Function
$(document).ready(function () {
    ViewCouponList();
});

// View Coupon List
function ViewCouponList() {
    $.get("/Coupon/GetCoupons", function (res) {
        var html = "";
        var pagin = "";
        for (var i = 0; i < res.length; i++) {
            html += '<tr>';
            html += '<td>' + res[i].id + '</td>';
            html += '<td>' + res[i].name + '</td>';
            html += '<td>' + moment(res[i].relaseDate).format("YYYY-MM-DD") + '</td>';
            html += '<td>' + res[i].duration + '</td>';
            html += '<td>' + res[i].discountPercent + '%</td>';
            html += '<td>' + res[i].status + '</td>';
            html += '<td id="' + res[i].id + '" onclick="GetCouponById(this.id);"><i class="far fa-pen"></i></td>';
            html += '<td id="' + res[i].id + '" onclick="OpenDeleteCouponModal(this.id)"><i class="far fa-trash-alt"></i></td>';
            html += '</tr>';
            $('#CouponTbody').html(html);

            // Pagination
            pagin += '<i class="fas fa-angle-left btn1"></i>';
            pagin += '<h4 class="btn2">1</h4>';
            pagin += '<h4 class="btn3">2</h4>';
            pagin += '<h4 class="btn4">3</h4>';
            pagin += '<h4 class="btn5">...</h4>';
            pagin += '<h4 class="btn6">13</h4>';
            pagin += '<i class="fas fa-angle-right btn7"></i>';
            $('.pagination').html(pagin);
        }
    });
}

function GetCouponById(id) {
    $.get("/Coupon/GetCouponById?Id=" + id, function (res) {
        $('#id_edit').val(res.id);
        $('#id_edit').attr("disabled", true);
        $('#id_edit').css("cursor", "not-allowed");
        $('#couponDuration_edit').val(res.duration);
        $('#name_edit').val(res.name);
        $('#discountPercent_edit').val(res.discountPercent);
        $('#status_edit').val(res.status);
        $('#status_edit').attr("disabled", true);
        $('#status_edit').css("cursor", "not-allowed");
        $('#releaseDate_edit').val(moment(res.relaseDate).format("YYYY-MM-DD"));
        $('#releaseDate_edit').attr("disabled", true);
        $('#releaseDate_edit').css("cursor", "not-allowed");
        OpenModalFunction("editcoupon-modal");
    });
}

// add coupon
function AddCouponList() {
    var data = {
        Duration: $('#duration').val(),
        name: $('#name').val(),
        discountPercent: $('#discountPercent').val(),
        status: $('#status').val(),
        relaseDate: $('#releaseDate').val()
    };

    $.post("/Coupon/AddCoupon", data, function (res) {
        if (res == "Added") {
            toastr.success("New Coupon Added Successfully", "Message");
            CloseOpenedModal("addcoupon-modal");
            ViewCouponList();
        }
        else {
            toastr.error("Something Went Wrong", "Warning");
        }
    });
}

// Update Coupon List
function UpdateCouponList() {
    var data = {
        id: $('#id_edit').val(),
        duration: $('#couponDuration_edit').val(),
        name: $('#name_edit').val(),
        discountPercent: $('#discountPercent_edit').val(),
        //status: $('#status').val(),
        //relaseDate: $('#releaseDate').val()
    };

    $.post("/Coupon/UpdateCoupon", data, function (res) {
        if (res == "Updated") {
            toastr.success("Coupon Updated Successfully", "Message");
            CloseOpenedModal("editcoupon-modal");
            ViewCouponList();
        }
        else {
            toastr.error("Something Went Wrong", "Warning");
        }
    });
}

// Open Delete Coupon Modal
function OpenDeleteCouponModal(id) {
    $('#CouponId_del').val(id);
    OpenModalFunction("deleteCouponModal");
}

// Delete Coupon
function DeleteCoupon() {
    var id = $('#CouponId_del').val();
    $.get("/Coupon/DeleteCoupon?Id=" + id, function (res) {
        toastr.success("Coupon Deleted Successfully", "Message");
        CloseOpenedModal("deleteCouponModal");
        ViewCouponList();
    });
}
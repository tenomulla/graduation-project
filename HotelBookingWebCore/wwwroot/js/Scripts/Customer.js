// On Load Function
$(document).ready(function () {
    ViewAllCustomers();
});

// View All Customers
function ViewAllCustomers() {
    $.get("/Customer/GetAllCustomers", function (res) {
        var html = '';
        var pagin = '';
        if (res.length > 0) {
            for (var i = 0; i < res.length; i++) {
                html += '<tr>';
                html += '<td>' + res[i].name + '</td>';
                html += '<td class="email">' + res[i].email + '</td>';
                html += '<td class="phonenumbers">' + res[i].phone + '</td>';
                html += '</tr>';
            }
        }
        else {
            html += '<tr>';
            html += '<td></td>';
            html += '<td>No Customer Found</td>';
            html += '<td></td>';
            html += '</tr>';
        }
        $('#CustomersTbody').html(html);
        // appending pagination
        pagin += '<i class="fas fa-angle-left btn1"></i>';
        pagin += '<h4 class="btn2">1</h4>';
        pagin += '<h4 class="btn3">2</h4>';
        pagin += '<h4 class="btn4">3</h4>';
        pagin += '<h4 class="btn5">...</h4>';
        pagin += '<h4 class="btn6">13</h4>';
        pagin += '<i class="fas fa-angle-right btn7"></i>';
        $('.pagination').html(pagin);
    });
}

// Copy Email
function CopyEmails() {
    var clickedTdText = [];
    $('.email').each(function (index, element) {
        clickedTdText.push($(this).text()); //get the clicked text
    });
    var temp = $("<input>"); //create temp  input
    $("body").append(temp); //append temp input
    temp.val(clickedTdText).select();
    document.execCommand("copy");
    temp.remove(); //remove temp inout
    toastr.success("Emails Copied", "Success");
}

// Copy Phone
function CopyPhoneNumber() {
    var clickedTdText = [];
    $('.phonenumbers').each(function (index, element) {
        clickedTdText.push($(this).text()); //get the clicked text
    });
    var temp = $("<input>"); //create temp  input
    $("body").append(temp); //append temp input
    temp.val(clickedTdText).select();
    document.execCommand("copy");
    temp.remove(); //remove temp inout
    toastr.success("Phone Numbers Copied", "Success");
}
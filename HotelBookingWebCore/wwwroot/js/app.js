function bookingModal() {
    // Get the modal
var modal = document.getElementById("bookingModal");

// Get the button that opens the modal
// var bookingModal = document.getElementsByClassName("booking-modal");
// console.log(bookingModal);
// Get the <span> element that closes the modal
var spanOne = document.getElementsByClassName("close")[0];
var spanTwo = document.getElementsByClassName("close")[1];

// When the user clicks on the button, open the modal
modal.style.display = "block";
// When the user clicks on <span> (x), close the modal
spanOne.onclick = function() {
  modal.style.display = "none";
}
spanTwo.onclick = function() {
  modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
  if (event.target == modal) {
    modal.style.display = "none";
  }
}
}

function OpenModalFunction(modalName) {
    // Get the modal
    var modal = document.getElementById(modalName);

    // Get the button that opens the modal
    // Get the <span> element that closes the modal
    var span = document.getElementById("closeModal");


    // When the user clicks on the button, open the modal
    modal.style.display = "block";
    // When the user clicks on <span> (x), close the modal
    span.onclick = function () {
        modal.style.display = "none";
    }

    // When the user clicks anywhere outside of the modal, close it
    //window.onclick = function (event) {
    //    if (event.target == modal) {
    //        modal.style.display = "none";
    //    }
    //}
}

function CloseOpenedModal(ModalName) {
    var modal = document.getElementById(ModalName);
    modal.style.display = "none";
}

function deleteModal() {
  // Get the modal
var modal = document.getElementById("deleteModal");

// Get the button that opens the modal
// var bookingModal = document.getElementsByClassName("booking-modal");
// console.log(bookingModal);
// Get the <span> element that closes the modal
var span = document.getElementById("close");


// When the user clicks on the button, open the modal
modal.style.display = "block";
// When the user clicks on <span> (x), close the modal
span.onclick = function() {
modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
if (event.target == modal) {
  modal.style.display = "none";
}
}
}

function addCouponModal() {
  // Get the modal
var modal = document.getElementById("addcoupon-modal");


var span = document.getElementById("close");

// When the user clicks on the button, open the modal
modal.style.display = "block";
// When the user clicks on <span> (x), close the modal
span.onclick = function() {
modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
if (event.target == modal) {
  modal.style.display = "none";
}
}
}

function editCouponModal() {
  // Get the modal
var modal = document.getElementById("editcoupon-modal");


var span = document.getElementById("edit-coupon-close");

// When the user clicks on the button, open the modal
modal.style.display = "block";
// When the user clicks on <span> (x), close the modal
span.onclick = function() {
modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
if (event.target == modal) {
  modal.style.display = "none";
}
}
}


function addAdminModal() {
  // Get the modal
var modal = document.getElementById("addAdmin-modal");


var span = document.getElementById("close");

// When the user clicks on the button, open the modal
modal.style.display = "block";
// When the user clicks on <span> (x), close the modal
span.onclick = function() {
modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
if (event.target == modal) {
  modal.style.display = "none";
}
}
}

function editAdminModal() {
  // Get the modal
var modal = document.getElementById("editAdmin-modal");


var span = document.getElementById("closeIt");

// When the user clicks on the button, open the modal
modal.style.display = "block";
// When the user clicks on <span> (x), close the modal
span.onclick = function() {
modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
if (event.target == modal) {
  modal.style.display = "none";
}
}
}



function addRoomModal() {
  // Get the modal
var modal = document.getElementById("addRoom-modal");


var span = document.getElementById("close");

// When the user clicks on the button, open the modal
modal.style.display = "block";
// When the user clicks on <span> (x), close the modal
span.onclick = function() {
modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
if (event.target == modal) {
  modal.style.display = "none";
}
}
}

function editRoomModal() {
  // Get the modal
var modal = document.getElementById("editRoom-modal");


var span = document.getElementById("closeIt");

// When the user clicks on the button, open the modal
modal.style.display = "block";
// When the user clicks on <span> (x), close the modal
span.onclick = function() {
modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
if (event.target == modal) {
  modal.style.display = "none";
}
}
}

function bookingListModal() {
  // Get the modal
var modal = document.getElementById("bookingListModal");


var span = document.getElementById("close");
var spantwo = document.getElementById("closeIt");

// When the user clicks on the button, open the modal
modal.style.display = "block";
// When the user clicks on <span> (x), close the modal
span.onclick = function() {
modal.style.display = "none";
}
spantwo.onclick = function() {
  modal.style.display = "none";
  }
// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
if (event.target == modal) {
  modal.style.display = "none";
}
}
}

function deleteListModal(id) {
  // Get the modal
    var modal = document.getElementById("deleteListModal");
    $('#DelBookingId').val(id);

// Get the button that opens the modal
// var bookingModal = document.getElementsByClassName("booking-modal");
// console.log(bookingModal);
// Get the <span> element that closes the modal
var span = document.getElementById("closeModal");


// When the user clicks on the button, open the modal
modal.style.display = "block";
// When the user clicks on <span> (x), close the modal
span.onclick = function() {
modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
if (event.target == modal) {
  modal.style.display = "none";
}
}
}


function addReservationModal() {
  // Get the modal
var modal = document.getElementById("addreservation-modal");


var span = document.getElementById("closeThis");


// When the user clicks on the button, open the modal
modal.style.display = "block";
// When the user clicks on <span> (x), close the modal
span.onclick = function() {
modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
if (event.target == modal) {
  modal.style.display = "none";
}
}
}

function addAppointmentModal() {
  // Get the modal
var modal = document.getElementById("addappointment-modal");


var span = document.getElementById("closeThis");


// When the user clicks on the button, open the modal
modal.style.display = "block";
// When the user clicks on <span> (x), close the modal
span.onclick = function() {
modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
if (event.target == modal) {
  modal.style.display = "none";
}
}
}

function editAppointmentModal() {
  // Get the modal
var modal = document.getElementById("editappointment-modal");


var span = document.getElementById("closeIT");


// When the user clicks on the button, open the modal
modal.style.display = "block";
// When the user clicks on <span> (x), close the modal
span.onclick = function() {
modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
if (event.target == modal) {
  modal.style.display = "none";
}
}
}

function hours(){
  var select = '';
    for (i=1;i<=12;i++){
        select += '<option val=' + i + '>' + i + '</option>';
    }
    $('#hours').html(select);
}

hours();

function minutes(){
  var select = '';
    for (i=1;i<=59;i++){
        select += '<option val=' + i + '>' + i + '</option>';
    }
    $('#minutes').html(select);
}

minutes();


// fucntion to change the color of select inputs according to their values
function status() {
  var select = document.getElementById("status");
  var value = select.value;
  if (value == "confirmed") {
    select.style.backgroundColor = "#78A5DA";
    select.style.color = "#333333";
  }
  else if (value == "unconfirmed"){
    select.style.backgroundColor = "#F66D6D";
    select.style.color = "#333333";
  }
  else if (value == "paid"){
    select.style.backgroundColor = "#4EE59D";
    select.style.color = "#333333";
  }
  else if (value == "canceled"){
    select.style.backgroundColor = "#A8A8A8";
    select.style.color = "#333333";
  }
}

// fucntion to change the color of select inputs according to their values
function statusActive() {
  var select = document.getElementById("status");
  var value = select.value;
  
  if (value == "active"){
    select.style.backgroundColor = "#4EE59D";
    select.style.color = "#333333";
  }
  else if (value == "expired"){
    select.style.backgroundColor = "#A8A8A8";
    select.style.color = "#333333";
  }
}


// jquery function for upload btn
$( document ).ready(function() {

});

$(".upload_btn").on("click",function (e){
    var fileDialog = $('#ImgFile');
    fileDialog.click();
    fileDialog.on("change", onFileSelected);
    return false;
});
//
$("#btn_Upload").on("click", function (e) {
    var fileDialog = $('#ImgFile_edit');
    fileDialog.click();
    fileDialog.on("change", onFileSelected);
    return false;
});




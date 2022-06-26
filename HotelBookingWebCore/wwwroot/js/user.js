// When the user scrolls the page, execute myFunction
window.onscroll = function() {navbarSticky()};

// Get the navbar
var navbar = document.getElementById("navbar");

// Get the offset position of the navbar
var sticky = navbar.offsetTop;

// Add the sticky class to the navbar when you reach its scroll position. Remove "sticky" when you leave the scroll position
function navbarSticky() {
  if (window.pageYOffset >= sticky) {
    navbar.classList.add("sticky")
  } else {
    navbar.classList.remove("sticky");
  }
}



// menu for userpage

var slider = document.getElementById('slider');



function openit() {
    slider.style.top = "0";


}

function closeit() {
    slider.style.top = '-70%';
    console.log("close");
}


function bookingInformation() {
    // Get the modal
    var modal = document.getElementById("booking-information");


    var span = document.getElementById("close");


    // When the user clicks on the button, open the modal
    modal.style.display = "block";
    // When the user clicks on <span> (x), close the modal
    span.onclick = function () {
        modal.style.display = "none";
    }

    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
}



// to show answers

var arrow = document.getElementsByClassName('arrow');
var arrow1 = document.getElementById("arrow1");
var arrow2 = document.getElementById("arrow2");
var arrow3 = document.getElementById("arrow3");
var arrow4 = document.getElementById("arrow4");
var arrow5 = document.getElementById("arrow5");
var arrow6 = document.getElementById("arrow6");


var answer = document.getElementsByClassName('answer');
var answer1 = document.getElementById('answer1');
var answer2 = document.getElementById('answer2');
var answer3 = document.getElementById('answer3');
var answer4 = document.getElementById('answer4');
var answer5 = document.getElementById('answer5');
var answer6 = document.getElementById('answer6');

function showanswer1() {


    arrow1.classList.add('fa-rotate-270');
    if (arrow1.classList = 'fas fa-angle-left arrow fa-rotate-270') {
        answer1.style.display = 'block';

        answer2.style.display = 'none';
        answer3.style.display = 'none';
        answer4.style.display = 'none';
        answer5.style.display = 'none';
        answer6.style.display = 'none';


        arrow2.classList.remove("fa-rotate-270");  arrow2.classList.add("fa-rotate-0");
        arrow3.classList.remove("fa-rotate-270"); arrow3.classList.add("fa-rotate-0");
        arrow4.classList.remove("fa-rotate-270"); arrow4.classList.add("fa-rotate-0");
        arrow5.classList.remove("fa-rotate-270"); arrow5.classList.add("fa-rotate-0");
        arrow6.classList.remove("fa-rotate-270"); arrow6.classList.add("fa-rotate-0");
    }

    
}

function showanswer2() {


    arrow2.classList.add('fa-rotate-270');
    if (arrow2.classList = 'fas fa-angle-left arrow fa-rotate-270') {
        answer2.style.display = 'block';

        answer1.style.display = 'none';
        answer3.style.display = 'none';
        answer4.style.display = 'none';
        answer5.style.display = 'none';
        answer6.style.display = 'none';

        arrow1.classList.remove("fa-rotate-270");  arrow1.classList.add("fa-rotate-0");
        arrow3.classList.remove("fa-rotate-270"); arrow3.classList.add("fa-rotate-0");
        arrow4.classList.remove("fa-rotate-270"); arrow4.classList.add("fa-rotate-0");
        arrow5.classList.remove("fa-rotate-270"); arrow5.classList.add("fa-rotate-0");
        arrow6.classList.remove("fa-rotate-270"); arrow6.classList.add("fa-rotate-0");
    }

}

function showanswer3() {


    arrow3.classList.add('fa-rotate-270');
    if (arrow3.classList = 'fas fa-angle-left arrow fa-rotate-270') {
        answer3.style.display = 'block';

        answer1.style.display = 'none';
        answer2.style.display = 'none';
        answer4.style.display = 'none';
        answer5.style.display = 'none';
        answer6.style.display = 'none';

        arrow2.classList.remove("fa-rotate-270");  arrow2.classList.add("fa-rotate-0");
        arrow1.classList.remove("fa-rotate-270"); arrow1.classList.add("fa-rotate-0");
        arrow4.classList.remove("fa-rotate-270"); arrow4.classList.add("fa-rotate-0");
        arrow5.classList.remove("fa-rotate-270"); arrow5.classList.add("fa-rotate-0");
        arrow6.classList.remove("fa-rotate-270"); arrow6.classList.add("fa-rotate-0");
    }

}

function showanswer4() {


    arrow4.classList.add('fa-rotate-270');
    if (arrow4.classList = 'fas fa-angle-left arrow fa-rotate-270') {
        answer4.style.display = 'block';

        answer1.style.display = 'none';
        answer2.style.display = 'none';
        answer3.style.display = 'none';
        answer5.style.display = 'none';
        answer6.style.display = 'none';

        arrow2.classList.remove("fa-rotate-270");  arrow2.classList.add("fa-rotate-0");
        arrow3.classList.remove("fa-rotate-270"); arrow3.classList.add("fa-rotate-0");
        arrow1.classList.remove("fa-rotate-270"); arrow1.classList.add("fa-rotate-0");
        arrow5.classList.remove("fa-rotate-270"); arrow5.classList.add("fa-rotate-0");
        arrow6.classList.remove("fa-rotate-270"); arrow6.classList.add("fa-rotate-0");
    }

}


function showanswer5() {


    arrow5.classList.add('fa-rotate-270');
    if (arrow5.classList = 'fas fa-angle-left arrow fa-rotate-270') {
        answer5.style.display = 'block';

        answer1.style.display = 'none';
        answer2.style.display = 'none';
        answer3.style.display = 'none';
        answer4.style.display = 'none';
        answer6.style.display = 'none';

        arrow2.classList.remove("fa-rotate-270");  arrow2.classList.add("fa-rotate-0");
        arrow3.classList.remove("fa-rotate-270"); arrow3.classList.add("fa-rotate-0");
        arrow4.classList.remove("fa-rotate-270"); arrow4.classList.add("fa-rotate-0");
        arrow1.classList.remove("fa-rotate-270"); arrow1.classList.add("fa-rotate-0");
        arrow6.classList.remove("fa-rotate-270"); arrow6.classList.add("fa-rotate-0");
    }

}


function showanswer6() {


    arrow6.classList.add('fa-rotate-270');
    if (arrow6.classList = 'fas fa-angle-left arrow fa-rotate-270') {
        answer6.style.display = 'block';

        answer1.style.display = 'none';
        answer2.style.display = 'none';
        answer3.style.display = 'none';
        answer4.style.display = 'none';
        answer5.style.display = 'none';

        arrow2.classList.remove("fa-rotate-270");  arrow2.classList.add("fa-rotate-0");
        arrow3.classList.remove("fa-rotate-270"); arrow3.classList.add("fa-rotate-0");
        arrow4.classList.remove("fa-rotate-270"); arrow4.classList.add("fa-rotate-0");
        arrow5.classList.remove("fa-rotate-270"); arrow5.classList.add("fa-rotate-0");
        arrow1.classList.remove("fa-rotate-270"); arrow1.classList.add("fa-rotate-0");
    
    }

}

$("input[type=radio]:checked").parent().addClass("selected");

$('input[type=radio]').change(function () {
    $("input[type=radio]").parent().removeClass("selected");
    $("input[type=radio]:checked").parent().addClass("selected");

});
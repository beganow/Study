
$(document).ready(function(){
    $('#p1').mouseover(function(){$('#p1').css("color","red")});
    $('#p1').mouseout(function(){$('#p1').css("color","white")});
    $('#p2').mouseover(function(){$('#p2').css("color","red")});
    $('#p2').mouseout(function(){$('#p2').css("color","white")});
    $('#p3').mouseover(function(){$('#p3').css("color","red")});
    $('#p3').mouseout(function(){$('#p3').css("color","white")});
    $('#p4').mouseover(function(){$('#p4').css("color","red")});
    $('#p4').mouseout(function(){$('#p4').css("color","white")});
    $('#p5').mouseover(function(){$('#p5').css("color","red")});
    $('#p5').mouseout(function(){$('#p5').css("color","white")});
    $('#p6').mouseover(function(){$('#p6').css("color","green")});
    $('#p6').mouseout(function(){$('#p6').css("color","white")});
    $('#myscroll').mouseover(function(){$('#myscroll').css("background-color","white")});
    $('#myscroll').mouseover(function(){$('#myscroll').css("color","black")});
    $('#myscroll').mouseout(function(){$('#myscroll').css("background-color","black")});
    $('#myscroll').mouseout(function(){$('#myscroll').css("color","white")});
    $('.catalog_title').mouseover(function(){$('.catalog_title').css("font-size","40px")});
    $('.catalog_title').mouseout(function(){$('.catalog_title').css("font-size","24px")});
    $('.catalog_title').mouseover(function(){$('.catalog_title').css("color","red")});
    $('.catalog_title').mouseout(function(){$('.catalog_title').css("color","black")});
    $('.butt').click(function(){$('.rerut').css("background-color","green")});
    $('form').click(function(){$('form').css("background-color","black")});
    $('form').click(function(){$('.formh').css("color","purple")});
    $('.send34').click(function(){$('.send34').css("background-color","green")});
}); 
function fun1(){
    alert("Вы успешно зарегистрированы,"+ ' ' +document.forms[0].elements[1].value + "!!!");
}
let offset = 0;
const sliderLine = document.querySelector('.slider_line');

document.querySelector('.slider_next').addEventListener('click', function(){
    offset = offset + 400;
    if (offset>2000){
        offset=0;
    }
    sliderLine.style.left = -offset + 'px';
});
document.querySelector('.slider_prev').addEventListener('click', function(){
    offset = offset - 400;
    if (offset<0){
        offset=2000;
    }
    sliderLine.style.left = -offset + 'px';
});

let offset1 = 0;
const sliderLineu = document.querySelector('.slider_line1');
document.querySelector('.slider_next1').addEventListener('click', function(){
    offset1 = offset1 + 400;
    if (offset1>2000){
        offset1=0;
    }
    sliderLineu.style.left = -offset1 + 'px';
});
document.querySelector('.slider_prev1').addEventListener('click', function(){
    offset1 = offset1 - 400;
    if (offset1<0){
        offset1=2000;
    }
    sliderLineu.style.left = -offset1 + 'px';
});
document.getElementById('myscroll').addEventListener('click', scrollToElement);
function scrollToElement(e) {
element = document.getElementById('scroll')
element.scrollIntoView(true);
}
$(function() {
    // при нажатии на кнопку scrollup
    $('.btn').click(function() {
      // переместиться в верхнюю часть страницы
      $("html, body").animate({
        scrollTop:4000
      },5000);
    })
  })




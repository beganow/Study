$(document).ready(function(){
    $('#myColor').mouseover(function(){$('#myColor').css("color","red")});
    $('#myColor').mouseout(function(){$('#myColor').css("color","black")});
    $('#font').click(function(){$('#font').css("font-size","40px")});
    $('#pic1').click(function(){$('#pic1').attr({"src":"js.jpg"})});
    $('#dropw').click(function () {$('#dropw').html('<img src="jases.jpg">');})
    $('#writl12').dblclick(function(){$('#writl12').css("border","2px dashed blue")})
    $('#pic2').mouseover(function(){$('#pic2').css("width","500px")})
    $('#pic2').mouseover(function(){$('#pic2').css("height","500px")})
    $('#pic2').mouseout(function(){$('#pic2').css("width","100px")})
    $('#pic2').mouseout(function(){$('#pic2').css("height","100px")})
               // вызываем метод draggable чтобы мог перетаскиваться myElement
     $("#draggable").draggable();
        $( "#node" ).click(function(){ // задаем функцию при нажатиии на элемент с классом right
          $( "#node" ).animate({
            right: "-=1350px", 
  // смещение позиционированного элемента от правого края (уменьшение текущего значения на 50)
   // увеличение ширины границы элемента на два пикселя от текущего значения
            }, "linear"); // скорость анимации
        }); 
            $("#block").click(function(){
            $("#block").animate({
                    "left": "400px"
                },{
                 step: function(now, fx) {
                $(fx.elem).offset({top: Math.sin(now/80)*100+1300});        
                 }
                },1000);
            $("#block").mouseover(function(){
            $("#block").animate({
                "left":"0px",
                "top" :"0px"   
            });
        });
    });
});
document.querySelector('.burger-menu').addEventListener('click', function () {
    document.querySelector('.menu').classList.toggle('active');
    document.querySelector('.burger-menu').classList.toggle('change'); // Добавляем класс change при клике на бургер-меню
});
function playSound(sound) {
    var audio = new Audio(sound);
    audio.play();
}

function highlightArea(area) {
    area.classList.add('highlighted-area');
}

function removeHighlight(area) {
    area.classList.remove('highlighted-area');
}
function init() {
    if (document.layers) document.captureEvents(Event.MOUSEMOVE);
    document.onmousemove = mousemove;
}
function mousemove(event) {
    var mouse_x = mouse_y = 0;
    if (document.attachEvent != null) {
        mouse_x = window.event.clientX;
        mouse_y = window.event.clientY;
    } else if (!document.attachEvent && document.addEventListener) {
        mouse_x = event.clientX;
        mouse_y = event.clientY;
    }
    status = "x = " + mouse_x + ", y = " + mouse_y;
    document.getElementById('xy').innerHTML = "x = " + mouse_x + ", y = " + mouse_y;
}
init()
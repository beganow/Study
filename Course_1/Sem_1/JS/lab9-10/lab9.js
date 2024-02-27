let curPosX = 1600;
let interval; 
let n = 10; 
let width = document.documentElement.clientWidth; //размер элемента
let imgWidth = 102; 
 img1 = document.getElementById("one"); 
interval = setInterval(right, 10);//задание интервала с движением 10мс 
function right() { 
img1.style.right = (curPosX -= n) + "px";  //движение вправо
if (curPosX <= 0) 

{  
clearInterval(interval);//если выходит за пределы интервал остановить
interval = setInterval(left, 10); //движение влево
} 
} 
function left (){
  img1.style.right = (curPosX += n) + "px";
 if (curPosX >= 1470){
    clearInterval(interval);
  }
} 
var DragManager = new function() { //использование drag n drop

    /*
      составной объект для хранения информации о переносе:
      {
       elem - элемент, на котором была зажата мышь
       avatar - аватар
       downX/downY - координаты, на которых был mousedown
        shiftX/shiftY - относительный сдвиг курсора от угла элемента
     * }
     */
    var dragObject = {};
  
    var self = this;
  
    function onMouseDown(e) {
  
      if (e.which != 1) return; //which свойство объекта event
  
      var elem = e.target.closest('.meals'); //указание на элемент вызванного события
      if (!elem) return;
  
      dragObject.elem = elem;
  
      // запомним, что элемент нажат на текущих координатах pageX/pageY
      dragObject.downX = e.pageX;
      dragObject.downY = e.pageY;
  
      return false;
    }
  
    function onMouseMove(e) {
      if (!dragObject.elem) return; // элемент не зажат
  
      if (!dragObject.avatar) { // если перенос не начат...
        var moveX = e.pageX - dragObject.downX;
        var moveY = e.pageY - dragObject.downY;
  
        // если мышь передвинулась в нажатом состоянии недостаточно далеко
        if (Math.abs(moveX) < 3 && Math.abs(moveY) < 3) {
          return;
        }
  
        // начинаем перенос
        dragObject.avatar = createAvatar(e); // создать аватар
        if (!dragObject.avatar) { // отмена переноса, нельзя "захватить" за эту часть элемента
          dragObject = {};
          return;
        }
  
        // аватар создан успешно
        // создать вспомогательные свойства shiftX/shiftY
        var coords = getCoords(dragObject.avatar);
        dragObject.shiftX = dragObject.downX - coords.left;
        dragObject.shiftY = dragObject.downY - coords.top;
  
        startDrag(e); // отобразить начало переноса
      }
  
      // отобразить перенос объекта при каждом движении мыши
      dragObject.avatar.style.left = e.pageX - dragObject.shiftX + 'px';
      dragObject.avatar.style.top = e.pageY - dragObject.shiftY + 'px';
  
      return false;
    }
  
    function onMouseUp(e) {
      if (dragObject.avatar) { // если перенос идет
        finishDrag(e);
      }
  
      // перенос либо не начинался, либо завершился
      // в любом случае очистим "состояние переноса" dragObject
      dragObject = {};
    }
  
    function finishDrag(e) {
      var dropElem = findDroppable(e);
  
      if (!dropElem) {
        self.onDragCancel(dragObject);
      } else {
        self.onDragEnd(dragObject, dropElem);
      }
    }
  
    function createAvatar(e) {
  
      // запомнить старые свойства, чтобы вернуться к ним при отмене переноса
      var avatar = dragObject.elem;
      var old = {
        parent: avatar.parentNode,
        nextSibling: avatar.nextSibling,
        position: avatar.position || '',
        left: avatar.left || '',
        top: avatar.top || '',
        zIndex: avatar.zIndex || ''
      };
  
      // функция для отмены переноса
      avatar.rollback = function() {
        old.parent.insertBefore(avatar, old.nextSibling);
        avatar.style.position = old.position;
        avatar.style.left = old.left;
        avatar.style.top = old.top;
        avatar.style.zIndex = old.zIndex
      };
  
      return avatar;
    }
  
    function startDrag(e) {
      var avatar = dragObject.avatar;
  
      // инициировать начало переноса
      document.body.appendChild(avatar);
      avatar.style.zIndex = 9999;
      avatar.style.position = 'absolute';
    }
  
    function findDroppable(event) {
      // спрячем переносимый элемент
      dragObject.avatar.hidden = true;
  
      // получить самый вложенный элемент под курсором мыши
      var elem = document.elementFromPoint(event.clientX, event.clientY);
  
      // показать переносимый элемент обратно
      dragObject.avatar.hidden = false;
  
      if (elem == null) {
        // такое возможно, если курсор мыши "вылетел" за границу окна
        return null;
      }
  
      return elem.closest('.meals');
    }
  
    document.onmousemove = onMouseMove;
    document.onmouseup = onMouseUp;
    document.onmousedown = onMouseDown;
  
    this.onDragEnd = function(dragObject, dropElem) {};
    this.onDragCancel = function(dragObject) {};
  
  };
  
  
  function getCoords(elem) { 
    var box = elem.getBoundingClientRect();// возвращает размер элемента и его позицию относительно viewport
  
    return {
      top: box.top + pageYOffset,
      left: box.left + pageXOffset
    };
  
  }
  DragManager.onDragCancel = function(dragObject) {
    dragObject.avatar.rollback();
  };

  DragManager.onDragEnd = function(dragObject, dropElem) {
    dragObject.elem.style.display = 'none';
    dropElem.classList.add('ball');
    setTimeout(function() {
      dropElem.classList.remove('ball');
    }, 200);}
    function animation(args, elem) { // некоторые аргументы определим на будущее
        var $ = {
            radius  :     250, // радиус окружности 
            speed   :     20 // скорость/задержка ( в js это мс, например 10 мс = 100 кадров в секунду)
        }
        var f = 0;
        var s = 2 * Math.PI / 180; //Вычислим угол
        setInterval(function() { // функция движения 
            f += s; // приращение аргумента
              elem.style.left =  235 + $.radius * Math.sin(f)  + 'px'; // меняем координаты элемента, подобно тому как мы это делали в школе в декартовой системе координат. Правда, в данном случае используется полярная система координат, изменяя угол
              elem.style.top =   235 + $.radius * Math.cos(f) + 'px';
        }, $.speed)
    }
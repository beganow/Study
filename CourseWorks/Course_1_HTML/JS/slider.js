const slideContainer = document.querySelector(".container"); // контейнер слайдов
const slide = document.querySelector(".slides"); // получаем контейнер слайдов
const nextBtn = document.getElementById("next-btn"); // кнопка вперед
const prevBtn = document.getElementById("prev-btn"); // кнопка назад
const interval = 3000; // интервал между слайдами
let slides = document.querySelectorAll(".slide"); // получаем все слайды
let index = 0; // индекс текущего слайда
let slideId;

const firstClone = slides[0].cloneNode(true); // клонируем первый слайд  и добавляем его в конец контейнера слайдов
const lastClone = slides[slides.length - 1].cloneNode(true); // клонируем последний слайд и добавляем его в начало контейнера слайдов

firstClone.id = "first-clone"; // добавляем id клонированному слайду
lastClone.id = "last-clone"; // добавляем клонированный слайд в конец контейнера слайдов

slide.append(firstClone); // добавляем клонированный слайд в конец контейнера слайдов
slide.prepend(lastClone); // добавляем клонированный слайд в начало контейнера слайдов
var slideWidth; // ширина слайда
setInterval(() => {
  slideWidth = slides[0].clientWidth;
}, 0);
slide.style.transform = `translateX(${-slideWidth * index}px)`; // перемещаем слайд на нужную позицию
const startSlide = () => {
  // запускаем слайдер
  slideId = setInterval(() => {
    moveToNextSlide(); //
  }, interval);
};

const getSlides = () => document.querySelectorAll(".slide"); // получаем все слайды
slide.addEventListener("transitionend", () => {
  // при завершении анимации
  slides = getSlides(); //  получаем все слайды
  if (slides[index].id === firstClone.id) {
    // если переместились на первый слайд
    slide.style.transition = "none"; // отключаем анимацию
    index = 1; // возвращаем индекс на первый слайд
    slide.style.transform = `translateX(${-slideWidth * index}px)`; // перемещаем слайд на первый слайд
  }

  if (slides[index].id === lastClone.id) {
    // если переместились на последний слайд
    slide.style.transition = "none"; // отключаем анимацию
    index = slides.length - 2; // возвращаем индекс на последний слайд
    slide.style.transform = `translateX(${-slideWidth * index}px)`; // перемещаем слайд на последний слайд
  }
});
const moveToNextSlide = () => {
  slides = getSlides(); //  получаем все слайды
  if (index >= slides.length - 1) return; // если переместились на последний слайд
  index++; // увеличиваем индекс
  slide.style.transition = ".7s ease-out";
  slide.style.transform = `translateX(${-slideWidth * index}px)`;
};

const moveToPreviousSlide = () => {
  if (index <= 0) return; // если переместились на первый слайд
  index--; // уменьшаем индекс
  slide.style.transition = ".7s ease-out";
  slide.style.transform = `translateX(${-slideWidth * index}px)`;
};

slideContainer.addEventListener("mouseenter", () => {
  // при наведении на контейнер слайдов
  clearInterval(slideId); // останавливаем слайдер
});

slideContainer.addEventListener("mouseleave", startSlide); // при отведении курсора от контейнера слайдов
nextBtn.addEventListener("click", moveToNextSlide); // при нажатии на кнопку "следующий слайд"
prevBtn.addEventListener("click", moveToPreviousSlide); // при нажатии на кнопку "предыдущий слайд"

startSlide(); // запускаем слайдер


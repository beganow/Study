// Получаем элементы слайдера
const slider = document.querySelector('.slider');
const prevButton = document.querySelector('.prev-button');
const nextButton = document.querySelector('.next-button');
const slides = Array.from(slider.querySelectorAll('img'));
const slideCount = slides.length;
let slideIndex = 0;

// Устанавливаем обработчики событий для кнопок
prevButton.addEventListener('click', showPreviousSlide);
nextButton.addEventListener('click', showNextSlide);
// Получаем элементы слайдера

document.querySelector('.burger-menu').addEventListener('click', function () {
  document.querySelector('.menu').classList.toggle('active');
  document.querySelector('.burger-menu').classList.toggle('change'); // Добавляем класс change при клике на бургер-меню
});



// Функция для показа предыдущего слайда
function showPreviousSlide() {
  slideIndex = (slideIndex - 1 + slideCount) % slideCount;
  updateSlider();
}

// Функция для показа следующего слайда
function showNextSlide() {
  slideIndex = (slideIndex + 1) % slideCount;
  updateSlider();
}

// Функция для обновления заголовка
function updateCaption() {
  const captions = ['Тема: Мультиварка', 'Выполнил: Ободов Павел Андреевич<br>ФИТ 3-2']; // Замените на нужные заголовки
  const currentCaption = captions[slideIndex]; // Получаем текущий заголовок
  document.querySelector('.slider-caption').innerHTML = currentCaption; // Обновляем заголовок
}


// Функция для обновления отображения слайдера
function updateSlider() {
  slides.forEach((slide, index) => {
    if (index === slideIndex) {
      slide.style.display = 'block'; // Показываем текущий слайд
    } else {
      slide.style.display = 'none'; // Скрываем предыдущий слайд
    }
  });
  updateCaption(); // Обновляем заголовок при смене слайда
}

// Инициализация слайдера
updateSlider();
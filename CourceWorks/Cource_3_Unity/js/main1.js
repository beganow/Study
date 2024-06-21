document.querySelector('.burger-menu').addEventListener('click', function () {
    document.querySelector('.menu').classList.toggle('active');
    document.querySelector('.burger-menu').classList.toggle('change'); // Добавляем класс change при клике на бургер-меню
});

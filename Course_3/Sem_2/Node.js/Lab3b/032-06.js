// Функция для вычисления квадрата числа
function square(number) {
    return new Promise((resolve, reject) => {
        if (typeof number !== 'number') {
            reject('Invalid input');
        } else {
            setTimeout(() => {
                const result = number * number;
                resolve(result);
            }, 2000); // Разрешение Promise спустя 2 секунды
        }
    });
}

// Функция для вычисления куба числа
function cube(number) {
    return new Promise((resolve, reject) => {
        if (typeof number !== 'number') {
            reject('Invalid input');
        } else {
            setTimeout(() => {
                const result = number * number * number;
                resolve(result);
            }, 3000); // Разрешение Promise спустя 3 секунды
        }
    });
}

// Функция для вычисления четвертой степени числа
function fourthPower(number) {
    return new Promise((resolve, reject) => {
        if (typeof number !== 'number') {
            reject('Invalid input');
        } else {
            setTimeout(() => {
                const result = Math.pow(number, 4);
                resolve(result);
            }, 4000); // Разрешение Promise спустя 4 секунды
        }
    });
}

// Вычисление квадрата, куба и четвертой степени числа с использованием Promise.race()
const number = 5;

Promise.race([square(number), cube(number), fourthPower(number)])
    .then((result) => {
        console.log('First result:', result);
    })
    .catch((error) => {
        console.error('Error:', error);
    });

// Получение первого разрешенного Promise с использованием Promise.any()
Promise.any([square(number), cube(number), fourthPower(number)])
    .then((result) => {
        console.log('First resolved result:', result);
    })
    .catch((errors) => {
        console.error('All promises rejected:', errors);
    });
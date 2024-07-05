// Функция для вычисления квадрата числа
function square(number) {
    return new Promise((resolve, reject) => {
        if (typeof number !== 'number') {
            reject('Invalid input');
        } else {
            const result = number * number;
            resolve(result);
        }
    });
}

// Функция для вычисления куба числа
function cube(number) {
    return new Promise((resolve, reject) => {
        if (typeof number !== 'number') {
            reject('Invalid input');
        } else {
            const result = number * number * number;
            resolve(result);
        }
    });
}

// Функция для вычисления четвертой степени числа
function fourthPower(number) {
    return new Promise((resolve, reject) => {
        if (typeof number !== 'number') {
            reject('Invalid input');
        } else {
            const result = Math.pow(number, 4);
            resolve(result);
        }
    });
}

// Вычисление квадрата, куба и четвертой степени числа с использованием Promise.all()
const number = 5;

Promise.all([square(number), cube(number), fourthPower(number)])
    .then((results) => {
        const squareResult = results[0];
        const cubeResult = results[1];
        const fourthPowerResult = results[2];

        console.log(`Square of ${number}: ${squareResult}`);
        console.log(`Cube of ${number}: ${cubeResult}`);
        console.log(`Fourth power of ${number}: ${fourthPowerResult}`);
    })
    .catch((error) => {
        console.error('Error:', error);
    });
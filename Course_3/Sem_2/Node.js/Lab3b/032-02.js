const http = require('http');

// Функция, возвращающая Promise
function secondJob() {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            reject('Error');
        }, 3000);
    });
}

// Обработка Promise с помощью обработчиков .then() и .catch()
function handleSecondJobWithHandlers(req, res) {
    secondJob()
        .then(result => res.end(result))
        .catch(error => res.end(error));
}

// Обработка Promise с помощью async/await и try/catch
async function handleSecondJobWithAsyncAwait(req, res) {
    try {
        let result = await secondJob();
        res.end(result);
    } catch (error) {
        res.end(error);
    }
}

// Создание сервера
http.createServer((req, res) => {
    if (req.url === '/w') {
        handleSecondJobWithHandlers(req, res);
    } else if (req.url === '/async') {
        handleSecondJobWithAsyncAwait(req, res);
    } else {
        res.end('Invalid route');
    }
}).listen(3000);

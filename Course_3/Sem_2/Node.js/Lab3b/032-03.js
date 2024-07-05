const http = require('http');
const url = require('url');

// Функция, возвращающая Promise
function thirdJob(data) {
    return new Promise((resolve, reject) => {
        if (isNaN(data)) {
            reject('error');
        } else if (data % 2 !== 0) {
            setTimeout(() => {
                resolve('odd');
            }, 1000);
        } else {
            setTimeout(() => {
                reject('even');
            }, 2000);
        }
    });
}

function handleThirdJobWithHandlers(req, res, number) {
    const data = Number(number);

    thirdJob(data)
        .then(result => res.end(result))
        .catch(error => res.end(error));
}

async function handleThirdJobWithAsyncAwait(req, res, number) {
    const data = Number(number);

    try {
        let result = await thirdJob(data);
        res.end(result);
    } catch (error) {
        res.end(error);
    }
}

// Создание сервера
http.createServer((req, res) => {
    const urlPath = url.parse(req.url).pathname;
    const urlParts = urlPath.split('/');

    if (urlParts.length === 3 && urlParts[1] === 'handler') {
        const number = urlParts[2];

        handleThirdJobWithHandlers(req, res, number);
    } else if (urlParts.length === 3 && urlParts[1] === 'async-await') {
        const number = urlParts[2];

        handleThirdJobWithAsyncAwait(req, res, number);
    } else {
        res.statusCode = 404;
        res.end('Not Found');
    }
}).listen(3000);
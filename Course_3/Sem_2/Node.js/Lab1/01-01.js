const http = require('http');

const hostname = '127.0.0.1';
const port = 3000;

const server = http.createServer((req, res) => {
    res.statusCode = 200;
    res.setHeader('Content-Type', 'text/html');

    // Формируем HTML-страницу с информацией о запросе
    requestInfo = `
        <h1>Hello world!</h1>
    `;

    // Если есть тело запроса, добавляем его в HTML
    let requestBody = '';
    req.on('data', chunk => {
        requestBody += chunk.toString();
    });
    req.on('end', () => {
        if (requestBody) {
            requestInfo += `<h2>Task 2</h2><p>${requestBody}</p>`;
        }
        res.end(`<!DOCTYPE html><html><head><title>Lab1Tk1</title></head><body>${requestInfo}</body></html>`);
    });
});

server.listen(port, hostname, () => {
    console.log(`Server running at http://${hostname}:${port}/`);
});
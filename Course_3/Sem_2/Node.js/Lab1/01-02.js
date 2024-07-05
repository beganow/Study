const http = require('http');

const hostname = '127.0.0.1';
const port = 3000;

const server = http.createServer((req, res) => {
    res.statusCode = 200;
    res.setHeader('Content-Type', 'text/html');

    // Формируем HTML-страницу с информацией о запросе
    requestInfo = `
        <h1>Task 2</h1>
        <p><strong>Method:</strong> ${req.method}</p>
        <p><strong>URI:</strong> ${req.url}</p>
        <p><strong>HTTP Version:</strong> ${req.httpVersion}</p>
        <h2>Headers:</h2>
        <ul>
            ${Object.keys(req.headers).map(key => `<li><strong>${key}:</strong> ${req.headers[key]}</li>`).join('')}
        </ul>
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
        res.end(`<!DOCTYPE html><html><head><title>Lab1Tk2</title></head><body>${requestInfo}</body></html>`);
    });
});

server.listen(port, hostname, () => {
    console.log(`Server running at http://${hostname}:${port}/`);
});
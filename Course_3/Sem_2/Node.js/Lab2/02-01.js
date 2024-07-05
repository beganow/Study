const http = require('http');
const fs = require('fs');
const port = 5000;

const server = http.createServer((req, res) => {
    if (req.url === '/html') {
        fs.readFile('index.html', (err, data) => {
            if (err) {
                res.writeHead(404);
                res.end(JSON.stringify(err));
                return;
            }
            res.writeHead(200, { 'Content-Type': 'text/html; charset=utf-8' });
            res.end(data);
        });
    }
});

server.listen(port, () => {
    console.log(`Сервер запущен на http://localhost:${port}`);
});

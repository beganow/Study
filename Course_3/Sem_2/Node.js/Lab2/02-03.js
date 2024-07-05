const http = require('http');

const port = 5000;
const fullName = 'Ободов Павел Андреевич';

const server = http.createServer((req, res) => {
    if (req.url === '/api/name') {
        if (req.method === 'GET') {
            res.writeHead(200, { 'Content-Type': 'text/plain; charset=utf-8' });
            res.end(fullName);
        } else {
            res.writeHead(405);
            res.end();
        }
    } else {
        res.writeHead(404);
        res.end();
    }
});

server.listen(port, () => {
    console.log(`Сервер запущен на http://localhost:${port}`);
});
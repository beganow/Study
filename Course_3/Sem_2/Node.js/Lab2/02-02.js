const http = require('http');
const fs = require('fs');
const path = require('path');

const port = 5000;
const filePath = path.join(__dirname, 'spb.png');

const server = http.createServer((req, res) => {
    if (req.url === '/png') {
        fs.readFile(filePath, (err, data) => {
            if (err) {
                res.writeHead(404);
                res.end(JSON.stringify(err));
                return;
            }
            res.writeHead(200, { 'Content-Type': 'image/png' });
            res.end(data);
        });
    }
});

server.listen(port, () => {
    console.log(`Сервер запущен на http://localhost:${port}`);
});
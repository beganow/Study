const http = require('http');
const path = require('path');
const fs = require('fs');

const server = http.createServer((req, res) => {
    if (req.url == '/api/name') {
        res.writeHead(200, {
            'Content-Type': 'text/plain;charset=UTF-8',
        })
        res.end('Ободов Павел Андреевич')
    } else if (req.url == '/xmlhttprequest') {
        let filePath = path.join(__dirname, 'xmlhttprequest.html');
        let stat = fs.statSync(filePath);

        res.writeHead(200, {
            'Content-Type': 'text/html',
            'Content-Length': stat.size
        });

        let readStream = fs.createReadStream(filePath);

        readStream.pipe(res);
    }
    else if (req.url == '/fetch') {
        let filePath = path.join(__dirname, 'fetch.html');
        let stat = fs.statSync(filePath);

        res.writeHead(200, {
            'Content-Type': 'text/html',
            'Content-Length': stat.size
        });

        let readStream = fs.createReadStream(filePath);

        readStream.pipe(res);
    }
    else if (req.url == '/jquery') {
        let filePath = path.join(__dirname, 'jquery.html');
        let stat = fs.statSync(filePath);

        res.writeHead(200, {
            'Content-Type': 'text/html',
            'Content-Length': stat.size
        });

        let readStream = fs.createReadStream(filePath);

        readStream.pipe(res);
    }
});

server.listen(5000, () => {
    console.log('Сервер запущен на порту 5000');
});
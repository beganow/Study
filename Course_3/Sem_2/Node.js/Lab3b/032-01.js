const http = require('http');

function firstJob() {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("Hello World");
        }, 2000);
    });
}

const server = http.createServer(async (req, res) => {
    if (req.url === '/') {
        try {
            // С помощью async/await и try/catch
            const result1 = await firstJob();
            res.writeHead(200, { 'Content-Type': 'text/plain' });
            res.end(result1);
        } catch (error) {
            res.writeHead(500, { 'Content-Type': 'text/plain' });
            res.end(error.toString());
        }

        // С помощью явных обработчиков Promise
        firstJob()
            .then(result2 => {
                console.log(result2); // "Hello World"
            })
            .catch(error => {
                console.error(error);
            });

    } else {
        res.writeHead(404, { 'Content-Type': 'text/plain' });
        res.end('Not Found');
    }
});

const port = 3000;
server.listen(port, () => {
    console.log(`Server is running on port ${port}`);
});
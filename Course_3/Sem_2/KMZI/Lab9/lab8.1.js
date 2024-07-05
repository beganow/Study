document.addEventListener("DOMContentLoaded", function () {
    const input = "ободовпавел";
    const output = document.getElementById("output");

    class HuffmanNode {
        constructor(symbol, probability, left = null, right = null) {
            this.symbol = symbol;
            this.probability = probability;
            this.bitCode = "";
            this.left = left;
            this.right = right;
        }
    }

    class HuffmanEncoding {
        static encode(input) {
            const frequency = {};
            for (const ch of input) {
                frequency[ch] = (frequency[ch] || 0) + 1;
            }

            const priorityQueue = Object.entries(frequency).map(([symbol, count]) =>
                new HuffmanNode(symbol, count / input.length)
            );

            while (priorityQueue.length > 1) {
                priorityQueue.sort((a, b) => a.probability - b.probability);
                const left = priorityQueue.shift();
                const right = priorityQueue.shift();
                const newNode = new HuffmanNode(null, left.probability + right.probability, left, right);
                priorityQueue.push(newNode);
            }

            const root = priorityQueue[0];
            const codeTable = {};
            HuffmanEncoding.traverse(root, "", codeTable);
            return { codeTable, frequency };
        }

        static traverse(node, code, codeTable) {
            if (!node.left && !node.right) {
                codeTable[node.symbol] = code;
                node.bitCode = code;
            } else {
                if (node.left) HuffmanEncoding.traverse(node.left, code + "0", codeTable);
                if (node.right) HuffmanEncoding.traverse(node.right, code + "1", codeTable);
            }
        }
    }

    class EncodeDecode {
        static getEncodedMessage(input, codeTable) {
            return input.split('').map(ch => codeTable[ch]).join('');
        }

        static getDecodedMessage(encodedMessage, codeTable) {
            const reverseCodeTable = Object.fromEntries(
                Object.entries(codeTable).map(([k, v]) => [v, k])
            );
            let decodedMessage = '';
            let currentBits = '';
            for (const bit of encodedMessage) {
                currentBits += bit;
                if (reverseCodeTable[currentBits]) {
                    decodedMessage += reverseCodeTable[currentBits];
                    currentBits = '';
                }
            }
            return decodedMessage;
        }

        static encodingToBytes(message) {
            const encoder = new TextEncoder();
            const bytes = encoder.encode(message);
            return Array.from(bytes).map(b => b.toString(2).padStart(8, '0')).join('');
        }
    }

    function displayMessage(message) {
        const p = document.createElement("p");
        p.textContent = message;
        output.appendChild(p);
    }

    function displayTable(headers, rows) {
        const table = document.createElement("table");
        const thead = document.createElement("thead");
        const tr = document.createElement("tr");

        headers.forEach(header => {
            const th = document.createElement("th");
            th.textContent = header;
            tr.appendChild(th);
        });

        thead.appendChild(tr);
        table.appendChild(thead);

        const tbody = document.createElement("tbody");
        rows.forEach(row => {
            const tr = document.createElement("tr");
            row.forEach(cell => {
                const td = document.createElement("td");
                td.textContent = cell;
                tr.appendChild(td);
            });
            tbody.appendChild(tr);
        });

        table.appendChild(tbody);
        output.appendChild(table);
    }

    displayMessage("Сообщение: " + input);

    const { codeTable, frequency } = HuffmanEncoding.encode(input);

    const probabilityTable = Object.entries(frequency).map(([char, count]) => [char, count, (count / input.length).toFixed(6)]);
    displayMessage("Таблица частот и вероятностей:");
    displayTable(["Символ", "Частота", "Вероятность"], probabilityTable);

    displayMessage("Метод сжатия Хаффмана:");
    const huffmanTable = Object.entries(codeTable).map(([char, bits]) => [char, bits]);
    displayTable(["Символы", "Биты"], huffmanTable);

    const encodedMessage = EncodeDecode.getEncodedMessage(input, codeTable);
    const decodedMessage = EncodeDecode.getDecodedMessage(encodedMessage, codeTable);
    displayMessage("Закодированное сообщение: " + encodedMessage);
    displayMessage("Декодированное сообщение: " + decodedMessage);

    displayMessage("В ASCII:");
    const asciiEncoded = EncodeDecode.encodingToBytes(input);
    displayMessage("Закодированное сообщение: " + asciiEncoded);
    displayMessage("Сообщение: " + input);

    displayMessage("Символов после сжатия:");
    displayMessage("методом Хаффмана: " + encodedMessage.length);
    displayMessage("в ASCII: " + asciiEncoded.length);

    const times = (asciiEncoded.length / encodedMessage.length).toFixed(2);
    displayMessage("Эффективность сжатия:");
    displayMessage("Методом метода Хаффмана мы уменьшили общий размер данных в " + times + " раз по сравнению с кодом, полученным преобразованием в коды ASCII");
});

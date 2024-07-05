document.addEventListener("DOMContentLoaded", function () {
    const input = "ободовпавел";
    const output = document.getElementById("output");

    const chars = [];
    const frequency = [];
    const probability = [];
    const lettersArray = [];
    const frequenciesArray = [];
    const probabilitiesArray = [];
    const letterBitsArray = [];

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

    function getProbabylityAndFrequency(inputMessage) {
        [...new Set(inputMessage)].forEach(ch => {
            const count = inputMessage.split(ch).length - 1;
            chars.push(ch);
            frequency.push(count);
            probability.push(count / inputMessage.length);
        });
    }

    function getArrayFromChars() {
        for (let i = 0; i < chars.length; i++) {
            lettersArray[i] = chars[i];
            frequenciesArray[i] = frequency[i];
            probabilitiesArray[i] = probability[i];
        }
    }

    function printResults() {
        const headers = ["Символ", "Частота", "Вероятность"];
        const rows = lettersArray.map((char, i) => [char, frequenciesArray[i], probabilitiesArray[i].toFixed(6)]);
        displayTable(headers, rows);
    }

    function getSortedArray() {
        const combined = lettersArray.map((char, i) => ({ char, probability: probabilitiesArray[i] }));
        combined.sort((a, b) => b.probability - a.probability);

        combined.forEach((item, i) => {
            lettersArray[i] = item.char;
            probabilitiesArray[i] = item.probability;
        });
    }

    function getSummaryProbabilities() {
        return probabilitiesArray.reduce((acc, prob) => acc + prob, 0);
    }

    function shannonFano(left, right) {
        if (left >= right) return;
        const splitPoint = toSplitSequences(left, right);
        for (let i = left; i <= splitPoint; i++) letterBitsArray[i] += "0";
        for (let i = splitPoint + 1; i <= right; i++) letterBitsArray[i] += "1";
        shannonFano(left, splitPoint);
        shannonFano(splitPoint + 1, right);
    }

    function toSplitSequences(left, right) {
        const total = probabilitiesArray.slice(left, right + 1).reduce((acc, prob) => acc + prob, 0);
        const halfTotal = total / 2;
        let acc = 0;
        let i;
        for (i = left; i <= right; i++) {
            acc += probabilitiesArray[i];
            if (acc >= halfTotal) break;
        }
        return i;
    }

    function getEncodeMessage(input, charsArray, charBitsArray) {
        return input.split('').map(ch => charBitsArray[charsArray.indexOf(ch)]).join('');
    }

    function getDecodedMessage(encodedMessage, charsArray, charBitsArray) {
        let decodedMessage = '';
        let currentBits = '';
        for (const bit of encodedMessage) {
            currentBits += bit;
            const index = charBitsArray.indexOf(currentBits);
            if (index !== -1) {
                decodedMessage += charsArray[index];
                currentBits = '';
            }
        }
        return decodedMessage;
    }

    function encodingToBytes(message) {
        const bytes = new TextEncoder("windows-1251").encode(message);
        return Array.from(bytes).map(b => b.toString(2).padStart(8, '0')).join('');
    }

    displayMessage("Сообщение: " + input);
    displayMessage("Рассчет вероятностей появления символов в сообщении:");

    getProbabylityAndFrequency(input);
    getArrayFromChars();
    printResults();

    getSortedArray();

    letterBitsArray.length = lettersArray.length;
    letterBitsArray.fill("");

    const sumOfProbabilities = getSummaryProbabilities();
    displayMessage("Сумма вероятностей = " + sumOfProbabilities);

    displayMessage("Метод сжатия Шеннона-Фано:");
    shannonFano(0, lettersArray.length - 1);

    const headers = ["Символы", "Биты"];
    const rows = lettersArray.map((char, i) => [char, letterBitsArray[i]]);
    displayTable(headers, rows);

    const encodedMessage = getEncodeMessage(input, lettersArray, letterBitsArray);
    const decodedMessage = getDecodedMessage(encodedMessage, lettersArray, letterBitsArray);
    displayMessage("Закондированное сообщение: " + encodedMessage);
    displayMessage("Декодированное сообщение: " + decodedMessage);

    displayMessage("В ASCII:");
    const asciiEncoded = encodingToBytes(input);
    displayMessage("Закодированное сообщение: " + asciiEncoded);
    displayMessage("Сообщение: " + input);

    displayMessage("Символов после сжатия:");
    displayMessage("методом Шеннона-Фано: " + encodedMessage.length);
    displayMessage("в ASCII: " + asciiEncoded.length);

    const times = (asciiEncoded.length / encodedMessage.length).toFixed(2);
    displayMessage("Эффективность сжатия:");
    displayMessage("Методом метода Шеннона-Фано мы уменьшили общий размер данных в " + times + " раз по сравнению с кодом, полученным преобразованием в коды ASCII");
});

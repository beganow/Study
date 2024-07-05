var matrix;
document.getElementById('convertButton').addEventListener('click', function () {
    const file = document.getElementById('fileInput').files[0];
    if (file) {
        const reader = new FileReader();

        reader.onload = function () {
            const binaryData = textToBinary(reader.result);
            document.getElementById('binaryOutput').innerText = binaryData;
            let output = '';
            const k = binaryData.length;
            const r = Math.floor(Math.log2(k)) + 1;
            document.getElementById('Matrix').addEventListener('click', function () {

                var checkMatrix = hammingMatrix(r, k);
                matrix = checkMatrix;
                for (let i = 0; i < r; i++) {
                    output += checkMatrix[i].join(' ') + '<br>';
                    console.log(checkMatrix[i].join(' '));
                }
                document.getElementById('binaryOutput1').innerHTML = output;
            });

            document.getElementById('izbitok').addEventListener('click', function () {
                const izbitok = calculateRedundantBits(binaryData, output, r, k);
                document.getElementById('redundantBitsOutput').innerText = "Yr=" + izbitok;
            });
        }
        reader.readAsText(file);
    } else {
        alert('Выберите файл');
    }
});


function textToBinary(text) {
    let binStr = '';
    for (let i = 0; i < text.length; i++) {
        if (text[i] !== ' ') {
            binStr += text[i].charCodeAt(0).toString(2).padStart(8, '0');
        }
    }
    return binStr;
}

function factorial(n) {
    if (n === 1) return 1;
    else return n * this.factorial(n - 1);
}

function newtonBinom(wt, r) {
    return this.factorial(r) / (this.factorial(wt) * this.factorial(r - wt));
}

function matrixA(r, k) {
    let countOfColumn = 0;
    let wt = 2;

    const matrixA = [];
    while (true) {
        let amountAllCombination = this.newtonBinom(wt, r);
        let rightCombination = 0;
        let number = 3;

        while (rightCombination !== amountAllCombination && countOfColumn !== k) {
            let binaryNumber = number.toString(2);
            let binaryNumberLength = binaryNumber.length;

            let unitCounter = 0;

            for (let i = 0; i < binaryNumberLength; i++) {
                if (binaryNumber[i] === '1') unitCounter++;
            }

            if (unitCounter === wt) {
                countOfColumn++;

                if (binaryNumberLength < r) {
                    binaryNumber = '0'.repeat(r - binaryNumberLength) + binaryNumber;
                }

                matrixA.push(Array.from(binaryNumber));
                rightCombination++;
            }
            number++;
        }

        if (countOfColumn !== k) wt++;
        else break;
    }
    return matrixA;
}
function matrixI(r) {
    const matrixI = [];

    for (let i = 0; i < r; i++) {
        const row = [];
        for (let j = 0; j < r; j++) {
            row.push(i === 0 ? '1' : '0');
        }
        matrixI.push(row);
    }
    return matrixI;
}

function hammingMatrix(r, k) {
    const hammingMatrix = [];
    const matrixA = this.matrixA(r, k);
    const matrixI = this.matrixI(r);

    for (let i = 0; i < k; i++) {
        hammingMatrix.push(matrixA.map(row => row[i]));
    }

    for (let i = k; i < k + r; i++) {
        hammingMatrix.push(matrixI.map(row => row[i - k]));
    }
    return hammingMatrix;
}

function XOR(a, b) {
    let result = '';
    for (let i = 0; i < Math.max(a.length, b.length); i++) {
        if ((a[i] === '0' && b[i] === '0') || (a[i] === '1' && b[i] === '1')) {
            result += '0';
        } else {
            result += '1';
        }
    }
    return result;
}




function calculateRedundantBits(Xk, hammingMatrix, r, k) {
    let Xr = '';
    for (let i = 0; i < r; i++) {
        let pairs = 0;
        for (let j = 0; j < k; j++) {
            if (hammingMatrix[i][j] === '1' && Xk[j] === '1') pairs++;
        }
        Xr += pairs % 2 === 0 ? '0' : '1';
    }
    return Xr;
}




function binaryToText(binaryData) {
    let result = '';
    for (let i = 0; i < binaryData.length; i += 8) {
        let byte = binaryData.substr(i, 8);
        result += String.fromCharCode(parseInt(byte, 2));
    }
    return result;
}




function generateError(binaryData, numErrors) {
    let Yk = binaryData.split('');
    let prevPosition = 100;

    for (let i = 0; i < numErrors; i++) {
        let currentPosition = Math.floor(Math.random() * binaryData.length);
        while (currentPosition === prevPosition) {
            currentPosition = Math.floor(Math.random() * binaryData.length);
        }
        Yk[currentPosition] = (parseInt(Yk[currentPosition]) ^ 1).toString();
        prevPosition = currentPosition;
    }
    return Yk.join('');
}



let binaryData, correctedData, numErrors, errorVector, syndrome, errorData, Yr1, Xr0, correctedYn, errorPosition1, corr, errorVector1;


document.getElementById('generateError').addEventListener('click', function () {
    binaryData = document.getElementById('binaryOutput').innerText;
    const k = binaryData.length;
    const r = Math.floor(Math.log2(k)) + 1;
    Xr0 = calculateRedundantBits(binaryData, matrix, r, k);
    numErrors = parseInt(document.getElementById('numErrors').value);
    errorData = generateError(binaryData, numErrors);
    correctedData = correctError(errorData, matrix);
    Yr1 = calculateRedundantBits(errorData, matrix, r, k);
    syndrome = XOR(Yr1, Xr0);
    errorPosition1 = errorPosition(matrix, syndrome, r, k);
    corr = Yr1.substring(r);
    document.getElementById('errorOutput').innerText = errorData;
    document.getElementById('errorOutput1').innerText = "Yn=" + binaryToText(errorData);
});

document.getElementById('recalculate').addEventListener('click', function () {

    document.getElementById('redundantBitsOutput2').innerText = "Yr'=" + Yr1;

});

function correctError(binaryData, matrix) {
    binaryData = document.getElementById('binaryOutput').innerText;
    const k = binaryData.length;
    const r = Math.floor(Math.log2(k)) + 1;
    errorVector1 = generateErrorVector(errorPosition1, r + k);
    alert(errorVector1);

    if (errorPosition1 !== -1) {
        let correctedYk = '';
        for (let i = 0; i < binaryData.length; i++) {
            if (errorData[i] !== binaryData[i]) {
                errorVector1 = errorVector1.substr(0, i) + '1' + errorVector1.substr(i + 1);
            }
            correctedYk += (errorVector1[i] === '1') ? (binaryData[i] === '0' ? '1' : '0') : errorData[i];
        }

        correctedYn = binaryData;
    } else {
        console.log('Невозможно исправить.');
    }
}

function generateErrorVector(position, n) {
    let errorVector = '';
    for (let i = 0; i < n; i++) {
        errorVector += i !== position ? '0' : '1';
    }
    return errorVector;
}

function errorPosition(matrix, syndrome, r, k) {
    let amountCoincidences = 0;
    for (let i = 0; i < k; i++) {
        for (let j = 0; j < r; j++) {
            if (matrix[j][i] === syndrome[j]) amountCoincidences++;
        }
        if (amountCoincidences === r) return i;
        else amountCoincidences = 0;
    }
    return -1;
}





document.getElementById('correctError').addEventListener('click', function () {
    document.getElementById('syndromeOutput').innerText = "Syndrome: " + syndrome;
    document.getElementById('correctedOutput').innerText = correctedYn;
    document.getElementById('correctedOutput1').innerText = "Yn=" + binaryToText(correctedYn)
    document.getElementById('errorVectorOutput').innerText = "Еn=" + errorVector1;
});

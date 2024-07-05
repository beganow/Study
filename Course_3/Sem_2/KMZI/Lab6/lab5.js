let outputDiv = document.getElementById('output');
function main() {
    //6.1
    let Xk = "100010";
    let Xr = "101111";

    let k = Xk.length;
    let n = 11;
    let r = n - k;

    let error;

    let masXk = new Array(k);
    strInMas(masXk, Xk);

    let masXr = new Array(Xr.length);
    strInMas(masXr, Xr);


    outputDiv.innerHTML += "<p>Входная строка: " + Xk + "</p>";
    outputDiv.innerHTML += "<p>Порождающий полином: " + Xr + "</p>";
    outputDiv.innerHTML += "<p>k = " + k + ", r = " + r + ", n = " + n + "</p>";


    let generationMatrix = new Array(k).fill().map(() => new Array(n));
    createGenerationMatrix(generationMatrix, masXr, k, n);

    outputDiv.innerHTML += "<p>Порождающая матрица</p>";
    outMatrix(generationMatrix, k, n, outputDiv);

    createCanonicalMatrix(generationMatrix, k, n);

    outputDiv.innerHTML += '<br>' + '<br>' + ("\n\nКаноническая матрица");
    outMatrix(generationMatrix, k, n);

    let checkMatrix = new Array(n).fill().map(() => new Array(r));
    createCheckMatrix(checkMatrix, generationMatrix, k, n);

    outputDiv.innerHTML += '<br>' + ("\nПроверочная матрица");
    outMatrix(checkMatrix, n, r);
    //6.2

    let masXn = new Array(n);
    shift(masXn, masXk, r);

    //2.
    outputDiv.innerHTML += '<br>' + ("\nДеление");
    searchResidue(masXn, masXr);

    outputDiv.innerHTML += '<br>' + '<br>' + ("\nОстаток:");
    outMass(masXn);

    outputDiv.innerHTML += '<br>' + '<br>' + ("\nИтоговая строка:");
    shift(masXn, masXk, r);
    outMass(masXn);

    try {

        error = parseInt(prompt()) - 1;
        outputDiv.innerHTML += '<br>' + '<br>' + ("Место первой ошибки " + error);
        if (masXn[error] === 1) masXn[error] = 0;
        else masXn[error] = 1;
    } catch (error) { }

    outputDiv.innerHTML += '<br>' + '<br>' + ("Ошибочная строка:");
    outMass(masXn);
    let codewordWithTwoErrors = [...masXn]; // Создаем копию исходного кодового слова
    introduceTwoErrors(codewordWithTwoErrors); // Вводим две ошибки
    const errorVector = computeErrorVector(codewordWithTwoErrors, masXn); // Генерируем унарный вектор ошибки
    outputDiv.innerHTML += `<p>Кодовое слово с двумя ошибками: ${codewordWithTwoErrors.filter(bit => bit === 0 || bit === 1).join('')}</p>`;

    outputDiv.innerHTML += `<p>Унарный вектор ошибки: ${errorVector.join('')}</p>`;


    searchError(masXn, masXr, checkMatrix, r);

}

function searchError(masXn, masXr, checkMatrix, r) {
    let n = masXn.length;
    let k = n - r;

    let masXnSecond = [...masXn];

    outputDiv.innerHTML += '<br>' + '<br>' + ("\nДеление");
    searchResidue(masXnSecond, masXr);

    outputDiv.innerHTML += '<br>' + '<br>' + ("\nОстаток:");
    outMass(masXnSecond);

    for (let i = 0; i < n; i++) {
        let coincidence = 0;
        for (let j = 0; j < r; j++) {
            if (checkMatrix[i][j] === masXnSecond[k + j]) {
                coincidence++;
            }
        }
        if (coincidence === r) {
            masXn[i] = (masXn[i] + 1) % 2;
            break;
        }
    }
    outputDiv.innerHTML += '<br>' + '<br>' + ("\nИсправленная строка:");
    outMass(masXn);

    return masXn;
}

function searchResidue(masXn, masXr) {
    let end = masXn.length - masXr.length + 1;

    for (let i = 0; i < end; i++) {
        if (masXn[i] === 1) {
            addingMasMod2(masXn, masXr, i);
            outMass(masXn)
        }
    }
    return masXn;
}



function addingMasMod2(mas1, mas2, pos) {
    let end = pos + mas2.length;

    for (let i = pos; i < end; i++) {
        mas1[i] = (mas1[i] + mas2[i - pos]) % 2;
    }
    return mas1;
}

function shift(shiftMas, mas, r) {
    for (let i = 0; i < mas.length; i++) {
        shiftMas[i] = mas[i];
    }
    return shiftMas;
}

function strInMas(mas, str) {
    for (let i = 0; i < str.length; i++) {
        if (str[i] === '1')
            mas[i] = 1;
        else mas[i] = 0;
    }
    return mas;
}

function createGenerationMatrix(generationMatrix, mas, k, n) {
    for (let i = 0; i < n; i++) {
        if (i < mas.length) {
            generationMatrix[0][i] = mas[i];
        } else {
            generationMatrix[0][i] = 0;
        }
    }

    for (let i = 1; i < k; i++) {
        for (let j = 0; j < n - 1; j++) {
            generationMatrix[i][j + 1] = generationMatrix[i - 1][j];
        }
        generationMatrix[i][0] = generationMatrix[i - 1][n - 1];
    }

    return generationMatrix;
}

function createCanonicalMatrix(generationMatrix, k, n) {
    for (let i = 0; i < k; i++) {
        let i2 = i + 1;
        for (let j = i + 1; j < k; j++) {
            if (generationMatrix[i][j] === 1) {
                for (; i2 < k; i2++) {
                    let repeat = false;
                    if (generationMatrix[i2][j] === 1) {
                        for (let j2 = j - 1; j2 > 0; j2--) {
                            if (generationMatrix[i2][j2] === 1) {
                                repeat = true;
                            }
                        }
                        if (repeat)
                            continue;
                        outputDiv.innerHTML += '<br>' + (i + " " + i2);
                        addingLinesMatrixMod2(generationMatrix, i, i2, n);
                        i2++;
                        break;
                    }
                }
            }
        }
    }

    return generationMatrix;
}

function createCheckMatrix(checkMatrix, generationMatrix, k, n) {
    let r = n - k;

    for (let i = 0; i < k; i++) {
        for (let j = 0; j < r; j++) {
            checkMatrix[i][j] = generationMatrix[i][k + j];
        }
    }

    for (let i = k; i < n; i++) {
        for (let j = 0; j < r; j++) {
            if (j === i - k) {
                checkMatrix[i][j] = 1;
            } else {
                checkMatrix[i][j] = 0;
            }
        }
    }

    return checkMatrix;
}

function addingLinesMatrixMod2(matrix, str1, str2, lengthString) {
    for (let i = 0; i < lengthString; i++) {
        matrix[str1][i] = (matrix[str1][i] + matrix[str2][i]) % 2;
    }
    return matrix;
}

function outMatrix(matrix, k, n) {
    for (let i = 0; i < k; i++) {
        let row = "";
        for (let j = 0; j < n; j++) {
            row += matrix[i][j];
        }
        outputDiv.innerHTML += '<br>' + row + '<br>';
    }
}

function outMass(mas) {
    let output = "";
    for (let i = 0; i < mas.length; i++) {
        // Добавляем проверку на биты (0 или 1)
        if (mas[i] === 0 || mas[i] === 1) {
            output += mas[i];
        }
    }
    outputDiv.innerHTML += '<br>' + (output + "\n");
}
function introduceTwoErrors(codeword) {
    const n = codeword.length;
    const errorPositions = [];
    for (let i = 0; i < n; i++) {
        errorPositions.push(i);
    }
    for (let i = 0; i < 2; i++) {
        const randomIndex = Math.floor(Math.random() * errorPositions.length);
        const errorPosition = errorPositions[randomIndex];
        codeword[errorPosition] = (codeword[errorPosition] + 1) % 2; // Инвертируем бит
        errorPositions.splice(randomIndex, 1); // Удаляем использованную позицию
    }
}

// Функция для вычисления унарного вектора ошибки
function computeErrorVector(codeword, originalCodeword) {
    const errorVector = [];
    for (let i = 0; i < codeword.length; i++) {
        if (codeword[i] !== originalCodeword[i]) {
            errorVector.push(1);
        } else {
            errorVector.push(0);
        }
    }
    return errorVector;
}


main(document.getElementById('output'));;

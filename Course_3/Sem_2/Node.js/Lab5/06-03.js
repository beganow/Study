
import { send } from "./m06_OPA.js"

const pass = 'cxbs swtb hmkm vcqt';
let message = 'Hello from 05-03!';
const from = 'pashok12.obodov@gmail.com'; // Замените на ваше отправляющее адрес электронной почты
const to = 'pashok12.obodov@gmail.com'; // Замените на адрес электронной почты получателя


async function main() {
    try {
        await send(from, to, pass, message);
        console.log('Функция send успешно выполнена');
    } catch (error) {
        console.error('Произошла ошибка при выполнении функции send:', error);
    }
}

main();

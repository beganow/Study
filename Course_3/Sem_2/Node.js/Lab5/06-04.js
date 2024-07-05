import { send } from "m05_opa";
async function main() {
    const from = 'pashok12.obodov@gmail.com'; // тут почта
    const to = 'pashok12.obodov@gmail.com\n';
    const pass = 'cxbs swtb hmkm vcqt';
    let message = 'Hello from 05-04!';

    try {
        await send(from, to, pass, message);
        console.log('Функция send успешно выполнена');
    } catch (error) {
        console.error('Произошла ошибка при выполнении функции send:', error);
    }
}

main();
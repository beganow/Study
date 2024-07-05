const { v4: uuidv4 } = require('uuid');

// Функция для проверки валидности карты
function validateCard(cardNumber) {
  console.log('Card number:', cardNumber);
  // Рандомное значение true или false
  return Math.random() < 0.5;
}

// Функция для создания заказа
function createOrder(cardNumber) {
  return new Promise((resolve, reject) => {
    if (!validateCard(cardNumber)) {
      reject('Card is not valid');
    } else {
      // Генерация номера заказа
      const orderId = uuidv4();

      setTimeout(() => {
        resolve(orderId);
      }, 5000);
    }
  });
}

// Функция для процесса оплаты
function proceedToPayment(orderId) {
  console.log('Order ID:', orderId);

  return new Promise((resolve, reject) => {
    // Рандомное разрешение или отклонение Promise
    if (Math.random() < 0.5) {
      resolve('Payment successful');
    } else {
      reject('Payment failed');
    }
  });
}

// Использование с помощью обработчиков Promise
createOrder('1234567890123456')
  .then((orderId) => {
    console.log('Order created:', orderId);
    return proceedToPayment(orderId);
  })
  .then((paymentResult) => {
    console.log('Payment result:', paymentResult);
  })
  .catch((error) => {
    console.error('Error:', error);
  });

// Использование с использованием конструкции async/await и try/catch
async function processOrder() {
  try {
    const orderId = await createOrder('1234567890123456');
    console.log('Order created:', orderId);

    const paymentResult = await proceedToPayment(orderId);
    console.log('Payment result:', paymentResult);
  } catch (error) {
    console.error('Error:', error);
  }
}

processOrder();
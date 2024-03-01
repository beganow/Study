import sqlite3
from datetime import datetime
# Класс для представления клиентов
class Customer:
    def __init__(self, customer_id, name, surname, address, phone, email):
        self.customer_id = customer_id
        self.name = name
        self.surname = surname
        self.address = address
        self.phone = phone
        self.email = email

# Класс для представления водителей
class Driver:
    def __init__(self, driver_id, name, surname, address, phone, license):
        self.driver_id = driver_id
        self.name = name
        self.surname = surname
        self.address = address
        self.phone = phone
        self.license = license

# Класс для представления автомобилей
class Vehicle:
    def __init__(self, vehicle_id, type, license_plate, model, status_id, location, fuel, issue_year, color):
        self.vehicle_id = vehicle_id
        self.type = type
        self.license_plate = license_plate
        self.model = model
        self.status_id = status_id
        self.location = location
        self.fuel = fuel
        self.issue_year = issue_year
        self.color = color

# Класс для представления заказов
class Order:
    def __init__(self, order_id, driver_id, customer_id, review_id, vehicle_id, datetime, startpoint, endpoint, price, status_id):
        self.order_id = order_id
        self.driver_id = driver_id
        self.customer_id = customer_id
        self.review_id = review_id
        self.vehicle_id = vehicle_id
        self.datetime = datetime
        self.startpoint = startpoint
        self.endpoint = endpoint
        self.price = price
        self.status_id = status_id

# Класс для представления платежей
class Payment:
    def __init__(self, payment_id, order_id, amount, datetime, method_id):
        self.payment_id = payment_id
        self.order_id = order_id
        self.amount = amount
        self.datetime = datetime
        self.method_id = method_id

class VehicleDriverView:
    def __init__(self, vehicle_id, license_plate, driver_name, driver_surname, driver_address, driver_phone):
        self.vehicle_id = vehicle_id
        self.license_plate = license_plate
        self.driver_name = driver_name
        self.driver_surname = driver_surname
        self.driver_address = driver_address
        self.driver_phone = driver_phone



# Подключение к базе данных
conn = sqlite3.connect('D:\БД-3\sqlite\TransportService.db')
cursor = conn.cursor()
def add_new_order(driver_id, client_id, car_id, startpoint, endpoint, price, status_id):
    current_datetime = datetime.now().strftime("%Y-%m-%d %H:%M:%S")

    # Insert the new order into the Orders table
    cursor.execute("""
        INSERT INTO Orders (driver_id, client_id, car_id, Order_DateTime, startpoint, endpoint, price, status_id)
        VALUES (?, ?, ?, ?, ?, ?, ?, ?)
    """, (driver_id, client_id, car_id, current_datetime, startpoint, endpoint, price, status_id))

    # Commit the transaction
    conn.commit()

# Example usage:
# Assuming you have driver_id, client_id, car_id, startpoint, endpoint, price, status_id values
driver_id = 1
client_id = 2
car_id = 3
startpoint = "A"
endpoint = "B"
price = 50
status_id = 5

# Adding a new order
add_new_order(driver_id, client_id, car_id, startpoint, endpoint, price, status_id)
# Пример использования объектов
# Получение списка клиентов
cursor.execute("SELECT * FROM Customers")
customers = []
for row in cursor.fetchall():
    customer = Customer(row[0], row[1], row[2], row[3], row[4], row[5])
    customers.append(customer)

# Получение списка заказов
cursor.execute("SELECT * FROM Orders")
orders = []
for row in cursor.fetchall():
    order = Order(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9])
    orders.append(order)

# Получение списка платежей
cursor.execute("SELECT * FROM Payments")
payments = []
for row in cursor.fetchall():
    payment = Payment(row[0], row[1], row[2], row[3], row[4])
    payments.append(payment)

cursor.execute("SELECT * FROM VehicleDriverView")
vehicle_driver_views = []
for row in cursor.fetchall():
    vehicle_driver_view = VehicleDriverView(row[0], row[1], row[2], row[3], row[4], row[5])
    vehicle_driver_views.append(vehicle_driver_view)



# Использование полученных объектов
# Вывод списка клиентов
for customer in customers:
    print(f"Customer ID: {customer.customer_id}, Name: {customer.name}, Surname: {customer.surname}")

# Вывод списка заказов
for order in orders:
    print(f"Order ID: {order.order_id}, Driver ID: {order.driver_id}, Customer ID: {order.customer_id}, Status id: {order.status_id}")

# Вывод списка платежей
for payment in payments:
    print(f"Payment ID: {payment.payment_id}, Order ID: {payment.order_id}, Amount: {payment.amount}")

for vehicle_driver_view in vehicle_driver_views:
    print(f"Vehicle ID: {vehicle_driver_view.vehicle_id}, License Plate: {vehicle_driver_view.license_plate}")
    print(f"Driver: {vehicle_driver_view.driver_name} {vehicle_driver_view.driver_surname}, Address: {vehicle_driver_view.driver_address}, Phone: {vehicle_driver_view.driver_phone}")

# Function to add a new order


# Закрытие соединения с базой данных
conn.close()
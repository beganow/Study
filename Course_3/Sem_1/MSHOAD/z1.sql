select emp_id, prd_type_id, year, month, sales_amount
from all_sales
model 
partition by (prd_type_id, month, year)
dimension by (emp_id)
measures (amount sales_amount)
rules (
sales_amount[for emp_id from 21 to 22 increment 1] = sales_amount[currentv()]*1.1,
sales_amount[for emp_id from 22 to 26 increment 1] = sales_amount[currentv()]*1.05
)
order by year DESC, month, emp_id, prd_type_id;
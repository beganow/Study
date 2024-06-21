SELECT emp_id, year, month, sales_amount
FROM
    all_sales
MODEL
    PARTITION BY (prd_type_id, emp_id)
    DIMENSION BY (month, year)
    MEASURES (amount sales_amount)
    RULES (
        sales_amount[FOR month FROM 1 TO 12 INCREMENT 1, 2023] =
            AVG(sales_amount)[MONTH BETWEEN currentv() AND (currentv() - 3), 2022]
    );
# Budget Tracker API

## Expense Controller API Routes

### List All Expenses

- **Route:** `GET /api/Expense`
- **Description:** Retrieves a list of all expenses.
- **Response:** 
  - Status Code: 200 OK
  - Body: JSON array containing expense objects.

### Add New Expense

- **Route:** `POST /api/Expense`
- **Description:** Adds a new expense to the system.
- **Request Body:** Expense object to be added.
- **Response:** 
  - Status Code: 201 Created
  - Body: JSON object representing the newly created expense.
- **Error Response:**
  - Status Code: 400 Bad Request
  - Body: Error message if the expense could not be added.

### Update Expense

- **Route:** `PUT /api/Expense`
- **Description:** Updates an existing expense.
- **Request Body:** Updated expense object.
- **Response:** 
  - Status Code: 202 Accepted
  - Body: JSON object representing the updated expense.
- **Error Response:**
  - Status Code: 400 Bad Request
  - Body: Error message if the expense could not be updated.

### Delete Expense

- **Route:** `DELETE /api/Expense`
- **Description:** Deletes an existing expense.
- **Request Body:** Expense object to be deleted.
- **Response:** 
  - Status Code: 200 OK
  - Body: Success message indicating the expense was deleted.
- **Error Response:**
  - Status Code: 400 Bad Request
  - Body: Error message if the expense could not be deleted.


## Income Controller API Routes

### List All Income

- **Route:** `GET /api/Income`
- **Description:** Retrieves a list of all income records.
- **Response:** 
  - Status Code: 200 OK
  - Body: JSON array containing income objects.

### Add New Income

- **Route:** `POST /api/Income`
- **Description:** Adds a new income record to the system.
- **Request Body:** Income object to be added.
- **Response:** 
  - Status Code: 201 Created
  - Body: JSON object representing the newly created income record.
- **Error Response:**
  - Status Code: 400 Bad Request
  - Body: Error message if the income record could not be added.

### Update Income

- **Route:** `PUT /api/Income`
- **Description:** Updates an existing income record.
- **Request Body:** Updated income object.
- **Response:** 
  - Status Code: 202 Accepted
  - Body: JSON object representing the updated income record.
- **Error Response:**
  - Status Code: 400 Bad Request
  - Body: Error message if the income record could not be updated.

### Delete Income

- **Route:** `DELETE /api/Income`
- **Description:** Deletes an existing income record.
- **Request Body:** Income object to be deleted.
- **Response:** 
  - Status Code: 200 OK
  - Body: Success message indicating the income record was deleted.
- **Error Response:**
  - Status Code: 400 Bad Request
  - Body: Error message if the income record could not be deleted.


## Budget Controller API Routes

### Get Summary

- **Route:** `GET /api/Budget`
- **Description:** Retrieves a summary of the budget, including total income, total expenses, and other relevant information.
- **Response:** 
  - Status Code: 200 OK
  - Body: JSON object containing the budget summary.

### Get Expense Types

- **Route:** `GET /api/Budget/expenseTypes`
- **Description:** Retrieves a list of expense types/categories.
- **Response:** 
  - Status Code: 200 OK
  - Body: JSON array containing the expense types.

### Get Income Types

- **Route:** `GET /api/Budget/incomeTypes`
- **Description:** Retrieves a list of income types/categories.
- **Response:** 
  - Status Code: 200 OK
  - Body: JSON array containing the income types.

# Appointment Booking System

## Overview
The Appointment Booking System is a .NET 8 application that provides an endpoint to query available slots for sales managers based on customer requirements. It matches customers with sales managers by considering criteria such as language, product expertise, and customer ratings, while ensuring no overlapping bookings for sales managers.

---

## Features
1. **Sales Manager Matching**:
   - Matches customers with sales managers based on language, product expertise, and customer ratings.
   - Ensures all requested products are supported by the sales manager.

2. **Slot Management**:
   - Filters slots based on availability.
   - Prevents overlapping bookings for sales managers.

3. **RESTful API**:
   - Provides a single endpoint for querying available slots.

---

## Requirements
### Technology Stack
- **.NET 8**
- **PostgreSQL**
- **Swashbuckle (Swagger)** for API documentation

---

## Installation
### Prerequisites
- .NET 8 SDK
- PostgreSQL

### Steps
1. Clone the repository:
   ```bash
   cd AppointmentBooking
   ```

2. Configure the database connection in `appsettings.json`. There is already a valid connection string in appsettings.json file for given docker image:

   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Port=5432;Database=appointment_booking;Username=postgres;Password=yourpassword"
   }
   ```

3. Run the docker container into the directory "database" folder
    ```bash
    cd database
    docker build -t enpal-coding-challenge-db 
    docker run --name enpal-coding-challenge-db -p 5432:5432 -d enpal-coding-challenge-db
    ```

4. Run the application:
   ```bash
   dotnet run
   ```

5. Access the API documentation at:
   ```
   http://localhost:3000/swagger
   ```

---

## API Endpoint
### Query Available Slots
**Endpoint**: `POST /calendar/query`

**Request Body**:
```json
{
    "date": "2024-05-04",
    "products": ["Heatpumps"],
    "language": "English",
    "rating": "Silver"
}
```

**Response**:
```json
[
    {
        "start_date": "2024-05-04T10:30:00.000Z",
        "available_count": 1
    }
]
```

---

## Testing
### Unit Tests
Run the following command to execute the test suite:
```bash
cd test-app
npm run test
```

Ensure the `test.js` file is located into the directory "test-app"

```
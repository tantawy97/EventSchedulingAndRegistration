# User Registration Event Application

This application is designed for user registration events, leveraging Domain-Driven Design (DDD), Clean Architecture, CQRS, and the Mediator pattern.

## Getting Started

### Prerequisites

Make sure you have the following installed on your machine:

- [Docker](https://www.docker.com/get-started)

### Running the Application

1. Clone the repository:
   ```bash
   git clone https://github.com/tantawy97/EventSchedulingAndRegistration.git
   cd EventSchedulingAndRegistration
   docker-compose up

2. Open your browser and navigate to:
    Application: https://localhost:7081/

    Swagger Documentation: https://localhost:7081/swagger/index.html

3. To pull the image: docker pull tantawy9701/evenschedulingandregistration:latest

4. Database Connection
The application connects to a PostgreSQL database. Use the following credentials:
 Server: localhost
 Username: postgres
Password: postgres
Port: 5433

### --- Please Note ---
    if you want to login by Admin please use this
    E-mail: Admin@Admin.com
    Password: 1234
    All Event And EventRegistration endpoints is Authorized 
    only Admin Can create Event in this post endpoint:https://localhost:7081/api/Event



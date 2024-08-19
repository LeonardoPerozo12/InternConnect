# InternConnect

## Final Project for IDS325 - Aseguramiento de Calidad De Software

### Overview

This is the backend for the whole project, InternConnect is a platform that works as a bridge between students and companies, sort of like LinkedIn but for College Students who are looking for an InternShip

### Technologies Used

- **.NET 8.0**: For building the application.
- **Entity Framework Core**: For ORM and database management.
- **MySQL**: As the database system.
- **Swagger**: For API documentation.
- **ASP.NET Core**: For building web APIs.

### Setup and Installation

1. **Clone the repository**:
    ```sh
    git clone https://github.com/yourusername/InternConnect.git
    cd InternConnect
    ```

2. **Configure the database connection**:
    - Ensure you have MySQL installed and running.
    - Create a database named `InternConnect`.
    - Use user secrets to securely store your connection string:
      ```sh
      dotnet user-secrets set "ConnectionStrings:Connection" "Server=localhost;Database=internconnect;user=root;password=yourpassword;"
      ```

3. **Run Migrations**:
    ```sh
    dotnet ef database update
    ```

4. **Build and run the project**:
    ```sh
    dotnet build
    dotnet run
    ```

### Configuration

- **appsettings.json**: Contains general settings for the application.
- **appsettings.Development.json**: Contains settings specific to the development environment.

### Usage

- **Swagger**: Visit `https://localhost:5001/swagger` in your browser to view and test the available API endpoints.
- **Controllers**: Use the controllers to manage the models
### Contributing

Contributions are welcome! Please fork this repository and submit a pull request for any improvements or bug fixes.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/yourFeature`)
3. Commit your changes (`git commit -m 'Add some feature'`)
4. Push to the branch (`git push origin feature/yourFeature`)
5. Open a pull request

### Acknowledgements

- Professors FRANCIA ODALIS MEJIA POLANCO and MARIO ANTONIO LUCIANO RECIO, for guidance and support throughout the course.
- INTEC, for providing the resources to complete this project.


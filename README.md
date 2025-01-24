# Online Resource Bank (ORB) API

The **Online Resource Bank (ORB) API** is a backend service designed to manage and provide access to a centralized database of online government resources. It supports functionality for searching, adding, editing, and deleting records related to government offices and services, such as assessors, tax collectors, recorder offices, judgment records, and miscellaneous records.

## Features

- **Search Resources:** Query the database by state, county, and locality to retrieve relevant government office information.
- **Resource Management:** Add, update, and delete records via a secure API.
- **Data Integration:** Retrieve necessary data through a custom web API.
- **Scalability:** Built to handle large datasets and multiple users simultaneously.

## Prerequisites

- [.NET 7 or later](https://dotnet.microsoft.com/download)
- [SQLite](https://sqlite.org/) as the database backend
- A REST client like [Postman](https://www.postman.com/) or [cURL](https://curl.se/) for testing

## Installation

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/your-username/orb-api.git
   cd orb-api
   ```

2. **Set Up the Environment:**
   - Rename `appsettings.json.example` to `appsettings.json`.
   - Update the database connection string and other configurations as needed.

3. **Set Up the Database:**
   - Create a MariaDB database for the project.
   - Execute the provided SQL scripts in the `database` folder to initialize the schema and seed data.

4. **Build and Run the API:**
   ```bash
   dotnet build
   dotnet run
   ```

   The API will be available at `https://localhost:5001` (or another specified port).

## Endpoints

### Search
- `GET /api/states` - Get a list of all states.
- `GET /api/counties/{state]` - Get a list of counties for the specified state
- `GET /api/resources/{state}/{county}` - Get a list of all resources for the specified county in the given state.

### Resource Management
- `POST /api/resources` - Add a new resource.
- `PUT /api/resources/{id}` - Update an existing resource.
- `DELETE /api/resources/{id}` - Delete a resource by ID.

### Example Request
```http
GET /api/resource/39/2417 HTTP/1.1
Host: localhost:5001
Content-Type: application/json
```

## Development

### Tools
- [Swagger](https://swagger.io/) for API documentation.

### Running Tests
Run unit tests to ensure functionality:
```bash
dotnet test
```

### Contributing
Contributions are welcome! Please follow these steps:
1. Fork the repository.
2. Create a feature branch.
3. Submit a pull request with a clear description of your changes.

## Deployment

1. Configure the production environment variables.
2. Publish the project:
   ```bash
   dotnet publish -c Release -o ./publish
   ```
3. Deploy the contents of the `publish` folder to your server or cloud provider.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact

For questions or feedback, please contact:
- **Name:** Lewis J. Hannah
- **Email:** lewis.j.hannah@gmail.com
- **GitHub:** [ljhannah74](https://github.com/ljhannah74)


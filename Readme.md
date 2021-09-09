# Introduction


Student-RESTful-API is an HTTP REST API based on the typical client/server paradigm.
It allows a consumer to request and manipulate Student/Instructor/Exam resources via a uniform HTTP interface.
At its heart Student-RESTful-API is a stateless web service that computes HTTP requests against the **/swagger/v1/** URI.

The desired resource manipulation can be achieved by specifying one of the four HTTP methods supported.
While we know that the data stored in SqlLite is a series of tuples, its representation is conceptually independent from the one returned to the client, which is in JSON.

## Use Cases

The main purpose of this project is develop an API RESTful and shows how it works.

## Building a sample

Build any .NET Core sample using the .NET Core CLI, which is installed with [the .NET Core SDK](https://www.microsoft.com/net/download). 
Then run these commands from the CLI in the project root folder (where the API.csproj file is located):

```console
cd .\API\  --> navigate into the root folder
dotnet ef migrations add MyMigration
dotnet ef database update
```

These will compares the current state of the model with the previous migration if one exists and generates a file containing a class inheriting from Microsoft.EntityFrameworkCore.Migrations.Migration featuring an Up and a Down method. The class is given the same name as you specified for the migration. The file name itself is the name of the migration prefixed with a timestamp.

Secondly, will EF will create the database and create the schema from the migration 

Now start the api by running dotnet run from the command line, you should see the message ```Now listening on: http://localhost:8080```

```console
dotnet build
dotnet run
```

These will install any needed dependencies, build the project, and run the project respectively.

<!-- Import the ... for test out with Postman -->

## Authorization

Some API requests require the use of a generated API key. You can generate your API key making a POST request to the /users/authenticate endpoint.

```http
POST /users/authenticate
```
**Body**
```json
{
    "username": "Tom",
    "password": "Zara"
}
```



To authenticate an API request, you should provide your API key in the `Authorization` header.

```http
GET /api/users
```
**Headers**
| Parameter | Type | Description |
| :--- | :--- | :--- |
| `Authorization` | `Bearer Token` | **Required**. Your API jwt token |

## Responses

Many API endpoints return the JSON representation of the resources created or edited. However, if an invalid request is submitted, or some other error occurs, API returns a JSON response in the following format:

```json
{
  "message" : "Error! CouldNotDelete 😡",
}
```

The `message` attribute contains a message commonly used to indicate errors.

## Status Codes

Student-RESTful-API returns the following status codes in its API:

| Status Code | Description |
| :--- | :--- |
| 200 | `OK` |
| 201 | `CREATED` |
| 400 | `BAD REQUEST` |
| 404 | `NOT FOUND` |




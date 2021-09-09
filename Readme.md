# Introduction


Student-RESTful-API is an HTTP REST API based on the typical client/server paradigm.
It allows a consumer to request and manipulate Student/Instructor/Exam resources via a uniform HTTP interface.
At its heart Student-RESTful-API is a stateless web service that computes HTTP requests against the _/api/v1/Student-RESTful-API_ URI.
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

[//]: # Import the ... for test out with Postman

## Authorization

All API requests require the use of a generated API key. You can find your API key, or generate a new one, by navigating to the /settings endpoint, or clicking the “Settings” sidebar item.

To authenticate an API request, you should provide your API key in the `Authorization` header.

Alternatively, you may append the `api_key=[API_KEY]` as a GET parameter to authorize yourself to the API. But note that this is likely to leave traces in things like your history, if accessing the API through a browser.

```http
GET /api/campaigns/?api_key=12345678901234567890123456789012
```

| Parameter | Type | Description |
| :--- | :--- | :--- |
| `api_key` | `string` | **Required**. Your XXXX API key |

## Responses

Many API endpoints return the JSON representation of the resources created or edited. However, if an invalid request is submitted, or some other error occurs, XXXX returns a JSON response in the following format:

```javascript
{
  "message" : string,
  "success" : bool,
  "data"    : string
}
```

The `message` attribute contains a message commonly used to indicate errors or, in the case of deleting a resource, success that the resource was properly deleted.

The `success` attribute describes if the transaction was successful or not.

The `data` attribute contains any other metadata associated with the response. This will be an escaped string containing JSON data.

## Status Codes

XXX returns the following status codes in its API:

| Status Code | Description |
| :--- | :--- |
| 200 | `OK` |
| 201 | `CREATED` |
| 400 | `BAD REQUEST` |
| 404 | `NOT FOUND` |
| 500 | `INTERNAL SERVER ERROR` |




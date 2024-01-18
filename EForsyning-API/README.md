# API

A C# API that collects data from EForsyning and stores the data in blobs in an Azure Storage Account

## Quickstart - local :wrench:

### Build & Run

```go
docker build . --no-cache -t eforsyning-api-image:[your-version] 
```

```go
docker run -d -p 5000:8080 -e ASPNETCORE_ENVIRONMENT='development' --name eforsyning-api eforsyning-api-image:[your-version]
```

If environment variable is omitted then it defaults to production.

### Endpoint

View the swagger documentation at: http://localhost:5000/swagger/index.html


## License :page_facing_up:

The project is under [MIT license][file-license].

[file-license]: https://www.apache.org/licenses/LICENSE-2.0
# registry-api

This app is being developed because I would like to improve my skills with .NET.

# Swagger documentation

Open this url http://localhost:5000/docs to acess swagger documentiton

# Exemple launchSettings.json 

```
{
  "profiles": {
    "RegistryApi": {
      "commandName": "Project",
      "launchBrowser": false,
      "applicationUrl": "http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "",
        "CONNECTION_STRING_MONGODB": "",
        "DATABASE_NAME": "",
        "CUSTOMERS_COLLECTION_NAME": "",
        "PRODUCT_COLLECTION_NAME": "",
        "AUTH0_AUTHORITY": "",
        "AUTH0_AUDIENCE": "",
        "AUTH0_CLIENT_ID": "",
        "AUTH0_CLIENT_SECRET": "",
        "AUTHORIZATION_KEY": ""
      }
    }
  }
}

```

# How to execute application with docker

## steps:

1. Install the docker;
2. Set the connection string env at the Dockerfile;
3. Open the prompt command and execute this command at the root folder:

```
docker build -t registry-api .
```

4. Lastly, exceute command to up container:

```
docker run --name registry-api -p 5000:80 -d registry-api
```

To acess the aplication documentation:
http://localhost:5000/docs

To acess the aplication health check:
http://localhost:5000/healthcheck

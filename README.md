# registry-api

This app is being developed because I would like to improve my skills with .NET.

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
http://localhost:5000/swagger

To acess the aplication health check:
http://localhost:5000/healthcheck

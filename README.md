# Comentarios
Api de comentarios usando patron repositorio
## Table of Contents
1. [General Info](#general-info)
2. [Technologies](#technologies)
3. [Installation](#installation)

### General Info
***
Api made whit Repository Pattern C#, for educational purposes
### Screenshot
![swagger-api-comentarios](https://user-images.githubusercontent.com/20881963/138023881-b6ea31bf-d602-4dda-825e-b5d1a7d7b50c.PNG)

![apicomentarios](https://user-images.githubusercontent.com/20881963/138598366-6487b3c6-7cb3-4c7a-b97d-498cebdaf6a7.JPG)

## Technologies
***
* [.NETFrameworkCore](https://dotnet.microsoft.com/download/dotnet/5.0)
* [MySql](https://www.mysql.com/)
* [Angular](https://angular.io/guide/what-is-angular)
* [Docker](https://www.docker.com/)
## Installation
***

dotnetcore ef CLI
```
$ dotnet tool install --global dotnet-ef
$ dotnet tool update --global dotnet-ef
$ dotnet add package Microsoft.EntityFrameworkCore.Design
$ dotnet add package MySql.EntityFrameworkCore
$ dotnet ef database update
$ docker build -t api-comments-build -f ComentariosAPI.dockerfile .
```

SDK Ubuntu
```
$ git clone https://github.com/josuecaleb6482/
$ sudo apt-get update; \
$ sudo apt-get install -y apt-transport-https && \
$ sudo apt-get update && \
$ sudo apt-get install -y dotnet-sdk-5.0
$ nano .env
```

Run the app
```
$ docker-compose run -d
$ dotnet watch run
```

Api connecting to a mysql database mounted on an image with docker, uses Angular in frontend. You can use this implementetion both in Ubuntu like Windows or Mac, you can also uncouple more the repository and classes in another library classes proyects for better maintenance.
Remember to write the .env file that has the environment variables.
If you find an issue with this library, feel free to open an issue here on GitHub🙂. Thks


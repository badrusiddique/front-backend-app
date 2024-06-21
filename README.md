# Sample-WebApi
A sample web-api project using EF-Core code first migration via Sqlite DB and Fluent configuration

## Project setup
dotnet build                 // compile the project
dotnet restore               // restore all the project dependency
dotnet run                   // run the web api

## Database migration
Inorder to run migration locally use the following command in Package Manager Console (PMC), inside visual studio
add-migration MIGRATION_FILE_NAME           // add migration
update-database                             // update database


## Documentation
API documentation is handled by Swagger and can be accessed via https://localhost:8086 and https://localhost:8086/swagger url


# Sample-Website
It represents a user interface using VueJS hosted under a NodeJS express server.

## Project setup
npm install                     // on the project root folder to Install dependencies
cd host && npm install          // in the /host folder to Install dependencies

### Compiles and hot-reloads for development
npm run serve:local                 // app running using vue-cli
npm run serve:host-dev              // app running under NodeJS host

### Compiles and minifies bundle for deployment
npm run build               // for production
npm run build:dev           // for development
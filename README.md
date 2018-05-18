# employeeService
This is a simple dotnet core based REST api which uses postgres as a backend and has a simple db called "employeedb" with a single table called emplyee.

# Following are the postgres scripts for database and tables in it:
$ CREATE DATABASE employeedb //Note that the user used for this db is postgres with password also as postgress
$ CREATE TABLE employee
(
  id serial PRIMARY KEY,
  name character(50) NOT NULL,
  salary integer NOT NULL
)

# To build and run the api
$ dotnet build 
$ dotnet run

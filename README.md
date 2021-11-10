# DIRS21.WebApi
In this project, the goal is to add additional services through a web API. It offers adding, deleting, updating, current availability request, adding new photos on a product basis and reservation processes. A multi-layer architect was preferred in view of the ease with which the project was manageable. It was established by considering the layered structure software patterns. All controller able to test with swagger UI. In order to have a structure independent of the database type, the repository pattern was used and the existing project was carried out with the MongoDb database.

If we refer to the structural logic of the project;

* Entities;
  It is the class library that holds the classes associated with database objects and tables.

* DataAccess;
  It is the layer on which communication with the database is provided and managed. The repository software pattern can be implemented in this layer. So if you want to work with a   different database, just add a new database context.
  
 * Core;
   It is essentially a class library that generally contains the functions that we need regardless of the project.
   
* Business;
  This is a structure that meets the requirements in which project-related work is carried out in the class library. All kinds of logical operations, filters and business logic     can be applied here. It is the layer that communicates with the data access layer and allows us to define the functions we need.
  
 * Web Api Contollers;
   You can write endpoints according to your needs and get results. These layers communicate with the business layer.

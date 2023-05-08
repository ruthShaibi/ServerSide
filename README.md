# ServerSide
The server side is written in c#, divided into the 3-layer model.
The API layer is written in the asp.net web api project, the rest of the layers are written in the class library.
The project contains various libraries including: Entity FreameWork, Asp.Net.Cors, Asp.Net Web Api.
The API layer contains controllers that accept the client's request and forward it to the service in the BLL layer, The service forwards the request to the model in the DAL layer,The model sends/receives data from the DB and returns to the service, Before returning the response to the controllers, the service passes the response object to the converts which is also in the BLL layer,The object is converted to a DTO class object and from there the service returns an answer to the controllers and from there to the client.

Customer requests are sent via the following routing:"https://localhost:44368/api/controllerName/functionName/parameters(optional)".
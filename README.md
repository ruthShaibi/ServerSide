# ServerSide
The server side is written in c#, divided into the 3-layer model.
The API layer is written in the asp.net web api project, the rest of the layers are written in the class library.
The project contains various libraries including: Entity FrameWork, Asp.Net.Cors, Asp.Net Web Api.
The API layer contains controllers that accept the client's request and forward it to the service in the BLL layer, The service forwards the request to the model in the DAL layer,The model sends/receives data from the DB and returns to the service.The service returns an response to the controllers and from there to the client.
Almost at every step conversions are made to an object of the DTO class type.

The server side implements functions of retrieving, inserting and updating records.
Customer requests are sent via the following routing:"https://localhost:44368/api/controllerName/functionName/parameters(optional)".

# Cal
Web api for login and get data by token

I uploaded all the solution project without the packages dir.
Also, the file - visa-cal.postman_collection.json is at the root dir, is Postman export collection file - 
import the file, you have 3 methods - 
1. login - login method - send json with email and password
2. token - get token by email and password
3. Authorize (GetData) - getting data after login

The Code - 
controller - CalApiController.cs

Two methods in the controller:
1. Login - making the auth(call getting the token like client side) and return answer to the client
2. GetData - authorize method for getting mock data if you are authorize

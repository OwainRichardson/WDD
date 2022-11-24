# Owain Richardson - Tech Test

## Running
* The API can be run from Visual Studio as normally, you can either click the WDD.API button at the top or you can navigate to the application folder and run 
```
dotnet build
dotnet run
```

* The App can be run by navigating to app/wdd-app and running
```
npm install
npm run dev
```
** This will run the application on to http://localhost:3000/

## Notes
* I have unit tested some of the API project where I usually wouldn't. This is because the project is so simple, unit tests aren't always necessary. For example, the read operation is just returning what is in the database and has no logic that actually needs testing.
* The app doesn't refresh the contact list when you add a new contact, I would like it to, but I have run out of time and now need to continue with my working day.
* I would normally add a tonne of logging around the API as well, however, as we are not connected to a logging service, I have not added it as part of this exercise.
* Given more time I would like to insert more error handling throughout both the API and app, however, time constraints mean I haven't had time to do this.
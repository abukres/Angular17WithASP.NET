
This is an unfinished basic ASP.NET 8 and Angular 17 web application. The app is based on the 'Angular and ASP.NET Core' project template in Visual Studio 2022. The goal was to use DevExpress' <a href="https://github.com/DevExpress/devextreme-ui-template-gallery?tab=readme-ov-file" target="_blank">DevExtreme UI Template Gallery</a> Angular application and use it as the client side of an ASP.NET application to demonstrate a nice looking line of business (LOB) app.  
I noticed most if not all the asp.net apps on Github lack any UI or use a very simplistic UI. I decided someone should show a good UI.

The original DevExpress' UI gets all its data from DevExpress' web services. I copied and modified their Angular version so that it runs as part of the asp.net app as the web client part. The 'Contact List' section now gets its data from the asp.net back end which gets it from the database. The goal was to do the same type of conversion for the rest of the UI but I stopped short and moved on to concentrate on Blazor. The back end is based on the clean architecture pattern and the same worflow of endpoint -> services -> repository -> database can be applied to the rest of the application using the same convention. 
  
The application doesn't implement any authentication, authorization, logging, containers. etc. To implement such features, see <a href="https://github.com/jasontaylordev/CleanArchitecture" target="_blank">jasontaylordev/CleanArchitecture</a> for some inspiration and implementation.
  
The UI is based on DevExpress' DevExtreme which is a full featured and polished UI component suite and the demo gallery was a nice demo. I highly recommend it. DevExtreme is free for non commercial applications and requires a license for commercial apps. 


#### Instructions for setting up the database:
* The first step is setting up the database. The app uses SQL Server. If you're using SQL Server 2019 or higher, you can simply restore the database from the backup file, DXFullApp.bak, in the 'Misc_Files' folder in the Infrastructure project.
* Else run the DXFullApp.sql script that's in the 'Misc_Files' folder to create and populate the database with data. Edit the file if necessary to update the FILENAME values to the proper paths of your SQL Server installation in your system.
* Update the DefaultConnectionString value if necessary in the appsettings.json file in the Server project.

#### Instructions for running the app:
* (There's an issue where the solution takes several minutes to load in VS 2022. Not sure yet if it's a local issue.)
* After setting up the database and the connection string, make the Server project the startup project. Run the app and it will launch the browser with the page loaded with contacts. The initial page will show a broken page then auto refreshes and renders properly. This should be fixed.

#### TO DO list (Currently no plan to finish them):
* Convert all the UI to use the ASP.NET back end instead of DevExpress' end points.
* Create all the DTOs to serve the client and map the entities to them. (using AutoMapper or Mapster if that's preferred).
* Add unit, functional, integration and end to end tests.
* The UI doesn't do any updates like saving the edits or creating new objects. Implement those.
* Add authentication, authorization, logging, health checks.. etc.
* Try out minimal APIs instead of controller based APIs. 
* The Angular client while it is at version 17, it doesn't really use any of the version's specific features. All I did is converted it from version 15 to 17.



#### Why DevExtreme:
* It has tens of high quality, polished and extensible UI components which natively support Angular, React, Vue, jQuery and plain Javascript.
* Excellent technical support and documentation. Online with real time customizable demos that show the features of each component.
* Powerful and mobile responsive data grid. The price of the whole suite is less than the price of another popular only-a-grid UI component.
* While it does cost money, in the long run it will save you a lot of money by cutting costs of development and support time vs using a hodgepodge of open source UI components that work, behave and look inconsistently. Use components that a company makes a living out of instead of being dependent on a developer or community's free time.
* PS: I am not affiliated with DevExpress other than being a happy customer. I am just expressing my personal opinions.
* Enjoy coding!






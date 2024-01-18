Online Menu Yummy - Bar and Food

Welcome to Online Menu Yummy, an ASP.NET MVC (.NET6) web application that brings you a delightful selection of food and drinks. 
Whether you're a casual visitor or a registered user, the platform allows you to explore the menu hassle-free.

User Types:
1. Regular (registered) User
    Explore the entire menu.
    Add favorite food and drinks.
    Search food and drinks by category or keyword.

2. Manager
    All regular user privileges.
    Perform (CRUD) operations on food and drinks.

3. Admin
    The most powerful user with all available permissions.
    Access to the admin panel.
    Add/remove users as managers or admins.
    Perform (CRUD) operations on food and drinks.
    Perform (CRUD) operations on food and drink categories.
    Explore other users and their permissions.


Admin Panel
The admin panel provides the following capabilities:

    User Management:
        Add and remove users as managers.
        Add and remove users as admins.
        
    Menu Management:
        Perform (CRUD) operations on food and drinks.
        Perform (CRUD) operations on food and drink categories.
    User Exploration:
        Investigate other users and their respective permissions.


Web API for Statistics
    The menu comes equipped with a Web API for statistics, providing real-time information on the count of available food and drinks.


Error Pages and Error Handling
    Custom error pages are implemented but errors and notifications are handled by toastr, a JavaScript notifications bar.


Getting Started
To get started with Online Menu Yummy, follow these steps:

    1. Clone the repository
    2. Navigate to the project directory, open the "OnlineMenu.Web" folder and double click on "OnlineMenu.Web.sln".
    3. Provide a connection string to the database!
    4. To have admin-user first register a new user with the following email: admin@abv.bg.
    	Go to "Program.cs" and uncomment the if statement of "SeedAdministrator(AdminEmail);" method.
    	Run the application again.
	Login with email: admin@abv.bg.
    5. To obtain the web api functionality for statistics set multiple startup projects: "OnlineMenu.Web" and "OnlineMenu.WebApi", otherwise the button for statistics will not work.
	Important: In the project "OnlineMenu.WebApi" find the following link "https://localhost:7070", 
	after starting the application provide the link from your browser (the difference in the port numbers will cause issues). 
   

This project is licensed under the MIT License.

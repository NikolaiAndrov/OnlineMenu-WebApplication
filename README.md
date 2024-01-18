# Online Menu Yummy - Bar and Food

Welcome to Online Menu Yummy, an ASP.NET MVC (.NET6) web application that brings you a delightful selection of food and drinks. 
Whether you're a casual visitor or a registered user, the platform allows you to explore the menu hassle-free.

# User Types:
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


# Admin Panel:
## The admin panel provides the following capabilities:

    User Management:
        Add and remove users as managers.
        Add and remove users as admins.
        
    Menu Management:
        Perform (CRUD) operations on food and drinks.
        Perform (CRUD) operations on food and drink categories.
    User Exploration:
        Investigate other users and their respective permissions.


# Web API for Statistics
    The menu comes equipped with a Web API for statistics, providing real-time information on the count of available food and drinks.


# Error Pages and Error Handling
    Custom error pages are implemented but errors and notifications are handled by toastr, a JavaScript notifications bar.


# Getting Started
## To get started with Online Menu Yummy, follow these steps:

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
   

# This project is licensed under the MIT License.


# Screenshots:

# <img width="1280" alt="Screenshot 2024-01-18 161023" src="https://github.com/NikolaiAndrov/OnlineMenu-WebApplication/assets/32267207/f189eae6-3e20-4ba4-829a-0e651bbf050e">
# <img width="1280" alt="Screenshot 2024-01-18 161341" src="https://github.com/NikolaiAndrov/OnlineMenu-WebApplication/assets/32267207/02b1346e-1295-4577-97e8-8e6d59df3dba">
# <img width="1280" alt="Screenshot 2024-01-18 161632" src="https://github.com/NikolaiAndrov/OnlineMenu-WebApplication/assets/32267207/8c8f0c76-48e8-470e-82b9-da951d7cd9e1">
# <img width="1280" alt="Screenshot 2024-01-18 161913" src="https://github.com/NikolaiAndrov/OnlineMenu-WebApplication/assets/32267207/27a3ab3f-0bc6-4d48-ae7f-65d6be7821c0">
# <img width="1280" alt="Screenshot 2024-01-18 162026" src="https://github.com/NikolaiAndrov/OnlineMenu-WebApplication/assets/32267207/2aa539fa-1a95-4295-8c70-a28b4f986c49">
# <img width="1280" alt="Screenshot 2024-01-18 162209" src="https://github.com/NikolaiAndrov/OnlineMenu-WebApplication/assets/32267207/44353ca0-494b-48a6-94fc-17d887721575">
# <img width="1280" alt="Screenshot 2024-01-18 162502" src="https://github.com/NikolaiAndrov/OnlineMenu-WebApplication/assets/32267207/5531c35a-21dd-4962-8799-9b740aadb995">
# <img width="1280" alt="Screenshot 2024-01-18 162656" src="https://github.com/NikolaiAndrov/OnlineMenu-WebApplication/assets/32267207/048895e8-868d-4a89-a29a-00a03abf4bb8">
# <img width="1280" alt="Screenshot 2024-01-18 162912" src="https://github.com/NikolaiAndrov/OnlineMenu-WebApplication/assets/32267207/71bb5878-9580-4ead-ab94-6d8f789a2e7e">




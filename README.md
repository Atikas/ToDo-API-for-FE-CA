# To-Do Application

## Project Overview

This project is a simple To-Do application that includes user registration, login functionality, and task management. The user will be able to register, log in, and manage their tasks. The project uses HTML, CSS, and JavaScript for the frontend, and communicates with the backend through an API.

## Starting the .NET Project (ensure you have .net6 runtime installed)

To start the project, follow these steps:

1. Checkout the repository.
2. Open the solution in Visual Studio.
3. In the `ToDo.Api` project, locate the `appsettings.json` file and check the value of `"DefaultConnection"` to ensure that the server is pointing to your SQL Server instance.
4. In the Package Manager Console, run the following command to update the database: Update-Database
5. Build and run the project.





## Application Features and Requirements

### 1. Landing Page
- Two buttons should be available: "Register" and "Login."
- Clicking "Register" redirects the user to the registration form.
- Clicking "Login" redirects the user to the login form.

### 2. Registration Form
- Create a form with four input fields: `First Name`, `Last Name`, `Password`, and `Email`.
- The user's information should be saved to the database upon registration.
- After successful registration, the user should be automaticaly redirected to the login page.
- **Field Validations**: Ensure all fields are required and password should be masked (not visible).
- The error messages must be on a red background and clearly visible.

### 3. Login Form
- Create a form with three input fields: `First Name`, `Last Name`, and `Password`
- Create one button "Login".
- Check if the user exists in the database.
- If the user exists, redirect them to the To-Do app. If not, display a red error message: "User does not exist."
- Password should be masked.

### 4. To-Do App
- Display the logged-in user's name and last name at the top left corner.
- Create an "Add" button that opens a form with three fields: `Task Type`, `Content`, `Done`, `Priority`, and `End Date`.
- Upon submission, the task data should be saved in the database, along with the user's name.
- The To-Do app should only display tasks related to the logged-in user by filtering tasks using their name.
- Implement functionality to edit and delete tasks, with updates being reflected in the database.
- Add a "Reset" button to clear any unsaved input data in the form.
- **Field Validations**: Inputs should be appropriate for their intended purposes, with restrictions to prevent invalid data.

### 5. API Usage
- Implement all four API methods:
- `GET`: Fetch user tasks.
- `POST`: Add new tasks.
- `PUT`: Edit tasks.
- `DELETE`: Remove tasks.

### 6. Design
- The page background should be white.
- All elements and forms must have borders.
- Content should be centered on the page, with consistent form and element widths.
- The design should be minimalist but visually appealing.

### 7. File Structure
- The main HTML, CSS, and JavaScript files should be stored together in the root.
- Separate subfolders should be created for other pages, such as the registration and login forms, to maintain order.


## Evaluation Criteria

The project will be evaluated based on the following criteria:

### 1. **Functionality**
   - The application correctly implements all required features:
     - User registration and login functionality.
     - Proper validation of registration and login forms.
     - Display of the logged-in user's name on the To-Do page.
     - Ability to add, edit, and delete tasks with correct interactions with the database.
     - Filtering and displaying tasks only for the logged-in user.
   - All API methods (GET, POST, PUT, DELETE) are properly implemented and tested.

### 2. **Code Quality**
   - The code is clean, well-structured, and follows best practices.
   - Meaningful variable and function names are used.
   - The file structure is organized, and unnecessary duplication of code is avoided.
   - Proper error handling is implemented.

### 3. **User Interface and Design**
   - The application design follows the provided requirements:
     - White background with borders around elements and forms.
     - Centered content with consistent element and form widths.
     - A minimalist but visually appealing design.
   - Responsiveness of the layout (optional but rewarded if included).

### 4. **Validation, Security, and Robustness**
   - Form validations are properly implemented, preventing invalid data entry.
   - Passwords are masked in both registration and login forms.
   - Error messages are displayed appropriately (e.g., when the user does not exist).
   - The program handles edge and corner input values without crashing or throwing errors (e.g., empty inputs, extremely long strings, special characters, invalid dates, etc.).

### 5. **Performance and Efficiency**
   - The application performs efficiently with quick response times.
   - The database is accessed efficiently, and filtering operations are performed correctly.

### 6. **Documentation**
   - The project includes clear and detailed documentation, including:
     - A README file that explains how to set up, run, and use the project.
     - Comments in the code where necessary to explain complex logic.


## Support

If you found this project helpful and would like to support my work, consider buying me a coffee! Your support is greatly appreciated.

[![Buy Me A Coffee](https://www.buymeacoffee.com/assets/img/custom_images/yellow_img.png)](https://www.buymeacoffee.com/atikas)

	
## Good luck with your implementation!

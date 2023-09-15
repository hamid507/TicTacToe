# TicTacToe
Winforms multiplayer TicTacToe game with user registration and a daily bonus system.

# Tech
Framework is .NET6
Frontend is Windows Forms Application
Backend uses REST API for user registration and user login.
App uses WebSocketSharp to create a client-server connections and send socket endpoints.

# Repository
1) Clone the repository: git clone https://github.com/hamid507/TicTacToe.git
2) Open the "TicTacToe"/{project} folder in Visual Studio or your preferred IDE.
Install dependencies: dotnet restore
3) Configure the REST API endpoints and database connection in the appsettings.json file.

Quick note: For app to work, appsettings.json files in projects "TicTacToeGame" and "TicTacToeMatchingServer" and
appsettings.{Environment}.json file in "TicTacToeApi" need to be configured. MailKit credentials should
not be exposed and should be saved in UserSecrets.

4) Build and run the backend application: dotnet run

# Usage
App is a turn based multiplayer tic-tac-toe game. You need to register, login and verify your user via email to be able to play.

# User Registration
Navigate to the registration page via main form "Register" button.
Fill out the required information (e.g., username, email, password).
Click the "Register" button.

# User Login
Navigate to the login page via main form "Login" button.
Enter your username and password.
Click the "Login" button.

# WebSocket Communication
WebSocket clients in the frontend try to connect to server in TicTacToeMatchingServer project to establish communication.
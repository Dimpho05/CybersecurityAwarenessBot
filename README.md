Cybersecurity Awareness Bot 

About The Project
The Cybersecurity Awareness Bot is a console-based chatbot designed to educate 
people about cybersecurity threats and how to avoid them. 
The bot covers topics such as password safety, phishing scams, safe browsing, 
and online privacy. This project was developed as part of the PROG6221 
Programming 2A module at IIE Rosebank.



Software Needed
Before running this project, make sure you have the following installed:

| Software       | Version       | Download                             |
|----------------|---------------|--------------------------------------|
| Visual Studio  | 2022 or later | https://visualstudio.microsoft.com/  |
| .NET Framework | 8.0 or later  | https://dotnet.microsoft.com/download|
| Git            | Latest        | https://git-scm.com/downloads        |                  |



How To Run The Project

Step 1: Clone the Repository
Open **Git Bash** or **Visual Studio Terminal** and run:
git clone https://github.com/Dimpho05/CybersecurityAwarenessBot.git

Step 2: Open the Project
1. Open **Visual Studio**
2. Click **File** → **Open** → **Project/Solution**
3. Navigate to the cloned folder
4. Select **CybersecurityAwarenessBot.sln**
5. Click **Open**

Step 3: Add the WAV File
1. Locate the `greeting.wav` file in the project folder
2. In **Solution Explorer** click on `greeting.wav`
3. Press **F4** to open Properties
4. Set **Build Action** to `Content`
5. Set **Copy to Output Directory** to `Copy Always`

Step 4: Build the Project
1. Click **Build** at the top menu
2. Click **Build Solution**
3. Make sure there are no errors in the **Error List**

Step 5: Run the Project
1. Press **F5** or click the green **Run** button
2. The console window will open
3. The voice greeting will play automatically
4. The ASCII art logo will display
5. Follow the on screen instructions



How To Use The Bot

Starting the Bot
When the bot launches it will:
1. Play a voice greeting
2. Display the ASCII art logo
3. Ask for your name

Chatting With The Bot
Once you enter your name you can ask the bot questions like:

| What You Type          | What The Bot Does              |
|------------------------|--------------------------------|
| `how are you`          | Bot responds with a greeting   |
| `what is your purpose` | Bot explains what it does      |
| `help`                 | Bot lists all available topics |
| `password`             | Bot gives password safety tips |
| `phishing`             | Bot explains phishing scams    |
| `safe browsing`        | Bot gives safe browsing tips   |
| `exit`                 | Bot says goodbye and closes    |



Project Structure

CybersecurityAwarenessBot/
    .github/
        workflows/
            dotnet-desktop.yml ← CI workflow
    CybersecurityAwarenessBot/
        Program.cs    ← Entry point
        Greeting.cs    ← Voice greeting
        AsciiArt.cs    ← ASCII art logo
        UserInteraction.cs  ← User name input
        ChatBot.cs    ← Chat loop
        ResponseSystem.cs  ← Bot responses
        ConsoleUI.cs    ← Console styling
        greeting.wav    ← Voice greeting audio
    README.md


CI/CD Workflow
This project uses **GitHub Actions** for Continuous Integration.
Every push to the `master` branch automatically:
1. Checks out the code
2. Sets up .NET
3. Restores dependencies
4. Builds the project

Successful CI Run 
[CI Workflow]
<img width="1920" height="879" alt="image" src="https://github.com/user-attachments/assets/db31ce26-5af8-446c-b944-f03b5e0f7423" />




Features
- Voice greeting on startup
- ASCII art logo display
- Personalised conversation using user's name
- Cybersecurity tips on password safety, phishing and safe browsing
- Input validation for empty or unrecognised inputs
- Colour coded console interface
- Typing effect for bot messages



Author
- Student Name: Dimpho Mouba
- Student Number: ST10492572
- Module: PROG6221 - Programming 2A
- Institution: IIE Rosebank

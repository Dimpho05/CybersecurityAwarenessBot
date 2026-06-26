# Cybersecurity Awareness Bot

## About The Project
The Cybersecurity Awareness Bot is a WPF GUI chatbot designed to educate people about cybersecurity threats and how to avoid them. The bot covers topics such as password safety, phishing scams, safe browsing, and online privacy.

This project was developed as part of the PROG6221 Programming 2A module at Rosebank College.

---

## Software Needed

| Software | Version | Download |
|---|---|---|
| Visual Studio | 2022 or later | https://visualstudio.microsoft.com/ |
| .NET Framework | 4.8 or later | https://dotnet.microsoft.com/download |
| MySQL Server | 8.0 | https://dev.mysql.com/downloads/installer/ |
| Git | Latest | https://git-scm.com/downloads |

---

## How To Run The Project

### Step 1: Clone the Repository

git clone https://github.com/Dimpho05/CybersecurityAwarenessBot.git

### Step 2: Set Up MySQL Database
1. Open **MySQL Workbench**
2. Run the following SQL:
```sql
CREATE DATABASE IF NOT EXISTS cybersecurity_bot;
USE cybersecurity_bot;
CREATE TABLE IF NOT EXISTS tasks (
    id INT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    description TEXT,
    is_completed BOOLEAN DEFAULT FALSE,
    reminder_date DATE NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);
```

### Step 3: Configure Database Connection
1. Open `DatabaseHelper.cs`
2. Replace `YOUR_PASSWORD_HERE` with your MySQL root password

### Step 4: Install NuGet Package
1. Right-click the project → **Manage NuGet Packages**
2. Search for and install **MySql.Data**

### Step 5: Open the Project
1. Open **Visual Studio**
2. Click **File → Open → Project/Solution**
3. Navigate to `CybersecurityAwarenessBotGUI`
4. Open `CybersecurityAwarenessBotGUI.slnx`

### Step 6: Build and Run
1. Click **Build → Build Solution**
2. Press **F5** or click the green **Run** button

---

## How To Use The Bot

### Starting the Bot
When the bot launches it will:
1. Play a voice greeting
2. Ask for your name
3. Display feature buttons for Task Assistant, Quiz, and Activity Log

### Chatting With The Bot

| What You Type | What The Bot Does |
|---|---|
| `help` | Lists all available topics |
| `password` | Gives password safety tips |
| `phishing` | Explains phishing scams |
| `safe browsing` | Gives safe browsing tips |
| `privacy` | Gives online privacy tips |
| `malware` | Explains malware threats |
| `2fa` | Explains two-factor authentication |
| `add task` | Opens the Task Assistant |
| `start quiz` | Opens the Cybersecurity Quiz |
| `show activity log` | Shows recent bot actions |
| `exit` | Ends the chat session |

---

## Features

### Part 1 (Console)
- Voice greeting on startup
- ASCII art logo display
- Personalised conversation using user's name
- Keyword-based cybersecurity responses
- Colour coded console interface

### Part 2 (WPF GUI)
- Cyberpunk-themed chat bubble interface
- Sentiment detection (worried, curious, frustrated)
- Memory system (remembers name and favourite topic)
- Random response variation per topic
- Follow-up conversation flow

### Part 3 (Advanced Features)
- **Task Assistant** — Add, view, complete, and delete cybersecurity tasks stored in MySQL
- **Cybersecurity Quiz** — 12 questions with immediate feedback and final score
- **NLP Simulation** — Recognises varied phrasings and natural language commands
- **Activity Log** — Records all key actions with timestamps, shows last 10 with show more option

---

## Project Structure
CybersecurityAwarenessBot/
CybersecurityAwarenessBot/ ← Part 1 Console App
Program.cs
Greeting.cs
AsciiArt.cs
ResponseSystem.cs
ChatBot.cs
CybersecurityAwarenessBotGUI/ ← Part 2 & 3 WPF App
MainWindow.xaml
MainWindow.xaml.cs
ChatMessage.cs
ResponseSystem.cs
SentimentDetector.cs
MemorySystem.cs
UserSession.cs
TaskItem.cs
DatabaseHelper.cs
TaskWindow.xaml
QuizWindow.xaml
QuizData.cs
ActivityLog.cs
ActivityLogWindow.xaml

---

## GitHub Releases

| Version | Description |
|---|---|
| v2.0 | WPF GUI with cyberpunk theme, sentiment detection, memory system |
| v3.0 | Task Assistant with MySQL database integration |
| v3.1 | Cybersecurity Quiz mini-game with 12 questions |
| v3.2 | Activity Log feature with show more option |

---

## Author
- **Student Name:** Dimpho Mouba
- **Student Number:** ST10492572
- **Module:** PROG6221 - Programming 2A
- **Institution:** Rosebank College

# SmartHabitTracker

SmartHabitTracker is an AI-powered habit tracking application that goes beyond simple reminders. It learns your behavior over time, suggests new habits based on your patterns, and helps you stay consistent — acting more like a personal coach than a checklist.

> 🚧 **In active development**

## Vision

Most habit trackers just log what you did. SmartHabitTracker aims to understand *how* you behave — then use that to help you build better routines. The AI layer will:

- Remind you of habits at the right times based on your history
- Suggest new habits aligned with your goals and current patterns
- Learn when you're most likely to succeed and adapt accordingly
- Give you insight into your consistency over time

## Planned Features

- ✅ Habit creation and tracking
- ✅ Progress history and streaks
- 🚧 AI-driven reminders and scheduling
- 🚧 Habit suggestions based on learned behavior
- 🚧 Personalized insights and weekly summaries
- 🔜 Notification system

## Tech Stack

**Backend:** C# / ASP.NET Core Web API

**Frontend:** React, TypeScript

## Getting Started

```bash
# Clone the repo
git clone https://github.com/kifo99/SmartHabitTracker.git
cd SmartHabitTracker
```

**Backend**
```bash
cd backend/SmartHabitTracker.API
dotnet restore
dotnet run
```

**Frontend**
```bash
cd frontend/SmartHabitTracker
npm install
npm run dev
```

## Project Structure

```
SmartHabitTracker/
├── backend/
│   └── SmartHabitTracker.API/   # ASP.NET Core REST API
└── frontend/
    └── SmartHabitTracker/       # React + TypeScript client
```

## Author

[@kifo99](https://github.com/kifo99)

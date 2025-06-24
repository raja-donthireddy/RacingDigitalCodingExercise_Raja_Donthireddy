# 🏇 Horse Racing Insights Portal

An Angular 19 + ASP.NET Core web application that manages race results and surfaces insights such as the best-performing jockey for a given horse. Built with modularity, reusability, and clean UX in mind.

---

## 🚀 Features

- 📋 View detailed race data and notes
- ✏️ Edit and save notes per race
- 🏆 Discover the best jockey for any horse
- 🔍 Searchable dropdown to browse horses dynamically
- 🧠 Backend LINQ logic to analyze top jockeys based on finish position

---

## 🛠 Tech Stack

- **Frontend**: Angular 19 + Angular Material + RxJS
- **Backend**: ASP.NET Core Web API + Entity Framework Core
- **Database**: SQL Server / LocalDB
- **Styling**: SCSS, Material Theme
- **Tooling**: TypeScript, Visual Studio Code, Visual Studio, .NET CLI

---

## 🧪 Getting Started

### Prerequisites

- Node.js (v18+)
- .NET 7 or later
- SQL Server / LocalDB

### Running the App

**Frontend**:

```bash
cd racing-digital-ui
npm install
ng serve

```
**Backend**:

### 📦 API Highlights
- GET /api/raceResults/{id} – Fetch race detail
- POST /api/raceResults/{id}/note – Save or update notes
- GET /api/raceResults/best-jockey?horse=Shadow Dancer – Get top jockey by win count
- GET /api/raceResults/horses – List all distinct horses

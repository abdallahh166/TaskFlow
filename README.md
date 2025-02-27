
# TaskFlow Project: Full-Stack Web Application

## Agile Workflow
### 1. Define User Stories
- As a user, I want to sign up and log in so that my tasks are secure.
- As a user, I want to add, edit, and delete tasks so that I can manage my work efficiently.
- As a user, I want to set task priorities so that I can focus on critical work.
- As a user, I want to see my task progress so that I can track my productivity.

### 2. Sprint Planning
**Sprint 1:** 
- Set up the environment (frontend and backend).
- Build backend API for authentication (register, login).

**Sprint 2:** 
- Develop the frontend for authentication and basic task dashboard.

**Sprint 3:** 
- Add task filtering, priorities, and progress tracking features.

**Sprint 4:** 
- Final testing, debugging, and deployment.

### 3. Scrum Meetings
Daily or alternate-day short meetings to discuss:
- What was done yesterday?
- What’s planned for today?
- Any blockers or challenges?

### 4. Testing Plan
- Unit testing for backend APIs.
- Integration testing for frontend-backend interaction.
- User testing to validate the application's features.

---

## Structure and Analysis

### 1. System Architecture
**Frontend:**
- Built with HTML, CSS (Bootstrap), and JavaScript.
- Interacts with the backend through RESTful APIs.

**Backend:**
- .NET Core Web API for authentication and CRUD operations.
- Secures data with authentication (JWT tokens).

**Database:**
- SQL Server to store user and task information.

**Deployment:**
- Use Azure App Service or AWS Elastic Beanstalk.

---

### 2. System Components
**Frontend:**
- UI Components: Login/Register forms, task list, progress dashboard.
- JavaScript Modules: Handle API calls and dynamic UI updates.

**Backend:**
- Controllers: Hanadle API requests (e.g., UserController, TaskController).
- Services: Business logic (e.g., validation, CRUD operations).
- Models: User, Task, and TaskCategory objects.
- Database Access: Using Entity Framework Core for ORM.

**Database Schema:**
| Table Name   | Columns                                              |
|--------------|------------------------------------------------------|
| **Users**    | UserID (PK), Username, Password, Email, CreatedAt    |
| **Tasks**    | TaskID (PK), UserID (FK), Title, Description, Status, Priority, DueDate, CreatedAt |
| **Categories** | CategoryID (PK), Name                              |

---

### 3. Feature Analysis
**Authentication:**
- Sign-up: Validate email/password.
- Login: Generate and verify JWT tokens.

**Task CRUD Operations:**
- API Endpoints: `/tasks` (POST, GET, PUT, DELETE).
- Frontend: Forms to add/edit tasks and buttons for deletion.

**Progress Tracking:**
- Use JavaScript to calculate and display completed tasks as a percentage.
- Optional: Use a charting library like Chart.js for visualization.

**Filtering and Sorting:**
- By priority, category, or due date.

---

## Summary
This document outlines the Agile workflow, system architecture, components, database schema, and feature analysis for the TaskFlow project. Follow these processes before starting the coding phase to ensure a structured development approach.

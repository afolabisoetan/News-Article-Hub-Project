TrueGlobalNews is a full-stack web application built with ASP.NET MVC, C#, Entity Framework, and Chart.js that empowers users to explore how political bias influences global news coverage.

The platform dynamically aggregates topics, sources, and articles from a database, visualizing each article’s bias level (1–5 scale) across topics like international conflicts and world affairs. Users can browse categorized articles, view color-coded bias indicators, and analyze how news sources lean politically — all through an intuitive, data-driven dashboard.


Key Features:

Dynamic Data Visualization: Interactive bias charts powered by Chart.js render real-time political bias trends.

Relational Database Integration: Uses Entity Framework with PostgreSQL/SQL Server to manage Topics, Articles, and Sources with referential integrity and constraints.

Modular MVC Architecture: Separation of concerns with ViewModels, Controllers, and strongly-typed Razor views.

Secure and Maintainable: Environment variables used for DB credentials; includes error handling for connectivity failures.

Admin Functionality: Add, update, or delete news topics, articles, and sources through validation-protected forms.

Responsive Design: Clean, Bootstrap 5-based UI that adapts beautifully to desktop and mobile screens.


Tech Stack:

Backend: ASP.NET MVC (C#), Entity Framework

Frontend: Razor Views, Bootstrap 5, Chart.js

Database: PostgreSQL / SQL Server

Tools: LINQ, ViewModels, environment-based configuration

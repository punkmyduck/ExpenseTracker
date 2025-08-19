# ExpenseTracker API
Учебный pet-проект на **ASP.NET Core** с использованием **Clean Architecture**.  
Позволяет пользователям вести учёт расходов и доходов, управлять категориями и получать отчёты.

## Цели проекта
- Практика применения **чистой архитектуры** в API
- Освоение работы с **EntityFramework** + **PostgreSQL**
- Реализация аутентификации и авторизации через **JWT**
- Создание **API** с CRUD, фильтрацией, аутентификацией, отчетностью 

## Возможности
- **Управление пользователями**
  - Регистрация, вход, авторизация через JWT, хранимых в Cookie
  - Получение информации о текущем пользователе
- **Транзакции**
  - CRUD для транзакций
  - Фильтрация транзакций по дате, категории и сумме
- **Категории**
  - CRUD-операции над категориями
  - Базовые категории (по умолчанию)
  - Пользовательские категории доходов и расходов
- **Отчеты**
  - Формирование отчетов по транзакиям за период, по категориям, по типу (расход/доход)
  - Сохранение отчетов в БД, чтение/удаление отчетов

## Стек технологий
- **.NET 8 / ASP.NET Core Web API**
- **Entity Framework Core (PostgreSQL)**
- **JWT Bearer Authentication**
- **Clean Architecture** (Domain → Application → Infrastructure → Presentation)
- **Swagger-документация API**
- **Microsoft.VisualStudio.TestTools.UnitTesting** для юнит-тестов

## Структура проекта
```
├── Domain/ # Сущности и правила предметной области
│ ├── Entities/
│ ├── Enums/
│ ├── Exceptions/
│ ├── Repositories/ # (Интерфейсы)
│ └── Validation/
│
├── Application/ # Use-cases, DTO, интерфейсы, мапперы
│ ├── DTO/
│ ├── Mapping/
│ ├── Options/
│ ├── Services/
│ ├── Validation/
│ └── DependencyInjection.cs
│
├── Infrastructure/ # Работа с БД, JWT, внешние сервисы
│ ├── Extensions/
│ ├── Persistence/
│ ├── Repositories/
│ └── DependencyInjection.cs/
│
├── Presentation/ # Контроллеры, запросы/ответы
│ ├── Controllers/
│ └── Middlewares/
│
├── appsettings.json # Файл конфигурации
└── Program.cs # Точка входа
```

## Примеры API
### 1. Регистрация пользователя
```http
POST /auth/register
Content-Type: application/json

{
  "username": "matvey",
  "email": "matvey@example.com",
  "password": "matvey1Password"
}
```
### 2. Авторизация (Получение JWT)
```http
POST /auth/login
Content-Type: application/json

{
  "username": "matvey",
  "password": "123456"
}
```
**Ответ:**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIs..."
}
```
### 3. Получение транзакций пользователя
```http
GET /transactions?startDate=2025-01-01&endDate=2025-01-31
Authorization: Bearer <JWT>
```
### 4. Создание транзакции
```http
POST /transactions
Authorization: Bearer <JWT>
Content-Type: application/json

{
  "type": "Expense",
  "amount": 1200,
  "dateTime": "2025-01-15T10:30:00",
  "categoryId": 3,
  "description": "Продукты"
}
```

## Запуск проекта
### Установка зависимостей
Установите зависимости:
- [.NET 8 SDK](https://dotnet.microsoft.com/download)  
- [PostgreSQL](https://www.postgresql.org/download/)
### Создание базы данных
Подключитесь к PostgreSQL и создайте пустую базу данных:
```sql
CREATE DATABASE "ExpenseTracker";
```
### Настройка параметров
Откройте файл appsettings.json и укажите свои параметры PostgreSQL:
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=ExpenseTracker;Username=postgres;Password=your_password"
}
```
Настройте параметры JWT в том же файле:
```json
"JwtOptions": {
  "SecretKey": "your_secret_key_here",
  "Issuer": "issuer",
  "Audience": "audience",
  "ExpiresHours": 60
}
```
### Запуск приложения
По умолчанию API будет доступно по адресу https://localhost:7269/swagger/index.html с документацией от Swagger UI.

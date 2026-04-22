# 🏗️ Catalog Project - Clean Architecture

Микросервис построен по принципам Clean Architecture с четким разделением слоев и зависимостей

## 📋 Структура проектов


| Проект | Назначение | Зависимости |
| :--- | :--- | :--- |
| **Catalog.API** | Web API, контроллеры, точка входа | Application, Infrastructure |
| **Catalog.Application** | Бизнес-логика, сервисы, use cases | Domain |
| **Catalog.Domain** | Доменные модели, интерфейсы, entities | - |
| **Catalog.Infrastructure** | Данные, внешние сервисы, repositories | Application |
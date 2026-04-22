### Создаем проект по шаблону, регистрируем в файле решения из корня директории.
```bash
Get-ChildItem -Recurse -Filter *.csproj | ForEach-Object { dotnet sln add $_.FullName }
```

## Последовательность действий

### Domain

- Создаем папку Entities
    - Создаем класс BaseEntity от которой будем наследовать общие поля
- Создаем папку Repositories с интерфейсами через которые будет взаимодействовать сущностями
  - Создаем IYourEntityRepository под каждую сущность
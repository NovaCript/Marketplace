```bash
Get-ChildItem -Recurse -Filter *.csproj | ForEach-Object { dotnet sln add $_.FullName }
```

```bash
dotnet user-secrets init
dotnet user-secrets set "OpenAI:ApiKey" "12345"
dotnet user-secrets remove "OpenAI:ApiKey"
```
```xpath
%APPDATA%\Microsoft\UserSecrets\
```
```json
"OpenAI": {
  "ApiKey": "REPLACE_ME_IN_USER_SECRETS"
}
```
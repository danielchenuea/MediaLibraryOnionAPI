Change this description

Add new Appsettings.json

{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=sqlite.db"
  },
  "FeatureManagement": {
    "EmailFeature": true
  },
  "JWTSettings": {
    "Key": <jwtKey>,
    "Issuer": "Identity",
    "Audience": "IdentityUser",
    "Authority": "https://localhost:7060",
    "DurationInMinutes": 60
  },
  "MailSettings": {
    "Mail": <mail>,
    "DisplayName": <name>,
    "Password": <password>,
    "Host": "smtp.gmail.com",
    "Port": 587
  }
}

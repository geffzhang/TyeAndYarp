# Install Global Tools
```
dotnet tool install --global Microsoft.Tye --version 0.2.0-alpha.20258.3
```

# Using Tye Cli to Exec All Projects 
```
tye run
```
or

# Using dotnet   Cli to Exec All Projects 
```
dotnet run -p ./Api1/Api1.csproj
dotnet run -p ./Api2/Api2.csproj
dotnet run -p ./ReverseProxy/ReverseProxy.csproj
```

# Application Url
- http://localhost:5020/api1/WeatherForecast
- http://localhost:5020/api2/WeatherForecast


# Reference
- https://github.com/dotnet/tye
- https://github.com/microsoft/reverse-proxy
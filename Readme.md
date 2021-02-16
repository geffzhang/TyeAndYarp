# Install Global Tools
```
dotnet tool install/update --global Microsoft.Tye --version 0.6.0-alpha.21070.5
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
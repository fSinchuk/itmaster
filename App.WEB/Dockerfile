#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY App.WEB/App.WEB.csproj App.WEB/
COPY App.DAL/App.DAL.csproj App.DAL/
COPY App.Models/App.Models.csproj App.Models/
RUN dotnet restore App.WEB/App.WEB.csproj
COPY . .
WORKDIR /src/App.WEB
RUN dotnet build App.WEB.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish App.WEB.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "App.WEB.dll"]

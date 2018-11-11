FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 64050
EXPOSE 44369

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY CM.Services/CM.Services.Exchange/CM.Services.Exchange.API/CM.Services.Exchange.API.csproj CM.Services/CM.Services.Exchange/CM.Services.Exchange.API/
COPY CM.Shared/CM.Shared.Web/CM.Shared.Web.csproj CM.Shared/CM.Shared.Web/
COPY CM.Services/CM.Services.Exchange/CM.Services.Exchange.Concrete/CM.Services.Exchange.Concrete.csproj CM.Services/CM.Services.Exchange/CM.Services.Exchange.Concrete/
COPY CM.Services/CM.Services.Exchange/CM.Services.Exchange.Infrastracture/CM.Services.Exchange.Infrastracture.csproj CM.Services/CM.Services.Exchange/CM.Services.Exchange.Infrastracture/
RUN dotnet restore CM.Services/CM.Services.Exchange/CM.Services.Exchange.API/CM.Services.Exchange.API.csproj
COPY . .
WORKDIR /src/CM.Services/CM.Services.Exchange/CM.Services.Exchange.API
RUN dotnet build CM.Services.Exchange.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CM.Services.Exchange.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CM.Services.Exchange.API.dll"]

FROM microsoft/dotnet:2.2-sdk AS build-env
WORKDIR /app

# Build da aplicacao
COPY . ./
RUN dotnet publish -c Release -o out

# Build da imagem
FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/Webmotors.WebApi/out .

EXPOSE 80

ENTRYPOINT ["dotnet", "Webmotors.WebApi.dll"]
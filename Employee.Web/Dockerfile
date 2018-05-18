FROM microsoft/dotnet:2.0-sdk
COPY . /app
WORKDIR /app
RUN dotnet restore && dotnet build
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet","run"]
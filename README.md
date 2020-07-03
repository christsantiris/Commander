## Install and Run SQL Server for Mac

First install SQL using Docker

### `sudo docker pull microsoft/mssql-server-linux:2017-latest`

Next run SQL with Docker
### `docker run -e 'HOMEBREW_NO_ENV_FILTERING=1' -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 1433:1433 -d microsoft/mssql-server-linux`

<br /> or <br />

### `docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-CU8-ubuntu` 

<br /> after model is created run<br />

### `dotnet ef migrations add <Migration Name>`
### `dotnet ef database update`
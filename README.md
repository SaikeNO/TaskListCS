## Na dockerze zainstalować mssql
https://learn.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver16&pivots=cs1-bash
https://learn.microsoft.com/en-us/sql/tools/sqlcmd/sqlcmd-utility?view=sql-server-ver16&tabs=go%2Clinux&pivots=cs1-bash

```bash
docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=TestoweHaslo111' -p 1401:1433 --name sql1 -d mcr.microsoft.com/mssql/server:2022-latest 
```

## Stawianie api na linux
https://www.youtube.com/watch?v=mtXE1LMQZEY&ab_channel=RavindraDevrani

1. `cd /var/www`
`sudo chmod -R 777 /var/www`
`mkdir app1`
`dotnet publish -C release -o /var/www/app1`

2. `sudo nano /etc/nginx/sites-available/default`
```bash
server {
    listen        80;
    server_name   example.com *.example.com;
    location / {
        proxy_pass         http://localhost:5000;
        proxy_http_version 1.1;
        proxy_set_header   Upgrade $http_upgrade;
        proxy_set_header   Connection keep-alive;
        proxy_set_header   Host $host;
        proxy_cache_bypass $http_upgrade;
        proxy_set_header   X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header   X-Forwarded-Proto $scheme;
    }
}
```

3.  `sudo nginx -t`
`sudo nginx -s reload`

4. `sudo nano /etc/systemd/system/app1.service`

```bash
[Unit] 
Description= mvcnew webapp
[Service] 
WorkingDirectory=/var/www/app1
ExecStart=/usr/bin/dotnet /var/www/app1/!!!DLL DO APKI!!!.dll 
Restart=always
#Restart service after 10 seconds if the dotnet service crashes:
RestartSec=10
SyslogIdentifier=mvcnew
Environment=ASPNETCORE_ENVIRONMENT=Production

[Install]
WantedBy=multi-user.target
```

5. `sudo systemctl enable app1.service`
`sudo systemctl start app1.service`

6. `dotnet ef database update `
```csharp
private string _connstring = "Server=localhost,1401;database=; User Id=SA; Password=; TrustServerCertificate=True;"
```

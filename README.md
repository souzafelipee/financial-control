# financial-control
Financial Control

1) Executar o comando "docker-compose up -d " para executar o arquivo compose que está na pasta src.
   Este comando irá subir os seguintes containeres:
   1- SQL Server
   2- RabbitMQ
   3- sqltools para criação do banco de dados
   3- Execução de Migrations a partir do projeto FinancialControl.Infra.DbMigrator.Runner

Após isso a aplicação pode ser acessada via swagger no link: http://localhost:32789/swagger/index.html

Instruções de Uso:

Para registrar um lançamento, publicar um evento na Fila do RabbitMQ.
Acessar o console do RabbitMQ pelo link http://localhost:15672/
- Usuário: guest
- Senha: guest

Selecionar a fila que foi criada:
![image](https://github.com/souzafelipee/financial-control/assets/42378416/2c9194d6-59f7-471e-9f29-8a1b4ef65a88)

publicar na Fila o seguinte evento:

{
    "destinationAddress": "rabbitmqs://localhost:0/FinancialControl.Domain.Events:RegisterTransactionEvent",
    "messageType": ["urn:message:FinancialControl.Domain.Events:RegisterTransactionEvent"],
    "message": {
        "transactionType": 1,
        "transactionDescription": "Crédito Saldo Inicial",
        "transactionValue": 1000.00
    }
}

![image](https://github.com/souzafelipee/financial-control/assets/42378416/3aed64bd-36db-4a7d-aac6-4ca53875c084)

TransactionType: 
 - 1 para débito
 - 2 para crédito

Para obter o extrato, consumir a api GET /Account/Statement preenchendo a Data Solicitada para relatório no formado YYYY-MM-DD

- api pode ser acessada via swagger

- Desenhos da Aplicação:
![image](https://github.com/souzafelipee/financial-control/assets/42378416/cb8051f4-4243-42fa-8b34-ddf14f32c4c9)

- Banco de Dados
![image](https://github.com/souzafelipee/financial-control/assets/42378416/0e30a0f7-85b4-4771-a52d-f17a5685dbd6)

https://docs.google.com/document/d/1o_D2nGpVC4fAH23Iz3k4EU-gouTIUzKXfaFaJtAmOnk/edit?usp=sharing

1) Subir Container SQL Server
    docker run --hostname=93cb9fe3d806 --user=mssql --env=ACCEPT_EULA=Y --env=MSSQL_SA_PASSWORD=Senha@2023 --env=PATH=/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin --env=MSSQL_RPC_PORT=135 --env=CONFIG_EDGE_BUILD= --env=MSSQL_PID=developer -p 1433:1433 --label='com.microsoft.product=Microsoft SQL Server' --label='com.microsoft.version=16.0.4095.4' --label='org.opencontainers.image.ref.name=ubuntu' --label='org.opencontainers.image.version=22.04' --label='vendor=Microsoft' --runtime=runc -d mcr.microsoft.com/mssql/server:latest

2) Subir Container RabbitMQ
   docker run --hostname=21239bbcf36d --mac-address=02:42:ac:11:00:03 --env=PATH=/opt/rabbitmq/sbin:/opt/erlang/bin:/opt/openssl/bin:/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin --env=ERLANG_INSTALL_PATH_PREFIX=/opt/erlang --env=OPENSSL_INSTALL_PATH_PREFIX=/opt/openssl --env=RABBITMQ_DATA_DIR=/var/lib/rabbitmq --env=RABBITMQ_VERSION=3.12.7 --env=RABBITMQ_PGP_KEY_ID=0x0A9AF2115F4687BD29803A206B73A36E6026DFCA --env=RABBITMQ_HOME=/opt/rabbitmq --env=HOME=/var/lib/rabbitmq --env=LANG=C.UTF-8 --env=LANGUAGE=C.UTF-8 --env=LC_ALL=C.UTF-8 --volume=/var/lib/rabbitmq -p 15672:15672 -p 5672:5672 --label='org.opencontainers.image.ref.name=ubuntu' --label='org.opencontainers.image.version=22.04' --runtime=runc -d masstransit/rabbitmq:latest

3) Subir Container Aplicação:
   docker run --hostname=516553f0f8e1 --mac-address=02:42:ac:11:00:04 --env=ASPNETCORE_LOGGING__CONSOLE__DISABLECOLORS=true --env=ASPNETCORE_ENVIRONMENT=Development --env=DOTNET_USE_POLLING_FILE_WATCHER=1 --env=NUGET_PACKAGES=/.nuget/fallbackpackages --env=NUGET_FALLBACK_PACKAGES=/.nuget/fallbackpackages --env=PATH=/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin --env=ASPNETCORE_URLS=http://+:80 --env=DOTNET_RUNNING_IN_CONTAINER=true --env=DOTNET_VERSION=6.0.25 --env=ASPNET_VERSION=6.0.25 --volume=C:\Users\Felipe Souza\AppData\Roaming\Microsoft\UserSecrets:/home/app/.microsoft/usersecrets:ro --volume=C:\Users\Felipe Souza\AppData\Roaming\ASP.NET\Https:/root/.aspnet/https:ro --volume=C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Sdks\Microsoft.Docker.Sdk\tools\HotReloadProxy\linux-x64\net6.0:/HotReloadProxy:ro --volume=C:\felipe\souzafelipee\financial-control\src:/src/ --volume=C:\Users\Felipe Souza\.nuget\packages\:/.nuget/fallbackpackages --volume=C:\felipe\souzafelipee\financial-control\src\FinancialControl:/app --volume=C:\Users\Felipe Souza\vsdbg\vs2017u5:/remote_debugger:rw --volume=C:\Users\Felipe Souza\AppData\Roaming\Microsoft\UserSecrets:/root/.microsoft/usersecrets:ro --volume=C:\Users\Felipe Souza\AppData\Roaming\ASP.NET\Https:/home/app/.aspnet/https:ro --volume=C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Sdks\Microsoft.Docker.Sdk\tools\TokenService.Proxy\linux-x64\net6.0:/TokenService.Proxy:ro --volume=C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\CommonExtensions\Microsoft\HotReload:/HotReloadAgent:ro --workdir=/app -p 32786:443 -p 32787:80 --restart=no --label='com.microsoft.created-by=visual-studio' --label='com.microsoft.visual-studio.project-name=FinancialControl' --runtime=runc -t -d financialcontrol:dev

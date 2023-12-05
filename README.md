# financial-control
Financial Control

1) Executar o comando "docker-compose up -d " para executar o arquivo compose que está na pasta src.
   Este comando irá subir os seguintes containeres:
   1- SQL Server
   2- RabbitMQ
   3- sqltools para criação do banco de dados
   4- Execução de Migrations a partir do projeto FinancialControl.Infra.DbMigrator.Runner

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

Para obter o extrato, consumir a api GET /Account/Statement preenchendo a Data Solicitada para relatório no formato YYYY-MM-DD

- api pode ser acessada via swagger

- Desenhos da Aplicação:
![image](https://github.com/souzafelipee/financial-control/assets/42378416/cb8051f4-4243-42fa-8b34-ddf14f32c4c9)

- Banco de Dados
![image](https://github.com/souzafelipee/financial-control/assets/42378416/0e30a0f7-85b4-4771-a52d-f17a5685dbd6)

https://docs.google.com/document/d/1o_D2nGpVC4fAH23Iz3k4EU-gouTIUzKXfaFaJtAmOnk/edit?usp=sharing

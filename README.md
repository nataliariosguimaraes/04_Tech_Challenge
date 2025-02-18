🚀 Arquitetura do Desafio - Kubernetes, Mensageria e Monitoramento
Este desafio envolve a criação e implementação de uma arquitetura baseada em Kubernetes, utilizando mensageria e monitoramento para tornar a aplicação escalável e resiliente.

📌 Estrutura da Aplicação
Dividimos nossa solução em três microsserviços principais:

1️⃣ Contato - Responsável pelo cadastro de contatos.

Repositório: Contato Service
Docker Hub: natriosg/appcontato
2️⃣ Análise de Sentimento - Realiza análise de sentimento ao cadastrar um contato.

Repositório: Análise de Sentimento Service
Docker Hub: natriosg/analisesentimento
3️⃣ Notificação - Envia notificações por e-mail para contatos cadastrados.

Repositório: Notificação Service
Docker Hub: natriosg/notificacao
📊 Arquitetura
A aplicação segue um modelo baseado em eventos, utilizando RabbitMQ como broker de mensagens para garantir desacoplamento entre os serviços.


🔹 O serviço Contato cadastra um novo usuário no banco de dados (PostgreSQL) e publica um evento no RabbitMQ.
🔹 O serviço Análise de Sentimento consome essa mensagem, processa o sentimento e armazena o resultado.
🔹 O serviço Notificação também consome a mensagem e envia um e-mail de confirmação para o usuário.

📽️ Explicação da Arquitetura
Para entender melhor a solução, assista ao vídeo explicativo:
🎥 Vídeo no Google Drive

⚙️ Tecnologias Utilizadas
✅ Kubernetes - Orquestração de containers
✅ RabbitMQ - Mensageria para comunicação assíncrona
✅ PostgreSQL - Banco de dados relacional
✅ Docker - Containerização dos serviços
✅ Monitoramento - Ferramentas para observabilidade da aplicação
✅ .NET 8 - Framework utilizado no desenvolvimento dos microsserviços
✅ C# - Linguagem de programação usada no projeto
✅ Entity Framework - ORM (Object-Relational Mapping) utilizado para interagir com o banco de dados
✅ xUnit - Framework de testes utilizado para testes unitários

📌 Como Executar o Projeto
1️⃣ Clone os repositórios listados acima.
2️⃣ Configure as variáveis de ambiente conforme necessário.
3️⃣ Utilize Docker Compose ou Kubernetes para subir os serviços.
4️⃣ Acompanhe os logs e o funcionamento dos microsserviços.

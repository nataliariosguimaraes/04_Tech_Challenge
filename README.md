

# 🚀 Arquitetura do Desafio - Kubernetes, Mensageria e Monitoramento  

Este desafio envolve a criação e implementação de uma arquitetura baseada em **Kubernetes**, utilizando **mensageria** e **monitoramento** para tornar a aplicação escalável e resiliente.  

## 📌 Estrutura da Aplicação  

Dividimos nossa solução em três microsserviços principais:  

1️⃣ **Contato** - Responsável pelo cadastro de contatos.  
   - Repositório: [Contato Service](https://github.com/nataliariosguimaraes/04_Tech_Challenge.git)  
   - Docker Hub: [natriosg/appcontato](https://hub.docker.com/repository/docker/natriosg/appcontato/general)  

2️⃣ **Análise de Sentimento** - Realiza análise de sentimento ao cadastrar um contato.  
   - Repositório: [Análise de Sentimento Service](https://github.com/nataliariosguimaraes/03_Tech_Challenge_Servico_Analise_Sentimento)  
   - Docker Hub: [natriosg/analisesentimento](https://hub.docker.com/repository/docker/natriosg/analisesentimento)  

3️⃣ **Notificação** - Envia notificações por e-mail para contatos cadastrados.  
   - Repositório: [Notificação Service](https://github.com/nataliariosguimaraes/Service.Notification)  
   - Docker Hub: [natriosg/notificacao](https://hub.docker.com/repository/docker/natriosg/notificacao/general)  

---

## 📊 Arquitetura  

A aplicação segue um modelo baseado em eventos, utilizando **RabbitMQ** como broker de mensagens para garantir desacoplamento entre os serviços.  

![Arquitetura da solução](caminho_para_a_imagem)  

🔹 O serviço **Contato** cadastra um novo usuário no banco de dados (**PostgreSQL**) e publica um evento no **RabbitMQ**.  
🔹 O serviço **Análise de Sentimento** consome essa mensagem, processa o sentimento e armazena o resultado.  
🔹 O serviço **Notificação** também consome a mensagem e envia um e-mail de confirmação para o usuário.  

---

## 📽️ Explicação da Arquitetura  

Para entender melhor a solução, assista ao vídeo explicativo:  
🎥 [Vídeo no Google Drive](https://drive.google.com/file/d/1LbwjnLpeBs2usjDQFlMXCOzfbEWspN3P/view?usp=sharing)  

---

## ⚙️ Tecnologias Utilizadas  

✅ **Kubernetes** - Orquestração de containers  
✅ **RabbitMQ** - Mensageria para comunicação assíncrona  
✅ **PostgreSQL** - Banco de dados relacional  
✅ **Docker** - Containerização dos serviços  
✅ **Monitoramento** - Ferramentas para observabilidade da aplicação  
✅ **.NET 8** - Framework utilizado no desenvolvimento dos microsserviços  
✅ **C#** - Linguagem de programação usada no projeto  
✅ **Entity Framework** - ORM (Object-Relational Mapping) utilizado para interagir com o banco de dados  
✅ **xUnit** - Framework de testes utilizado para testes unitários  

---  

## 📌 Como Executar o Projeto  

1️⃣ Clone os repositórios listados acima.  
2️⃣ Configure as variáveis de ambiente conforme necessário.  
3️⃣ Utilize **Docker Compose** ou **Kubernetes** para subir os serviços.  
4️⃣ Acompanhe os logs e o funcionamento dos microsserviços.  

---

Caso tenha dúvidas ou sugestões, fique à vontade para contribuir! 🚀

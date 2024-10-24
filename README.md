# Tech Challenger - CI/CD e Monitoramento

# Introdução

Na fase anterior do Tech Challenge, desenvolvemos um aplicativo .NET para cadastro de contatos regionais, com funcionalidades de adicionar, consultar, atualizar e excluir contatos, utilizando Entity Framework Core ou Dapper para persistência de dados e implementando validações de dados.

Nesta segunda fase, vamos aprimorar o projeto através da integração de práticas avançadas, como Integração Contínua (CI), testes de integração, e monitoramento de performance com Prometheus e Grafana.

# Objetivos

- **Testes de Integração**:
  - Garantir que todos os componentes do sistema funcionem corretamente quando integrados.
- **Integração Contínua (CI) com GitHub Actions**:
  - Automação dos processos de build, testes unitários e testes de integração.
- **Monitoramento com Prometheus e Grafana**:
  - Implementação de métricas de monitoramento para avaliar a saúde e o desempenho do aplicativo.

# Tecnologias Utilizadas:

- **.NET 8**: Framework para construção da Minimal API.
- **C#**: Linguagem de programação usada no desenvolvimento do projeto.
- **Entity Framework**: ORM (Object-Relational Mapping) utilizado para interagir com o banco de dados.
- **xUnit**: Framework de testes utilizado para realizar testes unitários.
- **Postegress**: Banco de dados relacional usado para armazenar os dados da aplicação.
- **Prometheus**: Ferramenta projetada para coletar, armazenar e consultar métricas de sistemas e serviços..
- **Grafana**: Plataforma de análise e visualização de código aberto que permite criar dashboards dinâmicos e interativos.

# Vídeo explicativo

- [Parte 1 - CI e CD (Branch Master)](https://drive.google.com/file/d/1IRKbsJnJ2XN0EcXyjbgSnHGPer4UXDHa/view)
- [Parte 2 - Monitoramento (Branch feature/grafana )](https://drive.google.com/file/d/1D0Ft5DvXD_T-1yJRdh8nVR3w2bgswGPW/view)

# Documentação

- [WorkFlow](https://horse-neon-79c.notion.site/Workflow-GitHub-Actions-e0cf8a925de945bc89acc7a61de6ab87?pvs=4)
- [DockerFile](https://horse-neon-79c.notion.site/DockerFile-Configura-es-3d917ef39a994f68b4ecd02f163b17a8?pvs=4)
- [Prometheus](https://horse-neon-79c.notion.site/Prometheus-Configura-es-dff855874cb14e34ab307de9f4cdb59a?pvs=4)
- [Grafana](https://horse-neon-79c.notion.site/Grafana-Configura-es-579faa08d53942d894ab27e6b755a035?pvs=4)

# **Checklist de Conclusão de Tarefas**

- [x] GitHub Actions
- [x] Prometheus
- [x] Grafana
- [x] Vídeo exibindo a entrega

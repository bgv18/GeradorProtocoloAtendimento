# GeradorProtocoloAtendimento

Projeto com a premissa de um sistema que gere um protocolo de atendimento baseados na seguinte regra:

Formação do Protocolo: XXXXXXAAAAMMDDNNNNNN
  
Ex: 31970820230921000001

onde:

XXXXXX = Número identificador da empresa: 6 dígitos numéricos. Ex: Empresa A = 319708

AAAAMMDD = Ano, Mês e Dia. Ex: 20230921

NNNNNN = Número sequencial do protocolo: 6 dígitos numéricos (confirmar). Ex: 000001, 000002, etc.

Algoritmo:
Implementar método de geração do sequencial do protocolo com controle de concorrência (método síncrono), somente um processo de cada vez pode gerar protocolo para não gerar dois sequenciais idênticos para a mesma empresa. 
 
Número identificador da empresa é sempre o mesmo.
A identificação da data muda a cada dia.

O número sequencial do protocolo deve ser reiniciado diariamente. Ao longo do dia, o sequencial incrementa à cada solicitação de novo protocolo.

  ## 🧪 Tecnologias

  O projeto foi desenvolvido usando as seguintes tecnologias:

  - [.NET 6]
  - [DBInMemory] - Para simular um banco de dados em memoria

  ## 🚀 Getting started

  Clone o projeto e acesse a pasta:

  ```bash
  $ git clone https://github.com/bgv18/GeradorProtocoloAtendimento.git && cd GeradorProtocoloAtendimento
  ```

  Siga os passos abaixo
  ```
  # Abra a pasta api e inicialize
  $ cd GeradorProtocoloAtendimento
  $ dotnet run
  
  # Abra a pasta frontend e inicialize
  $ cd GeradorProtocoloAtendimento.Web
  $ dotnet run

  OBS: Configuracoes de endereco da api para visualizacao do front estao fixas no codigo

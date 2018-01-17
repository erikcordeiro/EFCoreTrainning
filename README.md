# Entity Framework Core Trainning
Projeto de aprendizado e testes com Entity Framework Core que visa desenvolver uma arquitetura concisa e desacoplada de componentes de acesso a dados.

## Estruturação da solução
Projeto | Propósito
-- | --
```EFCoreTrainning.Domain```| Contém classes POCO do domínio do negócio.
```EFCoreTrainning.DataAccess```| Camada responsável pelas operações de CRUD no banco de dados.
```EFCoreTrainning.DataAccess.Tests```| Projeto de testes unitários do EFCoreTrainning.DataAccess.
```EFCoreTrainning.WebApi```| Aplicação da camada de apresentação para expor as funcionalidades do sistema.

## Esquema de dependências
Projeto | Depende de
-- | --
```EFCoreTrainning.Domain```| _nenhuma dependência_
```EFCoreTrainning.DataAccess```| ```EFCoreTrainning.Domain```
```EFCoreTrainning.WebApi```| ```EFCoreTrainning.Domain``` e ```EFCoreTrainning.DataAccess```
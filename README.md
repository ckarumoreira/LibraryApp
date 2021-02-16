LibraryApp
===

## Pré-requisitos:
* .NET Core 3.1
* Docker
* MongoDB

## Execução:
* Para rodar a aplicação, basta clonar este repositório e executar os dois comandos abaixo.
```
docker-compose build
docker-compose up
```

* Caso possua o Visual Studio instalado, basta verificar se o docker-compose consta como projeto inicial e pressionar o *play*.

A API está disponível para interação no endpoint:
```
https://<host>:44388/swagger
```
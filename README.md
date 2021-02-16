LibraryApp
===

## Pr�-requisitos:
* .NET Core 3.1
* Docker
* MongoDB

## Execu��o:
* Para rodar a aplica��o, basta clonar este reposit�rio e executar os dois comandos abaixo.
```
docker-compose build
docker-compose up
```

* Caso possua o Visual Studio instalado, basta verificar se o docker-compose consta como projeto inicial e pressionar o *play*.

A API est� dispon�vel para intera��o no endpoint:
```
https://<host>:44388/swagger
```
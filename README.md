# Criptografia Julio Cesar
Aplicativo para leitura de um arquivo Json que contém uma mensagem criptografada para ser descriptografada de acordo com a quantidade de casas enviadas no arquivo json. Essa mensagem descriptografada é retornada para uma api, cujo é simulado a maneira como o general Julio Cesar se comunicava com seus generais. 


# O aplicativo

Este aplicativo foi desenvolvido na plataforma .NET com a linguagem c#.

A idéia é buscar de uma api um json com as informações de Criptografia utilizando um token do usuário, onde foi utilizado a classe Answer para deserializar o json e poder manipulá-lo. Foi utilizado o HttpClient para requisição do arquivo e para o envio do mesmo com a mensagem descriptografada. Com essa mensagem, foi gerada um hash utilizando a biblioteca do SHA1 e anexada no arquivo JSON para responder a requisição. O arquivo foi enviado no corpo da mensagem (body) utilizando a classe MultipartFormDataContent da plataforma, na qual utiliza o mesmo conceito de envio de formulário HTML.

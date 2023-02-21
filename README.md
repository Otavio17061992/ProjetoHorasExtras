<p align="center">
<h1>Cadastro de Horas Extras em WinForms e SQLite</h1>
</p>
<br>

<p align="center">
Este é um aplicativo de cadastro de horas extras em C# com interface gráfica em
Windows Forms e banco de dados SQLite. Ele permite que o usuário insira informações
sobre as horas extras trabalhadas, como o nome do funcionário, a data, a quantidade de 
horas extras e uma descrição opcional.
</p>

<br>
Pré-requisitos
Necessário ter o pacote .Net 4.8


Como executar o aplicativo
Para executar o aplicativo, siga os seguintes passos:

Clone o repositório para a sua máquina.
<br>
Abra o arquivo "CadastroHorasExtras.sln" no Visual Studio.
<br>
Certifique-se de que o pacote NuGet do SQLite está instalado no seu projeto.
<br>
Pressione F5 para executar o aplicativo.
<br>
A tela inicial do aplicativo será exibida.

Tela inicial é a telaSplashScreen de carregamento
 <p align="center">
  <img src="https://user-images.githubusercontent.com/93503467/220215054-8418cece-27ae-427f-b93a-0c38f055a1d8.png?raw=true" alt="Sublime's custom image"/>
</p>

<h2>Tela de login do Usuario</h2>
 <p align="center">
  <img src="https://user-images.githubusercontent.com/93503467/220215739-2fd5cc32-a58d-44da-b531-222f597af645.png?raw=true" alt="Sublime's custom image"/>
</p>
apos logar com uma conta master 
"Login - Desenv"
"senha - desenv"

<p> ira abri a tela principal da interface para add colaboradores</p>
<h2>Tela Cadastras Colaboradores</h2>
 <p align="center">
  <img src="https://user-images.githubusercontent.com/93503467/220216953-ed32c84b-a095-4bd6-90b4-1c9b0a993f38.png?raw=true" alt="Sublime's custom image"/>
</p>

<br>

<p>Para adicionar um novo colaborador basta clicar no botao de "+"</p>
 <p align="center">
  <img src="https://user-images.githubusercontent.com/93503467/220216649-75756e6a-971e-4882-8017-97e9aabac854.png?raw=true" alt="Sublime's custom image"/>
</p>
Preencha as informações do novo Colaborador, como o nome do funcionário, Departamento.

<br>
<p>Após adicionar o colaborador a interface do botao ira mudar</p>
 <p align="center">
  <img src="https://user-images.githubusercontent.com/93503467/220217677-46767871-c2db-4f93-87eb-51767281a7b9.png?raw=true" alt="Sublime's custom image"/>
</p>

<p>Para editar um colaborador existe duas formas clicando com o botao direito ira aparecer um menuStrip 
com as seguintes informações editar abrir ou excluir</p>
 <p align="center">
  <img src="https://user-images.githubusercontent.com/93503467/220217923-456d1237-d2c4-4e06-87cc-1e395b5d9f7c.png?raw=true" alt="Sublime's custom image"/>
</p>

<p> Nota todas as ações feitas como editar ,excluir são permanentes tome muito cuidado, certifique-se que tem plena convicção</p> 

<br>
<p>Há outra maneira de se excluir o Colaborador e clicando e segurando com o botão direito do mouse e esperar 5 segundos</p>
<p>ira aparecer um botão para excluir o colaborador conforme imagem abaixo</p>
 <p align="center">
  <img src="https://user-images.githubusercontent.com/93503467/220219085-1e1e71c2-46a6-4ae2-a09c-782075ba1e6f.png?raw=true" alt="Sublime's custom image"/>
</p>

<p>Caso botão de excluir for clicado aparecera uma menssagem para confirmação de exclusão</p>
 <p align="center">
  <img src="https://user-images.githubusercontent.com/93503467/220220091-5deecbea-c026-48af-91c6-846ad8bc46f6.png?raw=true" alt="Sublime's custom image"/>
</p>

<p>Clicando no Colaborador com o botão esquerdo do mouse você ira para a tela de cadastrar as horas Extras do colaborador</p>
<h2>Tabela Horas Extras</h2>
 <p align="center">
  <img src="https://user-images.githubusercontent.com/93503467/220221869-78efb27e-68f9-4ac0-8d1c-990a279b8e3a.png?raw=true" alt="Sublime's custom image"/>
</p>

https://user-images.githubusercontent.com/93503467/220223347-c1b2b39d-032f-4d02-be41-b0e7ecf58593.mp4

Conclusão
Este aplicativo é uma ótima maneira de gerenciar as horas extras trabalhadas pelos funcionários de uma empresa. Ele permite que o usuário adicione novas entradas, edite entradas existentes e exclua entradas. Além disso, ele armazena as entradas em um banco de dados SQLite, o que torna o processo de gerenciamento de dados muito mais eficiente e fácil.

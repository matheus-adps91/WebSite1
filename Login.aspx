<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <title>Login</title>
    <meta name="author" content="Matheus Augusto de Paula Silva"/>
	<meta name="description" content="Programação WEB - Projeto P2"/>
	<link rel="stylesheet" href="loginEstilo.css"/>
	<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
</head>

<body>

<div class="login">
  
  <h2 class="login-header">Disciplinas</h2>

  <form class="login-container" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server">
      </asp:ScriptManager>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
              <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
              <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox>
              <asp:Button ID="btnAcessar" runat="server" OnClick="btnAcessar_Click" Text="ACESSAR" />
              <asp:Button ID="btnRecuperar" runat="server" OnClick="btnRecuperar_Click" Text="RECUPERAR SENHA" />
              <asp:Label ID="lblMensagem" runat="server" Text="Mensagem"></asp:Label>
          </ContentTemplate>
      </asp:UpdatePanel>
      <br />
      <asp:UpdateProgress ID="UpdateProgress1" runat="server">
          <ProgressTemplate>
              Aguarde, Enviando seu email.
          </ProgressTemplate>
      </asp:UpdateProgress>

  </form>
</div>





</body>	
       
</html>

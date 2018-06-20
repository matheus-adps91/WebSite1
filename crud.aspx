<%@ Page Language="C#" AutoEventWireup="true" CodeFile="crud.aspx.cs" Inherits="crud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Cadastro de Disciplina </title>
     <link rel="stylesheet" href="cadastroEstilo.css"/>    
</head>
<body>
	
		<!-- CABEÇALHO -->
			<header id="cabecalho">
				<h1 id="titulo"> Cadastro de Disciplinas </h1>
			</header>
			
			

		<!-- CONTAINER PRINCIPAL -->
		<div class="principal">

		<!-- FORMULÁRIO CENTRAL -->
			<div id="formularioCentral">
				<form id="form1" runat="server">
				<fieldset>
					<legend> Preencha o formulário: </legend>
						
						<div id="bloco2">
                            <label for="codigo" id="lblCodigo">Código</label>
                            <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
							<label for="nome" id="rtlNome">Nome:</label>&nbsp;
                            <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
						</div>

						<div class="bloco">
							<label for="descricao" id="rtlDescricao">Descrição:</label>&nbsp;
                            <asp:TextBox ID="txtDescritivo" runat="server"></asp:TextBox>
                            <br />
						</div>

						<div id="fmtRadio">
							<label id="lblStatus">Status:</label>
							<div id="opsRadio">
								&nbsp;<asp:RadioButton ID="rdoSim" name="ativo" runat="server" Text="Sim" />
                                <br />
                                <asp:RadioButton ID="rdoNao" name="ativo" runat="server" Text="Não" />
							</div>
						</div>
						
						<div class="bloco">
							<label class="rotulos">Nome do Curso:</label>&nbsp;
                            <asp:DropDownList ID="ddlNomeCurso" runat="server">
                            </asp:DropDownList>
						</div>

						<div class="bloco">
							<label for="email" class="rotulos">Email da Disciplina:</label>&nbsp;
                            <asp:TextBox ID="txtEmailDaDisciplina" runat="server"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Label ID="lblResultado" runat="server" Text="Resultado"></asp:Label>
                            <br />
                            <br />
                            <br />
						</div>
						
						<div id="botoes">
						
							&nbsp;
                            <asp:Button ID="btnCadastrar" runat="server" OnClick="btnCadastrar_Click" Text="CADASTRAR" />
                            <asp:Button ID="btnPesquisar" runat="server" OnClick="btnPesquisar_Click" Text="PESQUISAR" />
						    <br />
                            <asp:Button ID="btnAtualizar" runat="server" OnClick="btnAtualizar_Click" Text="ATUALIZAR" />
                            <asp:Button ID="btnExcluir" runat="server" OnClick="btnExcluir_Click" Text="EXCLUIR" />
                            <br />
						</div>
				</fieldset>	 
				</form>
			</div>
		</div>
		
		

			<!-- RODA PÉ DA PÁGINA -->
			<footer id="rodape">
				<p class="direito"> Todos os direitos reservado ao proprietário. </p>
			</footer>
			
	</body>
</html>
<script src="jquery-3.3.1.min.js"></script>
<script>
	function validar(){
		if (codigo.value.length != 7 )
		{
			alert("Digite o codigo da matéria com 7 caracteres");
			codigo.focus();
			return false;
		}
		if(nome.value.length < 2)
		{
			alert("digite um  nome completo");
			nome.focus();
			return false;
		}
		if(descricao.value.length < 3)
		{
			alert("digite a descrição completa");
			descricao.focus();
			return false;
		}
		if ( email.value.length < 6||
			email.value.indexOf("@") <1 || 
			email.value.indexOf(".") < 1)
			{
				alert("Digite seu e-mail");
				email.focus();
				return false;
			}
		alert("formulário preenchido com sucesso");
	}
	
	function Nova(){
		location.href=" lista.html"
	}

	$("#loadTextFile").click(function (e) {
        $("#textData").load("test.txt", function (response, status, xhr) {
            if (status == "error")
                $("#textData").html
        });
    });
</script>

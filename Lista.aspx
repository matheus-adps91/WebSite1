<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Lista.aspx.cs" Inherits="Lista" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
	<title> Lista de Disciplinas </title>
    <meta name="author" content="Matheus Augusto de Paula Silva"/>
	<meta name="description" content="Programação WEB - Projeto P2"/>
	<link rel="stylesheet" href="listaEstilo.css"/>
	<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
</head>
<body>
    <form id="form1" runat="server">
        <div id="textData">
            <asp:Label ID="lblUsuario" runat="server" Text="Label"></asp:Label>
            <br/>
            <br/>
            <asp:GridView ID="gvLista" runat="server">
            </asp:GridView>
            <br />
        </div>
			
        <script src="jquery-3.3.1.min.js"></script>
        <script>
		    $("#loadTextFile").ready(function (e) {
                $("#textData").load("test.txt", function (response, status, xhr) {
                    if (status == "error")
					    $("#textData").html
                });
            });
	</script>
    </form>
</body>
</html>

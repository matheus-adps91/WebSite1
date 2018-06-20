using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Lista : System.Web.UI.Page
{
    // String de conexão do banco de dados
    String sc = "Server=localhost;Database=progwebp2;Uid=root;Pwd=002856;SslMode=none;";

    protected void Page_Load(object sender, EventArgs e)
    {
        // Se a variável código de sessão for nula, redireciona para o login
        if (Session["codigo"] == null)
        {
            Response.Redirect("login.aspx");
        }
        // Escrevendo uma mensagem de boa binda para o usuário
        lblUsuario.Text = "Olá," + (String)Session["nome"];

        MySqlConnection conn = new MySqlConnection(sc);
        conn.Open();
        String sql = "select * from usuario";
        MySqlCommand comando = new MySqlCommand(sql, conn);
        gvLista.DataSource = comando.ExecuteReader();
        gvLista.DataBind();
        conn.Close();
    }

    protected void logout(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("login.aspx");
    }
}
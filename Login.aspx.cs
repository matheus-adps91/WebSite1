using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    // String de conexão do banco de dados
    String sc = "Server=localhost;Database=progwebp2;Uid=root;Pwd=002856;SslMode=none;";

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }// Fim do método Page_Load

    protected void btnRecuperar_Click(object sender, EventArgs e)
    {
        String email = txtEmail.Text;
        String resp = "";
        try
        {
            // Criando um objeto do tipo MySqlConnection
            MySqlConnection conn = new MySqlConnection(sc);
            // Abrindo conexão com o banco de dados
            conn.Open();
            // Montando a string de busca da senha
            String sql = "select senha from usuario where email='" + email + "'";
            //
            MySqlCommand executeQuery = new MySqlCommand(sql, conn);
            // Efetua a leitura de linhas de uma tabela
            MySqlDataReader readerRecord = executeQuery.ExecuteReader();
            // Verifica se um registro foi encontrado
            if (readerRecord.Read())
            {                
                resp = readerRecord["senha"].ToString();                
            }
            else
            {
                lblMensagem.Text = "Senha não encontrada !";
            }
            conn.Close();
        }
        catch (Exception err)
        {
            // Exibindo uma mensagem de erro de gravação
            lblMensagem.Text = "Erro de gravação do registro!\n" + err.Message;
        }

        MailAddress de = new MailAddress("fatecpwAds2016@outlook.com");
        MailAddress para = new MailAddress(email);
        MailMessage correioEletronico = new MailMessage();
        correioEletronico.Subject = "Recuperação de senha";
        correioEletronico.Body = "<br>A sua senha é : '" + resp+"'";
        correioEletronico.IsBodyHtml = true;
        correioEletronico.From = de;
        correioEletronico.To.Add(para);
        SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com");
        try
        {
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new
                NetworkCredential("fatecpwAds2016@outlook.com", "FreiJoao59");
            smtp.Send(correioEletronico);
            lblMensagem.Text = "Email enviado com sucesso!!";
        }
        catch (Exception err)
        {
            lblMensagem.Text = "Ocorreu um erro no envio " + err.Message;
        }
    }

    protected void btnAcessar_Click(object sender, EventArgs e)
    {
        MySqlConnection conn = new MySqlConnection(sc);
        conn.Open();
        String sql = "select codUsuario, nome from usuario where email='{0}' and senha='{1}'";
        sql = String.Format(sql, txtEmail.Text, txtSenha.Text);
        MySqlCommand comando = new MySqlCommand(sql, conn);
        MySqlDataReader readerRecord = comando.ExecuteReader();
        if (readerRecord.Read())
        {
            Session["codigo"] = readerRecord["codUsuario"].ToString();
            Session["nome"] = readerRecord["nome"].ToString();            
            Response.Redirect("lista.aspx");
        }
        else
        {
            lblMensagem.Text = "Email ou senha invalidos !!!";
        }
        conn.Close();
    }

}// Fim da classe Login
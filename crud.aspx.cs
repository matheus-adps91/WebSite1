using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class crud : System.Web.UI.Page
{
    // String de conexão do banco de dados
    String sc = "Server=localhost;Database=progwebp2;Uid=root;Pwd=002856;SslMode=none;";

    protected void Page_Load(object sender, EventArgs e)
    {
        // Verifica se é Carga ou Recarga da página
        if (!IsPostBack)
        {
            // Chama o método que carrega os cursos em um drop down list
            LoadNameOfCourse();
        }
    }   

    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        try
        {
            // Criando um objeto do tipo MySqlConnection
            MySqlConnection conn = new MySqlConnection(sc);
            // Abrindo conexão com o banco de dados
            conn.Open();
            // Armazena o status da disciplina
            int b_status = GetStatus();
            // Converte para string
            String status = b_status.ToString();
            // Armazena o nome da disciplina selecionado em uma Drop Down List
            String nomeDoCurso = getNameOfCourse();
            // Montando a string do comando INSERT
            String sql = "insert into disciplina(nome, descritivo, ativo, nomeCurso, emailDaDisciplina)" +
                         "values ('{0}','{1}','{2}','{3}','{4}')";
            // Trocando os scapes pelos valores que serão inseridos no banco
            sql = String.Format(sql, txtNome.Text, txtDescritivo.Text, status, nomeDoCurso, 
                txtEmailDaDisciplina.Text);

            MySqlCommand executeQuery = new MySqlCommand(sql, conn);
            // Executar a query
            executeQuery.ExecuteNonQuery();
            // Fechando a conexão com o banco
            conn.Close();
            // Limpando os campos do formulário
            Limpar();
            // Exibindo uma mensagem de sucesso de gravação
            lblResultado.Text = "Registro gravado com sucesso!";
        }catch (Exception err)
        {
            // Exibindo uma mensagem de erro de gravação
            lblResultado.Text = "Erro de gravação do registro!\n" + err.Message;
        }
        
    }

    // Carregando a lista de disciplina SOMENTE NA CARGA da página
    public void LoadNameOfCourse()
    {
        List<ListItem> NameOfCourse = new List<ListItem>();
        // Adicionando os cursos na Lista
        NameOfCourse.Add(new ListItem("Analise e Desenvolvimento de Sistemas"));
        NameOfCourse.Add(new ListItem("Gestao de Recursos Humanos"));
        NameOfCourse.Add(new ListItem("Eventos"));
        //
        ddlNomeCurso.DataSource = NameOfCourse;
        // Adicionando os cursos disponíveis na Drop Down List
        ddlNomeCurso.DataBind();
    }

    // Retornar o status da disciplina
    private int GetStatus()
    {
        if ( rdoSim.Checked ){
            return 1;
        } else{
            return 0;
        }
    }

    // Retorna o nome do curso selecionado na DropDownList
    public String getNameOfCourse()
    {
        String selectValue = ddlNomeCurso.SelectedItem.Value;
        return selectValue;
    }

    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        try
        {
            // Criando um objeto do tipo MySqlConnection
            MySqlConnection conn = new MySqlConnection(sc);
            // Abrindo conexão com o banco de dados
            conn.Open();
            // Montando a string de busca
            String sql = "select codigo, descritivo, ativo, nomeCurso, emailDaDisciplina from disciplina where nome='"+txtNome.Text+"'";
            //
            MySqlCommand executeQuery = new MySqlCommand(sql, conn);
            // Efetua a leitura de linhas de uma tabela
            MySqlDataReader readerRecord = executeQuery.ExecuteReader();
            // Verifica se um registro foi encontrado
            if (readerRecord.Read())
            {
                txtCodigo.Text = readerRecord["codigo"].ToString();
                txtDescritivo.Text = readerRecord["descritivo"].ToString();
                
                if (readerRecord["ativo"].Equals(1))
                {
                    rdoSim.Checked = true;
                }
                else
                {
                    rdoNao.Checked = true;
                }                
                ddlNomeCurso.SelectedValue = readerRecord["nomeCurso"].ToString();
                txtEmailDaDisciplina.Text = readerRecord["EmailDaDisciplina"].ToString();
                conn.Close();
            }
            else
            {
                lblResultado.Text = "Registro não encontrado !";
            }
            conn.Close();
        }
        catch (Exception err)
        {
            // Exibindo uma mensagem de erro de gravação
            lblResultado.Text = "Erro de gravação do registro!\n" + err.Message;
        }        
    }

    protected void btnAtualizar_Click(object sender, EventArgs e)
    {
        try
        {
            MySqlConnection conn = new MySqlConnection(sc);
            conn.Open();
            // Armazena o status da disciplina
            int i_status = GetStatus();
            // Converte para string
            String status = i_status.ToString();
            String nomeDoCurso = getNameOfCourse();
            String sql = "update disciplina set nome='{0}', descritivo='{1}', ativo='{2}', nomeCurso='{3}', EmailDaDisciplina='{4}' where codigo='{5}'";
            sql = String.Format(sql, txtNome.Text, txtDescritivo.Text, status, nomeDoCurso, txtEmailDaDisciplina.Text, txtCodigo.Text);
            MySqlCommand comando = new MySqlCommand(sql, conn);
            comando.ExecuteNonQuery();
            conn.Close();
            lblResultado.Text = "Registro alterado com sucesso!";
        }
        catch (Exception err)
        {
            // Exibindo uma mensagem de erro de gravação
            lblResultado.Text = "Erro de gravação do registro!\n" + err.Message;
        }        
    }

    // Limpa todos os controles do formulário
    private void Limpar()
    {
        txtCodigo.Text = "";
        txtNome.Text = "";
        txtDescritivo.Text = "";
        txtEmailDaDisciplina.Text = "";
        if (rdoSim.Checked == true)
        {
            rdoSim.Checked = false;
        }
        else
        {
            rdoNao.Checked = false;
        }
    }

    protected void btnExcluir_Click(object sender, EventArgs e)
    {
        try
        {
            MySqlConnection conn = new MySqlConnection(sc);
            conn.Open();
            String sql = "delete from disciplina where codigo=" + txtCodigo.Text;
            MySqlCommand comando = new MySqlCommand(sql, conn);
            comando.ExecuteNonQuery();
            conn.Close();
            Limpar();
            lblResultado.Text = "Registro removido com sucesso!";
        }
        catch (Exception err)
        {
            lblResultado.Text = "Ocorreu um erro !" + err.Message;
        }

    }
    

}// Fim da classe CRUD


            
            
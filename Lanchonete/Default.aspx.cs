using Data;
using Model;
using System;
using Proxy;
using System.Collections.Generic;

namespace Lanchonete
{
    public partial class Default : System.Web.UI.Page
    {
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Pizza pizza = new Pizza
            {
                Descricao = txtDescricao.Text,
                Valor = decimal.Parse(txtValor.Text)
            };

            if (new PizzaDB().Insert(pizza)) { 
                lblMsg.Text = "Inserido com Sucesso!";
                SaveLog("Inserção de Dado");
                LoadTable();
                LoadLog();
            }
            else { 
                lblMsg.Text = "Falha na inserção!";
                SaveLog("Erro Inserção de Dado");
            }
            LimpaCampos();
        }
        protected void btnAtualziar_Click(object sender, EventArgs e)
        {
            Pizza valor;
            string desc = txtDescricao.Text;
            string id = txtId.Text;

            if(id == "") 
            { 
                valor = new PizzaDB().Consultar(desc);
                SaveLog("Consulta por ID");
            }
            else 
            { 
                valor = new PizzaDB().Consultar(id);
                SaveLog("Consulta por Descrição");
            }
            LoadLog();
            txtId.Text = Convert.ToString(valor.Id);
            txtDescricao.Text = valor.Descricao;
            txtValor.Text = Convert.ToString(valor.Valor);
        }
        protected void btnAtt_Click(object sender, EventArgs e)
        {
            Pizza pizza = new Pizza
            {
                Id = int.Parse(txtId.Text),
                Descricao = txtDescricao.Text,
                Valor = decimal.Parse(txtValor.Text)
            };

            if(new PizzaDB().Atualizar(pizza))
            {
                lblMsg.Text = "Atualizado com Sucesso!";
                LoadTable();
                SaveLog("Atualiza campo");
                LoadLog();
            }
            else
            {
                lblMsg.Text = "Erro na Atualização";
                SaveLog("Erro atualização");
            }
            LimpaCampos();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);

            if(!new PizzaDB().Deletar(id))
            {
                lblMsg.Text = "Deletado com Sucesso!";
                SaveLog("Deleção de Dado");
                
            }
            else
            {
                lblMsg.Text = "Erro ao deletar!";
                SaveLog("Erro na Deleção");
            }
            LoadTable();
            LoadLog();

            LimpaCampos();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTable();
            LoadLog();
        }
        protected void btnLog_Click(object sender, EventArgs e)
        {
            LoadLog();
        }

        private void SaveLog(string msg)
        {
            IMonitore proxy = new Proxy.Proxy(new LogDB());
            proxy.SaveLog(msg);
        }

        private List<Log> GetLogs()
        {
            IMonitore proxy = new Proxy.Proxy(new LogDB());
            return proxy.Select();
        }

        private void LoadTable()
        {
            gvPizza.DataSource = new PizzaDB().Select();
            gvPizza.DataBind();
        }

        private void LoadLog()
        {
            gvLog.DataSource = this.GetLogs();
            gvLog.DataBind();
        }

        private void LimpaCampos()
        {
            txtId.Text = "";
            txtDescricao.Text = "";
            txtValor.Text = "";
        }

        
    }
}
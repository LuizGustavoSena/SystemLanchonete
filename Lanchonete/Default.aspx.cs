using Data;
using Model;
using System;
using Proxy;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lanchonete
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTable();
            LoadLog();
        }

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
    }
}
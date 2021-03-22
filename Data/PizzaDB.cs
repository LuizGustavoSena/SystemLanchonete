using Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using Util;

namespace Data
{
    public class PizzaDB : IPizzaDB
    {
        private ConnectionDB _conn;

        public bool Insert(Pizza pizza)
        {
            bool status = false;
            string sql = string.Format(Pizza.INSERT, pizza.Descricao, pizza.Valor);
            string sqlFk = string.Format(Pizza.INSERTFK, pizza.Descricao, pizza.Valor);
            using(_conn = new ConnectionDB())
            {
                _conn.ExecQuery(sql);
                status = _conn.ExecQuery(sqlFk);
            }
            return status;
        }

        public List<Pizza> Select()
        {
            string sql = Pizza.SELECT;

            using(_conn = new ConnectionDB())
            {
                var returnData = _conn.ExecQueryReturn(sql);
                return TransformDataReaderToList(returnData);
            }
        }

        public Pizza Consultar(string desc)
        {
            Pizza pizza = new Pizza();
            string sql;

            if (int.TryParse(desc, out int id))
                sql = string.Format(Pizza.SELECTUNIQID, id);
            else
                sql = string.Format(Pizza.SELECTUNIQ, desc);

            using(_conn = new ConnectionDB())
            {
                var returnData = _conn.ExecQueryReturn(sql);
                if (returnData.Read())
                    pizza = new Pizza
                    {
                        Id = int.Parse(returnData["id"].ToString()),
                        Descricao = returnData["descricao"].ToString(),
                        Valor = decimal.Parse(returnData["valor"].ToString())
                    };
                return pizza;
            }
        }

        public bool Atualizar(Pizza pizza)
        {
            bool status = false;
            string sql = string.Format(Pizza.UPDATE, pizza.Descricao, pizza.Valor, pizza.Id);
            using(_conn = new ConnectionDB())
            {
                status = _conn.ExecQuery(sql);
            }
            return status;
        }

        public bool Deletar(int id)
        {
            bool status = false;
            string sql = string.Format(Pizza.DELETAR, id);
            using(_conn = new ConnectionDB())
            {
                status = _conn.ExecQuery(sql);
            }
            return status;
        }

        private List<Pizza> TransformDataReaderToList(SqlDataReader returnData)
        {
            List<Pizza> list = new List<Pizza>();

            while (returnData.Read())
            {
                Pizza pizza = new Pizza
                {
                    Id = int.Parse(returnData["id"].ToString()),
                    Descricao = returnData["descricao"].ToString(),
                    Valor = decimal.Parse(returnData["valor"].ToString())
                };
                list.Add(pizza);
            }

            return list;
        }
    }
}

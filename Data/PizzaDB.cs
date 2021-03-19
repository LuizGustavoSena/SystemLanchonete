using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

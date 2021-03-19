using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Pizza : Refeicao
    {
        public const String INSERT = "INSERT INTO Refeicao (descricao, valor) VALUES ('{0}', {1})";
        public const String SELECT = "SELECT id, descricao, valor FROM Refeicao r JOIN Pizza p ON r.id = p.idRefeicao";
        public const String INSERTFK = "INSERT INTO Pizza (idRefeicao) SELECT id FROM Refeicao r WHERE r.descricao = '{0}' AND r.valor = {1}";
    }
}

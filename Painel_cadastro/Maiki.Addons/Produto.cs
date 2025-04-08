
using Microsoft.VisualBasic;
using System.Security.AccessControl;

namespace Maiki.Addons
{
    public class Produto
    {
        public static List<Produto> Lista { get; set; } = new List<Produto>();
        public static Produto Add(string nome, double valor)
        {
            var n_produto = new Produto();
            n_produto.id = 1;
            n_produto.Nome = nome;
            n_produto.Valor = valor;


            while (Lista.Find(x => x.id == n_produto.id) != null)
            {
                n_produto.id++;
            }

            Lista.Add(n_produto);
            return n_produto;
        }
        public static bool Edit(Produto produto, bool criar_se_nao_existe)
        {
            var igual = Lista.Find(x => x.id == produto.id);
            if (igual != null)
            {
                igual.Valor = produto.Valor;
                igual.Nome = produto.Nome;
                return true;
            }
            else if (criar_se_nao_existe)
            {
                Add(produto.Nome, produto.Valor);
                return true;
            }

            return false;
        }
        public static bool Delete(Produto produto)
        {
            var nprod = Lista.Find(x => x.id == produto.id);
            if (nprod != null)
            {
                Lista.Remove(nprod);
                return true;
            }

            return false;
        }

        private int id { get; set; }
        public string Nome { get; set; } = "";
        public double Valor { get; set; } = 0;

        public Produto()
        {

        }
    }
}

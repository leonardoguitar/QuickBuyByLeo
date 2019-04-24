using QuickBuy.Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;

namespace QuickBuy.Dominio.Entidades
{
    public class Pedido : Entidade
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string EnderecoCompleto { get; set; }
        public string NumeroEndereco { get; set; }

        public int FormaPagementoId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        /// <summary>
        /// Pedido pode ter pelo menos um Item de pedido ou varios Itens de pedidos
        /// </summary>
        public ICollection<ItemPedido> ItensPedidos { get; set; }

        public override void Validate()
        {
            LimparMensagemValidacao();

            if (!ItemPedido.Any())
                AdicionarCritica("Pedido não pode ficar sem item de pedido");

            if (string.IsNullOrEmpty(CEP))
                AdicionarCritica("CEP deve estar preenchido");

            if (FormaPagementoId == 0)
                AdicionarCritica("Não foi informado a forma de pagamento");
        }
    }
}

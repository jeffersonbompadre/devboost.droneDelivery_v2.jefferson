namespace devboost.Domain.Commands.Request
{
    public class RealizarPedidoRequest
    {
        public ClientePedidoRequest Cliente { get; set; }
        public int Peso { get; set; }
    }
}

using devboost.Domain.Commands.Request;
using devboost.Domain.Handles.Commands.Interfaces;
using devboost.Domain.Model;
using devboost.Domain.Repository;
using System;
using System.Threading.Tasks;

namespace devboost.Domain.Handles.Commands
{
    public class ClienteHandler : IClienteHandler
    {
        readonly IClienteRepository _clienteRepository;

        public ClienteHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task AddCliente(ClienteRequest cliente)
        {
            var cli = new Cliente(cliente.Nome, cliente.EMail, cliente.Telefone, cliente.Latitude, cliente.Longitude);
            if (!cli.IsValid())
                throw new Exception("Dados do cliente inválido, os campos: Nome, EMail, Telefone, Latitude e Longitude são obrigatórios.");
            await _clienteRepository.AddCliente(cli);
        }
    }
}

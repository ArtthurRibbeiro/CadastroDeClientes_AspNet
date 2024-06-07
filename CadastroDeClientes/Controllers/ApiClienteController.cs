
using CadastroDeClientes.Helpers;
using CadastroDeClientes.Models;
using CadastroDeClientes.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeClientes.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ApiClienteController : ControllerBase
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ApiClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        [HttpGet("")]
        public ActionResult<List<ClienteModel> > ListarTodos()
        {
            List<ClienteModel> clientes = _clienteRepositorio.BuscarTodos();
                if (clientes == null)
            {
                return NotFound();
            }
            return Ok(clientes);

        }

        [HttpGet("{id}")]
        public ActionResult<ClienteModel>  BuscarPorId(int id)
        {
            var cliente = _clienteRepositorio.BuscarPorId(id);
            if (cliente == null)
            {
                return NotFound(); 
            }
            return Ok(cliente);

        }

           
            
        [HttpGet("codigo/{codigo}")]
        public ActionResult<ClienteModel> BuscarPorCodigo(String codigo)
        {
            var cliente = _clienteRepositorio.BuscarPorCodigo(codigo);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);

        }
        [HttpGet("cpf-cnpj/{cc}")]
        public ActionResult<ClienteModel> BuscarPorDocumento(String documento)
        {
            var cliente = _clienteRepositorio.BuscarPorDocumento(documento);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);

        }
        [HttpGet("nome-razao-social/{nomeRazaoSocial}")]
        public ActionResult<ClienteModel> BuscarPorNomeRazaoSocial(String nomeRazaoSocial)
        {
            var cliente = _clienteRepositorio.BuscarPorDocumento(nomeRazaoSocial);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);

        }

           
            [HttpPost("")]
            public ActionResult<ClienteModel> Criar(ClienteModel cliente)
            {
                cliente.Inclusao = DataHelper.DataFormatada();
                cliente.Alteracao = DataHelper.DataFormatada();

                if (ModelState.IsValid) {
                    try {
                        _clienteRepositorio.Adicionar(cliente);
                        return CreatedAtAction(nameof(BuscarPorId), new { id = cliente.Id }, cliente);
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(500, $"Erro interno ao processar a requisição: {ex.Message}");
                    }

                }
                return BadRequest(ModelState);

            }


            [HttpPut("{id}")]
            public ActionResult Alterar(int id, ClienteModel cliente)
            {
                if (id != cliente.Id)
                {
                    return BadRequest("ID`s Não correspondem");
                }

                try
                {
                    _clienteRepositorio.Editar(cliente);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Erro interno ao processar a requisição: {ex.Message}");
                }
            }

            public ActionResult Deletar(int id)
            {
                var cliente = _clienteRepositorio.BuscarPorId(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                try
                {
                    _clienteRepositorio.Excluir(id);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Erro interno ao processar a requisição: {ex.Message}");
                }
            }

        }
    }

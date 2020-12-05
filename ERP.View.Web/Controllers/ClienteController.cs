using ERP.Core.Negocio;
using ERP.Entidades.Enums;
using ERP.Entidades.FiltrosDePesquisa;
using ERP.View.Web.ViewModel;
using ERP.View.Web.ViewModel.Cliente;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERP.View.Web.Controllers
{
    public class ClienteController : Controller
    {
        private NCliente nCliente = new NCliente();

        
        public async Task<ActionResult> Index(string nome = "")
        {
            var indexVM = new IndexVM();

            indexVM.Clientes = await nCliente.SelecionarTodos(new FiltroCliente(nome));

            if (Request.IsAjaxRequest())
                return PartialView("_Clientes", indexVM);

            return View(indexVM);
        }

        public async Task<ActionResult> Edit(int id = 0)
        {
            if (id == 0)
                return View(new EditVM
                {
                    Codigo = 0,
                    Nome = "",
                    DataNascimento = DateTime.Now,
                    Sexo = ESexo.Masculino,
                    LimiteCompra = 0
                });

            var cliente = await nCliente.SelecionarPorId(id);

            return View(new EditVM 
            { 
                Codigo = cliente.Codigo,
                Nome = cliente.Nome,
                DataNascimento = cliente.DataNascimento,
                Sexo = cliente.Sexo,
                LimiteCompra = cliente.LimiteCompra
            });
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditVM cliente)
        {
            var result = new Tuple<int, string>(0, "");

            if (cliente.Codigo == 0)
            {
                result = await nCliente.Inserir(new Entidades.Cliente
                (
                    cliente.Nome,
                    cliente.DataNascimento,
                    cliente.Sexo,
                    cliente.LimiteCompra
                ));

                if (result.Item1 > 0)
                {
                    cliente.Codigo = result.Item1;
                    ViewBag.Mensagem = "Cadastro inserido com sucesso!";

                    return View(cliente);
                }
            }
            else
            {
                result = await nCliente.Alterar(new Entidades.Cliente
                (
                    cliente.Codigo,
                    cliente.Nome,
                    cliente.DataNascimento,
                    cliente.Sexo,
                    cliente.LimiteCompra
                ));

                if (result.Item1 == 0)
                {
                    ViewBag.Mensagem = "Cadastro alterado com sucesso!";
                    return View(cliente);
                }

            }


            return View();
        }

        public async Task<ActionResult> Delete(int id)
        {
            var result = new Tuple<bool, string>(true, "");

            result = await nCliente.Excluir(id);

            if (!result.Item1)
                ViewBag.Mensagem = result.Item2;
            else
                ViewBag.Mensagem = "Cadastro excluído com sucesso!";

            return RedirectToAction("Index");
        }
    }
}
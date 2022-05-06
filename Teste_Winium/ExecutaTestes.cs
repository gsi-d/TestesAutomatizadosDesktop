using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace Teste_Winium
{
    [TestClass]
    public class ExecutaTestes        
    {
        VirtualLoomSteps stepsVL = new VirtualLoomSteps();
        [TestMethod]
        public void TestVirtualLoom()
        {
            //LOGIN
            stepsVL.GivenAbreVirtualLoom();
            Thread.Sleep(3000);
            stepsVL.LoginAutomatico("Aguarde. Inicializando conexão ...");
            Thread.Sleep(10000);
            //stepsVL.ClickToLoginDois("btnEntrar", "txtUsuario", "txtSenha");

            //CADASTROS

            //Tipo Processo
            /*stepsVL.SelecionarTelaFor("VirtualLoom.Controles.Visual.Helpers.Recurso");
            stepsVL.Crud();*/

            //OP
            stepsVL.SelecionarTela("VirtualLoom.Controles.Visual.Helpers.Recurso", "OPS");
            Thread.Sleep(2000);
            string Op = stepsVL.CadastroOP("14/05/2022", "SEQUENCIAL", "15009", "D3 CANADA 02", "400");
            stepsVL.EditarOP(Op);
            string Op2 = stepsVL.CopiarOp(Op);
            stepsVL.ExcluirOp(Op);
            stepsVL.ExcluirOp(Op2);
            stepsVL.fechaDesktop(2);

            //CONSULTAS

            //DESEMPENHO ARTIGO ANALÍTICO
            /*stepsVL.SelecionarTela("VirtualLoom.Controles.Visual.Helpers.Recurso", "DESEMPENHO ARTIGO ANALÍTICO");
            Thread.Sleep(1000);
            stepsVL.ConsultaGeral("01/03/2022", "AUTOMATEX 01");*/
            
            //GADGETS
        }

    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Input;
using TechTalk.SpecFlow;
using Teste_Winium.Entidades;

namespace Teste_Winium
{
    public class VirtualLoomSteps
    {
        public List<RecursosVL> listRecursos = new List<RecursosVL>();
        public WiniumDriver driver { get; set; }
        [Given(@"Abrir o App VirtualLoom")]
        public void GivenAbreVirtualLoom()
        {
            //Opcional
            //sobeServico();
            //Essencial
            //DesktopOptions options = new DesktopOptions { ApplicationPath = @"C:\Users\vlnote51\Documents\VirtualLoomWCFProject2018\VirtualLoom.Desktop\VirtualLoom.Desktop\bin\Debug\VirtualLoomDesktop.exe" };
            DesktopOptions options = new DesktopOptions { ApplicationPath = @"C:\VirtualLoom\SVN\Sup\Testes\Tst_Dev\Atualizacao2018\Padrao\DesktopBin\VirtualLoomDesktop.exe" };
            var service = WiniumDriverService.CreateDesktopService(@"C:\Winium\");
            service.Start();
            driver = new WiniumDriver(service, options, TimeSpan.FromSeconds(60));
            povoaLista("APPEL");
        }

        [When(@"Informar um número (.*)")]
        public void LoginAutomatico(string prop)
        {
            var searchBtn = driver.FindElementByName(prop);
            Actions actionProvider = new Actions(driver);
            actionProvider.ContextClick(searchBtn).Build().Perform();
            
        }

        [When(@"Informar um número (.*)")]
        public void SelecionarTelaFor(string prop)
        {
            var listRecursos = driver.FindElementsByName(prop);
            for(int i = 0; i < listRecursos.Count; i++)
            {
                if(i == 54)
                {
                    var searchBtn = listRecursos[i];
                    Actions actionProvider = new Actions(driver);
                    actionProvider.DoubleClick(searchBtn).Build().Perform();
                    break;
                }
            }
        }

        [When(@"Informar um número (.*)")]
        public void ClickToLoginDois( string botao, string txtUser, string txtSenha)
        {
            var user = driver.FindElementById(txtUser);
            user.SendKeys("dev");
            var senha = driver.FindElementById(txtSenha);
            senha.SendKeys("dev.3fodux69.dev");
            driver.FindElementById(botao).Click();
        }


        [When(@"Realizar CRUD \*")]
        public void Crud()
        {
            Cadastro("TESTE AUTOMATIZADO 05", "OLA MUNDO 05");
            Editar("TESTE AUTOMATIZADO 05", "TESTE AUTOMATIZADO 05", "TROCA DESCRICAO");
            Copiar("TESTE AUTOMATIZADO 05", "TESTE AUTOMATIZADO 06", "TROCA DESCRICAO");
            Excluir("TESTE AUTOMATIZADO 05");
            Excluir("TESTE AUTOMATIZADO 06");

        }

        public void Cadastro(string referencia, string descricao)
        {

            driver.FindElementById("btnNovo").Click();
            var txtRef = driver.FindElementById("txtReferencia");
            txtRef.Click();
            txtRef.SendKeys(referencia);

            var txtDesc = driver.FindElementById("txtDescricao");
            txtDesc.Click();
            txtDesc.SendKeys(descricao);

            /*var listRecursos = driver.FindElementsById("btnSalvar");
            for (int i = 0; i < listRecursos.Count; i++)
            {
                if (i == 1)
                {
                    listRecursos[i].Click();
                    
                }

            }*/
            driver.FindElementById("btnSalvar").Click();
        }

        public void Editar(string registro, string referencia, string descricao)
        {
            var txtRegistro = driver.FindElementByName(registro);
            txtRegistro.Click();
            driver.FindElementById("btnEditar").Click();

            /*var txtRef = driver.FindElementById("txtReferencia");
            txtRef.Click();
            txtRef.SendKeys(referencia);*/

            var txtDesc = driver.FindElementById("txtDescricao");
            txtDesc.Click();
            txtDesc.SendKeys(descricao);

            driver.FindElementById("btnSalvar").Click();
        }

        public void Copiar(string registro, string referencia, string novaRef)
        {
            var txtRegistro = driver.FindElementByName(registro);
            txtRegistro.Click();
            driver.FindElementById("btnCopiar").Click();

            var txtRef = driver.FindElementById("txtReferencia");
            txtRef.Click();
            txtRef.SendKeys(referencia);

            driver.FindElementById("btnSalvar").Click();
        }
        public void Excluir(string registro)
        {
            var txtRegistro = driver.FindElementByName(registro);
            txtRegistro.Click();
            driver.FindElementById("btnExcluir").Click();

            driver.FindElementById("btnSim").Click();
        }

        public string CadastroOP(string data, string producao, string fichaSearch, string ficha, string qtdFicha)
        {
            //driver.FindElementById("btnOk").Click();
            var listBtnOk = driver.FindElementsById("btnOk");
            for (int i = 0; i < listBtnOk.Count; i++)
            {
                if (i == 1)
                {
                    listBtnOk[i].Click();
                } 
            }

            driver.FindElementById("btnNovo").Click();
            driver.FindElementById("btnGeraOp").Click();
            string nrOP = driver.FindElementById("txtId").Text;
            var txtData = driver.FindElementsById("PART_TextBox");
            for (int i = 0; i < txtData.Count; i++)
            {
                if (i == 2)
                {
                    txtData[i].Click();
                    txtData[i].SendKeys(data);
                }
            }

            driver.FindElementById("cboProducao").Click();
            driver.FindElementByName(producao).Click();
            driver.FindElementById("btnAddFichaTecnica").Click();
            driver.FindElementById("btnZoomFichaTecnica").Click();
            
            var fichaTRef = driver.FindElementById("txtReferencia");
            fichaTRef.Click();
            fichaTRef.SendKeys(fichaSearch);

            var listBtnAtualizar = driver.FindElementsById("btnAtualizar");
            for (int i = 0; i < listBtnAtualizar.Count; i++)
            {
                if (i == 1)
                {
                    listBtnAtualizar[i].Click();
                    break;
                }
            }
            Thread.Sleep(1000);

            var fichaEscolhida = driver.FindElementByName(ficha);

            Actions actionProvider = new Actions(driver);
            actionProvider.DoubleClick(fichaEscolhida).Build().Perform();

            var txtQtdFicha = driver.FindElementById("txtQuantidadeFicha");
            txtQtdFicha.Click();
            txtQtdFicha.SendKeys(qtdFicha);

            driver.FindElementById("btnPopOk").Click();

            driver.FindElementById("btnSalvar").Click();

            return nrOP;
        }

        public void EditarOP(string op)
        {
            EditDadosGerais(op, "24/05/2022", "805");
        }

        public void EditDadosGerais(string Op, string data, string newQtdSlot)
        {
            //SELECIONA O ITEM
            var txtRegistro = driver.FindElementByName(Op);
            txtRegistro.Click();
            driver.FindElementById("btnEditar").Click();

            //ALTERA A DATA
            var txtData = driver.FindElementsById("PART_TextBox");
            for (int i = 0; i < txtData.Count; i++)
            {
                if (i == 2)
                {
                    txtData[i].Click();
                    txtData[i].SendKeys(data);
                }
            }

            //ALTERA A QUANTIDADE/SLOT
            var txtQtdSlot = driver.FindElementByName("400");
            Actions actionProvider = new Actions(driver);
            actionProvider.DoubleClick(txtQtdSlot).Build().Perform();
            txtQtdSlot.SendKeys(newQtdSlot);

            //SALVA EDIÇÃO
            driver.FindElementById("btnSalvar").Click();
        }

        public void ExcluirOp(string Op)
        {
            var txtRegistro = driver.FindElementByName(Op);
            txtRegistro.Click();
            driver.FindElementById("btnExcluir").Click();

            driver.FindElementById("btnSim").Click();
        }

        public string CopiarOp(string op)
        {
            driver.FindElementByName(op).Click();
            driver.FindElementById("btnCopiar").Click();
            driver.FindElementById("btnGeraOp").Click();
            string nrOP = driver.FindElementById("txtId").Text;
            driver.FindElementById("btnSalvar").Click();
            return nrOP;
        }

        public void povoaLista(string Base)
        {
            if(Base == "APPEL")
            {
                //ANALISES
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GERAL - DESEMPENHO MENSAL" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GRUPO - DESEMPENHO POR GRUPO DE MÁQUINA" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "LOCALIZAÇÃO - DESEMPENHO MENSAL" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "MÁQUINA - DESEMPENHO INDIVIDUAL POR MÁQUINA" });
                //CADASTROS
                listRecursos.Add(new RecursosVL() { NomeRecurso = "ALARMES" });
                //listRecursos.Add(new RecursosVL() { NomeRecurso = "ALOCAÇÃO SD" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "CALENDÁRIO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "CATEGORIA EVENTOS" });
                //listRecursos.Add(new RecursosVL() { NomeRecurso = "CLIENTE COLETOR UC" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "CLIENTES - VL" });
                //listRecursos.Add(new RecursosVL() { NomeRecurso = "COLETOR UC" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "CONFIGURAÇÃO DE MÁQUINA" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "CONFIGURAÇÃO DEMANDA" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "CONFIGURAÇÕES DA UC" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "CONFIGURAÇÕES DE PARÂMETROS DA UC" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "EDITOR DE CONSULTAS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "ETAPA PRODUÇÃO" });
                //listRecursos.Add(new RecursosVL() { NomeRecurso = "ETAPA SD" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "EVENTOS" });
                //listRecursos.Add(new RecursosVL() { NomeRecurso = "FABRICANTE" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "FERIADOS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "FICHA TÉC. SETUP" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "FICHA TÉCNICA" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "FÓRMULA" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GANTTS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GLOBALIZAÇÃO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GRUPO ALOCAÇÃO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GRUPO DE EVENTOS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GRUPO DE FICHAS TÉCNICAS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GRUPO DE TRABALHO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GRUPO DE TRABALHO/USUÁRIOS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GRUPO DE USUÁRIOS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GRUPO MÁQUINA" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GRUPO PARÂMETRO" });
                //listRecursos.Add(new RecursosVL() { NomeRecurso = "LICENÇA DISPOSITIVO" });
                //listRecursos.Add(new RecursosVL() { NomeRecurso = "LINHA DE PRODUÇÃO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "LISTA DE CHECAGEM" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "LOCAIS DE ARMAZENAMENTO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "LOCALIZAÇÃO MÁQUINA" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "MÁQUINA BASE" });
                //listRecursos.Add(new RecursosVL() { NomeRecurso = "MAQUINA/GRUPO/TRABALHO/TURNO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "MÁQUINAS" });
                //listRecursos.Add(new RecursosVL() { NomeRecurso = "NOTIFICAÇÕES" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "OPS" });
                //listRecursos.Add(new RecursosVL() { NomeRecurso = "ORDENS DE INTEGRAÇÃO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PACOTES" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PADRÃO TEC. BASE SETUP" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PADRÃO TÉC. SETUP" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PADRÕES TÉCNICOS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PARÂMETROS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PARÂMETROS SISTEMA" });
                //listRecursos.Add(new RecursosVL() { NomeRecurso = "PERFIL DE CONEXÃO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PLANO DE ALARME" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PROCESSOS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "RECEITAS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "RECURSO ALOCAÇÃO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "RECURSOS" });
                //listRecursos.Add(new RecursosVL() { NomeRecurso = "REGISTRO DE CHECAGEM" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "REGRA VALIDAÇÃO SETUP" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "ROTEIRO PRODUÇÃO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "SENSORES" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "SETUPS FICHAS TÉCNICAS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "SETUPS PADRÕES TÉCNICAS" });
                //listRecursos.Add(new RecursosVL() { NomeRecurso = "SOLICITAÇÃO DE DESENVOLVIMENTO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "TIPO PROCESSO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "TIPO SETUP" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "TIPOS DE FERIADOS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "TURNO BASE" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "TURNOS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "UNIDADE" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "UNIDADE DE VELOCIDADE" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "USUÁRIOS" });
                //CONSULTAS
                listRecursos.Add(new RecursosVL() { NomeRecurso = "AJUSTES UCS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "ANÁLISE DA PROGRAMAÇÃO DAS ETAPAS DE PRODUÇÃO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "ANÁLISE OEE" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "CONTROLE DE ACESSO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "CORTES DE OPS EM PRODUÇÃO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "DESEMPENHO ARTIGO ANALÍTICO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "DESEMPENHO GRUPO ARTIGO ANALÍTICO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "DESEMPENHO MÁQUINA ANALÍTICO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "DESEMPENHO ORDENS DE PRODUÇÃO ANALÍTICO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "DESEMPENHO POR PEÇA" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "DESEMPENHO POR TURNO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "DESEMPENHO PRODUÇÃO/TURNO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "DESEMPENHO SINTÉTICO TURNO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "DESEMEPNHO USUÁRIO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "EVENTOS SINTÉTICO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "HISTÓRICO UCS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "HORAS TRABALHADAS MÁQUINA" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "ÍNDICE DE RUPTURA" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "INVENTÁRIO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "LEAD TIME" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "LOG DOS ALARMES" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "LOG DOS SENSORES" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "MAPA DE EVENTO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "MAPA DE PRODUÇÃO T EXTO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "MONITORAMENTO UCS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PERDA POR EVENTO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PREVISÃO DE CORTE" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PRODUÇÃO %" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PRODUÇÃO ARTIGO EVENTOS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PRODUÇÃO POR PEÇA" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PROGRAMAÇÃO ETAPA PRODUÇÃO OP" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PROGRAMAÇÃO ETAPA PRODUÇÃO OP DETALHADO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PROJEÇÃO DE NECESSIDADES" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "VERIFICAR IPS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "WND TESTE" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "ACOMPANHAMENTO MÁQUINA" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "ACOMPANHAMENTO MÁQUINA UC" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "ACOMPANHAMENTO TINGIMENTO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "EVENTOS E CORES" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GANTT 1" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GANTT 2" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "CHAMADO VIRTUAL HELPER" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "CONFIGURAÇÕES DE COMANDOS UC" });
            }

            if (Base == "CIANORTE")
            {
                //ANALISES
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GERAL - DESEMPENHO MENSAL" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GRUPO - DESEMPENHO POR GRUPO DE MÁQUINA" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "LOCALIZAÇÃO - DESEMPENHO MENSAL" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "MÁQUINA - DESEMPENHO INDIVIDUAL POR MÁQUINA" });
                //CADASTROS
                listRecursos.Add(new RecursosVL() { NomeRecurso = "ALARMES" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "ALOCAÇÃO SD" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "CALENDÁRIO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "CATEGORIA EVENTOS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "CLIENTE COLETOR UC" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "CLIENTES - VL" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "COLETOR UC" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "CONFIGURAÇÃO DE MÁQUINA" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "CONFIGURAÇÃO DEMANDA" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "CONFIGURAÇÕES DA UC" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "CONFIGURAÇÕES DE PARÂMETROS DA UC" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "EDITOR DE CONSULTAS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "ETAPA PRODUÇÃO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "ETAPA SD" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "EVENTOS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "FABRICANTE" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "FERIADOS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "FICHA TÉC. SETUP" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "FICHA TÉCNICA" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "FÓRMULA" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GANTTS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GLOBALIZAÇÃO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GRUPO ALOCAÇÃO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GRUPO DE EVENTOS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GRUPO DE FICHAS TÉCNICAS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GRUPO DE TRABALHO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GRUPO DE TRABALHO/USUÁRIOS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GRUPO DE USUÁRIOS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GRUPO MÁQUINA" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GRUPO PARÂMETRO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "LICENÇA DISPOSITIVO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "LINHA DE PRODUÇÃO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "LISTA DE CHECAGEM" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "LOCAIS DE ARMAZENAMENTO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "LOCALIZAÇÃO MÁQUINA" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "MÁQUINA BASE" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "MAQUINA/GRUPO/TRABALHO/TURNO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "MÁQUINAS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "NOTIFICAÇÕES" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "OPS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "ORDENS DE INTEGRAÇÃO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PACOTES" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PADRÃO TEC. BASE SETUP" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PADRÃO TÉC. SETUP" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PADRÕES TÉCNICOS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PARÂMETROS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PARÂMETROS SISTEMA" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PERFIL DE CONEXÃO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PLANO DE ALARME" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PROCESSOS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "RECEITAS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "RECURSO ALOCAÇÃO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "RECURSOS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "REGISTRO DE CHECAGEM" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "REGRA VALIDAÇÃO SETUP" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "ROTEIRO PRODUÇÃO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "SENSORES" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "SETUPS FICHAS TÉCNICAS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "SETUPS PADRÕES TÉCNICAS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "SOLICITAÇÃO DE DESENVOLVIMENTO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "TIPO PROCESSO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "TIPO SETUP" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "TIPOS DE FERIADOS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "TURNO BASE" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "TURNOS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "UNIDADE" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "UNIDADE DE VELOCIDADE" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "USUÁRIOS" });
                //CONSULTAS
                listRecursos.Add(new RecursosVL() { NomeRecurso = "AJUSTES UCS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "ANÁLISE DA PROGRAMAÇÃO DAS ETAPAS DE PRODUÇÃO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "ANÁLISE OEE" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "CONTROLE DE ACESSO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "CORTES DE OPS EM PRODUÇÃO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "DESEMPENHO ARTIGO ANALÍTICO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "DESEMPENHO GRUPO ARTIGO ANALÍTICO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "DESEMPENHO MÁQUINA ANALÍTICO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "DESEMPENHO ORDENS DE PRODUÇÃO ANALÍTICO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "DESEMPENHO POR PEÇA" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "DESEMPENHO POR TURNO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "DESEMPENHO PRODUÇÃO/TURNO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "DESEMPENHO SINTÉTICO TURNO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "DESEMEPNHO USUÁRIO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "EVENTOS SINTÉTICO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "HISTÓRICO UCS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "HORAS TRABALHADAS MÁQUINA" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "ÍNDICE DE RUPTURA" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "INVENTÁRIO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "LEAD TIME" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "LOG DOS ALARMES" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "LOG DOS SENSORES" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "MAPA DE EVENTO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "MAPA DE PRODUÇÃO T EXTO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "MONITORAMENTO UCS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PERDA POR EVENTO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PREVISÃO DE CORTE" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PRODUÇÃO %" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PRODUÇÃO ARTIGO EVENTOS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PRODUÇÃO POR PEÇA" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PROGRAMAÇÃO ETAPA PRODUÇÃO OP" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PROGRAMAÇÃO ETAPA PRODUÇÃO OP DETALHADO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "PROJEÇÃO DE NECESSIDADES" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "VERIFICAR IPS" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "WND TESTE" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "ACOMPANHAMENTO MÁQUINA" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "ACOMPANHAMENTO MÁQUINA UC" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "ACOMPANHAMENTO TINGIMENTO" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "EVENTOS E CORES" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GANTT 1" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "GANTT 2" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "CHAMADO VIRTUAL HELPER" });
                listRecursos.Add(new RecursosVL() { NomeRecurso = "CONFIGURAÇÕES DE COMANDOS UC" });
            }

        }

        public void SelecionarTela(string prop, string tela)
        {
            var listTelas = driver.FindElements(By.Name(prop));
            for (int i = 0; i < listRecursos.Count; i++)
            {
                if (listRecursos[i].NomeRecurso == tela)
                {
                    var telaEscolhida = listTelas[i];
                    Actions actionProvider = new Actions(driver);
                    actionProvider.DoubleClick(telaEscolhida).Build().Perform();
                    break;
                }
            }
        }

        public void ConsultaGeral(string data, string maquina1)
        {
            var txtData = driver.FindElementById("PART_TextBox");
            txtData.SendKeys(data);

            driver.FindElementById("btnResetLocalizacao").Click();
            driver.FindElementById("btnResetGrupoMaquina").Click();
            driver.FindElementById("btnResetMaquina").Click();
            driver.FindElementById("btnResetEvento").Click();
            driver.FindElementById("btnResetTurno").Click();

            driver.FindElementById("ToggleButton").Click();

            //driver.FindElementById("chkSomenteEventosAutomaticos").Click();
            Thread.Sleep(1000);
            /*var listReset = driver.FindElementsByName("botão ''");
            for(int i = 0; i < listReset.Count; i++)
            {
                if (i == 2)
                    listReset[i].Click();
            }
            var cboMaquina = driver.FindElementById("cboMaquina");
            int X = cboMaquina.Location.X + 10;
            int Y = cboMaquina.Location.Y;
            Actions actionProvider = new Actions(driver);
            var acao = actionProvider.MoveByOffset(X, Y).Click();
            Point pCboMaquina = cboMaquina.Location;
            pCboMaquina = new Point() { X = 1031, Y = pCboMaquina.Y };

            driver.FindElementById("cboMaquina");
            driver.FindElementById(maquina1).Click();*/
            driver.FindElementById("btnOk").Click();
        }

        public void GadgetGeral()
        {

        }

        public void SelecionarGadget()
        {

        }

        public void sobeServico() { 
         
            DesktopOptions options = new DesktopOptions { ApplicationPath = @"C:\Users\vlnote51\AppData\Roaming\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar\File Explorer.lnk" };
            var service = WiniumDriverService.CreateDesktopService(@"C:\Winium\");
            service.Start();
            driver = new WiniumDriver(service, options, TimeSpan.FromSeconds(60));
            Actions actionProvider = new Actions(driver);

            Thread.Sleep(1000);

            var sup = driver.FindElementByName("Sup");   
            actionProvider.DoubleClick(sup).Build().Perform();
            var testes = driver.FindElementByName("Testes");
            actionProvider.DoubleClick(testes).Build().Perform();
            var tst_dev = driver.FindElementByName("Tst_Dev");
            actionProvider.DoubleClick(tst_dev).Build().Perform();
            var atualizacao2018 = driver.FindElementByName("Atualizacao2018");
            actionProvider.DoubleClick(atualizacao2018).Build().Perform();
            var padrao = driver.FindElementByName("Padrao");
            actionProvider.DoubleClick(padrao).Build().Perform();
            var windowsServiceHost = driver.FindElementByName("WindowsServiceHost");
            actionProvider.DoubleClick(windowsServiceHost).Build().Perform();

            driver.FindElementByName("Menu do aplicativo").Click();
            driver.FindElementByName("S").Click();
            driver.FindElementByName("Abrir o Windows PowerShell como administrador").Click();

            /*var powerShell = driver.FindElementByName("exec_PowerShell.bat");
            actionProvider.DoubleClick(powerShell).Build().Perform();*/
        }

        public void fechaDesktop(int desktop)
        {
            var btnFechar = driver.FindElementsByName("X");
            for (int i = 0; i < btnFechar.Count; i++)
            {
                if(i == desktop)
                {
                    btnFechar[i].Click();
                }
            }
        }
    }
}

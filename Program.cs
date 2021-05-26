using System;
using EfetuarPagamento.Classes;
using EfetuarPagamento.Enuns;

namespace EfetuarPagamento
{
    class Program
    {        /*
            ESCREVER UM PROGRAMA <ok>
            QUE RECEBE OS PRODUTOS A SEREM COMPRADOS<ok>
            E FORMA DE PAGAMENTO ESCOLHIDA;
            DE ACORDO COM A FORMA DE PAGAMENTO;
            EFETUAR A COMPRA UTILIZANDO O CORRETO MEIO DE PAGAMENTO.    


        */
        static void Main(string[] produtos)
        {
            //QUE RECEBE OS PRODUTOS A SEREM COMPRADOS<ok>
            if(produtos.Length == 0)
            {
                 Console.WriteLine("Nenhum produto foi listado para compra");
                 return;
            }

            Console.WriteLine("Favor informar a a forma de pagamento (Boleto,Pix,CartaoCredito,Transferencia)");
            var formaPagamentoDesejada = Console.ReadLine();

            if(string.IsNullOrEmpty(formaPagamentoDesejada) || string.IsNullOrWhiteSpace(formaPagamentoDesejada)
                ||(TipoPagamentoEnum.Boleto.ToString() != formaPagamentoDesejada
                    && TipoPagamentoEnum.Pix.ToString() != formaPagamentoDesejada
                    && TipoPagamentoEnum.CartaoCredito.ToString() != formaPagamentoDesejada
                    && TipoPagamentoEnum.Transferencia.ToString() != formaPagamentoDesejada))
            {
                 Console.WriteLine($"A forma de pagamento: {formaPagamentoDesejada} não é válida!" );
                 return;
            }

            FormaDePagamento formaDePagamento;
            if(TipoPagamentoEnum.Boleto.ToString() == formaPagamentoDesejada)
            {
                formaDePagamento = new FormaDePagamentoBoleto();
            }else if(TipoPagamentoEnum.Pix.ToString() ==formaPagamentoDesejada)
            {
                formaDePagamento = new FormaDePagamentoPix();
            }else if(TipoPagamentoEnum.CartaoCredito.ToString() == formaPagamentoDesejada)
            {
                formaDePagamento = new FormaDePagamentoCartaoCredito();
            }else if(TipoPagamentoEnum.Transferencia.ToString() ==formaPagamentoDesejada)
            {
                formaDePagamento = new FormaDePagamentoTranferencia();
            }
            else
            {
                Console.WriteLine($"A forma de pagamento: {formaPagamentoDesejada} não é válida!" );
                 return;
            }

            if(formaDePagamento != null)
            {
                formaDePagamento.EfetuarPagamento();
            }

           
        }
    }
}


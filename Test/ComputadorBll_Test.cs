using System;
using Xunit;
using Bll.Implementation;
using Bll.Interface;
using NSubstitute;
using Dal.DAO;
using Dal.Model;

namespace Test
{
    public class ComputadorBll_Test
    {
        private ComputadorDAO mockComputadorDAO;
        private Computador computadorPraso;
        private Computador computadorAVista;

        public ComputadorBll_Test()
        {
            computadorPraso = new Computador()
            {
                Id = 3,
                Nome = "Test",
                descricao = "Produto mock teste",
                preco = 250
            };

            computadorAVista = new Computador()
            {
                Id = 2,
                Nome = "Test",
                descricao = "Produto mock teste",
                preco = 50
            };

            mockComputadorDAO = Substitute.For<ComputadorDAO>();
            mockComputadorDAO.GetFind(3).Returns(computadorPraso);

            mockComputadorDAO = Substitute.For<ComputadorDAO>();
            mockComputadorDAO.GetFind(2).Returns(computadorAVista);
        }

        [Fact]
        public void Deve_retornar_true_quando_o_valor_do_pagamento_por_parcela_for_2_por_cento_maior_para_cada_parcela()
        {
            int id = 3;
            int parcelas = 2;
            double valorEsperado = 130.05;
            ComputadorBll pcBll = new ComputadorBll(mockComputadorDAO);

            var result = pcBll.GetCompPrecoParcelado(id, parcelas);
            
            Assert.Equal(valorEsperado, result.preco);
        }

        [Fact]
        public void Deve_retornar_true_quando_o_valor_do_pagamento_a_vista_for_10_por_cento_mais_barato_que_o_preco_original()
        {
        //Given
            int id = 2;
            double valorEsperado = 45;
            ComputadorBll pcBll = new ComputadorBll(mockComputadorDAO);
        //When
            var result = pcBll.GetCompPrecoAVista(id);
        //Then
            Assert.Equal(valorEsperado, result.preco);
        }
    }
}
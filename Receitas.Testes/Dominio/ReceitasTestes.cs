using FluentAssertions;
using Receitas.Dominio.Entidades;

namespace Receitas.Testes
{
    public class ReceitasTestes
    {
        [Fact]
        public void Nao_deve_criar_receita_com_nome_vazio()
        {
            Action action = () => new Receita("");

            action.Should().Throw<ArgumentException>()
                .WithMessage("O nome da receita não pode ser vazio.*");
        }
    }
}
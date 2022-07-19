using System;
using Xunit;
using Aula.AWS.Lib.Models;


namespace Aula.AWS.Test;

public class UsuarioTest
{
    [Fact]
    public void TestandoSetId()
    {
        var valorEsperado = 1;
        var usuario = CriarUsuario();

        usuario.SetId(valorEsperado);

        Assert.Equal(valorEsperado, usuario.Id);
    }
    [Fact]
    public void TestandoSetNome()
    {
        var valorEsperado = "Paulo";
        var usuario = CriarUsuario();

        usuario.SetNome(valorEsperado);

        Assert.Equal(valorEsperado, usuario.Nome);
    }
    [Fact]
    public void TestandoSetCpf()
    {
        var valorEsperado = "08211133309";
        var usuario = CriarUsuario();

        usuario.SetCpf(valorEsperado);

        Assert.Equal(valorEsperado, usuario.Cpf);
    }
    [Fact]
    public void TestSetDataNascimento()
    {
        var valorEsperado = DateTime.Parse("01/01/1956");
        var usuario = CriarUsuario();

        usuario.SetDataNascimento(valorEsperado);

        Assert.Equal(valorEsperado, usuario.DataNascimento);
    }
    [Fact]
    public void TestSetEmail()
    {
        var valorEsperado = "thiguinho@email.com";
        var usuario = CriarUsuario();

        usuario.SetEmail(valorEsperado);

        Assert.Equal(valorEsperado, usuario.Email);
    }
    [Fact]
    public void TestSetSenha()
    {
        var valorEsperado = "novasenha";
        var usuario = CriarUsuario();

        usuario.SetSenha(valorEsperado);

        Assert.Equal(valorEsperado, usuario.Senha);
    }
    public Usuario CriarUsuario()
    {
        return new Usuario(0, "Thiaguinho", "08211133309", DateTime.Parse("01/01/1956"), "thiguinho@email.com", "thiking123");
    }
}

//pro
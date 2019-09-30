using Features.Clientes;
using System;
using Xunit;

namespace Features.Tests
{
    [CollectionDefinition(nameof(ClienteCollection))]
    public class ClienteCollection : ICollectionFixture<ClienteTestsFixture>
    {
    }

    public class ClienteTestsFixture : IDisposable
    { 
        public Cliente GerarClienteValido()
        {
            return new Cliente(
                Guid.NewGuid(),
                "Carlos",
                "Aurélio",
                DateTime.Now.AddYears(-25),
                "carlosspok@gmail.com",
                true,
                DateTime.Now);
        }

        public Cliente GerarClienteInvalido()
        {
            return new Cliente(
                Guid.NewGuid(),
                "",
                "",
                DateTime.Now,
                "carlosspok1gmail.com",
                true,
                DateTime.Now);
        }

        public void Dispose()
        {
        }
    }
}

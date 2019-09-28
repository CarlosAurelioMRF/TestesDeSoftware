using System;
using System.Collections.Generic;

namespace Demo
{
    public class Pessoa
    {
        public string Nome { get; protected set; }
        public string Apelido { get; set; }
    }

    public class Funcionario : Pessoa
    {
        public double Salario { get; private set; }
        public EnumNivelProfissional NivelProfissional { get; private set; }
        public IList<string> Habilidades { get; private set; }

        public Funcionario(string nome, double salario)
        {
            Nome = string.IsNullOrEmpty(nome) ? "Fulano" : nome;

            DefinirSalario(salario);
            DefinirHabilidades();
        }

        private void DefinirSalario(double salario)
        {
            if (salario < 500) throw new Exception("Salario inferior ao permitido.");

            Salario = salario;

            if (salario < 2000) NivelProfissional = EnumNivelProfissional.Junior;
            else if (salario >= 2000 && salario < 8000) NivelProfissional = EnumNivelProfissional.Pleno;
            else if (salario >= 8000) NivelProfissional = EnumNivelProfissional.Senior;
        }

        private void DefinirHabilidades()
        {
            var habilidadesBasicas = new List<string>()
            {
                "Logica de Programação",
                "OOP"
            };

            Habilidades = habilidadesBasicas;

            switch (NivelProfissional)
            {
                case EnumNivelProfissional.Pleno:
                    Habilidades.Add("Testes");
                    break;
                case EnumNivelProfissional.Senior:
                    Habilidades.Add("Testes");
                    Habilidades.Add("Microservices");
                    break;
            }
        }

        public enum EnumNivelProfissional
        {
            Junior,
            Pleno,
            Senior
        }

        public class FuncionarioFactory
        {
            public static Funcionario Criar(string nome, double salario) => new Funcionario(nome, salario);
        }
    }
}

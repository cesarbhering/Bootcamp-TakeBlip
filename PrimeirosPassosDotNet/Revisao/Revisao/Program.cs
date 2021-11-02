using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            while (OpcaoUsuario.ToUpper() != "X")
            {
                switch (OpcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();
                        Console.WriteLine("Informe a nota do aluno: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor informado não é um número válido");
                        }
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;
                    case "2":
                        foreach(var a in alunos) {
                            if (a.Nome != null)
                            {
                                Console.WriteLine($"Aluno: {a.Nome}, Nota: {a.Nota}");
                            }
                        }
                        break;
                    case "3":
                    decimal notaTotal = 0;
                    var numAlunos = 0;
                    foreach(var a in alunos) {
                        if (a.Nome != null)
                        {
                            notaTotal += a.Nota;
                            numAlunos++;
                        }
                    }
                    Console.WriteLine($"Média geral: {notaTotal / numAlunos}");
                    Conceito conceitoGeral;
                    if (notaTotal / numAlunos < 3) {
                        conceitoGeral = Conceito.E;
                    }
                    else if (notaTotal / numAlunos < 4) {
                        conceitoGeral = Conceito.D;
                    }
                    else if (notaTotal / numAlunos < 6) {
                        conceitoGeral = Conceito.C;
                    }
                    else if (notaTotal / numAlunos < 8) {
                        conceitoGeral = Conceito.B;
                    }
                    else {
                        conceitoGeral = Conceito.A;
                    }
                    Console.WriteLine($"Conceito geral: {conceitoGeral}");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
        }
        OpcaoUsuario = ObterOpcaoUsuario();
    }

    }
        private static string ObterOpcaoUsuario() {
        Console.WriteLine("Informe a opção desejada:");
        Console.WriteLine("1 - Cadastrar novo aluno");
        Console.WriteLine("2 - Listar alunos");
        Console.WriteLine("3 - Calcular média geral");
        Console.WriteLine("X - Sair do programa");
        Console.WriteLine("");

        string opcao = Console.ReadLine();
        return opcao;
} }
}


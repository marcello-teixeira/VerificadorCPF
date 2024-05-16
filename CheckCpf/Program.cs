using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite seu nome: ");
        string? nome = Console.ReadLine();
        Console.Write("Digite seu CPF: ");
        string? cpf = Console.ReadLine();

        if (nome != null && cpf != null)
        {
            Pessoa pessoa = new(nome, cpf.Trim());
            pessoa.Imprimir();
        }
        Console.ReadKey();

    }

}

public class Pessoa
{
    public string Nome;
    private string CPF;
    public string cpf
    {
        set
        {
            if (value != null && CheckCPF(value))
            {
                CPF = value;
            }

        }
    }
    public Pessoa(string Nome, string cpf)
    {

        this.Nome = Nome;
        this.cpf = cpf;

    }

    private bool CheckCPF(string value)
    {
        int total_1 = 0;
        bool verificador_1 = false;
        int cont_1 = 10;

        int total_2 = 0;
        bool verificador_2 = false;
        int cont_2 = 11;

        int numero;
        foreach (char item in value)
        {
            numero = (int)char.GetNumericValue(item);
            if (item is '-' || item is '.')
            {
                continue;
            }

            // primeira verificação
            if (cont_1 == 1)
            {
                total_1 = (total_1 * 10) % 11;
                if (total_1 == numero)
                {
                    verificador_1 = true;
                }
            }

            total_1 += numero * cont_1;
            cont_1--;

            //segunda verificação
            if (cont_2 == 1)
            {
                total_2 = (total_2 * 10) % 11;
                if (total_2 == numero)
                {
                    verificador_2 = true;
                }
            }

            total_2 += numero * cont_2;
            cont_2--;

        }
        if (verificador_1 && verificador_2)
        {
            return true;
        }
        Console.WriteLine("Erro: CPF INCORRETO");
        return false;
    }

    public void Imprimir()
    {
        Console.Write($"Seu nome é: {this.Nome} | Seu CPF é: {this.CPF}");
    }

}

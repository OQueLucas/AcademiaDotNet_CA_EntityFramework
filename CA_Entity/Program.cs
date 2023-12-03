using CA_Entity.DataModels;
using Microsoft.EntityFrameworkCore;

namespace CA_Entity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite:\n" +
                "1 para criar uma pessoa\n" +
                "2 para alterar o nome da pessoa\n" +
                "3 para inserir um email\n" +
                "4 para excluir a pessoa\n" +
                "5 para consultar tudo\n" +
                "6 para consultar pelo ID da pessoa\n");

            int op = int.Parse(Console.ReadLine());
            Contexto contexto = new();

            switch(op)
            {
                case 1:
                    try
                    {
                        Pessoa p = new();
                        Console.WriteLine("Insira o nome da pessoa: ");
                        p.nome = Console.ReadLine();
                        Console.WriteLine("Insira o email: ");
                        string emailTemp = Console.ReadLine();

                        p.Emails = new List<Email>()
                        {
                            new()
                            {
                                email = emailTemp
                            }
                        };

                        contexto.Pessoas.Add(p);
                        contexto.SaveChanges();
                        Console.WriteLine("Pessoa inserida com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case 2:
                    try
                    {
                        Console.WriteLine("Informe o ID da pessoa:");
                        int id = int.Parse(Console.ReadLine());

                        Pessoa pAlt = contexto.Pessoas.Find(id);

                        Console.WriteLine("Informe o nome correto:");
                        pAlt.nome = Console.ReadLine();

                        contexto.Pessoas.Update(pAlt);
                        contexto.SaveChanges();
                        Console.WriteLine("Alteração efetuada!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case 3:
                    try
                    {
                        Console.WriteLine("Informe o ID da pessoa:");
                        int id = int.Parse(Console.ReadLine());

                        Pessoa p = contexto.Pessoas.Find(id);

                        Console.WriteLine("Informe um novo email:");
                        string emailTmp = Console.ReadLine();

                        p.Emails.Add(new() { email = emailTmp });

                        contexto.SaveChanges();
                        Console.WriteLine("Sucesso!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case 4:
                    try
                    {
                        Console.WriteLine("Infome o ID da pessoa:");
                        int id = int.Parse(Console.ReadLine());
                        Pessoa p = contexto.Pessoas.Find(id);

                        Console.WriteLine($"Confirma a exclusão de {p.nome} e de seus emails?");

                        foreach (Email e in p.Emails)
                        {
                            Console.WriteLine($"\t {e.email}");
                        }

                        Console.WriteLine("1 para SIM e 2 para NÃO");
                        if(int.Parse(Console.ReadLine()) == 1)
                        {
                            contexto.Pessoas.Remove(p);
                            contexto.SaveChanges();
                            Console.WriteLine($"{p.nome} removido com sucesso!");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case 5:
                    try
                    {
                        List<Pessoa> lista = (from Pessoa p in contexto.Pessoas select p).Include(pes => pes.Emails).ToList();

                        foreach (Pessoa p in lista)
                        {
                            Console.WriteLine(p.nome);

                            foreach (Email e in p.Emails)
                            {
                                Console.WriteLine($"\t {e.email}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case 6:
                    try
                    {
                        Console.WriteLine("Informe o ID da pessoa");
                        int id = int.Parse(Console.ReadLine());

                        Pessoa pessoa = contexto.Pessoas.Include(p => p.Emails).FirstOrDefault(p => p.id == id);

                        Console.WriteLine(pessoa.nome);

                        foreach(Email e in pessoa.Emails)
                        {
                            Console.WriteLine($"\t{e.email}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
            }
        }
    }
}

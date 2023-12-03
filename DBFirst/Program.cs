namespace DBFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int op;
                Console.WriteLine("Sistema de pedidos: ");
                Console.WriteLine("Digite: \n" +
                    "1 - Cadastrar clientes \n" +
                    "2 - Visualizar todos os clientes \n" +
                    "3 - Cadastrar pedidos \n" +
                    "4 - Visualizar todos os pedidos");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        InserirCliente();
                        break;
                    case 2:
                        MostratTodosClientes();
                        break;
                    case 3:
                        InserirPedidos();
                        break;
                    case 4:
                        MostratTodosPedidos();
                        break;
                    default:
                        Console.WriteLine("Insira um valor válido!");
                        break;
                }
            }
        }

        private static void InserirCliente()
        {
            using (var contexto = new bancoContext())
            {
                Cliente c = new();
                Console.WriteLine("Digite o nome do cliente: ");
                c.Nome = Console.ReadLine();
                Console.WriteLine("Digite o email do cliente: ");
                c.Email = Console.ReadLine();

                contexto.Clientes.Add(c);
                contexto.SaveChanges();

                Console.WriteLine("Pedido adicionado!");
            }
        }

        private static void MostratTodosClientes()
        {
            using (var contexto = new bancoContext())
            {
                var clientes = contexto.Clientes.ToList();

                foreach (var cliente in clientes)
                {
                    Console.WriteLine("Cliente: " + cliente.Id + " Nome: " + cliente.Nome + " Email: " + cliente.Email);
                }
            }
        }

        private static void InserirPedidos()
        {
            using (var contexto = new bancoContext())
            {
                Pedido p = new();
                Console.WriteLine("Digite o ID do cliente: ");
                p.IdCliente = int.Parse(Console.ReadLine());
                p.Datapedido = DateTime.Now;
                Console.WriteLine("Digite o valor do pedido: ");
                p.Valor = (decimal?)double.Parse(Console.ReadLine());

                contexto.Pedidos.Add(p);
                contexto.SaveChanges();

                Console.WriteLine("Pedido adicionado!");
            }
        }

        private static void MostratTodosPedidos()
        {
            using (var contexto = new bancoContext())
            {
                var pedidos = contexto.Pedidos.ToList();

                foreach (var pedido in pedidos)
                {
                    Console.WriteLine("Pedido: " + pedido.Id + " Nome: " + pedido.Valor + " Email: " + pedido.Datapedido + " Cliente: " + pedido.IdCliente);
                }
            }
        }
    }
}

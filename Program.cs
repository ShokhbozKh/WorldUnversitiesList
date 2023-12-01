using unversite.DatBase;
using unversite.Service;

namespace unversite
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Data data = new Data();
            Api api = new Api();
            // unversitlarni chiqaradi bush bulsa hammsini chiqaradi asinxron vaqti bilan
            Console.Write("Unversitet nomi:");
            string input = Console.ReadLine();

            var result = await api.GetUnversite(input);
            await data.RecordData(result);

            foreach ( var item in result )
            {
                Console.WriteLine($"{item.name}- {item.domains[0]}");
            }

        }
    }
}
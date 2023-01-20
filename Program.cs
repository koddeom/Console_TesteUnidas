using System.Text;

//------------------------------------------------------------------------------------
// ESCOPO
// RECEBA UMA STRING E UM VALOR PARA DIVIDIR ESSA STRING EM PARTES IGUAIS
// A STRING DEVE SER DIVIDIDA E REMONTADA PELA SEGUINTE REGRA:
// STRING COM DIVISAO DE PARTES EXATAS:
//        MANTER PARTES PARES E INVERTER PARTES IMPARES
// STRING COM DIVISAO DE PARTES NAO EXATAS:
//        INICIAR A STRING COM A SOBRA FINAL DA STRING INVERTIDA E SEGUIR A MESMA REGRA 
//        ANTERIOR DE INVERSAO
//------------------------------------------------------------------------------------
internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter text to shuffle:");
            string originalText = Console.ReadLine();

            Console.WriteLine("Enter chunk size:");
            int chunkSize = Convert.ToInt32(Console.ReadLine());

            //Se for menor ou vazio dispara uma exception
            if (string.IsNullOrEmpty(originalText) || originalText.Length < chunkSize)
            {
                throw new ArgumentException();
            }

            var result = shuffle(originalText, chunkSize);

            Console.WriteLine(result);
        }
        catch (Exception)
        {
            throw new ArgumentException();
        }
    }

    private static string shuffle(string originalText, int chunkSize)
    {
        StringBuilder finalString = new StringBuilder();

        int mod = (originalText.Length % chunkSize);

        IEnumerable<string> splited = new List<string>();

        //Divido usando Range....
        splited = Enumerable.Range(0, originalText.Length / chunkSize)
                            .Select(i => originalText.Substring(i * chunkSize, chunkSize));

        //Caso especial
        //Escopo:
        //  Se a divisao nao foi exata preciso pegar o resto da string
        //  O pedaco da string deve ser o inicio da string final revertida.

        if (mod > 0)
        {
            int pos = (splited.Count() * chunkSize);
            string modString = originalText.Substring(pos, originalText.Length - pos);
            //--------------------------------
            finalString.Append(reverseString(modString)).Append(" ");
        }

        //Faço o shuffle
        int itemCount = 0;
        foreach (var item in splited)
        {
            if (itemCount % 2 == 0)
            {
                finalString.Append(item).Append(" ");
            }
            else
            {
                finalString.Append(reverseString(item)).Append(" ");
            }
            itemCount++;
        }

        return finalString.ToString().Trim();
    }

    private static string reverseString(string splitedText)
    {
        //Inverte a string
        return new string(splitedText.Reverse().ToArray());
    }
}
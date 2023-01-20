using Console_TesteUnidas.Business.StringShuffle;

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
        ShuffleString shuffleString = new ShuffleString();

        Console.WriteLine("Enter text to shuffle:");
        string originalText = Console.ReadLine();

        Console.WriteLine("Enter chunk size:");
        int chunkSize = Convert.ToInt32(Console.ReadLine());

        //Se for menor ou vazio dispara uma exception
        if (string.IsNullOrEmpty(originalText) || originalText.Length < chunkSize)
        {
            Console.Error.WriteLine("String ou tamanho inválidos");
        }

        try
        {
            var result = shuffleString.Shuffle(originalText, chunkSize);

            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.ToString());
        }
    }
}
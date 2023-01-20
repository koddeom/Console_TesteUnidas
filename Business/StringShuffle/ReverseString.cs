using Console_TesteUnidas.Business.StringShuffle.Interface;

namespace Console_TesteUnidas.Business.StringShuffle
{
    internal class ReverseString : iReverse
    {
        public string Reverse(string splitedText)
        {
            //Inverte a string
            return new string(splitedText.Reverse().ToArray());
        }
    }
}
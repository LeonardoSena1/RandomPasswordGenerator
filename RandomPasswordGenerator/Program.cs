
namespace RandomPasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gerador de Senhas");

            int length = Generator.GetPasswordLength();
            bool useLowercase = Generator.GetYesOrNo("Incluir letras minúsculas? (y/n): ");
            bool useUppercase = Generator.GetYesOrNo("Incluir letras maiúsculas? (y/n): ");
            bool useDigits = Generator.GetYesOrNo("Incluir dígitos? (y/n): ");
            bool useSpecialChars = Generator.GetYesOrNo("Incluir caracteres especiais? (y/n): ");

            string generatedPassword = Generator.GeneratePassword(length, useLowercase, useUppercase, useDigits, useSpecialChars);
            Console.WriteLine($"Senha gerada: {generatedPassword}");
        }
    }
}
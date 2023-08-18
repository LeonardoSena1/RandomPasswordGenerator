using System.Security.Cryptography;

namespace RandomPasswordGenerator
{
    public class Generator
    {
        private const string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        private const string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string digitChars = "0123456789";
        private const string specialChars = "!@#$%^&*()_+-=[]{}|;:,.<>?";

        public static int GetPasswordLength()
        {
            Console.Write("Digite o comprimento da senha desejada: ");
            int length;
            while (!int.TryParse(Console.ReadLine(), out length) || length <= 0)
            {
                Console.Write("Comprimento inválido. Digite um número positivo: ");
            }
            return length;
        }

        public static bool GetYesOrNo(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().Trim().ToLower();
            return input == "y" || input == "yes";
        }

        public static string GeneratePassword(int length, bool useLowercase, bool useUppercase, bool useDigits, bool useSpecialChars)
        {
            string validChars = "";
            if (useLowercase) validChars += lowercaseChars;
            if (useUppercase) validChars += uppercaseChars;
            if (useDigits) validChars += digitChars;
            if (useSpecialChars) validChars += specialChars;

            if (validChars.Length == 0)
            {
                Console.WriteLine("Erro: Nenhum conjunto de caracteres selecionado.");
                return "";
            }

            using RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] randomBytes = new byte[length];
            rng.GetBytes(randomBytes);

            string password = new string(randomBytes.Select(b => validChars[b % validChars.Length]).ToArray());
            return password;
        }
    }
}

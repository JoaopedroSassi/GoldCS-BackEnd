using System.Text.RegularExpressions;

namespace src.Extensions
{
	public static class StringExtensions
    {
        public static bool IsCpfValid(this string cpf)
        {
            return Regex.Match(cpf, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$").Success;
        }

        public static bool IsCepValid(this string cep)
        {
            return Regex.Match(cep, @"^\d{5}-\d{3}$").Success;
        }

        public static bool IsPasswordValid(this string pass)
        {
            return Regex.Match(pass, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$").Success;
        }

        public static bool IsEmailValid(this string email)
        {
            return Regex.Match(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success;
        }
		
		public static bool IsUFValid(this string uf)
		{
			return Regex.Match(uf, @"\W\b(A[CLPM]|BA|CE|DF|GO|ES|M[ATSG]|P[ABREI]|R[JNSOR]|S[PCE]|TO)\W").Success;
		}
    }
}
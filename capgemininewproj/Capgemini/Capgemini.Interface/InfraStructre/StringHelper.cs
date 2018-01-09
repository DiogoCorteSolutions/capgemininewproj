using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Capgemini.Interface.InfraStructre
{
    public class StringHelper
    {
        public static string ReplaceEnconding(string strString)
        {
            strString = strString.Replace("Á", "&Aacute;");
            strString = strString.Replace("á", "&aacute;");
            strString = strString.Replace("Â", "&Acirc;");
            strString = strString.Replace("â", "&acirc;");
            strString = strString.Replace("À", "&Agrave;");
            strString = strString.Replace("à", "&agrave;");
            strString = strString.Replace("Å", "&Aring;");
            strString = strString.Replace("å", "&aring;");
            strString = strString.Replace("Ã", "&Atilde;");
            strString = strString.Replace("ã", "&atilde;");
            strString = strString.Replace("Ä", "&Auml;");
            strString = strString.Replace("ä", "&auml;");
            strString = strString.Replace("Æ", "&AElig;");
            strString = strString.Replace("æ", "&aelig;");
            strString = strString.Replace("É", "&Eacute;");
            strString = strString.Replace("é", "&eacute;");
            strString = strString.Replace("Ê", "&Ecirc;");
            strString = strString.Replace("ê", "&ecirc;");
            strString = strString.Replace("È", "&Egrave;");
            strString = strString.Replace("è", "&egrave;");
            strString = strString.Replace("Ë", "&Euml;");
            strString = strString.Replace("ë", "&euml;");
            strString = strString.Replace("Ð", "&ETH;");
            strString = strString.Replace("ð", "&eth;");
            strString = strString.Replace("Í", "&Iacute;");
            strString = strString.Replace("í", "&iacute;");
            strString = strString.Replace("Î", "&Icirc;");
            strString = strString.Replace("î", "&icirc;");
            strString = strString.Replace("Ì", "&Igrave;");
            strString = strString.Replace("ì", "&igrave;");
            strString = strString.Replace("Ï", "&Iuml;");
            strString = strString.Replace("ï", "&iuml;");
            strString = strString.Replace("Ó", "&Oacute;");
            strString = strString.Replace("ó", "&oacute;");
            strString = strString.Replace("Ô", "&Ocirc;");
            strString = strString.Replace("ô", "&ocirc;");
            strString = strString.Replace("Ò", "&Ograve;");
            strString = strString.Replace("ò", "&ograve;");
            strString = strString.Replace("Ø", "&Oslash;");
            strString = strString.Replace("ø", "&oslash;");
            strString = strString.Replace("Õ", "&Otilde;");
            strString = strString.Replace("õ", "&otilde;");
            strString = strString.Replace("Ö", "&Ouml;");
            strString = strString.Replace("ö", "&ouml;");
            strString = strString.Replace("Ú", "&Uacute;");
            strString = strString.Replace("ú", "&uacute;");
            strString = strString.Replace("Û", "&Ucirc;");
            strString = strString.Replace("û", "&ucirc;");
            strString = strString.Replace("Ù", "&Ugrave;");
            strString = strString.Replace("ù", "&ugrave;");
            strString = strString.Replace("Ü", "&Uuml;");
            strString = strString.Replace("ü", "&uuml;");
            strString = strString.Replace("Ç", "&Ccedil;");
            strString = strString.Replace("ç", "&ccedil;");
            strString = strString.Replace("Ñ", "&Ntilde;");
            strString = strString.Replace("ñ", "&ntilde;");
            //strString = strString.Replace("&", "&amp;");
            //strString = strString.Replace("®", "&reg;");
            //strString = strString.Replace("©", "&copy;");
            //strString = strString.Replace("Ý", "&Yacute;");
            //strString = strString.Replace("ý", "&yacute;");
            //strString = strString.Replace("Þ", "&THORN;");
            //strString = strString.Replace("þ", "&thorn;");
            //strString = strString.Replace("ß", "&szlig;");
            return strString;
        }

        public static string GetSubstringByString(string leftDelimiter, string rightDelimiter, string value)
        {
            return value.Substring((value.IndexOf(leftDelimiter) + leftDelimiter.Length),
                (value.IndexOf(rightDelimiter) - value.IndexOf(leftDelimiter) - leftDelimiter.Length));
        }

        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        public static string FormatarCnpj(string cnpj)
        {
            double cnpjVal;
            if (double.TryParse(cnpj, out cnpjVal))
            {
                return string.Format(@"{0:00\.000\.000\/0000\-00}", cnpjVal);
            }
            else
            {
                return cnpj;
            }
        }

        public static string FormatarCpf(string cpf)
        {
            double cpfVal;
            if (double.TryParse(cpf, out cpfVal))
            {
                return string.Format(@"{0:000\.000\.000\-00}", cpfVal);
            }
            else
            {
                return cpf;
            }
        }

        public static string FormatarData(DateTime? dt)
        {
            if (dt == null)
                return string.Empty;
            else
                return Convert.ToDateTime(dt).ToString("dd/MM/yyyy");
        }

        public static string FormatarDinheiro(decimal valor)
        {
            return String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valor);
        }

        /// <summary>
        /// Valida se o número de telefone ou celular é válido com ou sem o codigo do pais(55).
        /// </summary>
        /// <param name="telefone">Número do telefone.</param>
        /// <param name="codigoPais">Validar código do país (55).</param>
        /// <returns>bool</returns>
        public static bool ValidaTelefone(string telefone, bool codigoPais)
        {
            if (codigoPais)
            {
                //Valida se o numero é um telefone válido com o codigo do país (55 + DDD + numero).
                return Regex.IsMatch(telefone, @"^55\d{2}9?\d{8}$");
            }
            else
            {
                //Valida se o numero é um telefone válido sem o codigo do país ( DDD + numero). 
                return Regex.IsMatch(telefone, @"^\d{2}9?\d{8}$");
            }
        }

        public static bool ValidaEmail(string email)
        {
            return Regex.IsMatch(email,
                                 @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z"
                );
        }
    }
}
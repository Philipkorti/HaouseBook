using Data;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services
{
    public class PDFReader
    {
        
        public static Transaction ReadPDF(string path)
        {
            PdfReader pdfReader = new PdfReader(path);
            string sText = "";

            for (int i = 1; i <= pdfReader.NumberOfPages; i++)
            {
                 sText += PdfTextExtractor.GetTextFromPage(pdfReader, i);
            }

            string[] splitString = sText.Split(new char[] { '\n' });
            Transaction transaction = new Transaction();
            transaction.TransactionDescription= splitString[1].ToLower();
            string pattern = @"(\p{Sc})?";
            Regex rgx = new Regex(pattern);
            string sum;
            for (int i = 0; i < splitString.Length; i++)
            {
               string test = splitString[i].ToLower();
                switch (splitString[i].ToLower())
                {
                    case ("(l pos)"):
                    case ("summe"):
                    case ("total"):
                        {
                            try
                            {
                                sum = rgx.Replace(splitString[i + 1],"");
                                for (int k = 0; k < sum.Length; k++)
                                {
                                    int count = sum.IndexOf(' ');
                                    sum = sum.Remove(count, 1);
                                }
                                sum = sum.Replace('.', ',');
                                transaction.SumPrice = Convert.ToDouble(sum);
                            }catch (Exception ex)
                            {
                                transaction.SumPrice = 0;
                            }
                            
                            break;
                        }
                    default:
                        {
                            if (DateTime.TryParse(splitString[i], out DateTime date))
                            {
                                transaction.TransactionDate = date;
                            }
                            break;
                        }
                }
            }
            return transaction;
            
        }
    }
}

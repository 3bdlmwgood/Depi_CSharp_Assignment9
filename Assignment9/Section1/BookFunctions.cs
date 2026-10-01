using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment9.Section1
{
    public class BookFunctions
    {
        public static string GetTitle(Book B)
        {
            return B.Title;
        }

        public static string GetAuthors(Book B)
        {
            return string.Join(", ", B.Authors);
        }

        public static string GetPrice(Book B)
        {
            return B.Price.ToString("C");
        }

        public static DateTime GetPublicationDate(Book B) => B.PublicationDate;

        public static string GetISBN(Book B)
        {
            return B.ISBN;
        }
    }
}

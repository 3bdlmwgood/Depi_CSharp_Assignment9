using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment9.Section1
{
    public class LibraryEngine
    {
        public delegate string BookFunction(Book B);

        public static void ProcessBooks_UserDefined(List<Book> bList, BookFunction fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }

        public static void ProcessBooks_BuiltIn<T>(List<Book> bList, Func<Book, T> fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public static class getenumval
    {
        public static List<string> GetLogEnumValues(string enumTypeName)
        {
            Type enumType = Type.GetType($"test.{enumTypeName}");

            if (enumType == null || !enumType.IsEnum)
            {
                throw new ArgumentException($"Type '{enumTypeName}' is not an enum type.");
            }

            return enumType.GetFields(BindingFlags.Public | BindingFlags.Static).Select(x => x.Name).ToList();
        }

    }
    public enum LogType
    {
        Search,
        Price,
        Book,
        Ticket,
        Cancel,
        Void,
        PNR,
        FareRules,
        QueuePlace
    }

    public enum Search
    {
        Search,
        SrcSearch
    }

    public enum Price
    {
        Price,
        PriceReload,
        SrcPrice
    }

    public enum Book
    {
        Book,
        SrcBook
    }

    public enum Ticket
    {
        Ticket
    }

    public enum Cancel
    {
        Cancel
    }

    public enum PNR
    {
        FOPModify,
        PNRRetrive,
        URModify
    }

    public enum FareRules
    {
        FareDisplay,
        FareRules
    }

    public enum QueuePlace
    {
        QueuePlace
    }

}

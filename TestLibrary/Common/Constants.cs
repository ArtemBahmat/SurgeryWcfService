using System.Collections.Generic;

namespace TestLibrary.Common
{
    public static class Constants
    {
        public static class ReqNotesConstants
        {
            public const string NoteCategoryId = "TO";
            public const string NoteTypeId = "QD";
        }

        public static class HdrConstants
        {
            public static readonly List<string> RemoveSymbols = new List<string>
            {
                "\r\n",
                "\\11",
                "\n",
                "\r"
            };
        }
    }
}

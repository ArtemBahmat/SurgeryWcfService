using System;
using System.Collections.Generic;

namespace TestLibrary.Models
{
    public class ReqNotes
    {
        public string MdlNumber { get; }

        public string NoteCategoryId { get; }

        public string NoteTypeId { get; }

        public ReqNotes(string mdlNumber, string noteCategoryId, string noteTypeId)
        {
            MdlNumber = mdlNumber;
            NoteCategoryId = noteCategoryId;
            NoteTypeId = noteTypeId;
        }

        public List<DiscrepancyInfo> GetReqNotes()
        {
            throw new NotImplementedException();
        }
    }
}

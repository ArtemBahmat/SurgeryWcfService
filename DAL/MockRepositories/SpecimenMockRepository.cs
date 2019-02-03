using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.MockRepositories
{
    public class SpecimenMockRepository : ISpecimenMockRepository
    {
        public IQueryable<Specimen> GetAll()
        {
            return new List<Specimen>
            {
                new Specimen { Num = "1", IsOnePId = true, PathCase = "pathCase1", SlRejectionId = "id1", SmComments = "comment1" },
                new Specimen { Num = "2", IsOnePId = false, PathCase = "pathCase2", SlRejectionId = "id2", SmComments = "comment2" },
                new Specimen { Num = "3", IsOnePId = true, PathCase = "pathCase3", SlRejectionId = "id3", SmComments = "comment3" },

            }.AsQueryable();
        }
    }
}

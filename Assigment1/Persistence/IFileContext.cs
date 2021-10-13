using System.Collections.Generic;
using Models;

namespace Assigment1.Persistence
{
    public interface IFileContext
    {
        IList<Adult> GetPersons();
        void AddPerson(Adult adult);
        void RemovePerson(int personId);
        void Update(Adult adult);
        Adult Get(int id);
    }
}

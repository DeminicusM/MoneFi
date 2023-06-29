using MoneFi.Models.Domain.BorrowerDebt;
using MoneFi.Models.Domain.Notes;
using MoneFi.Models.Requests.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneFi.Services.Interfaces
{
    public interface INotesService
    {
        int Add(NotesAddRequest model, int userId);

        void Update(NotesUpdateRequest model);

        List<Note> GetByLectureIdByCreatedBy(int lectureId, int createdBy);

        void Delete(int id);
    }
}

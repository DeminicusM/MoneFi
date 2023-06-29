using MoneFi.Data.Providers;
using MoneFi.Models.Requests.Notes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sabio.Data;
using System.Data;
using MoneFi.Models.Domain.Notes;
using MoneFi.Services.Interfaces;
using MoneFi.Models.Domain.BorrowerDebt;
using MoneFi.Models.Domain;

namespace MoneFi.Services
{
    public class NotesService : INotesService
    {
        IDataProvider _data = null;

        public NotesService(IDataProvider data)
        {
            _data = data;
        }

        public int Add(NotesAddRequest model, int userId)
        {
            int id = 0;

            string procName = "[dbo].[Notes_Insert]";
            _data.ExecuteNonQuery(procName, inputParamMapper: delegate (SqlParameterCollection col)
            {
                SqlParameter idOut = new SqlParameter("@Id", SqlDbType.Int);
                idOut.Direction = ParameterDirection.Output;
                col.Add(idOut);
                AddCommonParams(model, col);
                col.AddWithValue("@CreatedBy", userId);
            },
            returnParameters: delegate (SqlParameterCollection returnCol)
            {
                object old = returnCol["@Id"].Value;
                int.TryParse(old.ToString(), out id);
            });
            return id;
        }


        public void Update(NotesUpdateRequest model)
        {
            string procName = "[dbo].[Notes_Update]";
            _data.ExecuteNonQuery(procName, inputParamMapper: delegate (SqlParameterCollection col)
            {
                col.AddWithValue("@LectureNotes", model.LectureNotes);
                col.AddWithValue("@Id", model.Id);
            },
            returnParameters: null);
        }



        public List<Note> GetByLectureIdByCreatedBy(int lectureId, int createdBy)
        {
            string procName = "[dbo].[Notes_Select_ByLectureIdByCreatedBy]";

            List<Note> list = null;

            _data.ExecuteCmd(procName, delegate (SqlParameterCollection paramCollection)
            {
                paramCollection.AddWithValue("@LectureId", lectureId);
                paramCollection.AddWithValue("@CreatedBy", createdBy);
            }, delegate (IDataReader reader, short set)
            {
                Note aNote = MapSingleNote(reader);
                if (list == null)
                {
                    list = new List<Note>();
                }
                list.Add(aNote);
            });
            return list;
        }

            public void Delete (int id)
        {
            string procName = "[dbo].[Notes_DeleteById]";
            _data.ExecuteNonQuery(procName, inputParamMapper: delegate (SqlParameterCollection col)
            {
                col.AddWithValue("@Id", id);
            },
            returnParameters: null);
        }

        private static Note MapSingleNote(IDataReader reader)
        {
            Note aNote = new Note();
            int startingIndex = 0;
            aNote.Id = reader.GetSafeInt32(startingIndex++);
            aNote.LectureNotes = reader.GetSafeString(startingIndex++);
            aNote.LecturedId = reader.GetSafeInt32(startingIndex++);
            aNote.Tags = reader.DeserializeObject<List<LookUp>>(startingIndex++);
            aNote.CreatedBy = reader.GetSafeInt32(startingIndex++);
            return aNote;
        }


        private static void AddCommonParams(NotesAddRequest model, SqlParameterCollection col)
        {
            col.AddWithValue("@LectureNotes", model.LectureNotes);
            col.AddWithValue("LectureId", model.LectureId);
        }

    }
}

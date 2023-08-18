using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPData
{
    //public class NotesStore
    //{
    //    private readonly List<Note> notes;

    //    private class Note
    //    {
    //        public string? Name { get; set; }
    //        public string? State { get; set; }
    //    }

    //    private enum State
    //    {
    //        completed,
    //        active,
    //        others
    //    }



    //    public NotesStore()
    //    {
    //        notes = new List<Note>();
    //    }

    //    public void AddNote(string state, string name)
    //    {
    //        if (string.IsNullOrEmpty(name))
    //        {
    //            throw new Exception("Name cannot be empty");
    //        }
    //        if (!typeof(State).IsEnumDefined(state))
    //        {
    //            throw new Exception($"Invalid state {state}");
    //        }

    //        notes.Add(new Note { Name = name, State = state });
    //    }
    //    public List<string> GetNotes(string state)
    //    {
    //        List<string> list = new List<string>();
    //        if (!typeof(State).IsEnumDefined(state.ToLower()))
    //        {
    //            throw new Exception($"Invalid state {state}");
    //        }

    //        return notes.Where(x => x.State == state).Select(x => x.Name).ToList();
    //    }
    //}
}
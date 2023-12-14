using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using NoteAPI.Domain.Entities.Dtos;

namespace NoteAPI.Domain.Entities.Models
{
    public class Notes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Note")]
        public string Note { get; set; }
        [BsonElement("Time")]
        public DateTime Time { get; set; }

        public Notes() { }

        public Notes(string _id, string _note, DateTime _time) { }

        public Notes ConvertNoteDtoToNote(NoteDto note)
        {
            this.Id = note.Id;
            this.Note = note.Note;
            this.Time = DateTime.Now.AddHours(-3);
            return new Notes(this.Id, this.Note, this.Time);
        }

        public bool isValid()
        {
            if (string.IsNullOrWhiteSpace(this.Id) || string.IsNullOrWhiteSpace(this.Note))
                return false;
            return true;
        }
    }
}

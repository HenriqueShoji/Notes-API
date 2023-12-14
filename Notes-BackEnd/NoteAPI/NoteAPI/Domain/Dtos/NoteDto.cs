using System.ComponentModel;

namespace NoteAPI.Domain.Entities.Dtos
{
    public class NoteDto
    {
        [DefaultValue("")]
        public string Id { get; set; }
        public string Note { get; set; }

        public bool isValid()
        {
            return string.IsNullOrWhiteSpace(this.Note) ? true : false;
        }
    }
}

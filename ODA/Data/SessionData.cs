using System.ComponentModel.DataAnnotations;

namespace ODA.Data
{
    internal class SessionData
    {
        [Required]
        public string SessionID { get; set; }
        [Required]
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
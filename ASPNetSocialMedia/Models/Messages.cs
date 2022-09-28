using MessagePack;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace ASPNetSocialMedia.Models
{
    public class Messages
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int? MessageId { get; set; }
        public string? MessageContent { get; set; }
        public string? UserEmail { get; set; }

        public string? FriendEmail { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNetSocialMedia.Models
{
    public class Friendship
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RelationId { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        public int FriendId { get; set; }

        [ForeignKey("FriendId")]
        public User? Friend { get; set; }
    }
}

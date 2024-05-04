namespace Models.DTOs.PostDTOs
{
    public class UpdatePostDto
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid? TextPostID { get; set; }
        public Guid? ImagePostID { get; set; }
        public Guid? VideoPostID { get; set; }
        public Guid? VoicePostID { get; set; }
        public Guid CommunityID { get; set; }
        public required string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

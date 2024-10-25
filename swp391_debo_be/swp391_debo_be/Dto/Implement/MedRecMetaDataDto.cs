namespace swp391_debo_be.Dto.Implement
{
    public class MedRecMetaDataDto
    {
        public string? NameFile { get; set; }
        public long? FileSize { get; set; }
        public DateTime? LastModified { get; set; }
        public string ContentType { get; set; }  // New field for the file type
    }
}

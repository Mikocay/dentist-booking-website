namespace swp391_debo_be.Dto.Implement
{
    public class TreatmentDto
    {
        public int Id { get; set; }

        public int? Category { get; set; }

        //public Guid? AdminId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public double? Price { get; set; }
    }
}

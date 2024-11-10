namespace swp391_debo_be.Dto.Implement
{
    public class CreateEmployeeDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public int? BrId { get; set; }

        public int? Type { get; set; }

        public double? Salary { get; set; }
        public int? TreatId { get; set; }
    }
}

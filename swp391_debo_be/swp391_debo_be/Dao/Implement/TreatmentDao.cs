using Microsoft.EntityFrameworkCore;
using swp391_debo_be.Dao.Interface;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Entity.Implement;

namespace swp391_debo_be.Dao.Implement
{
    public class TreatmentDao : ITreatmentDao
    {
        private readonly DeboDev02Context _context = new DeboDev02Context(new DbContextOptions<DeboDev02Context>());

        public TreatmentDao()
        {
        }
        public TreatmentDao(DeboDev02Context context)
        {
            _context = context;
        }

        public async Task<int> addTreatmentAsync(TreatmentDto treatment)
        {
            var newTreat = new ClinicTreatment
            {
                Id = treatment.Id,
                Category = treatment.Category,
                Name = treatment.Name,
                Description = treatment.Description,
                Price = treatment.Price,
                Status = true,
            };
            _context.ClinicTreatments.Add(newTreat);
            await _context.SaveChangesAsync();
            return newTreat.Id;
        }

        public async Task deleteTreatmentAsync(int id)
        {
            var deleteTreat = _context.ClinicTreatments!.SingleOrDefault(u => u.Id == id);
            if (deleteTreat != null)
            {
                deleteTreat.Status = false;
                _context.ClinicTreatments.Update(deleteTreat);
                await _context.SaveChangesAsync();
            }
        }

        public async Task activeTreatmentAsync(int id)
        {
            var activeTreat = _context.ClinicTreatments!.SingleOrDefault(u => u.Id == id);
            if (activeTreat != null)
            {
                activeTreat.Status = true;
                _context.ClinicTreatments.Update(activeTreat);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TreatmentDto>> getAllTreatmentAsync(int page, int limit)
        {
            IQueryable<ClinicTreatment> query = _context.ClinicTreatments
                                                         .Where(t => t.Status == true);

            if (limit > 0)
            {
                query = query.Skip(page * limit)
                             .Take(limit);
            }

            var treatments = await query.ToListAsync();

            var treatmentDtos = treatments.Select(t => new TreatmentDto
            {
                Id = t.Id,
                Category = t.Category,
                Name = t.Name,
                Description = t.Description,
                Price = t.Price,
            }).ToList();

            return treatmentDtos;
        }


        public List<object> GetTreatmentsBasedOnBranchId(int branchId)
        {

            List<object> result = new List<object>();
            var treatments = _context.ClinicBranches
                .Where(b => b.Id == branchId)
                .SelectMany(b => b.Employees)
                .Where(e => e.Type == 4)
                .SelectMany(e => e.Treats)
                .ToList();

            foreach (var treatment in treatments)
            {
                string? categoryName = _context.TreatmentCategories
                    .Where(tc => tc.Id == treatment.Category)
                    .Select(tc => tc.Name)
                    .FirstOrDefault();

                string? ruleName = _context.Rules.Where(r => r.Id == treatment.RuleId)
                    .Select(r => r.Name)
                    .FirstOrDefault();


                object treat = new
                {
                    ID = treatment.Id,
                    category_name = categoryName,
                    name = treatment.Name,
                    description = treatment.Description,
                    price = treatment.Price,
                    rule_name = ruleName,
                    num_of_appointment = treatment.NumOfApp
                };

                result.Add(treat);
            }
            return result;

        }

        public async Task<TreatmentDto> getTreatmentAsync(int id)
        {
            var treatment = await _context.ClinicTreatments.FindAsync(id);
            if (treatment == null || treatment.Status != true)
            {
                return null; // or throw an appropriate exception
            }

            return new TreatmentDto
            {
                Id = treatment.Id,
                Category = treatment.Category,
                Name = treatment.Name,
                Description = treatment.Description,
                Price = treatment.Price,
            };
        }

        public async Task updateTreatmentAsync(int id, TreatmentDto treatment)
        {
            var existingTreat = await _context.ClinicTreatments.FindAsync(id);

            if (existingTreat == null || existingTreat.Status != true || id != treatment.Id)
            {
                // Handle the case when the treatment is not found or status is not true, or IDs do not match
                throw new InvalidOperationException("Treatment not found, inactive, or ID mismatch.");
            }
            else
            {
                existingTreat.Category = treatment.Category;
                existingTreat.Name = treatment.Name;
                existingTreat.Description = treatment.Description;
                existingTreat.Price = treatment.Price;

                _context.ClinicTreatments.Update(existingTreat);
                await _context.SaveChangesAsync();
            }
        }
    }
}

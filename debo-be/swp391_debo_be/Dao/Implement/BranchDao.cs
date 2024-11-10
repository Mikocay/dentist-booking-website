using swp391_debo_be.Dao.Interface;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Entity.Implement;
using Microsoft.EntityFrameworkCore;

namespace swp391_debo_be.Dao.Implement
{
    public class BranchDao : IBranchDao
    {
        private readonly DeboDev02Context _context = new DeboDev02Context(new DbContextOptions<DeboDev02Context>());

        public BranchDao() 
        {
        }
        public BranchDao(DeboDev02Context context)
        {
            _context = context;
        }

        public async Task activeBranchAsync(int id)
        {
            var activeBranch = _context.ClinicBranches!.SingleOrDefault(u => u.Id == id);
            if (activeBranch != null)
            {
                activeBranch.Status = true;
                _context.ClinicBranches.Update(activeBranch);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> addBranchAsync(BranchDto branch)
        {
            var newBranch = new ClinicBranch
            {
                Id = branch.Id,
                MngId = branch.MngId,
                Name = branch.Name,
                Address = branch.Address,
                Phone = branch.Phone,
                Email = branch.Email,
                Avt = branch.Avt,
                Status = true,
            };
            _context.ClinicBranches.Add(newBranch);
            await _context.SaveChangesAsync();
            return newBranch.Id;
        }

        public async Task deleteBranchAsync(int id)
        {
            var deleteBranch = _context.ClinicBranches!.SingleOrDefault(x => x.Id == id);
            if (deleteBranch != null) 
            {
                deleteBranch.Status = false;
                _context.ClinicBranches.Update(deleteBranch);
                await _context.SaveChangesAsync() ;
            }
        }

        public async Task<List<BranchDto>> getAllBranchAsync(int page, int limit)
        {
            IQueryable<BranchDto> query = _context.ClinicBranches
                                                   .Where(b => b.Status == true)
                                                   .Select(b => new BranchDto
                                                   {
                                                       Id = b.Id,
                                                       Name = b.Name,
                                                       Address = b.Address,
                                                       Phone = b.Phone,
                                                       Email = b.Email,
                                                       Avt = b.Avt,
                                                   })
                                                   .AsNoTracking();

            if (limit > 0)
            {
                query = query.Skip(page * limit)
                             .Take(limit);
            }

<<<<<<< HEAD
            var branchsDto = branchs.Select(b => new BranchDto
            {
                Id = b.Id,
                MngId = b.MngId,
                Name = b.Name,
                Address = b.Address,
                Phone = b.Phone,
                Email = b.Email,
                Avt = b.Avt,
            }).ToList();
            return branchsDto;
=======
            return await query.ToListAsync();
>>>>>>> a0f4eeed9afedfd1eae96adbe41bfe37ae48af3d
        }


        public async Task<BranchDto> getBranchAsync(int id)
        {

            var branch = await _context.ClinicBranches.FindAsync(id);
            if (branch == null)
            {
                return null;
            }
            var query = from cb in _context.ClinicBranches
                        join u in _context.Users on cb.MngId equals u.Id into cb_u
                        from u in cb_u.DefaultIfEmpty()
                        where cb.Id == id
                        select new BranchDto
                        {
                            Id = cb.Id,
                            MngId = cb.MngId,
                            MngName = cb.MngId != null ? (u.FirstName + " " + u.LastName) : null,
                            Name = cb.Name,
                            Address = cb.Address,
                            Phone = cb.Phone,
                            Email = cb.Email,
                            Avt = cb.Avt,
                        };
            var branchDto = await query.FirstOrDefaultAsync();

            return branchDto;
        }

        public async Task updateBranchAsync(int id, BranchDto branch)
        {
            var existingBranch = await _context.ClinicBranches.FindAsync(id);
            if (existingBranch == null || existingBranch.Status != true || id != branch.Id)
            {
                throw new InvalidOperationException("Branch not found, inactive, or ID mismatch.");

            }
            else
            {
                if (branch.Phone.Length > 10 || branch.Phone.Any(char.IsLetter))
                {
                    throw new InvalidOperationException("Phone number cannot be more than 10 digits or contain alphabetic characters.");
                }
                existingBranch.Name = branch.Name;
                existingBranch.Address = branch.Address;
                existingBranch.Phone = branch.Phone;
                existingBranch.Email = branch.Email;
                existingBranch.Avt = branch.Avt;

                _context.ClinicBranches.Update(existingBranch);
                await _context.SaveChangesAsync();
            }
        }


    }
}

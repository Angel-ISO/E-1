using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace Application.Repository;
public class UserRepository : GenericRepository<User>, IUser
{
    private readonly E1AppContext _context;
    public UserRepository(E1AppContext context) : base(context)
    {
        _context = context;
    }
    public async Task<User> GetByUserNameAsync (string userName)
    {
        return await _context.Users.Include(u => u.Rols).FirstOrDefaultAsync (u => u.Name_User.ToLower()==userName.ToLower());
    }
}
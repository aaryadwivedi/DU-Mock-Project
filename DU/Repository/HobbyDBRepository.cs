using DU.Model;
using Microsoft.EntityFrameworkCore;

namespace DU.Repository
{
    public class HobbyDBRepository : iHobbyRepository
    {
        private readonly ADBContext context;
        public HobbyDBRepository(ADBContext dbContext )
        {
            this.context = dbContext;
        }


        public async Task<List<Hobby>> getHobbies()
        {
            var hobbies= await this.context.Hobbys.ToListAsync();
            return hobbies;
        }

        public async Task<Hobby> getHobbiesById(int Id)
        {
            var hobby = await this.context.Hobbys.SingleOrDefaultAsync(h=>h.Id==Id);
            return hobby;
        }
    }
}

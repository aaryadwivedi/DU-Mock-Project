using DU.Model;

namespace DU.Repository
{
    public interface iHobbyRepository
    {
        Task<List<Hobby>> getHobbies();
        Task<Hobby> getHobbiesById(int Id);
       
    }
}

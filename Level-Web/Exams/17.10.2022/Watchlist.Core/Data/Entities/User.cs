namespace Watchlist.Core.Data.Entities
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public User()
        {
            this.UsersMovies = new HashSet<UserMovie>();
        }

        public virtual ICollection<UserMovie> UsersMovies { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace FirstAspApp.Data
{
    public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
    {

    }
}

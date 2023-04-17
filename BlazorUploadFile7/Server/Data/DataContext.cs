using BlazorUploadFile7.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorUploadFile7.Server.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
            
        }

        public DbSet<UploadResult> Uploads => Set<UploadResult>();
    }
}

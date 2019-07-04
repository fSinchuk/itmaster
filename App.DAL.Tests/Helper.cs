using Microsoft.EntityFrameworkCore;

namespace App.DAL.Tests
{
    public static class Helper
    {
        public static DataBaseContext GetContext(string name)
        {
            var dbOptions = new DbContextOptionsBuilder<DataBaseContext>().UseInMemoryDatabase(name).Options;
            return new DataBaseContext(dbOptions);
        }
    }
}

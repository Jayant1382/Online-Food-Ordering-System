using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineFoodOrderingSystem.MenuMicroservice.DataAccessLayer
{
    public interface IMenuRepository
    {
        Task<IEnumerable<Menu>> GetAllMenus();
        Task<Menu> GetMenuById(int id);
        Task CreateMenu(Menu menu);
        Task UpdateMenu(Menu menu);
        Task DeleteMenu(int id);
    }

    public class MenuRepository : IMenuRepository
    {
        private readonly MenuDbContext _dbContext;

        public MenuRepository(MenuDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Menu>> GetAllMenus()
        {
            return await _dbContext.Menus.ToListAsync();
        }

        public async Task<Menu> GetMenuById(int id)
        {
            return await _dbContext.Menus.FindAsync(id);
        }

        public async Task CreateMenu(Menu menu)
        {
            _dbContext.Menus.Add(menu);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateMenu(Menu menu)
        {
            _dbContext.Menus.Update(menu);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteMenu(int id)
        {
            var menu = await _dbContext.Menus.FindAsync(id);

            if (menu != null)
            {
                _dbContext.Menus.Remove(menu);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

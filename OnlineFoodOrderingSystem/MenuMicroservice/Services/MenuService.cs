using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineFoodOrderingSystem.MenuMicroservice.DataAccessLayer;

namespace MenuMicroservice.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<Menu> GetMenuById(int id)
        {
            try
            {
                return await _menuRepository.GetMenuById(id);
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                throw; // Rethrow the exception to the calling code
            }
        }

        public async Task<IEnumerable<Menu>> GetAllMenus()
        {
            try
            {
                return await _menuRepository.GetAllMenus();
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                throw; // Rethrow the exception to the calling code
            }
        }

        public async Task CreateMenu(Menu menu)
        {
            try
            {
                await _menuRepository.CreateMenu(menu);
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                throw; // Rethrow the exception to the calling code
            }
        }

        public async Task UpdateMenu(Menu menu)
        {
            try
            {
                await _menuRepository.UpdateMenu(menu);
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                throw; // Rethrow the exception to the calling code
            }
        }

        public async Task DeleteMenu(int id)
        {
            try
            {
                await _menuRepository.DeleteMenu(id);
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                throw; // Rethrow the exception to the calling code
            }
        }
    }

    public interface IMenuService
    {
        Task<Menu> GetMenuById(int id);
        Task<IEnumerable<Menu>> GetAllMenus();
        Task CreateMenu(Menu menu);
        Task UpdateMenu(Menu menu);
        Task DeleteMenu(int id);
    }
}

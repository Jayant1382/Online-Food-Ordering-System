using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrderingSystem.MenuMicroservice.DataAccessLayer;

namespace OnlineFoodOrderingSystem.MenuMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository _menuRepository;

        public MenuController(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenus()
        {
            var menus = await _menuRepository.GetAllMenus();
            return Ok(menus);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuById(int id)
        {
            var menu = await _menuRepository.GetMenuById(id);

            if (menu == null)
            {
                return NotFound();
            }

            return Ok(menu);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu([FromBody] Menu menu)
        {
            await _menuRepository.CreateMenu(menu);
            return CreatedAtAction(nameof(GetMenuById), new { id = menu.Id }, menu);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenu(int id, [FromBody] Menu menu)
        {
            var existingMenu = await _menuRepository.GetMenuById(id);

            if (existingMenu == null)
            {
                return NotFound();
            }

            existingMenu.Name = menu.Name;
            existingMenu.Description = menu.Description;
            existingMenu.Price = menu.Price;

            await _menuRepository.UpdateMenu(existingMenu);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            var existingMenu = await _menuRepository.GetMenuById(id);

            if (existingMenu == null)
            {
                return NotFound();
            }

            await _menuRepository.DeleteMenu(id);
            return NoContent();
        }
    }
}

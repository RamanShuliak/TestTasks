using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRChat.Business.Hubs;
using SignalRChat.Core.Abstractions;
using SignalRChat.DataBase.Entities;

namespace SignalRChat.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(Guid chatId, Guid userId, string message)
        {
            try
            {
                var result = await _userService.SendMessageToChat(chatId, userId, message);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> JoinChat(Guid chatId, Guid userId)
        {
            try
            {
                var result = await _userService.JoinChat(chatId, userId);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteChat(Guid chatId, Guid userId)
        {
            try
            {
                var result = await _userService.DeleteChat(chatId, userId);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateNewChat(Guid userId, string chatName, 
            List<string> usersNamesForAdding)
        {
            try
            {
                var result = await _userService.CreateNewChat(userId, chatName, usersNamesForAdding);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpGet]
        public async Task<List<Chat>?> FindChats()
        {
            try
            {
                var chats = await _userService.FindChats();
                return chats;
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] string userName)
        {
            try
            {
                var result = await _userService.CreateNewUser(userName);
                return Ok($"Id of new User = {result}");
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

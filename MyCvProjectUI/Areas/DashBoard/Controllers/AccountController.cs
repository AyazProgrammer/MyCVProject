using Business.Abstract;
using Business.Validation;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MyCvProjectUI.Areas.DashBoard.Controllers
{

	[Area("DashBoard")]
	public class AccountController : Controller
    {
		private readonly IAuthService _authService;

		public AccountController(

			   IAuthService authService

			)
		{
			_authService = authService;
		}
		public IActionResult Login()
        {
            return View();
        }

		[HttpPost]
		public IActionResult Login(LoginDTO loginDTO)
		{
			
			try
			{
				var userToLogin = _authService.Login(loginDTO);
				if (!userToLogin.Success)
				{
					Console.WriteLine(userToLogin.Message);
					return  NotFound();
				}
				var result = _authService.CreateAccessToken(userToLogin.Data);
				var token = result.Data.Token;
				var tokenExpiration = result.Data.Expiration;

				if (result.Success)
				{
					var cookieOptions = new CookieOptions
					{
						HttpOnly = true,
						Expires = tokenExpiration, 
						Secure = true, 
						SameSite = SameSiteMode.Strict 
					};

					
					Response.Cookies.Append("jwt", token, cookieOptions);
					return RedirectToAction("Index", "Home");
				}
				else
				{
					return View();
				}

				
			}
			catch (Exception)
			{

				return NotFound();

			}
		}
		
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Register(RegisterDto userForRegisterDto)
		{
			var userExists = _authService.UserExists(userForRegisterDto.Email);
			if (userExists.Success)
			{
				var message = userExists.Message;
				return View();
            }

			var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
			var result = _authService.CreateAccessToken(registerResult.Data);
			if (result.Success)
			{
				return RedirectToAction("Login", "Account");
			}

           
            return View();
		}


	}
}

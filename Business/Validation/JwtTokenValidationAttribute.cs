using Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation
{
	public class JwtTokenValidationAttribute: ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var token = context.HttpContext.Request.Cookies["jwt"];

			if (string.IsNullOrEmpty(token))
			{
				context.Result = new RedirectToActionResult("Login", "Account", null);
				return;
			}

			
			var tokenExpiration = TokenTimeCheck.GetTokenExpiration(token);
			Console.WriteLine(tokenExpiration.ToString());

			if (tokenExpiration == null || tokenExpiration < DateTime.UtcNow)
			{
				context.Result = new RedirectToActionResult("Login", "Account", null);
				return;
			}

			base.OnActionExecuting(context);
		}
	}
}

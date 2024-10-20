using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
	public static class TokenTimeCheck
	{
		public static DateTime? GetTokenExpiration(string token)
		{
			if (string.IsNullOrEmpty(token))
				return null;

			var tokenHandler = new JwtSecurityTokenHandler();

			try
			{
				
				var jwtToken = tokenHandler.ReadJwtToken(token);
				return jwtToken.ValidTo; 
			}
			catch (Exception)
			{
				
				return null;
			}
		}
	}
}

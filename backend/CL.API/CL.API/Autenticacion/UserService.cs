using CL.Modelo;
using CL.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CL.API.Autenticacion
{
    public class UserService
    {

        protected readonly ContextoAplicacion db;
        
        public UserService(ContextoAplicacion contexto)
        {
            this.db = contexto;
        }

        public List<Empleado> Get() =>
            db.Empleados.ToList();

        public Empleado Get(Guid id) =>
            db.Empleados.Find(id);

        public Tokens Login(Authentication authentication)
        {
            Empleado user = db.Empleados.Where(u => u.NombreUsuario == authentication.Username).FirstOrDefault();

            bool validPassword = user.Hash == authentication.Password;

            if (validPassword)
            {
                var refreshToken = TokenManager.GenerateRefreshToken(user);

                if (user.RefreshTokens == null)
                    user.RefreshTokens = new List<string>();

                user.RefreshTokens.Add(refreshToken.refreshToken);

                /// AQUI DEBE GAURDARSE EL TOKEN DE REFRSCO EN SQL

                //_users.ReplaceOne(u => u.Id == user.Id, user);

                return new Tokens
                {
                    AccessToken = TokenManager.GenerateAccessToken(user),
                    RefreshToken = refreshToken.jwt
                };
            }
            else
            {
                throw new System.Exception("Username or password incorrect");
            }
        }

        public Tokens Refresh(Claim userClaim, Claim refreshClaim)
        {
            Empleado user = db.Empleados.Where(x => x.NombreUsuario == userClaim.Value).FirstOrDefault();

            if (user == null)
                throw new System.Exception("User doesn't exist");

            if (user.RefreshTokens == null)
                user.RefreshTokens = new List<string>();

            string token = user.RefreshTokens.FirstOrDefault(x => x == refreshClaim.Value);

            if (token != null)
            {
                var refreshToken = TokenManager.GenerateRefreshToken(user);

                user.RefreshTokens.Add(refreshToken.refreshToken);

                user.RefreshTokens.Remove(token);

                /// AQUI DEBE GAURDARSE EL TOKEN DE REFRSCO EN SQL

                //_users.ReplaceOne(u => u.Id == user.Id, user);

                return new Tokens
                {
                    AccessToken = TokenManager.GenerateAccessToken(user),
                    RefreshToken = refreshToken.jwt
                };
            }
            else
            {
                throw new System.Exception("Refresh token incorrect");
            }
        }

    }
}
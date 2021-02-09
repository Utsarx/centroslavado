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


            Empleado user;

            user = db.Empleados.Where(u => u.NombreUsuario == authentication.Email).FirstOrDefault();

            Console.WriteLine($"{user==null}");
            Console.WriteLine($"{authentication.Password} = {System.Text.Json.JsonSerializer.Serialize(user)}" );
            bool validPassword = user.Hash == authentication.Password;
            Console.WriteLine($"{validPassword}");
            if (validPassword)
            {

                List<RefreshToken> rts = db.RefreshTokens.Where(x => x.EmpleadoId == user.Id).ToList();
                if (rts.Count > 0)
                {
                    db.RefreshTokens.RemoveRange(rts);
                }

                var refreshToken = TokenManager.GenerateRefreshToken(user);
                var t = new RefreshToken()
                {
                    Id = new Guid(),
                    EmpleadoId = user.Id,
                    Token = refreshToken.refreshToken,
                    Jwt = refreshToken.jwt

                };

                db.RefreshTokens.Add(t);
                db.SaveChanges();

                return new Tokens
                {
                    AccessToken = TokenManager.GenerateAccessToken(user),
                    RefreshToken = refreshToken.jwt
                };
            }
            else
            {
                return null;
            }
        }

        public Tokens Refresh(Claim userClaim, Claim refreshClaim)
        {
            Empleado user = db.Empleados.Where(x => x.NombreUsuario == userClaim.Value).FirstOrDefault();

            if (user == null)
                throw new System.Exception("User doesn't exist");

            RefreshToken token = db.RefreshTokens.Where(x => x.EmpleadoId == user.Id).FirstOrDefault();

            if (token != null)
            {

                var refreshToken = TokenManager.GenerateRefreshToken(user);

                var t = new RefreshToken()
                {
                    Id = new Guid(),
                    EmpleadoId = user.Id,
                    Token = refreshToken.refreshToken,
                    Jwt = refreshToken.jwt

                };

                db.RefreshTokens.Add(t);
                db.RefreshTokens.Remove(token);
                db.SaveChanges();

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
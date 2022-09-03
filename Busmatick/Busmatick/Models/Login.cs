using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Threading.Tasks;
using Busmatick.MySql;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using static Google.Protobuf.WellKnownTypes.Field.Types;

namespace Busmatick.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Nombres { get; set; }
        public string Clave { get; set; }

        internal Conexion Db { get; set; }

        public Login()
        {
        }

        internal Login(Conexion db)
        {
            Db = db;
        }

        public async Task<List<Login>> GetAll()
        {
            using var cmd = Db.ConexionBD.CreateCommand();
            cmd.CommandText = @"SELECT `Id`, `Usuario`, `Clave` FROM `usuarios`;";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        public async Task<Login?> FindOneAsync(string usuario, string clave)
        {
            using var cmd = Db.ConexionBD.CreateCommand();
            cmd.CommandText = @"SELECT `Id`, `Usuario`, `Clave` FROM `usuarios` WHERE `Usuario` = @usuario and `clave`= @clave";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@usuario",
                DbType = DbType.String,
                Value = usuario,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@clave",
                DbType = DbType.String,
                Value = clave,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public List<Login>? Find(string usuario)
        {
            
            using var cmd = Db.ConexionBD.CreateCommand();
            cmd.CommandText = @"SELECT `Id`, `Usuario`, `Nombres` FROM `usuarios` WHERE `usuario` = @usuario";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@usuario",
                DbType = DbType.String,
                Value = usuario,
            });

            var result = ReadAll(cmd.ExecuteReader());

            return result.Count > 0 ? result : null;
        }

        public bool Validar(string usuario, string clave)
        {
            
            using var cmd = Db.ConexionBD.CreateCommand();
            cmd.CommandText = @"SELECT `Id`, `Usuario`, `Nombres`  FROM `usuarios` WHERE `Usuario` = @usuario and `clave`= @clave";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@usuario",
                DbType = DbType.String,
                Value = usuario,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@clave",
                DbType = DbType.String,
                Value = clave,
            });

            var result = ReadAll(cmd.ExecuteReader());
                      
            return result.Count > 0 ? true : false;

        }

        private List<Login> ReadAll(DbDataReader reader)
        {
            var usuarios = new List<Login>();
            using (reader)
            {
                while (reader.Read())
                {
                    var datos = new Login(Db)
                    {
                        Id      = reader.GetInt32(0),
                        Usuario = reader.GetString(1),
                        Nombres = reader.GetString(2),
                    };
                    usuarios.Add(datos);
                }
            }
            return usuarios;
        }

        private async Task<List<Login>> ReadAllAsync(DbDataReader reader)
        {
            var usuarios = new List<Login>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new Login(Db)
                    {
                        Id      = reader.GetInt32(0),
                        Usuario = reader.GetString(1),
                        Nombres = reader.GetString(2),
                    };
                    usuarios.Add(post);
                }
            }
            return usuarios;
        }
    }

}


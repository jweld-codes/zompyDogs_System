﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using static ZompyDogsDAO.UsuarioDAO;
using ZompyDogsLib;

namespace ZompyDogsDAO
{
    /// <summary>
    /// Clase de acceso a datos para operaciones relacionadas con usuarios.
    /// Esta clase proporciona métodos para obtener información de usuarios y realizar operaciones como actualización de contraseñas.
    /// </summary>
    public class UsuarioDAO
    {
        /// Cadena de conexión utilizada para interactuar con la base de datos.
        private static readonly string con_string = Conexion.cadena;
        /// Conexión SQL utilizada para ejecutar consultas.
        private static SqlConnection conn = new SqlConnection(con_string);

        /// Obtiene el ID de un usuario dado su nombre de usuario.
        /// <param name="nombreUsuario">Nombre del usuario para buscar.</param>
        /// <returns>El ID del usuario como un entero.</returns>
        public static int ObtenerIDPorNombreUsuario(string nombreUsuario) // ClaveOlvidada
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
            {
                throw new ArgumentException("El nombre de usuario no puede ser nulo o estar vacío.", nombreUsuario);
            }

            int idUsuario = 0;

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                string query = "SELECT IDUsuario, RolID FROM v_DetallesUsuarios WHERE Usuario = @NombreUsuario";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                conn.Open();
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    idUsuario = Convert.ToInt32(result);
                }
            }
            return idUsuario;
        }

        public static (string nombreUsuario, string codigoEmpleado) ObtenerNombreUsuarioPorID(int idUsuario)
        {
            string nombreUsuario = null;
            string codigoEmpleado = null;

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                string query = "SELECT Nombre_Completo, Codigo FROM v_DetallesUsuarios WHERE IDUsuario = @IDUsuario";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDUsuario", idUsuario);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nombreUsuario = reader["Nombre_Completo"].ToString();
                        codigoEmpleado = reader["Codigo"].ToString();
                    }
                }
            }

            return (nombreUsuario, codigoEmpleado);
        }

        /// <summary>
        /// Actualiza la clave de un usuario en la base de datos y marca su petición como completada.
        /// </summary>
        /// <param name="nombreUsuario">Nombre del usuario cuya clave será actualizada.</param>
        /// <param name="nuevaClave">Nueva clave que será asignada al usuario.</param>
        /// <param name="correoUsuario">Correo del usuario asociado (se obtiene dentro del método).</param>
        /// <returns>
        /// <c>true</c> si la clave y el estado de la petición fueron actualizados exitosamente; 
        /// de lo contrario, <c>false</c>.
        /// </returns>
        public static bool ActualizarClaveUsuario(string nombreUsuario, string nuevaClave, string correoUsuario)
        {
            correoUsuario = null;
            string queryUsername = "SELECT id_usuario FROM Usuario WHERE username = @nombreUsuario";
            string queryEmail = "SELECT email FROM Usuario WHERE username = @nombreUsuario";
            string queryUpdatePassword = "UPDATE Usuario SET password = @nuevaClave WHERE username = @nombreUsuario";
            string queryUpdateEstadoPeticion = "UPDATE Peticiones SET estado = 'Completado' WHERE codigoUsuario = @idUser";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Obtener el id_usuario
                        SqlCommand cmdQU = new SqlCommand(queryUsername, conn, transaction);
                        cmdQU.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

                        int idUser = (int)cmdQU.ExecuteScalar();

                        // Obtener el correo electrónico
                        SqlCommand cmdEmail = new SqlCommand(queryEmail, conn, transaction);
                        cmdEmail.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

                        correoUsuario = (string)cmdEmail.ExecuteScalar();

                        // Actualizar la contraseña
                        SqlCommand cmdUpdatePassword = new SqlCommand(queryUpdatePassword, conn, transaction);
                        cmdUpdatePassword.Parameters.AddWithValue("@nuevaClave", nuevaClave);
                        cmdUpdatePassword.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

                        int filasAfectadasPassword = cmdUpdatePassword.ExecuteNonQuery();

                        // Actualizar el estado de la petición
                        SqlCommand cmdUpdateEstadoPeticion = new SqlCommand(queryUpdateEstadoPeticion, conn, transaction);
                        cmdUpdateEstadoPeticion.Parameters.AddWithValue("@idUser", idUser);

                        int filasAfectadasPeticion = cmdUpdateEstadoPeticion.ExecuteNonQuery();

                        // Comprobar si ambas actualizaciones tuvieron éxito
                        if (filasAfectadasPassword > 0 && filasAfectadasPeticion > 0)
                        {
                            transaction.Commit();
                            return true;
                        }
                        else
                        {
                            transaction.Rollback();
                            Console.WriteLine("No se actualizaron filas en Usuario o Peticiones.");
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error al actualizar la clave del usuario: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        /* --------------  OBTENER DATOS PARA DATAGRIDS ------------------- */
        public static DataTable ObtenerDetalllesDeUsuarios()
        {
            DataTable dtpDetallesUsuarios = new DataTable();
            string query = "SELECT Codigo, Nombre_Completo, Telefono, Puesto, Salario, RolUsuario FROM v_DetallesUsuarios";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    conn.Open();
                    da.Fill(dtpDetallesUsuarios);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener las descripciones de usuarios: " + ex.Message);
                }
            }

            return dtpDetallesUsuarios;
        }

        public static DataTable ObtenerDetalllesDeUsuariosParaEditar(string codigoUsuario)
        {
            DataTable dtpDetallesUsuarios = new DataTable();
            string query = "SELECT * FROM v_DetallesUsuarios WHERE Codigo = @codigoUsuario";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@codigoUsuario", codigoUsuario);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    conn.Open();
                    da.Fill(dtpDetallesUsuarios);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener las descripciones de usuarios: " + ex.Message);
                }
            }

            return dtpDetallesUsuarios;
        }
        
        public static DataTable ObtenerDetalllesDeProveedoresParaEditar(string codigoUsuario)
        {
            DataTable dtpDetalleProveedor = new DataTable();
            string query = "SELECT * FROM v_DetallesProveedores WHERE Codigo = @codigoUsuario";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@codigoUsuario", codigoUsuario);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    conn.Open();
                    da.Fill(dtpDetalleProveedor);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener las descripciones de proveedores: " + ex.Message);
                }
            }

            return dtpDetalleProveedor;
        }

        public static DataTable ObtenerDetalllesDeUsuariosEmpleados()
        {
            DataTable dtpDetallesUsuarios = new DataTable();
            string query = "SELECT Codigo, Nombre_Completo, Usuario, Telefono, Puesto, Salario, RolUsuario FROM v_DetallesUsuarios WHERE RolID = 2";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    conn.Open();
                    da.Fill(dtpDetallesUsuarios);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener las descripciones de usuarios: " + ex.Message);
                }
            }

            return dtpDetallesUsuarios;
        }

        public static DataTable ObtenerDetalllesDeUsuariosAdmin()
        {
            DataTable dtpDetallesUsuarios = new DataTable();
            string query = "SELECT Codigo, Nombre_Completo, Usuario, Telefono, Puesto, Salario, RolUsuario FROM v_DetallesUsuarios WHERE RolID = 1";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    conn.Open();
                    da.Fill(dtpDetallesUsuarios);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener las descripciones de usuarios: " + ex.Message);
                }
            }

            return dtpDetallesUsuarios;
        }

        public static DataTable ObtenerDetalllesProveedores()
        {
            DataTable dtpDetallesUsuarios = new DataTable();
            string query = "SELECT * FROM v_DetallesProveedores";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    conn.Open();
                    da.Fill(dtpDetallesUsuarios);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener las descripciones de usuarios: " + ex.Message);
                }
            }

            return dtpDetallesUsuarios;
        }

        public static DataTable ObtenerDetalllesPuestos()
        {
            DataTable dtpPuestos = new DataTable();
            string query = "SELECT * FROM v_DetallesPuestos";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    conn.Open();
                    da.Fill(dtpPuestos);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener las descripciones de puestos: " + ex.Message);
                }
            }

            return dtpPuestos;
        }
        public static DataTable ObtenerDetalllesPuestosParaEditar(string codigoPuesto)
        {
            DataTable dtpPuestos = new DataTable();
            string query = "SELECT * FROM v_DetallesPuestos WHERE Codigo = @codiPuesto";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@codiPuesto", codigoPuesto);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    conn.Open();
                    da.Fill(dtpPuestos);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener las descripciones de puestos: " + ex.Message);
                }
            }

            return dtpPuestos;
        }

        public static DataTable ObtenerDetalllesDeUsuariosParaEditarPorID(int codigoUsuario)
        {
            DataTable dtpDetallesUsuarios = new DataTable();
            string query = "SELECT * FROM v_DetallesUsuarios WHERE IDUsuario = @codigoUsuario";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@codigoUsuario", codigoUsuario);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    conn.Open();
                    da.Fill(dtpDetallesUsuarios);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener las descripciones de usuarios: " + ex.Message);
                }
            }

            return dtpDetallesUsuarios;
        }
        
        /* --------------  BUSCADORES ------------------- */
        public static DataTable BuscadorDeUsuarios(string valorBusqueda)
        {
            string query = "SELECT  Codigo, Nombre_Completo, Usuario, Telefono, Puesto, Salario, RolUsuario FROM v_DetallesUsuarios WHERE Usuario LIKE @valorBusqueda OR Nombre_Completo LIKE @valorBusqueda OR Codigo LIKE @valorBusqueda";

            using (SqlConnection connection = new SqlConnection(con_string))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@valorBusqueda", "%" + valorBusqueda + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable resultados = new DataTable();
                    adapter.Fill(resultados);
                    return resultados;
                }
            }
        }
        public static DataTable BuscadorDeUsuariosAdmins(string valorBusqueda)
        {
            string query = "SELECT Codigo, Nombre_Completo, Usuario, Telefono, Puesto, Salario, RolUsuario " +
               "FROM v_DetallesUsuarios " +
               "WHERE (Usuario LIKE @valorBusqueda OR Nombre_Completo LIKE @valorBusqueda OR Codigo LIKE @valorBusqueda) " +
               "AND RolUsuario = 'Administrador'";


            using (SqlConnection connection = new SqlConnection(con_string))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@valorBusqueda", "%" + valorBusqueda + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable resultados = new DataTable();
                    adapter.Fill(resultados);
                    return resultados;
                }
            }
        }
        public static DataTable BuscadorDeUsuariosEmps(string valorBusqueda)
        {
            string query = "SELECT Codigo, Nombre_Completo, Usuario, Telefono, Puesto, Salario, RolUsuario " +
               "FROM v_DetallesUsuarios " +
               "WHERE (Usuario LIKE @valorBusqueda OR Nombre_Completo LIKE @valorBusqueda OR Codigo LIKE @valorBusqueda) " +
               "AND RolUsuario = 'Empleado'";


            using (SqlConnection connection = new SqlConnection(con_string))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@valorBusqueda", "%" + valorBusqueda + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable resultados = new DataTable();
                    adapter.Fill(resultados);
                    return resultados;
                }
            }
        }
        public static DataTable BuscadorDeProveedores(string valorBusqueda)
        {
            string query = "SELECT  Codigo, Proveedor, Nombre_Completo, Telefono, Correo, Estado FROM v_DetallesProveedores WHERE Codigo LIKE @valorBusqueda OR Nombre_Completo LIKE @valorBusqueda OR Proveedor LIKE @valorBusqueda";

            using (SqlConnection connection = new SqlConnection(con_string))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@valorBusqueda", "%" + valorBusqueda + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable resultados = new DataTable();
                    adapter.Fill(resultados);
                    return resultados;
                }
            }
        }

        /* --------------  OBTENER ID DEL PROXIMO DETALLE DE USUARIOS ------------------- */

        /// <summary>
        /// Obtiene el siguiente ID disponible para la tabla `DetalleUsuario`
        /// calculando el valor máximo actual en la columna `Id_DetalleUsuario` y sumándole 1.
        /// </summary>
        /// <returns>
        /// Un entero que representa el siguiente ID disponible.
        /// Si la tabla está vacía, el valor retornado será 1.
        /// </returns>
        /// <remarks>
        /// En caso de error, se captura la excepción y se imprime un mensaje en la consola.
        /// </remarks>
        public static int ObtenerSiguienteID()
        {
            int siguienteID = 1;
            try
            {
                using (SqlConnection conn = new SqlConnection(con_string))
                {
                    conn.Open();
                    string query = "SELECT MAX(Id_DetalleUsuario) FROM DetalleUsuario";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        var resultado = cmd.ExecuteScalar();
                        if (resultado != DBNull.Value)
                        {
                            siguienteID = Convert.ToInt32(resultado) + 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el siguiente ID: " + ex.Message);
            }
            return siguienteID;
        }

        /* --------------  CRUD PARA USUARIOS (GENERAL) ------------------- */
        
        //GUARDA DETALLES DEL USUARIO
        public static void GuardarDetalleUsuario(ZompyDogsLib.Usuarios.DetalleUsuario detalleusuario)
        {
            string query = "INSERT INTO DetalleUsuario(primNombreUsuario, segNombreUsuario, primApellidoUsuario, segApellido, codigoCedula, fechaNacimiento, estadoCivil, telefono, direccion, codigoPuesto, codigoUsuario) VALUES (@primern, @segundon, @primera, @segundoa, @codice, @fechanac, @civil, @tele, @direcc, @codpu, @codius)";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    
                    cmd.Parameters.AddWithValue("@primern", detalleusuario.primerNombre);
                    cmd.Parameters.AddWithValue("@segundon", detalleusuario.segundoNombre);
                    cmd.Parameters.AddWithValue("@primera", detalleusuario.primerApellido);
                    cmd.Parameters.AddWithValue("@segundoa", detalleusuario.segundoApellido);
                    cmd.Parameters.AddWithValue("@codice", detalleusuario.codigoCedula);
                    cmd.Parameters.AddWithValue("@fechanac", detalleusuario.fechaNacimiento);
                    cmd.Parameters.AddWithValue("@civil", detalleusuario.estadoCivil);
                    cmd.Parameters.AddWithValue("@tele", detalleusuario.telefono);
                    cmd.Parameters.AddWithValue("@direcc", detalleusuario.direccion);
                    cmd.Parameters.AddWithValue("@codpu", Convert.ToInt32(detalleusuario.codigoPuesto));
                    cmd.Parameters.AddWithValue("@codius", detalleusuario.codigoUsuario);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            Console.WriteLine("No se insertó ningún registro en la base de datos.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al guardar el usuario: " + ex.Message);
                    }
                }
            }
        }

       // GUARDA EL USUARIO CON SUS DETALLES (DetallesUsuario)
        public static void GuardarUsuario(ZompyDogsLib.Usuarios.UsuarioCrear userAdd)
        {
            string query = "INSERT INTO Usuario(username, password, fechaRegistro, codigoRol, codigoDetalleUsuario, email) VALUES (@nameuser, @claveuser, @fechareg, @codiRol, @codiDetalle, @email)";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@nameuser", userAdd.UserName);
                    cmd.Parameters.AddWithValue("@claveuser", userAdd.PassWord);
                    cmd.Parameters.AddWithValue("@fechareg", userAdd.FechaRegistro);
                    cmd.Parameters.AddWithValue("@codiRol", Convert.ToInt32(userAdd.CodigoRol));
                    cmd.Parameters.AddWithValue("@codiDetalle", Convert.ToInt32(userAdd.CodigoDetalleUsuario));
                    cmd.Parameters.AddWithValue("@email", userAdd.Email);
                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            Console.WriteLine("No se insertó ningún registro en la base de datos.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al guardar el usuario: " + ex.Message);
                    }
                }
            }
        }

        //ACTUALIZA LOS DATOS DEL USUARIO
        public static bool ActualizarDetalleUsuario(ZompyDogsLib.Usuarios.DetalleUsuario detalleUsuario)
        {
            string query = "UPDATE DetalleUsuario SET primNombreUsuario = @primNombreUsuario, segNombreUsuario = @segNombreUsuario, primApellidoUsuario = @primApellidoUsuario, segApellido = @segApellido, " +
               "codigoCedula = @codigoCedula, fechaNacimiento = @fechaNacimiento, estadoCivil = @estadoCivil, telefono = @telefono, direccion = @direccion, " +
               "codigoPuesto = @codigoPuesto " +
               "WHERE codigoUsuario = @codigoUsuario";
            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@primNombreUsuario", detalleUsuario.primerNombre);
                cmd.Parameters.AddWithValue("@segNombreUsuario", detalleUsuario.segundoNombre);
                cmd.Parameters.AddWithValue("@primApellidoUsuario", detalleUsuario.primerApellido);
                cmd.Parameters.AddWithValue("@segApellido", detalleUsuario.segundoApellido);
                cmd.Parameters.AddWithValue("@codigoCedula", detalleUsuario.codigoCedula);
                cmd.Parameters.AddWithValue("@fechaNacimiento", detalleUsuario.fechaNacimiento);
                cmd.Parameters.AddWithValue("@estadoCivil", detalleUsuario.estadoCivil);
                cmd.Parameters.AddWithValue("@telefono", detalleUsuario.telefono);
                cmd.Parameters.AddWithValue("@direccion", detalleUsuario.direccion);
                cmd.Parameters.AddWithValue("@codigoPuesto", detalleUsuario.codigoPuesto);
                cmd.Parameters.AddWithValue("@codigoUsuario", detalleUsuario.codigoUsuario);

                try
                {
                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar el usuario: " + ex.Message);
                    Console.WriteLine("Detalles de la excepción: " + ex.ToString());
                    return false;
                }
            }
        }
        
        // Eliminar Usuario Seleccionado
        public static bool EliminarUsuario(int idDetalleUsuario)
        {
            string query = "DELETE FROM Usuario WHERE codigoDetalleUsuario = @idDetalleUsuario";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idDetalleUsuario", idDetalleUsuario);

                try
                {
                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar la petición: " + ex.Message);
                    return false;
                }
            }
        }
        public static bool EliminarUsuarioPorDetalle(string codigoDetalle)
        {
            string query = "DELETE FROM DetalleUsuario WHERE codigoUsuario = @codigoDetalle";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@codigoDetalle", codigoDetalle);

                try
                {
                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar la petición: " + ex.Message);
                    return false;
                }
            }
        }
        
        /* --------------  CRUD PARA PROVEEDORES ------------------- */
        //GUARDA LOS DATOS DE LOS PROVEEDORES
        public static void GuardarProveedor(ZompyDogsLib.Usuarios.ProveedorCrear proveedorAdd)
        {
            string query = "INSERT INTO Proveedor(Nombre, Contacto, Telefono, Email, fechaRegistro, estado, codigoProveedor, apellidoContacto) " +
                "VALUES (@nombreP, @contactoP, @telefonoP, @emailProv, @fecharegistroP, @estadoP, @codiProveedor, @apellidoContactoP)";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombreP", proveedorAdd.NombreProv);
                    cmd.Parameters.AddWithValue("@contactoP", proveedorAdd.ContactoProv);
                    cmd.Parameters.AddWithValue("@telefonoP", proveedorAdd.TelefonoProv);
                    cmd.Parameters.AddWithValue("@emailProv", proveedorAdd.EmailProv); // Corregido aquí
                    cmd.Parameters.AddWithValue("@fecharegistroP", proveedorAdd.FechaRegistroProv);
                    cmd.Parameters.AddWithValue("@estadoP", proveedorAdd.EstadoProv);
                    cmd.Parameters.AddWithValue("@codiProveedor", proveedorAdd.CodigoProv);
                    cmd.Parameters.AddWithValue("@apellidoContactoP", proveedorAdd.ApellidoContactoProv);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            Console.WriteLine("No se insertó ningún registro en la base de datos.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al guardar el proveedor: " + ex.Message);
                    }
                }
            }
        }

        //ACTUALIZA LOS DATOS DE LOS PROVEEDORES
        public static bool ActualizarProveedotes(ZompyDogsLib.Usuarios.ProveedorCrear proveedorUpdate)
        {
            string query = "UPDATE Proveedor SET Nombre = @provNombre, Contacto = @provContacto, Telefono = @provTelefono, Email = @provEmail, " +
               "estado = @provEstado, apellidoContacto = @provApellido WHERE codigoProveedor = @provCodigo";
            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@provNombre", proveedorUpdate.NombreProv);
                cmd.Parameters.AddWithValue("@provContacto", proveedorUpdate.ContactoProv);
                cmd.Parameters.AddWithValue("@provTelefono", proveedorUpdate.TelefonoProv);
                cmd.Parameters.AddWithValue("@provEmail", proveedorUpdate.EmailProv);
                cmd.Parameters.AddWithValue("@provEstado", proveedorUpdate.EstadoProv);
                cmd.Parameters.AddWithValue("@provApellido", proveedorUpdate.ApellidoContactoProv);
                cmd.Parameters.AddWithValue("@provCodigo", proveedorUpdate.CodigoProv);

                try
                {
                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar el usuario: " + ex.Message);
                    Console.WriteLine("Detalles de la excepción: " + ex.ToString());
                    return false;
                }
            }
        }

        // Eliminar Proveedor Seleccionado
        public static bool EliminarProveedor(string codigoUsuario)
        {
            string query = "DELETE FROM Proveedor WHERE codigoPRoveedor = @codigoUsuario";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@codigoUsuario", codigoUsuario);

                try
                {
                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar la petición: " + ex.Message);
                    return false;
                }
            }
        }

        /* --------------  CRUD PARA PUESTO ------------------- */
        public static void GuardarPuesto(ZompyDogsLib.Usuarios.PuestoREF puestoAdd)
        {
            string query = "INSERT INTO Puestos (puesto, descripcion, salario, horalaboralInicio, diasLaborales, codigoPuesto, codigoRol, estado, horaLaboralTermina) " +
                           "VALUES (@puestoName, @puestoDesc, @puestoSalario, @horalaboralInicio, @puestoDias, @codiPuesto, @codiRol, @puestoEstado, @horaLaboralTermina)";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@puestoName", puestoAdd.Puesto);
                    cmd.Parameters.AddWithValue("@puestoDesc", puestoAdd.Descripcion);
                    cmd.Parameters.AddWithValue("@puestoSalario", puestoAdd.Salario);
                    cmd.Parameters.AddWithValue("@horalaboralInicio", puestoAdd.HoralaboralInicio);
                    cmd.Parameters.AddWithValue("@puestoDias", puestoAdd.DiasLaborales);
                    cmd.Parameters.AddWithValue("@codiPuesto", puestoAdd.CodigoPuesto);
                    cmd.Parameters.AddWithValue("@codiRol", puestoAdd.CodigoRol);
                    cmd.Parameters.AddWithValue("@puestoEstado", puestoAdd.Estado);
                    cmd.Parameters.AddWithValue("@horaLaboralTermina", puestoAdd.HoraLaboralTermina);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al guardar el puesto: " + ex.Message);
                        throw;
                    }
                }
            }
        }

        public static bool EliminarPuesto(string codigoPuesto)
        {
            string query = "DELETE FROM Puestos WHERE codigoPuesto = @codipuesto";

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@codipuesto", codigoPuesto);

                try
                {
                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar el puesto: " + ex.Message);
                    return false;
                }
            }
        }

        public static bool ActualizarPuesto(ZompyDogsLib.Usuarios.PuestoREF puestoUpdate)
        {
            try
            {
                // Usamos parámetros para evitar SQL injection
                string query = @"UPDATE Puestos 
                         SET puesto = @Puesto, 
                             descripcion = @Descripcion, 
                             salario = @Salario, 
                             horalaboralInicio = @HoraDeInicio, 
                             diasLaborales = @DiasLaboral, 
                             codigoRol = @codiRol, 
                             estado = @Estado, 
                             horaLaboralTermina = @HoraDeFin
                         WHERE codigoPuesto = @codiPuesto";

                // Crear la conexión a la base de datos
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@codiPuesto", puestoUpdate.CodigoPuesto);
                    cmd.Parameters.AddWithValue("@Puesto", puestoUpdate.Puesto);
                    cmd.Parameters.AddWithValue("@Descripcion", puestoUpdate.Descripcion);
                    cmd.Parameters.AddWithValue("@Salario", puestoUpdate.Salario);
                    cmd.Parameters.AddWithValue("@HoraDeInicio", puestoUpdate.HoralaboralInicio);
                    cmd.Parameters.AddWithValue("@DiasLaboral", puestoUpdate.DiasLaborales);
                    cmd.Parameters.AddWithValue("@codiRol", puestoUpdate.CodigoRol);
                    cmd.Parameters.AddWithValue("@Estado", puestoUpdate.Estado);
                    cmd.Parameters.AddWithValue("@HoraDeFin", puestoUpdate.HoraLaboralTermina);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones
                throw new Exception("Error al actualizar el puesto: " + ex.Message);
            }
        }

        /* ------------------- EXTRAS ------------------------- */
        public static DataTable ObtenerPuestosDeEmpleadosParaComboBox()
        {
            DataTable dtPuestos = new DataTable();
            using (SqlConnection conn = new SqlConnection(con_string))
            {
                conn.Open();
                string query = "SELECT IdPuesto, puesto FROM Puestos Where codigoRol = 2 AND estado = 'ACTIVO'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dtPuestos);
                }
            }
            return dtPuestos;
        }
        public static DataTable ObtenerPuestosDeAdminsParaComboBox()
        {
            DataTable dtPuestos = new DataTable();
            using (SqlConnection conn = new SqlConnection(con_string))
            {
                conn.Open();
                string query = "SELECT IdPuesto, puesto FROM Puestos Where codigoRol = 1 AND estado = 'ACTIVO'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dtPuestos);
                }
            }
            return dtPuestos;
        }
        public static DataTable ObtenerRolesParaComboBox()
        {
            DataTable dtRoles = new DataTable();
            using (SqlConnection conn = new SqlConnection(con_string))
            {
                conn.Open();
                string query = "SELECT Id_Rol, Rol FROM Rol WHERE Id_Rol = 1 OR Id_Rol = 2;";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dtRoles);
                }
            }
            return dtRoles;
        }

    }
    
}

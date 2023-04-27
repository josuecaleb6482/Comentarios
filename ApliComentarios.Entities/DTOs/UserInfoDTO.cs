namespace ApiComentarios.Entities.DTOs
{
    /// <summary>
    /// User Object
    /// </summary>
    public class UserInfoDTO
    {
        /// <summary>
        /// Nombre del Usuario
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Rol Asignado
        /// </summary>
        public string Rol { get; set; }
        /// <summary>
        /// Correo del usuario, tambien usado cómo username
        /// </summary>
        public string Email { get; set; }
    }
}

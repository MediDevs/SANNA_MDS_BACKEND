namespace MDS.Dto.Resources
{
    public class UsuarioResource : ResourceParameter
    {
        public string usuario { get; set; } = "";
        public string persona { get; set; } = "";
        public string numero_documento { get; set; } = "";
        public string email { get; set; } = "";
    }
}

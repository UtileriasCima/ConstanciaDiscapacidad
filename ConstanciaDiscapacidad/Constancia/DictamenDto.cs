namespace ConstanciaDiscapacidad.Constancia
{
    public class DictamenDto
    {
        public string NumeroPermiso { get; set; }
        public byte[] Foto { get; set; }
        public string Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string Municipio { get; set; }
        public string Diagnostico { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Medico { get; set; }
        public string Cedula { get; set; }
        public bool IsPlacas { get; set; }
        
        public string NombreCompleto => $"{Nombre} {ApellidoPaterno} {ApellidoMaterno}";
    }
}
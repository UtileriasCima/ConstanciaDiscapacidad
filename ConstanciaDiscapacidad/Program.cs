using ConstanciaDiscapacidad.Constancia;
using ConstanciaDiscapacidad.Utilities;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace ConstanciaDiscapacidad 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            
            string imagePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\Images\\girl.jpg";
            
            byte[] image = Extensions.ImageToByteArray(imagePath);
            
            DictamenDto dictamen = new()
            {
                NumeroPermiso = "123456",
                Foto = image,
                Nombre = "Juan",
                ApellidoPaterno = "Perez",
                ApellidoMaterno = "Gomez",
                Municipio = "Juarez",
                Diagnostico = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                Observaciones = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                FechaEmision = DateTime.Now,
                Medico = "Dr. Medico",
                Cedula = "123456",
                IsPlacas = true
            };
            
            Designer caidas = new(dictamen);
            caidas.GeneratePdfAndShow();
        }
    }
}
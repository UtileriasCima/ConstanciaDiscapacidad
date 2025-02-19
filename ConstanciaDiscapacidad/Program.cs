using System.Globalization;
using ConstanciaDiscapacidad.Constancia;
using ConstanciaDiscapacidad.Utilities;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

namespace ConstanciaDiscapacidad 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            
            string imagePath = $@"{AppDomain.CurrentDomain.BaseDirectory}\Images\girl.jpg";
            
            CultureInfo culture = new("es-MX");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            
            byte[] image = Extensions.ImageToByteArray(imagePath);
            
            DictamenDto dictamen = new()
            {
                NumeroPermiso = "123456",
                Foto = image,
                Nombre = "Lorem ipsum dolor sit amet, consectetur adipiscing elit Lorem ipsum dolor sit amet, consectetur adipiscing elit Lorem ipsum dolor sit amet, consectetur adipiscing eli Lorem ipsum dolor sit amet, consectetur adipiscing elit scing elit Lorem ipsum dolor sit amet, consectetur adipiscing elit Lorem ipsum dolor sit amet, consectetur adipiscing eli Lorem ipsum dolor sit ur adipiscing elit Lorem ipsum dolor sit amet, consectetur adipiscing eli Lorem ipsum dolor sit",
                ApellidoPaterno = "De la Blanca",
                ApellidoMaterno = "Perez",
                Municipio = "Chihuahua",
                Diagnostico = "Lorem ipsum dolor sit amet, consectetur adipiscing elit Lorem ipsum dolor sit amet, consectetur adipiscing elit Lorem ipsum dolor sit amet, consectetur adipiscing eli Lorem ipsum dolor sit amet, consectetur adipiscing elit scing elit Lorem ipsum dolor sit amet, consectetur adipiscing elit Lorem ipsum dolor sit amet, consectetur adipiscing eli Lorem ipsum dolor sit ur adipiscing elit Lorem ipsum dolor sit amet, consectetur adipiscing eli Lorem ipsum dolor sit",
                Observaciones = "Lorem ipsum dolor sit amet, consectetur adipiscing elit Lorem ipsum dolor sit amet, consectetur adipiscing elit Lorem ipsum dolor sit amet, consectetur adipiscing eli Lorem ipsum dolor sit amet, consectetur adipiscing elit scing elit Lorem ipsum dolor sit amet, consectetur adipiscing elit Lorem ipsum dolor sit amet, consectetur adipiscing eli Lorem ipsum dolor sit ur adipiscing elit Lorem ipsum dolor sit amet, consectetur adipiscing eli Lorem ipsum dolor sit",
                FechaEmision = new DateTime(2021, 09, 10),
                Medico = "Ximena Mendoza Villanueva",
                Cedula = "12345698",
                IsPlacas = false
            };
            
            Designer caidas = new(dictamen);
            caidas.ShowInCompanion();
        }
    }
}
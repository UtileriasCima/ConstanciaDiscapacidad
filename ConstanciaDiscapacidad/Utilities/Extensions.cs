using System.Drawing;
using System.Drawing.Imaging;

namespace ConstanciaDiscapacidad.Utilities
{
    public class Extensions
    {
        public static byte[] ImageToByteArray(string imagePath)
        {
            // Cargar la imagen desde la ruta especificada
#pragma warning disable CA1416
            using Image image = Image.FromFile(imagePath);
#pragma warning restore CA1416

            using MemoryStream memoryStream = new();
            // Guardar la imagen en el MemoryStream en formato PNG (puedes cambiar el formato si es necesario)
            
#pragma warning disable CA1416
            image.Save(memoryStream, ImageFormat.Png);
#pragma warning restore CA1416
                
            // Convertir el MemoryStream a un arreglo de bytes
            return memoryStream.ToArray();
        }
    }
}
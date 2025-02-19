using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace ConstanciaDiscapacidad.Constancia
{
    public class Designer(DictamenDto dto) : IDocument
    {
        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.Letter);
                page.Margin(0); // Sin márgenes
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(12).FontFamily("Arial"));

                page.Content()
                    .Element(ComposeContent);
            });
        }

        private void ComposeContent(IContainer container)
        {
            container
                .Layers(layers =>
                {
                    layers
                        .PrimaryLayer()
                        .Image("Images/ConstanciaDiscapacidadV2.jpg")
                        .WithCompressionQuality(ImageCompressionQuality.Best);
                    
                    layers
                        .Layer()
                        .Element(element =>
                        {
                            element
                                .AlignCenter()
                                .AlignMiddle()
                                .Column(column =>
                                {
                                    // Numero Permiso
                                    column.Item().TranslateY(-289).TranslateX(87).Row(rowF =>
                                    {
                                        rowF.RelativeItem().Element(elementF =>
                                        {
                                            elementF.Text(dto.NumeroPermiso)
                                                .FontSize(12)
                                                .FontFamily("Arial").Bold()
                                                .FontColor(Colors.Red.Accent3);
                                        });
                                    });
                                });
                        });
                    
                    layers
                        .Layer()
                        .Element(element =>
                        {
                            element
                                .AlignCenter()
                                .AlignMiddle()
                                .Column(column =>
                                {
                                    // Foto
                                    column.Item().TranslateX(-223).TranslateY(-93).Width(105).Height(117).Image(dto.Foto)
                                        .WithCompressionQuality(ImageCompressionQuality.Best).FitUnproportionally();
                                });
                        });
                    
                    layers
                        .Layer()
                        .Element(element =>
                        {
                            element
                                .AlignCenter()
                                .AlignMiddle()
                                .Column(column =>
                                {
                                    int y = dto.IsPlacas ? -134 : -111;
                                    // Tipo Discapacidad
                                    column.Item().TranslateX(-142).TranslateY(y).Width(30).Image("Images/comprobado.png")
                                        .WithCompressionQuality(ImageCompressionQuality.Best);
                                });
                        });
                    
                    layers
                        .Layer()
                        .Element(element =>
                        {
                            element
                                .AlignCenter()
                                .AlignMiddle()
                                .Column(column =>
                                {
                                    // Municipio
                                    column.Item().TranslateX(-80).TranslateY(-90).Row(row =>
                                    {
                                        row.ConstantItem(120)
                                            .Background(Colors.Transparent)
                                            .Height(35)
                                            .Element(inner =>
                                            {
                                                string municipio = dto.Municipio;
                                                float fontSize = municipio.Length > 20 ? 12 : 13;
                                                inner.AlignBottom()
                                                    .Text(municipio)
                                                    .FontSize(fontSize)
                                                    .FontFamily("Arial")
                                                    .FontColor(Colors.Black)
                                                    .LineHeight(0.9f)
                                                    .AlignLeft()
                                                    .ClampLines(3, "..");
                                            });
                                    });
                                });
                        });
                    
                    layers
                        .Layer()
                        .Element(element =>
                        {
                            element
                                .AlignCenter()
                                .AlignMiddle()
                                .Column(column =>
                                {
                                    // Día
                                    column.Item().TranslateX(50).TranslateY(-80).Text(dto.FechaEmision.ToString("dd")).FontSize(12).FontFamily("Arial").FontColor(Colors.Black);
                                });
                        });
                    
                    layers
                        .Layer()
                        .Element(element =>
                        {
                            element
                                .AlignCenter()
                                .AlignMiddle()
                                .Column(column =>
                                {
                                    // Mes
                                    column.Item().TranslateX(115).TranslateY(-80).Text(dto.FechaEmision.ToString("MMMM")).FontSize(12).FontFamily("Arial").FontColor(Colors.Black);
                                });
                        });
                    
                    layers
                        .Layer()
                        .Element(element =>
                        {
                            element
                                .AlignCenter()
                                .AlignMiddle()
                                .Column(column =>
                                {
                                    // Año
                                    column.Item().TranslateX(185).TranslateY(-80).Text(dto.FechaEmision.ToString("yyyy")).FontSize(12).FontFamily("Arial").FontColor(Colors.Black);
                                });
                        });
                    
                    layers
                        .Layer()
                        .Element(element =>
                        {
                            element
                                .AlignCenter()
                                .AlignMiddle()
                                .Column(column =>
                                {
                                    // Nombre
                                    column.Item().TranslateX(-13).TranslateY(35).Row(row =>
                                    {
                                        row.ConstantItem(490)
                                            .Background(Colors.Transparent)
                                            .Height(60)
                                            .Element(inner =>
                                            {
                                                string nombre = dto.NombreCompleto;
                                                float fontSize = nombre.Length switch
                                                {
                                                    > 200 => 9,
                                                    > 100 => 10,
                                                    _ => 11
                                                };
                                                inner.AlignTop()
                                                    .Text(nombre)
                                                    .FontSize(fontSize)
                                                    .FontFamily("Arial")
                                                    .FontColor(Colors.Black)
                                                    .Underline()
                                                    .LineHeight(1.3f)
                                                    .Justify()
                                                    .ClampLines(5, "..");
                                            });
                                    });
                                });
                        });
                    
                    layers
                        .Layer()
                        .Element(element =>
                        {
                            element
                                .AlignCenter()
                                .AlignMiddle()
                                .Column(column =>
                                {
                                    // Diagnostico
                                    column.Item().TranslateX(-13).TranslateY(106).Row(row =>
                                    {
                                        row.ConstantItem(490)
                                            .Background(Colors.Transparent)
                                            .Height(60)
                                            .Element(inner =>
                                            {
                                                string diagnostico = dto.Diagnostico;
                                                float fontSize = diagnostico.Length switch
                                                {
                                                    > 200 => 9,
                                                    > 100 => 10,
                                                    _ => 11
                                                };
                                                inner.AlignTop()
                                                    .Text(diagnostico)
                                                    .FontSize(fontSize)
                                                    .FontFamily("Arial")
                                                    .FontColor(Colors.Black)
                                                    .Underline()
                                                    .LineHeight(1.3f)
                                                    .Justify()
                                                    .ClampLines(5, "..");
                                            });
                                    });
                                });
                        });
                    
                    layers
                        .Layer()
                        .Element(element =>
                        {
                            element
                                .AlignCenter()
                                .AlignMiddle()
                                .Column(column =>
                                {
                                    // Observaciones
                                    column.Item().TranslateX(-13).TranslateY(176).Row(row =>
                                    {
                                        row.ConstantItem(490)
                                            .Background(Colors.Transparent)
                                            .Height(60)
                                            .Element(inner =>
                                            {
                                                string observaciones = dto.Observaciones;
                                                float fontSize = observaciones.Length switch
                                                {
                                                    > 200 => 9,
                                                    > 100 => 10,
                                                    _ => 11
                                                };
                                                inner.AlignTop()
                                                    .Text(observaciones)
                                                    .FontSize(fontSize)
                                                    .FontFamily("Arial")
                                                    .FontColor(Colors.Black)
                                                    .Underline()
                                                    .LineHeight(1.3f)
                                                    .Justify()
                                                    .ClampLines(4, "..");
                                            });
                                    });
                                });
                        });
                    
                    layers
                        .Layer()
                        .Element(element =>
                        {
                            element
                                .AlignCenter()
                                .AlignMiddle()
                                .Column(column =>
                                {
                                    // Medico
                                    column.Item().TranslateX(132).TranslateY(284).Row(row =>
                                    {
                                        row.ConstantItem(180)
                                            .Background(Colors.Transparent)
                                            .Height(16)
                                            .Element(inner =>
                                            {
                                                string medico = dto.Medico;
                                                float fontSize = medico.Length > 20 ? 10 : 11;
                                                inner.AlignBottom()
                                                    .Text(medico)
                                                    .FontSize(fontSize)
                                                    .FontFamily("Arial")
                                                    .FontColor(Colors.Black)
                                                    .LineHeight(0.8f)
                                                    .AlignLeft()
                                                    .ClampLines(2, "..");
                                            });
                                    });
                                });
                        });
                    
                    layers
                        .Layer()
                        .Element(element =>
                        {
                            element
                                .AlignCenter()
                                .AlignMiddle()
                                .Column(column =>
                                {
                                    // Cedula
                                    column.Item().TranslateX(132).TranslateY(305).Row(row =>
                                    {
                                        row.ConstantItem(180)
                                            .Background(Colors.Transparent)
                                            .Height(16)
                                            .Element(inner =>
                                            {
                                                string cedula = dto.Cedula;
                                                float fontSize = cedula.Length > 20 ? 10 : 11;
                                                inner.AlignBottom()
                                                    .Text(cedula)
                                                    .FontSize(fontSize)
                                                    .FontFamily("Arial")
                                                    .FontColor(Colors.Black)
                                                    .LineHeight(0.8f)
                                                    .AlignLeft()
                                                    .ClampLines(2, "..");
                                            });
                                    });
                                });
                        });
                });
        }
    }
}
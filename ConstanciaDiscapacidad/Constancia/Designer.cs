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
                        .Image("resources/Images/Caidas/ConstanciaPCD.jpg")
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
                                    column.Item().TranslateY(-247).TranslateX(82).Row(rowF =>
                                    {
                                        rowF.RelativeItem().Element(elementF =>
                                        {
                                            elementF.Text(dto.NumeroPermiso).FontSize(12).FontFamily("Arial").Bold()
                                                .FontColor(Colors.Black);
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
                                    column.Item().TranslateX(-223).TranslateY(-83).Width(105).Height(117).Image(dto.Foto)
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
                                    int y = dto.IsPlacas ? -119 : -97;
                                    // Tipo Discapacidad
                                    column.Item().TranslateX(-130).TranslateY(y).Width(30).Image("resources/Images/Dictamen/comprobado.png")
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
                                    column.Item().TranslateX(-80).TranslateY(-65).Row(row =>
                                    {
                                        row.ConstantItem(120)
                                            .Background(Colors.Transparent)
                                            .Height(35)
                                            .Element(inner =>
                                            {
                                                string municipio = dto.Municipio;
                                                float fontSize = municipio.Length > 20 ? 14 : 18;
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
                                    column.Item().TranslateX(70).TranslateY(-55).Text(dto.FechaEmision.ToString("dd")).FontSize(15).FontFamily("Arial").FontColor(Colors.Black);
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
                                    column.Item().TranslateX(150).TranslateY(-55).Text(dto.FechaEmision.ToString("MMMM")).FontSize(15).FontFamily("Arial").FontColor(Colors.Black);
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
                                    column.Item().TranslateX(240).TranslateY(-55).Text(dto.FechaEmision.ToString("yyyy")).FontSize(15).FontFamily("Arial").FontColor(Colors.Black);
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
                                    column.Item().TranslateX(0).TranslateY(42).Row(row =>
                                    {
                                        row.ConstantItem(540)
                                            .Background(Colors.Transparent)
                                            .Height(50)
                                            .Element(inner =>
                                            {
                                                string nombre = dto.NombreCompleto;
                                                float fontSize = nombre.Length switch
                                                {
                                                    > 250 => 9,
                                                    > 200 => 10,
                                                    > 150 => 11,
                                                    > 100 => 12,
                                                    > 50 => 14,
                                                    _ => 14
                                                };
                                                inner.AlignTop()
                                                    .Text(nombre)
                                                    .FontSize(fontSize)
                                                    .FontFamily("Arial")
                                                    .FontColor(Colors.Black)
                                                    .LineHeight(1.3f)
                                                    .Justify()
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
                                    // Diagnostico
                                    column.Item().TranslateX(0).TranslateY(108).Row(row =>
                                    {
                                        row.ConstantItem(540)
                                            .Background(Colors.Transparent)
                                            .Height(50)
                                            .Element(inner =>
                                            {
                                                string diagnostico = dto.Diagnostico;
                                                float fontSize = diagnostico.Length switch
                                                {
                                                    > 250 => 9,
                                                    > 200 => 10,
                                                    > 150 => 11,
                                                    > 100 => 12,
                                                    > 50 => 14,
                                                    _ => 14
                                                };
                                                inner.AlignTop()
                                                    .Text(diagnostico)
                                                    .FontSize(fontSize)
                                                    .FontFamily("Arial")
                                                    .FontColor(Colors.Black)
                                                    .LineHeight(1.3f)
                                                    .Justify()
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
                                    // Observaciones
                                    column.Item().TranslateX(0).TranslateY(166).Row(row =>
                                    {
                                        row.ConstantItem(540)
                                            .Background(Colors.Transparent)
                                            .Height(50)
                                            .Element(inner =>
                                            {
                                                string observaciones = dto.Observaciones;
                                                float fontSize = observaciones.Length switch
                                                {
                                                    > 250 => 9,
                                                    > 200 => 10,
                                                    > 150 => 11,
                                                    > 100 => 12,
                                                    > 50 => 14,
                                                    _ => 14
                                                };
                                                inner.AlignTop()
                                                    .Text(observaciones)
                                                    .FontSize(fontSize)
                                                    .FontFamily("Arial")
                                                    .FontColor(Colors.Black)
                                                    .LineHeight(1.3f)
                                                    .Justify()
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
                                    // Medico
                                    column.Item().TranslateX(188).TranslateY(304).Row(row =>
                                    {
                                        row.ConstantItem(130)
                                            .Background(Colors.Transparent)
                                            .Height(16)
                                            .Element(inner =>
                                            {
                                                string medico = dto.Medico;
                                                float fontSize = medico.Length > 20 ? 9 : 13;
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
                                    column.Item().TranslateX(210).TranslateY(320).Row(row =>
                                    {
                                        row.ConstantItem(100)
                                            .Background(Colors.Transparent)
                                            .Height(16)
                                            .Element(inner =>
                                            {
                                                string cedula = dto.Cedula;
                                                float fontSize = cedula.Length > 20 ? 9 : 13;
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
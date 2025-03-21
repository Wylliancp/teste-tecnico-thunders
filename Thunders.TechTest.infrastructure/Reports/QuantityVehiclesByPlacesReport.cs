using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using Thunders.TechTest.Domain.Entities;

namespace Thunders.TechTest.infrastructure.Reports;

public class QuantityVehiclesByPlacesReport : IDocument
{
    public int Quantity { get; set; }
    public string Places { get; set; }
    public QuantityVehiclesByPlacesReport(int quantity, string places)
    {
        QuestPDF.Settings.License = LicenseType.Community;
        Quantity = quantity;
        Places = places;
    }

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Margin(5);
            page.Header()
                .AlignCenter()
                .Text($"Tolls relatorios - Quantos tipos de veículos passaram em uma determinada praça : {Places}")
                .FontSize(24)
                .SemiBold();
            
            page.Content().Column(col =>
            {
                col.Spacing(5);
                col.Item().Text($"Quantidade: {Quantity}");
                col.Item().Text($"Data Relatorio : {DateTime.UtcNow:g}");
            });
        });
    }
}
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using Thunders.TechTest.Domain.Entities;

namespace Thunders.TechTest.infrastructure.Reports;

public class TotalValueByStateReport : IDocument
{
    public decimal Value { get; set; }
    public string City { get; set; }
    public TotalValueByStateReport(decimal value, string city)
    {
        QuestPDF.Settings.License = LicenseType.Community;
        Value = value;
        City = city;
    }

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Margin(5);
            page.Header()
                .AlignCenter()
                .Text($"Tolls relatorios: - Valor total por hora por cidade \n: {City}")
                .FontSize(24)
                .SemiBold();
            
            page.Content().Column(col =>
            {
                col.Spacing(5);
                col.Item().Text($"Valor total: {Value}");
                col.Item().Text($"Data Relatorio : {DateTime.UtcNow:g}");
            });
        });
    }
}
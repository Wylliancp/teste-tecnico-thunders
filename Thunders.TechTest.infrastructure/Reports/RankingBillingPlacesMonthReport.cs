using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using Thunders.TechTest.Domain.Entities;

namespace Thunders.TechTest.infrastructure.Reports;

public class RankingBillingPlacesMonthReport : IDocument
{
    public Toll Model { get; set; }
    public RankingBillingPlacesMonthReport(Toll model)
    {
        QuestPDF.Settings.License = LicenseType.Community;
        Model = model;
    }

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Margin(5);
            page.Header()
                .AlignCenter()
                .Text($"Tolls relatorios da Praca: {Model.Place}")
                .FontSize(24)
                .SemiBold();
            
            page.Content().Column(col =>
            {
                col.Spacing(5);
                col.Item().Text($"Cidade: {Model.City}");
                col.Item().Text($"Estado: {Model.State}");
                col.Item().Text($"Valor: {Model.County}");
                col.Item().Text($"Tipo de veiculo: {Model.TypeCar}");
                col.Item().Text($"Data de Criacao : {Model.dateCreate:g}");
                
                
                col.Item().Text($"Data Relatorio : {DateTime.UtcNow:g}");

            });
        });
    }
}
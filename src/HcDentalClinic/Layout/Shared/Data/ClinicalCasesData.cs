namespace HcDentalClinic.Layout.Shared.Data;

public static class ClinicalCasesData
{
    public static List<ClinicalCase> Cases =>
    [
        // TODO(cliente): rever e substituir os textos de exemplo pelas descrições reais do caso.
        new ClinicalCase
        {
            Slug = "ortodontia-1",
            Title = "Ortodontia — Alinhamento Dentário",
            Summary = "Correção do alinhamento dos dentes e da mordida, com resultados visíveis no sorriso e na função mastigatória.",
            Paragraphs =
            [
                "Este caso clínico acompanhou um paciente com apinhamento dentário e desalinhamento da mordida. Após uma consulta de avaliação completa, com registos fotográficos e estudo do caso, foi definido um plano de tratamento ortodôntico personalizado.",
                "Ao longo do tratamento, o paciente foi acompanhado em consultas regulares de controlo, garantindo que cada fase decorria conforme o planeado e com o máximo conforto.",
                "O resultado final, visível nas fotografias de antes e depois, reflete não só a melhoria estética do sorriso, mas também ganhos funcionais na mastigação e na higiene oral diária."
            ],
            Images =
            [
                new ClinicalCaseImage { Src = "images/cases/1/front.webp", Alt = "Vista frontal do sorriso — antes e depois do tratamento de ortodontia" },
                new ClinicalCaseImage { Src = "images/cases/1/side.webp",  Alt = "Vista lateral do sorriso — antes e depois do tratamento de ortodontia" },
                new ClinicalCaseImage { Src = "images/cases/1/teeth.webp", Alt = "Vista dos dentes — antes e depois do tratamento de ortodontia" }
            ]
        }
        // TODO: adicionar o segundo caso clínico quando as fotografias estiverem disponíveis em wwwroot/images/cases/2/
    ];

    public static ClinicalCase? FindBySlug(string? slug) =>
        Cases.FirstOrDefault(c => string.Equals(c.Slug, slug, StringComparison.OrdinalIgnoreCase));
}

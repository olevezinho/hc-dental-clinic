namespace HcDentalClinic.Layout.Shared.Data;

public static class GoogleReviewsData
{
    public static List<GoogleReview> Reviews =>
    [
        new GoogleReview
        {
            AuthorName = "Micael Miranda",
            Rating = 5,
            Text = "A excelência vê-se nos detalhes. Profissionalismo, precisão e qualidade do início ao fim. Um espaço de tranquilidade absoluta, com um ambiente quase de spa, onde cada momento transmite conforto e bem-estar. Uma verdadeira referência na sua área."
        },
        new GoogleReview
        {
            AuthorName = "Alexandra Pereira",
            Rating = 5,
            Text = "Espaço lindo, acolhedor e muito bem cuidado. Profissionais extremamente qualificados, competentes e atenciosos. O atendimento é excelente, sempre com muita simpatia e profissionalismo. Recomendo"
        },
        new GoogleReview
        {
            AuthorName = "Dina Peixoto",
            Rating = 5,
            Text = "Consulta com o meu filho que acabou por ser uma experiência maravilhosa. Sem dúvida um serviço premium. Obrigada"
        }
    ];
}

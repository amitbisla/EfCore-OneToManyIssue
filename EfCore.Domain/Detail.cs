namespace EfCore.Domain
{
    public class Detail
    {

        public int Id { get; set; }

        public int ScenarioId { get; set; }

        public string Description { get; set; }


        public int ProductId { get; set; }
        public int Year { get; set; }
        public string EntityCode { get; set; }

        public Product Product { get; set; }

       // public Scenario Scenario { get; set; }


    }
}
namespace ProjectApiRestDapper.Queries
{
    public class ProductQueries
    {
        public const string LISTAR =
            @"SELECT Id, Name, Price, Quantity FROM product";

        public const string INSERIR =
           @"INSERT INTO product (Id, 
                                    Name, 
                                    Price, 
                                    Quantity)
                         VALUES (@Nome,
                                    @Id, 
                                    @Name, 
                                    @Price, 
                                    @Quantity;";

    }
}

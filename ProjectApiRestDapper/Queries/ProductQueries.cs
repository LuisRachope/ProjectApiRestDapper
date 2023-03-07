namespace ProjectApiRestDapper.Queries
{
    public class ProductQueries
    {
        public const string LISTAR =
            @"SELECT Id, 
                     Name, 
                     Price, 
                     Quantity
              FROM product";

        public const string OBTER =
            @"SELECT Id, 
                     Name, 
                     Price, 
                     Quantity 
              FROM product 
              WHERE Id=@id";

        public const string INSERIR =
           @"INSERT INTO product (Name, 
                                  Price,
                                  Quantity)
             VALUES (@Name, 
                     @Price, 
                     @Quantity);";

        public const string ATUALIZAR =
           @"UPDATE product 
             SET Name = @Name, 
                 Price = @Price, 
                 Quantity = @Quantity 
             WHERE Id=@Id";

        public const string APAGAR =
            @"DELETE FROM Product 
              WHERE Id=@Id";
    }
}

namespace ProjectApiRestDapper.Queries
{
    public class CustomerQueries
    {
        public const string LISTAR =
            @"SELECT c.Id as Id, 
                        c.Name, 
                        c.Email, 
                        c.ProductId,
                        p.Id as Id, 
                        p.Name, 
                        p.Price, 
                        p.Quantity
            FROM customer c
            LEFT JOIN product p ON p.Id = c.ProductId;";

        public const string BUSCAR =
            @"SELECT c.Id as Id, 
                        c.Name, 
                        c.Email, 
                        c.ProductId,
                        p.Id as Id, 
                        p.Name, 
                        p.Price, 
                        p.Quantity
            FROM customer c
            LEFT JOIN product p ON p.Id = c.ProductId
            WHERE c.Id=@Id";

        public const string CRIAR =
                @"INSERT INTO customer (
                        Name,
                        Email, 
                        ProductId) 
                VALUES (@Name, 
                        @Email, 
                        @ProductId);";
    }
}


namespace WebshopAPI.Lib.Services
{
    public class OrderManagerService
    {
        public OrderManagerService() { }

        public async Task AddOrder(Order order, string _currentUser)
        {
            ObjectValidatorService<Order> orderValid = new ObjectValidatorService<Order>(order);
            orderValid.IsValid();

            using (SQL sql = new SQL())
            {
                order.Products.ToList().ForEach(product =>
                {
                    if (!sql.Products.Any(a => a.ID == product.ProductID))
                    {
                        throw new ProductNotFoundException();
                    }
                });

                var _order = new Order()
                {
                    UserEmail = _currentUser,
                    Address = order.Address,
                    Payment = order.Payment,
                    Status = EStatus.PROCESSING,
                    TotalPrice = order.Products.Sum(a => a.PricePerUnit * a.Quantity),
                    OrderDate = order.OrderDate,
                };
                await sql.Orders.AddAsync(_order);
                await sql.SaveChangesAsync();

                order.Products.Where(a => a.Quantity > 0).ToList().ForEach(orderProduct =>
                {
                    var _orderProduct = new OrderedProduct()
                    {
                        OrderID = _order.ID,
                        ProductID = orderProduct.ProductID,
                        Quantity = orderProduct.Quantity,
                        PricePerUnit = orderProduct.PricePerUnit,
                    };
                    sql.OrderedProducts.Add(_orderProduct);
                    sql.SaveChanges();
                });
            }
        }

        public async Task UpdateOrder(Order order)
        {
            ObjectValidatorService<Order> orderValid = new ObjectValidatorService<Order>(order);
            orderValid.IsValid();

            using (SQL sql = new SQL())
            {
                if (!sql.Orders.Any(a => a.ID == order.ID))
                {
                    throw new OrderNotFoundException();
                }

                var oldOrder = sql.Orders.Single(a => a.ID == order.ID);

                oldOrder.Address = order.Address;
                oldOrder.Payment = order.Payment;
                oldOrder.Status = order.Status;
                oldOrder.TotalPrice = order.Products.Sum(a => a.PricePerUnit * a.Quantity);
                await sql.SaveChangesAsync();

                order.Products.ToList().ToList().ForEach(orderProduct =>
                {
                    var oldOrderedProduct = sql.OrderedProducts.Single(a => a.OrderID == oldOrder.ID);
                    oldOrderedProduct.Quantity = orderProduct.Quantity;

                    sql.SaveChanges();

                });
            }
        }

    }
}

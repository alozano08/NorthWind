using FluentValidation;
using NorthWind.Entities.Exceptions;
using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOEntities;
using NorthWind.UseCases.Common.Validator;
using NorthWind.UseCasesDTOs.CreateOrder;
using NorthWind.UseCasesPorts.CreateOrder;

namespace NorthWind.UseCases.CreateOrder
{
    public class CreateOrderInteractor : ICreateOrderInputPort
    {
        readonly IOrderRepository OrderRepository;
        readonly IOrderDetailRepository OrderDetailRepository;
        readonly IUnitOfWork UnitOfWork;
        readonly ICreateOrderOutputPort OutputPort;
        readonly IEnumerable<IValidator<CreateOrderParams>> Validator;

        public CreateOrderInteractor(IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IUnitOfWork unitOfWork,
            ICreateOrderOutputPort outputPort,
            IEnumerable<IValidator<CreateOrderParams>> validator) =>
            (OrderRepository, OrderDetailRepository, UnitOfWork, OutputPort, Validator) =
            (orderRepository, orderDetailRepository, unitOfWork, outputPort, validator);

        public async Task Handle(CreateOrderParams order)
        {
            await Validator<CreateOrderParams>.Validate(order, Validator);

            Order Order = new Order
            {
                CustomerId = order.CustomerId,
                OderDate = DateTime.Now,
                ShipAddress = order.ShipAdress,
                ShipCity = order.ShipCity,
                ShipCountry = order.ShipCountry,
                ShipPostalCode = order.ShipPostalCode,
                DiscountType = Entities.Enums.DiscountType.Percentage,
                Discount = 10,
                ShippingType = Entities.Enums.ShippingType.Road
            };

            OrderRepository.Create(Order);

            foreach (var Item in order.OderDetails)
            {
                OrderDetailRepository.Create(
                    new OrderDetail
                    {
                        Order = Order,
                        ProductId = Item.ProductId,
                        UnitPrice = Item.UnitPrice,
                        Quantity = Item.Quantity
                    });
            }

            try
            {
                await UnitOfWork.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al crear la Orden.", ex.Message);
            }

           await OutputPort.Handle(Order.Id);

        }
    }
}
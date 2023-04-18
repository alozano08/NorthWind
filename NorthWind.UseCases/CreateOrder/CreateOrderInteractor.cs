﻿using MediatR;
using NorthWind.Entities.Exceptions;
using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.UseCases.CreateOrder
{
    public class CreateOrderInteractor : AsyncRequestHandler<CreateOrderInputPort>
    {
        readonly IOrderRepository OrderRepository;
        readonly IOrderDetailRepository OrderDetailRepository;
        readonly IUnitOfWork UnitOfWork;

        public CreateOrderInteractor(IOrderRepository orderRepository, 
            IOrderDetailRepository orderDetailRepository, 
            IUnitOfWork unitOfWork) =>
            (OrderRepository, OrderDetailRepository, UnitOfWork) = 
            (orderRepository,orderDetailRepository, unitOfWork);        

        protected async override Task Handle(CreateOrderInputPort request,
            CancellationToken cancellationToken)
        {
            Order Order = new Order
            {
                CustomerId = request.RequestData.CustomerId,
                OrderDate = DateTime.Now,
                ShipAddress = request.RequestData.ShipAdress,
                ShipCity = request.RequestData.ShipCity,
                ShipCountry = request.RequestData.ShipCountry,
                ShipPostalCode = request.RequestData.ShipPostalCode,
                DiscountType = Entities.Enums.DiscountType.Percentage,
                Discount = 10,
                ShippingType = Entities.Enums.ShippingType.Road
            };

            OrderRepository.Create(Order);

            foreach (var Item in request.RequestData.OderDetails)
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

            request.OutputPort.Handle(Order.Id);
        }
    }
}
﻿using Machine.Specifications;
using ShopifySharp.Tests.Test_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopifySharp.Tests
{
    [Subject(typeof(OrderService))]
    public class When_getting_an_order
    {
        Establish context = () =>
        {
            Service = new OrderService(Utils.MyShopifyUrl, Utils.AccessToken);
            Order = Service.CreateAsync(OrderCreation.GenerateOrder()).Await().AsTask.Result;
        };

        Because of = () =>
        {
            Order = Service.GetAsync(Order.Id.Value).Await().AsTask.Result;
        };

        It should_get_an_order = () =>
        {
            Order.ShouldNotBeNull();
        };

        Cleanup after = () =>
        {
            Service.DeleteAsync(Order.Id.Value).Await();
        };

        static OrderService Service;
        static Order Order;
    }
}

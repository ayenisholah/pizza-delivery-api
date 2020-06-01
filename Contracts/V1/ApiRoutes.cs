using System;
namespace DeliveryAPI.Contracts
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class Orders
        {
            public const string GetAll = Base + "/orders";

            public const string Get = Base + "/orders/{orderId}";

            public const string Update = Base + "/orders/{orderId}";

            public const string Delete = Base + "/orders/{orderId}";

            public const string Create = Base + "/orders";
        }
    }
}

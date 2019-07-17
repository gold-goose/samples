﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.21030.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Original file name:
// Generation date: 11/20/2009 1:47:48 PM
namespace CustomDataServiceClient.OrderItems
{
    
    /// <summary>
    /// There are no comments for OrderItemData in the schema.
    /// </summary>
    public partial class OrderItemData : global::System.Data.Services.Client.DataServiceContext
    {
        /// <summary>
        /// Initialize a new OrderItemData object.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public OrderItemData(global::System.Uri serviceRoot) : 
                base(serviceRoot)
        {
            this.ResolveName = new global::System.Func<global::System.Type, string>(this.ResolveNameFromType);
            this.ResolveType = new global::System.Func<string, global::System.Type>(this.ResolveTypeFromName);
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// Since the namespace configured for this service reference
        /// in Visual Studio is different from the one indicated in the
        /// server schema, use type-mappers to map between the two.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected global::System.Type ResolveTypeFromName(string typeName)
        {
            if (typeName.StartsWith("CustomDataServiceClient", global::System.StringComparison.Ordinal))
            {
                return this.GetType().Assembly.GetType(string.Concat("CustomDataServiceClient.OrderItems", typeName.Substring(23)), false);
            }
            return null;
        }
        /// <summary>
        /// Since the namespace configured for this service reference
        /// in Visual Studio is different from the one indicated in the
        /// server schema, use type-mappers to map between the two.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected string ResolveNameFromType(global::System.Type clientType)
        {
            if (clientType.Namespace.Equals("CustomDataServiceClient.OrderItems", global::System.StringComparison.Ordinal))
            {
                return string.Concat("CustomDataServiceClient.", clientType.Name);
            }
            return null;
        }
        /// <summary>
        /// There are no comments for Orders in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Order> Orders
        {
            get
            {
                if ((this._Orders == null))
                {
                    this._Orders = base.CreateQuery<Order>("Orders");
                }
                return this._Orders;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Order> _Orders;
        /// <summary>
        /// There are no comments for Items in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Item> Items
        {
            get
            {
                if ((this._Items == null))
                {
                    this._Items = base.CreateQuery<Item>("Items");
                }
                return this._Items;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Item> _Items;
        /// <summary>
        /// There are no comments for Orders in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToOrders(Order order)
        {
            base.AddObject("Orders", order);
        }
        /// <summary>
        /// There are no comments for Items in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToItems(Item item)
        {
            base.AddObject("Items", item);
        }
    }
    /// <summary>
    /// There are no comments for CustomDataServiceClient.Order in the schema.
    /// </summary>
    /// <KeyProperties>
    /// OrderId
    /// </KeyProperties>
    [global::System.Data.Services.Common.DataServiceKeyAttribute("OrderId")]
    public partial class Order
    {
        /// <summary>
        /// Create a new Order object.
        /// </summary>
        /// <param name="orderId">Initial value of OrderId.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Order CreateOrder(int orderId)
        {
            Order order = new Order();
            order.OrderId = orderId;
            return order;
        }
        /// <summary>
        /// There are no comments for Property OrderId in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int OrderId
        {
            get
            {
                return this._OrderId;
            }
            set
            {
                this.OnOrderIdChanging(value);
                this._OrderId = value;
                this.OnOrderIdChanged();
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _OrderId;
        partial void OnOrderIdChanging(int value);
        partial void OnOrderIdChanged();
        /// <summary>
        /// There are no comments for Property Customer in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Customer
        {
            get
            {
                return this._Customer;
            }
            set
            {
                this.OnCustomerChanging(value);
                this._Customer = value;
                this.OnCustomerChanged();
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Customer;
        partial void OnCustomerChanging(string value);
        partial void OnCustomerChanged();
        /// <summary>
        /// There are no comments for Items in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Collections.ObjectModel.Collection<Item> Items
        {
            get
            {
                return this._Items;
            }
            set
            {
                if ((value != null))
                {
                    this._Items = value;
                }
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Collections.ObjectModel.Collection<Item> _Items = new global::System.Collections.ObjectModel.Collection<Item>();
    }
    /// <summary>
    /// There are no comments for CustomDataServiceClient.Item in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Product
    /// </KeyProperties>
    [global::System.Data.Services.Common.DataServiceKeyAttribute("Product")]
    public partial class Item
    {
        /// <summary>
        /// Create a new Item object.
        /// </summary>
        /// <param name="product">Initial value of Product.</param>
        /// <param name="quantity">Initial value of Quantity.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Item CreateItem(string product, int quantity)
        {
            Item item = new Item();
            item.Product = product;
            item.Quantity = quantity;
            return item;
        }
        /// <summary>
        /// There are no comments for Property Product in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Product
        {
            get
            {
                return this._Product;
            }
            set
            {
                this.OnProductChanging(value);
                this._Product = value;
                this.OnProductChanged();
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Product;
        partial void OnProductChanging(string value);
        partial void OnProductChanged();
        /// <summary>
        /// There are no comments for Property Quantity in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int Quantity
        {
            get
            {
                return this._Quantity;
            }
            set
            {
                this.OnQuantityChanging(value);
                this._Quantity = value;
                this.OnQuantityChanged();
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _Quantity;
        partial void OnQuantityChanging(int value);
        partial void OnQuantityChanged();
    }
}

using System;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;
using Task.DB;

namespace Task.Surrogates
{
    /// <summary>
    /// Represents a <see cref="OrderDataContractSurrogate"/> class
    /// </summary>
    public class OrderDataContractSurrogate : IDataContractSurrogate
    {
        /// <summary>
        /// Get object to serialize.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="targetType">The target type.</param>
        /// <returns>The <see cref="object"/></returns>
        public object GetObjectToSerialize(object obj, Type targetType)
        {
            switch (obj)
            {
                case Order order:
                    return GetOrderToSerialize(order);
                case Order_Detail orderDetail:
                    return GetOrderDetailToSerialize(orderDetail);
                case Customer customer:
                    return GetCustomerToSerialize(customer);
                case Employee employee:
                    return GetEmployeeToSerialize(employee);
                case Shipper shipper:
                    return GetShipperToSerialize(shipper);
                default:
                    return obj;
            }
        }

        ///<inheritdoc/>
        public Type GetDataContractType(Type type)
        {
            return type;
        }

        ///<inheritdoc/>
        public object GetDeserializedObject(object obj, Type targetType)
        {
            return obj;
        }

        #region Not implement public methods 

        ///<inheritdoc/>
        public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public CodeTypeDeclaration ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Get order to serialize.
        /// </summary>
        /// <param name="order">The <see cref="Order"/></param> instance.
        /// <returns>The <see cref="object"/></returns>
        private object GetOrderToSerialize(Order order)
        {
            return new Order
            {
                OrderID = order.OrderID,
                CustomerID = order.CustomerID,
                EmployeeID = order.EmployeeID,
                OrderDate = order.OrderDate,
                RequiredDate = order.RequiredDate,
                ShippedDate = order.ShippedDate,
                ShipVia = order.ShipVia,
                Freight = order.Freight,
                ShipName = order.ShipName,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipRegion = order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry,
                Employee = order.Employee,
                Customer = order.Customer,
                Order_Details = order.Order_Details,
                Shipper = order.Shipper
            };
        }

        /// <summary>
        /// Get order_detail
        /// </summary>
        /// <param name="orderDetail">The order detail.</param>
        /// <returns>The <see cref="object"/></returns>
        private object GetOrderDetailToSerialize(Order_Detail orderDetail)
        {
            return new Order_Detail
            {
                OrderID = orderDetail.OrderID,
                ProductID = orderDetail.ProductID,
                UnitPrice = orderDetail.UnitPrice,
                Quantity = orderDetail.Quantity,
                Discount = orderDetail.Discount,
                Order = null,
                Product = null
            };
        }

        /// <summary>
        /// Get customer info.
        /// </summary>
        /// <param name="customer">The customer info.</param>
        /// <returns>The <see cref="object"/></returns>
        private object GetCustomerToSerialize(Customer customer)
        {
            return new Customer
            {
                CustomerID = customer.CustomerID,
                ContactName = customer.ContactName,
                CompanyName = customer.CompanyName,
                ContactTitle = customer.ContactTitle,
                Address = customer.Address,
                City = customer.City,
                Region = customer.Region,
                PostalCode = customer.PostalCode,
                Country = customer.Country,
                Phone = customer.Phone,
                Fax = customer.Fax,
                CustomerDemographics = customer.CustomerDemographics,
                Orders = null
            };
        }

        /// <summary>
        /// Get employee info.
        /// </summary>
        /// <param name="employee">The employee info.</param>
        /// <returns>The <see cref="object"/></returns>
        private object GetEmployeeToSerialize(Employee employee)
        {
            return new Employee
            {
                EmployeeID = employee.EmployeeID,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Title = employee.Title,
                TitleOfCourtesy = employee.TitleOfCourtesy,
                BirthDate = employee.BirthDate,
                HireDate = employee.HireDate,
                Address = employee.Address,
                City = employee.City,
                Region = employee.Region,
                PostalCode = employee.PostalCode,
                Country = employee.Country,
                HomePhone = employee.HomePhone,
                Extension = employee.Extension,
                Photo = employee.Photo,
                Notes = employee.Notes,
                ReportsTo = employee.ReportsTo,
                PhotoPath = employee.PhotoPath,
                Employees1 = null,
                Employee1 = null,
                Orders = null,
                Territories = null,
            };
        }

        /// <summary>
        /// Get shipper info.
        /// </summary>
        /// <param name="shipper">The shipper info.</param>
        /// <returns>The <see cref="object"/></returns>
        private object GetShipperToSerialize(Shipper shipper)
        {
            return new Shipper
            {
                ShipperID = shipper.ShipperID,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone,
                Orders = null,
            };
        }

        #endregion
    }
}

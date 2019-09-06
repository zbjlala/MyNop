using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// Represents a shopping cart type
    /// 表示购物车类型
    /// </summary>
    public enum ShoppingCartType
    {
        /// <summary>
        /// Shopping cart
        /// </summary>
        ShoppingCart = 1,

        /// <summary>
        /// Wishlist
        /// </summary>
        Wishlist = 2
    }
}

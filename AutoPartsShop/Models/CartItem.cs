﻿namespace AutoPartsShop.Models
{
    /// <summary>
    /// Model with the Cart Item object and properties.
    /// </summary>
    public class CartItem
    {
        public int CartItemId { get; set; }
        public string CartId { get; set; }
        public Part Part { get; set; }
        public int Quantity { get; set; }
    }
}

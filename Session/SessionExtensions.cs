using CS5227_A1_ABDUL36302.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

public static class SessionExtensions
{
    public static void SetCart(this ISession session, List<CartItem> cart)
    {
        session.SetString("cart", string.Join(",", cart.Select(ci => $"{ci.FoodItemId}|{ci.Name}|{ci.Price}|{ci.Quantity}")));
    }

    public static List<CartItem> GetCart(this ISession session)
    {
        var cartString = session.GetString("cart");
        if (string.IsNullOrEmpty(cartString))
        {
            return new List<CartItem>();
        }

        return cartString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                         .Select(ci => ci.Split('|'))
                         .Select(parts => new CartItem
                         {
                             FoodItemId = int.Parse(parts[0]),
                             Name = parts[1],
                             Price = decimal.Parse(parts[2]),
                             Quantity = int.Parse(parts[3])
                         })
                         .ToList();
    }
}

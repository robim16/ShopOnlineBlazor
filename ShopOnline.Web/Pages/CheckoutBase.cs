﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;
using System.Globalization;

namespace ShopOnline.Web.Pages
{
    public class CheckoutBase:ComponentBase
    {
        [Inject]
        public IJSRuntime Js { get; set; }
        protected IEnumerable<CartItemDto> ShoppingCartItems { get; set; }
        protected int TotalQty { get; set; }
        protected string PaymentDescription { get; set; }
        protected decimal PaymentAmount { get; set; }

        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }

        [Inject]
        public IManageCartItemsLocalStorageService ManageCartItemsLocalStorageService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                
                ShoppingCartItems = await ManageCartItemsLocalStorageService.GetCollection();

                if (ShoppingCartItems != null)
                {
                    Guid orderGuid = Guid.NewGuid();

                    PaymentAmount = Decimal.Parse(ShoppingCartItems.Sum(p => p.TotalPrice).ToString(), new CultureInfo("en-US"));


                    TotalQty = ShoppingCartItems.Sum(p => p.Qty);
                    PaymentDescription = $"O_{HardCoded.UserId}_{orderGuid}";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {

                    await Js.InvokeVoidAsync("initPayPalButton");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

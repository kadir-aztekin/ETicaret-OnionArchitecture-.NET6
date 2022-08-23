using ETicaret.Application.VİewModels.Product;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Application.Valdations.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("Lütfen ürün adını boş geçmeyiniz").
                MaximumLength(150).MinimumLength(5).WithMessage("Lütfen ürün adını 5 ile 150 karakter arası olmalı");


            RuleFor(p => p.Stock).NotEmpty().NotNull().WithMessage("Lütfen Stok Bilgisini Boş Geçmeyiniz")
                .Must(p => p >= 0).WithMessage("Stok Bilgisi Negetaif Olamaz");

            RuleFor(p => p.Price).NotEmpty().NotNull().WithMessage("Lütfen Price Bilgisini Boş Geçmeyiniz")
                .Must(p => p >= 0).WithMessage("Price Bilgisi Negetaif Olamaz");

        }
    }
}

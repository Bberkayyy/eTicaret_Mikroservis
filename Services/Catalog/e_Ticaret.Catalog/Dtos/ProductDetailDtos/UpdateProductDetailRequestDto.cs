﻿namespace e_Ticaret.Catalog.Dtos.ProductDetailDtos;

public class UpdateProductDetailRequestDto
{
    public string Id { get; set; }
    public string ProductId { get; set; }
    public string ProductDescription { get; set; }
    public string ProductInfo { get; set; }
}
